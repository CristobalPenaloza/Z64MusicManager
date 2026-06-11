using NAudio.Lame;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
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
using Z64MusicManager.Utils;

namespace Z64MusicManager {
	public partial class MMRForm : MainForm {
		static readonly object _generatePreviewLock = new object();

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

			List<MMCategory> allCategories = MMCategory.GeneralBgmCategories;
			allCategories.AddRange(MMCategory.GeneralFanfareCategories);
			allCategories.AddRange(MMCategory.SpecificBgmCategories);
			allCategories.AddRange(MMCategory.SpecificFanfareCategories);
			clbCategories.DataSource = allCategories;

			FillFormWithCurrentFile();
		}

		protected override void CleanForm() {
			cbxBank.SelectedItem = Z64Bank.MMBanks.Where(b => b.Id == "3").FirstOrDefault();
			clbCategories.ClearSelected();
			lbFormat.Text = "MMRS";
		}

		protected override void FillFormWithCurrentFile() {
			if (!string.IsNullOrEmpty(FileName)) {
				CleanForm();
				try {
					// We open the mmrs file as zip
					using (ZipArchive archive = ZipFile.OpenRead(FileName)) {
						bool customBank = false;
						bool customSamples = false;
						bool formMask = false;

						foreach (ZipArchiveEntry entry in archive.Entries) {
							string extension = Path.GetExtension(entry.Name).ToLower();

							// Process the categories.txt file
							if (entry.Name == "categories.txt") {
								using (var reader = new StreamReader(entry.Open())) {

									// Categories
									// This file should only have one line, so we only read that
									string line = reader.ReadLine() ?? "";
									string[] categories = line.Split(',', '-');

									for (int i = 0; i < clbCategories.Items.Count; i++) {
										string itemValue = clbCategories.Items[i].ToString().Between("[", "]");
										bool isChecked = categories.Any(c => c.Trim() == itemValue);
										clbCategories.SetItemChecked(i, isChecked);
									}
								}
							}

							// Process the .zseq file
							// Also consider .seq files, those also should be compatible
							if (extension == ".zseq" || extension == ".seq") {
								// Get the bank from the file name
								string bank = entry.Name.Replace(".zseq", "").Replace(".seq", "").Trim();
								cbxBank.SelectedItem = Z64Bank.MMBanks.Where(b =>
									b.Id.Replace("0x", "").ToUpper() == bank.Replace("0x", "").ToUpper()
								).FirstOrDefault();

								// Calculate the duration of the file
								Duration = SeqUtils.CalculateDuration(() => entry.Open());
								lbDuration.Text = "Duration: " + Duration.ToString(@"mm\:ss");

								// Search the file until we find the master volume command (0xDB)
								int mainVolume = SeqUtils.SearchSeqCommandValue(() => entry.Open(), 0xDB);
								tbMainVolume.Value = mainVolume;
							}

							// Process extra files
							if (extension == ".zbank") customBank = true;
							if (extension == ".zsound") customSamples = true;
							if (extension == ".formmask") formMask = true;
						}

						// Set the title of the program as the current opened file
						Text = Path.GetFileName(FileName) + " - Z64 Music Manager";
						lbFormat.Text = "MMRS | " + (customBank ? ("Custom bank" + (customSamples ? " and samples" : "")) : "Vanilla bank") + (formMask ? " | FormMask" : "");
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
							SeqUtils.ReplaceSeqCommandValue(() => entry.Open(), 0xDB, tbMainVolume.Value);
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


		protected override void ConvertFile(string path) {
			string fileName = Path.GetFileNameWithoutExtension(path);

			// Open the file in update mode
			using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update)) {

				// Read the zseq file to get the bank
				var zseqEntry = archive.Entries.Where(e => e.Name.EndsWith(".zseq")).FirstOrDefault();
				string bankId = ConversionTools.MMBank2OoTBank(zseqEntry.Name.Replace(".zseq", ""));

				// Read the categories file for the categories
				var categoriesEntry = archive.Entries.Where(e => e.Name == "categories.txt").FirstOrDefault();
				List<int> categories = new List<int>();
				using (var reader = new StreamReader(categoriesEntry.Open())) {
					string line = reader.ReadLine() ?? "";
					categories = line.Split(',').Select(s => int.Parse(s)).ToList();
				}

				// Create the meta file
				var metaEntry = archive.CreateEntry(fileName + ".meta");
				using (var entryStream = metaEntry.Open()) {
					using (var writer = new StreamWriter(entryStream)) {
						writer.WriteLine(fileName); // Name
						writer.WriteLine(bankId); // Bank
						writer.WriteLine(ConversionTools.OoTSequenceTypeFromMMCategories(categories)); // Sequence type
						writer.WriteLine(ConversionTools.MMCategories2OoTMusicGroups(categories)); // Music groups
					}
				}

				// Rename the zseq file
				zseqEntry.CopyToNewEntry(fileName + ".seq");

				// Rename the bank files
				var bankEntries = archive.Entries.Where(e => e.Name.EndsWith(".zbank") || e.Name.EndsWith(".bankmeta")).ToList();
				foreach (var currentEntry in bankEntries) {
					string extension = Path.GetExtension(currentEntry.Name);
					currentEntry.CopyToNewEntry("25" + extension);
				}

				// Clean the mmrs files
				zseqEntry.Delete();
				categoriesEntry.Delete();
				foreach (var b in bankEntries) b.Delete();
			}

			// We are finished!
		}



		protected override string GeneratePreviewRom(bool unique = false) {
			// Lock this process to allow safe concurrency
			lock (_generatePreviewLock) {

				// Check if the mm rando exe file is setup
				string mmrCLIPath = Properties.Settings.Default.MMRCLIPath;
				if (File.Exists(mmrCLIPath)) {
					string songtestPath = "";

					try {
						// TO ALLOW THIS PROCESS IN ASYNC, the mayor issue is that the music folder is shared
						// Is there any way to force a specific songtest song for a given generation? It seems not...
						// So, the generation process should work like a queue... The recording process itself can be async
						// TODO: LOCK THIS PROCESS, make everything else wait until they are finished!

						// Get the necesary paths...
						string mmrFolder = Path.GetDirectoryName(mmrCLIPath);
						string outputRom = $"{mmrFolder}/output/{(unique ? Guid.NewGuid().ToString() : "")}_zmusicmanager-songtest.z64";
						string defaultMMRSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mmr-default-settings.json");
						songtestPath = mmrFolder + "/music/_zmusicmanager-songtest.mmrs";

						// First, we copy our current opened file to the MMR music folder
						File.Copy(FileName, songtestPath, true);

						// Next, we create the rom using MMR CLI
						using (Process romCreationProcess = new Process()) {
							romCreationProcess.StartInfo.FileName = mmrCLIPath;
							romCreationProcess.StartInfo.Arguments = "-output \"" + outputRom + "\" -settings \"" + defaultMMRSettingsPath + "\"";
							romCreationProcess.Start();
							romCreationProcess.WaitForExit();
							// TODO: Check if the generation was succesful

							return outputRom;
						}

					} catch (Exception ex) {
						ShowError("An error ocurred while generating preview ROM", ex.ToString());

					} finally {
						// And for cleanup, we remove the song from the music folder so we don't disturb normal usage of the randomizer
						if (!string.IsNullOrEmpty(songtestPath)) File.Delete(songtestPath);
					}

				} else {
					var result = SetupMMCustomMusicStarter();
					if (result == DialogResult.OK) return GeneratePreviewRom();
				}

				return null;
			}
		}

		protected override bool IsFanfare() {
			foreach (var item in clbCategories.CheckedItems) {
				string categoryId = item.ToString().Between("[", "]");
				if (MMCategory.GeneralFanfareCategories.Any(c => c.Id == categoryId) || MMCategory.SpecificFanfareCategories.Any(c => c.Id == categoryId)) {
					return true;
				}
			}
			return false;
		}

		private void btnPreview_Click(object sender, EventArgs e) {
			Preview();
		}

		private void btnRecord_Click(object sender, EventArgs e) {
			Record();
		}
		
	}
}
