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
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace Z64MusicManager{
	public partial class OoTRForm : MainForm {
		public OoTRForm() {
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

			FillFormWithCurrentFile();
		}

		protected override void CleanForm() {
			txtName.Text = "";
			cbxBank.SelectedItem = Z64Bank.OoTBanks.Where(b => b.Id == "0x03").FirstOrDefault();
			cbxSequenceType.SelectedIndex = cbxSequenceType.FindStringExact("Bgm");
			txtMusicGroups.Text = "";
		}

		protected override void FillFormWithCurrentFile() {
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
						Text = Path.GetFileName(FileName) + " - Z64 Music Manager";
						UnsavedChanges = false;
					}

				// If we cannot find the file, then we treat this as a new file
				} catch(FileNotFoundException) {
					NewFile();
				}


			// The FileName is empty... so that means we are creating a new file!
			// Also, clean the form.
			} else {
				NewFile();
			}
		}

		private void tbMainVolume_ValueChanged(object sender, EventArgs e) {
			txtMainVolume.Text = tbMainVolume.Value.ToString("X");
		}

		private void btnOpenMusicGroupSelector_Click(object sender, EventArgs e) {
			// In the meantime, we just open the music group tool on the browser for easy access
			// TODO: Implement TheSoundDefense's tool in-app in the future
			ProcessStartInfo sInfo = new ProcessStartInfo("https://thesounddefense.github.io/musicgroups/");
			Process.Start(sInfo);
		}

		protected override void SaveFile(string path) {
			try {
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
							using (var entryStream = entry.Open()) {
								entryStream.SetLength(0); // We truncate the file before writing
								using (var writer = new StreamWriter(entryStream)) {
									foreach (string line in lines) writer.WriteLine(line);
								}
							}
						

							// Modify the volume of the seq file
						} else if (extension == ".seq") {
							Utils.ReplaceSeqCommandValue(() => entry.Open(), 0xDB, tbMainVolume.Value);
						}
					}
				}

				FillFormWithCurrentFile();
				
			} catch (Exception ex) {
				MessageBox.Show("We couldn't save the file, because of the following error: " + ex.Message, "Save file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		// https://github.com/NewSoupVi/ootr-custom-music-starter
		// TODO: Migrate all this code directly to this program.
		private void btnPreview_Click(object sender, EventArgs e) {
			
			// Check if the custom music starter exists
			string ootMusicStarter = Properties.Settings.Default.OoTMusicStarterPath;
			if (File.Exists(ootMusicStarter)) {
				ProcessStartInfo sInfo = new ProcessStartInfo(ootMusicStarter, "\"" + FileName + "\"");
				Process.Start(sInfo);

			} else {
				var result = SetupOoTCustomMusicStarter();
				if(result == DialogResult.OK) btnPreview_Click(sender, e);
			}
		}

	}
}
