using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace ZMusicManager{
	public partial class Form1 : Form {
		public string FileName;
		public bool UnsavedChanges = false;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			txtName.TextChanged += ProcUnsavedChanges;
			cbxBank.SelectedValueChanged += ProcUnsavedChanges;
			cbxSequenceType.SelectedValueChanged += ProcUnsavedChanges;
			txtMusicGroups.TextChanged += ProcUnsavedChanges;
			tbMainVolume.ValueChanged += ProcUnsavedChanges;

			cbxBank.DisplayMember = "Name";
			cbxBank.ValueMember = "Id";
			cbxBank.DataSource = Z64Bank.OoTBanks;

			OpenCurrentFile();
		}

		private void ProcUnsavedChanges(object sender, EventArgs e) {
			if (!UnsavedChanges) {
				Text = "*" + Text;
				UnsavedChanges = true;
			}
		}

		private void OpenCurrentFile() {
			if (!string.IsNullOrEmpty(FileName)) {
				try {
					// We open the ootrs file as zip
					using (ZipArchive archive = ZipFile.OpenRead(FileName)) {

						foreach (ZipArchiveEntry entry in archive.Entries) {
							string extension = Path.GetExtension(entry.Name).ToLower();

							// Process the .meta file
							if (extension == ".meta") {
								using (var reader = new StreamReader(entry.Open())) {

									// Read the .meta file line by line
									string line;
									int lineIndex = 0;
									while ((line = reader.ReadLine()) != null) {

										// Song name
										if (lineIndex == 0) txtName.Text = line;

										// Bank
										else if (lineIndex == 1) cbxBank.SelectedItem = Z64Bank.OoTBanks.Where(b => b.Id == line).FirstOrDefault();

										// Sequence type
										else if (lineIndex == 2) cbxSequenceType.SelectedIndex = cbxSequenceType.FindStringExact(line);

										// Music groups
										else if (lineIndex == 3) txtMusicGroups.Text = line;

										// TODO: CUSTOM SAMPLE STUFF...
										lineIndex++;
									}

								}
							}

							// Process the .seq file
							if (extension == ".seq") {
								// Search the file until we find the master volume command (0xDB)
								int mainVolume = Utils.SearchSeqCommandValue(entry.Open(), 0xDB);
								tbMainVolume.Value = mainVolume;
							}
						}
						
						// Set the title of the program as the current opened file
						Text = Path.GetFileName(FileName) + " - ZMusic Manager";
						UnsavedChanges = false;
					}

				// If we cannot find the file, then we treat this as a new file
				} catch(FileNotFoundException) {
					NewFile();
				}


			// The FileName is empty... so that means we are creating a new file!
			// Also, clean the form.
			} else {
				txtName.Text = "";
				cbxBank.SelectedItem = Z64Bank.OoTBanks.Where(b => b.Id == "0x03").FirstOrDefault();
				cbxSequenceType.SelectedIndex = cbxSequenceType.FindStringExact("Bgm");
				txtMusicGroups.Text = "";

				Text = "Untitled - ZMusic Manager";
				UnsavedChanges = false;
			}
		}

		private void btnNew_Click(object sender, EventArgs e) {
			NewFile();
		}

		private void NewFile() {
			FileName = null;
			UnsavedChanges = false;
			OpenCurrentFile();
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			ofd.Filter = "Ocarina of Time Radomizer Sound Files (*.ootrs)|*.ootrs";
			ofd.RestoreDirectory = true;

			// We show the open file dialog
			DialogResult result = ofd.ShowDialog();

			if (result == DialogResult.OK) {
				// Save the filename path in a setting so we can persist it for the future...
				FileName = ofd.FileName;
				Properties.Settings.Default.LastPath = Path.GetDirectoryName(FileName);
				Properties.Settings.Default.Save();

				// We open the file!
				OpenCurrentFile();
			}
		}

		private void tbMainVolume_ValueChanged(object sender, EventArgs e) {
			txtMainVolume.Text = tbMainVolume.Value.ToString("X");
		}

		private void btnOpenMusicGroupSelector_Click(object sender, EventArgs e) {
			// TODO: Port TheSoundDefense's tool for music groups
		}

		private void btnSave_Click(object sender, EventArgs e) {
			SaveFile(FileName);
		}

		private void btnSaveAs_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			sfd.Filter = "Ocarina of Time Radomizer Sound Files (*.ootrs)|*.ootrs";
			sfd.RestoreDirectory = true;

			// We show the open file dialog
			DialogResult result = sfd.ShowDialog();

			if (result == DialogResult.OK) {
				SaveFile(sfd.FileName);
			}
		}

		private void SaveFile(string path) {

			// First check if file exists. If it doesn't, we create a new file
			bool newFile = !File.Exists(path);
			string name = Path.GetFileNameWithoutExtension(path);
			
			// Open the file
			using (ZipArchive archive = ZipFile.Open(path, newFile ? ZipArchiveMode.Create : ZipArchiveMode.Update)) {

				// Create the files if they don't exist
				if (!archive.Entries.Any(e => e.Name.EndsWith(".meta"))) archive.CreateEntry(name + ".meta");
				if (!archive.Entries.Any(e => e.Name.EndsWith(".seq"))) archive.CreateEntry(name + ".seq");

				// Loop the existing entries
				foreach (ZipArchiveEntry entry in archive.Entries) {
					string extension = Path.GetExtension(entry.Name).ToLower();

					// Modify the meta file with the forms data
					if (extension == ".meta") {
						// Get all lines of the meta file
						List<string> lines = Utils.StreamReadAllLines(entry.Open()).ToList();

						// Make sure we have enough space to fit all the data
						if (lines.Count < 4) {
							for (int i = 0; i < 4 - lines.Count; i++) lines.Add("");
						}

						// Ovewrite all lines of the meta file
						lines[0] = txtName.Text;
						lines[1] = ((Z64Bank)cbxBank.SelectedValue).Id;
						lines[2] = (string)cbxSequenceType.SelectedItem;
						lines[3] = txtMusicGroups.Text;

						// Write all the lines to the entry
						using (var writer = new StreamWriter(entry.Open())) {
							foreach (string line in lines) writer.WriteLine(line);
						}

						// Modify the volume of the seq file
					} else if (extension == ".seq") {
						Utils.ReplaceSeqCommandValue(() => entry.Open(), 0xDB, tbMainVolume.Value);
					}
				}
			}

			OpenCurrentFile();
		}
		

		private void btnExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}
	}

	public class Z64Bank {
		public string Id;
		public string Name;

		public static List<Z64Bank> OoTBanks = new List<Z64Bank> {
			new Z64Bank{ Id = "0x03", Name = "0x03 - Main Orchestra/Hyrule Field" },
			new Z64Bank{ Id = "0x04", Name = "0x04 - Deku Tree" },
			new Z64Bank{ Id = "0x05", Name = "0x05 - Market" },
			new Z64Bank{ Id = "0x06", Name = "0x06 - Title Screen" },
			new Z64Bank{ Id = "0x07", Name = "0x07 - Jabu Jabu's Belly" },
			new Z64Bank{ Id = "0x08", Name = "0x08 - Kakariko Village (Guitar)" },
			new Z64Bank{ Id = "0x09", Name = "0x09 - Fairy Fountain" },
			new Z64Bank{ Id = "0x0A", Name = "0x0A - Fire Temple" },
			new Z64Bank{ Id = "0x0B", Name = "0x0B - Dodongo's Cavern" },
			new Z64Bank{ Id = "0x0C", Name = "0x0C - Forest Temple" },
			new Z64Bank{ Id = "0x0D", Name = "0x0D - Lon Lon Ranch" },
			new Z64Bank{ Id = "0x0E", Name = "0x0E - Goron City" },
			new Z64Bank{ Id = "0x0F", Name = "0x0F - Kokiri Forest" },
			new Z64Bank{ Id = "0x10", Name = "0x10 - Spirit Temple" },
			new Z64Bank{ Id = "0x11", Name = "0x11 - Horse Race" },
			new Z64Bank{ Id = "0x12", Name = "0x12 - Warp Songs" },
			new Z64Bank{ Id = "0x13", Name = "0x13 - Goddess Cutscene" },
			new Z64Bank{ Id = "0x14", Name = "0x14 - Shooting Gallery" },
			new Z64Bank{ Id = "0x15", Name = "0x15 - Zora's Domain" },
			new Z64Bank{ Id = "0x16", Name = "0x16 - Shop" },
			new Z64Bank{ Id = "0x17", Name = "0x17 - Ice Cavern" },
			new Z64Bank{ Id = "0x18", Name = "0x18 - Shadow Temple" },
			new Z64Bank{ Id = "0x19", Name = "0x19 - Water Temple" },
			new Z64Bank{ Id = "0x1A", Name = "0x1A - Piano (Unused)" },
			new Z64Bank{ Id = "0x1B", Name = "0x1B - Gerudo Valley" },
			new Z64Bank{ Id = "0x1C", Name = "0x1C - Lakeside Laboratory" },
			new Z64Bank{ Id = "0x1D", Name = "0x1D - Kotake and Koume" },
			new Z64Bank{ Id = "0x1E", Name = "0x1E - Ganon's Castle (Organ)" },
			new Z64Bank{ Id = "0x1F", Name = "0x1F - Inside Ganon's Castle" },
			new Z64Bank{ Id = "0x20", Name = "0x20 - Ganondorf Battle" },
			new Z64Bank{ Id = "0x21", Name = "0x21 - Ending Sequence 1" },
			new Z64Bank{ Id = "0x22", Name = "0x22 - Ending Sequence 2" },
			new Z64Bank{ Id = "0x23", Name = "0x23 - Fanfares" },
			new Z64Bank{ Id = "0x24", Name = "0x24 - Owl" },
			new Z64Bank{ Id = "-", Name = "Custom Bank" },
		};

		public override string ToString() {
			return Name;
		}
	}
}
