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
								int mainVolume = Utils.SearchSeqCommandValue(() => entry.Open(), 0xDB);
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
				// If we are editing an existing file, first we copy it to the destination location
				bool editingExistingFile = File.Exists(FileName);
				if (editingExistingFile) File.Copy(FileName, sfd.FileName, true);

				// Then, we try to save the file
				FileName = sfd.FileName;
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
						List<string> lines = Utils.StreamReadAllLines(() => entry.Open()).ToList();

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
}
