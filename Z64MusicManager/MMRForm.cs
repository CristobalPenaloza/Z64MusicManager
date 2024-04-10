using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z64MusicManager {
	public partial class MMRForm : MainForm {
		public MMRForm() {
			InitializeComponent();
		}

		private void MMRForm_Load(object sender, EventArgs e) {
			cbxBank.SelectedValueChanged += ProcUnsavedChanges;
			clbCategories.SelectedValueChanged += ProcUnsavedChanges;
			tbMainVolume.ValueChanged += ProcUnsavedChanges;

			cbxBank.DisplayMember = "Name";
			cbxBank.ValueMember = "Id";
			cbxBank.DataSource = Z64Bank.MMBanks;

			FillFormWithCurrentFile();
		}

		protected override void CleanForm() {
			cbxBank.SelectedItem = Z64Bank.MMBanks.Where(b => b.Id == "3").FirstOrDefault();
			clbCategories.ClearSelected();
		}

		protected override void FillFormWithCurrentFile() {
			if (!string.IsNullOrEmpty(FileName)) {
				try {
					// We open the mmrs file as zip
					using (ZipArchive archive = ZipFile.OpenRead(FileName)) {

						foreach (ZipArchiveEntry entry in archive.Entries) {
							string extension = Path.GetExtension(entry.Name).ToLower();

							// Process the categories.txt file
							if (entry.Name == "categories.txt") {
								using (var reader = new StreamReader(entry.Open())) {

									// Categories
									// This file should only have one line, so we only read that
									string line = reader.ReadLine() ?? "";
									string[] categories = line.Split(',');

									for(int i = 0; i < clbCategories.Items.Count; i++) {
										string itemValue = clbCategories.Items[i].ToString().Between("[", "]");
										bool isChecked = categories.Any(c => c.Trim() == itemValue);
										clbCategories.SetItemChecked(i, isChecked);
									}
								}
							}

							// Process the .zseq file
							if (extension == ".zseq") {
								// Get the bank from the file name
								string bank = entry.Name.Replace(".zseq", "").Trim();
								cbxBank.SelectedItem = Z64Bank.MMBanks.Where(b => b.Id == bank).FirstOrDefault();

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
				} catch (FileNotFoundException) {
					NewFile();
				}
				
				// The FileName is empty... so that means we are creating a new file!
				// Also, clean the form.
			} else {
				NewFile();
			}
		}

		protected override void SaveFile(string path) {
			try {
				// First check if file exists. If it doesn't, we create a new file
				bool newFile = !File.Exists(path);
				string name = Path.GetFileNameWithoutExtension(path);

				// Open the file
				using (ZipArchive archive = ZipFile.Open(path, newFile ? ZipArchiveMode.Create : ZipArchiveMode.Update)) {
					string bank = ((Z64Bank)cbxBank.SelectedValue).Id;

					// Create the files if they don't exist
					if (!archive.Entries.Any(e => e.Name == "categories.txt")) archive.CreateEntry("categories.txt");
					if (!archive.Entries.Any(e => e.Name.EndsWith(".zseq"))) archive.CreateEntry(bank + ".zseq");

					// Rename the zseq to file to match the bank ID if it's different
					// We do it outside the loop to not break it
					var zseqEntry = archive.Entries.Where(e => e.Name.EndsWith(".zseq")).FirstOrDefault();
					if (zseqEntry.Name.Replace(".zseq", "") != bank) {
						// We copy the current entry with the new name
						var newEntry = archive.CreateEntry(bank + ".zseq");
						using (var a = zseqEntry.Open())
						using (var b = newEntry.Open()) a.CopyTo(b);

						// We delete the original file to cleanup
						zseqEntry.Delete();
					}

					// Loop the existing entries
					foreach (ZipArchiveEntry entry in archive.Entries) {
						string extension = Path.GetExtension(entry.Name).ToLower();

						// Modify the categories file
						if (entry.Name == "categories.txt") {
							List<string> selectedCategories = new List<string>();
							foreach (var item in clbCategories.CheckedItems) {
								selectedCategories.Add(item.ToString().Between("[", "]"));
							}

							// Overwrite the first line to the entry with the categories list
							using (var entryStream = entry.Open()) {
								entryStream.SetLength(0); // We truncate the file before writing
								using (var writer = new StreamWriter(entryStream)) {
									writer.Write(string.Join(",", selectedCategories));
								}
							}


						} else if (extension == ".zseq") {
							// Modify the volume of the seq file
							Utils.ReplaceSeqCommandValue(() => entry.Open(), 0xDB, tbMainVolume.Value);
						}
					}
				}

				FillFormWithCurrentFile();

			} catch (Exception ex) {
				MessageBox.Show("We couldn't save the file, because of the following error: " + ex.Message, "Save file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}



		private void tbMainVolume_ValueChanged(object sender, EventArgs e) {
			txtMainVolume.Text = tbMainVolume.Value.ToString("X");
		}

		private void btnPreview_Click(object sender, EventArgs e) {

			// Check if the mm rando exe file is setup
			string mmrCLIPath = Properties.Settings.Default.MMRCLIPath;
			if (File.Exists(mmrCLIPath)) {

				// Get the necesary paths...
				string mmrFolder = Path.GetDirectoryName(mmrCLIPath);
				string songtestPath = mmrFolder + "\\music\\_zmusicmanager-songtest.mmrs";
				string outputRom = mmrFolder + "\\output\\_zmusicmanager-songtest.z64";
				string defaultMMRSettingsPath = AppDomain.CurrentDomain.BaseDirectory + "\\mmr-default-settings.json";

				// First, we copy our current opened file to the MMR music folder
				File.Copy(FileName, songtestPath, true);

				// Next, we create the rom using MMR CLI
				using (Process romCreationProcess = new Process()) {
					romCreationProcess.StartInfo.FileName = mmrCLIPath;
					romCreationProcess.StartInfo.Arguments = "-output \"" + outputRom
						+ "\" -settings \"" + defaultMMRSettingsPath + "\"";
					romCreationProcess.Start();
					romCreationProcess.WaitForExit();
					// TODO: Check if the generation was succesful
				}

				// Now we open the rom we just created
				Process.Start(outputRom);

				// And for cleanup, we remove the song from the music folder so we don't disturb normal usage of the randomizer
				File.Delete(songtestPath);

			} else {
				var result = SetupMMCustomMusicStarter();
				if (result == DialogResult.OK) btnPreview_Click(sender, e);
			}
		}
	}
}
