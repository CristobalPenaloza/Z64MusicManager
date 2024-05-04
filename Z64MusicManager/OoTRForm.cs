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
using Z64MusicManager.Utils;

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
								int mainVolume = SeqUtils.SearchSeqCommandValue(() => entry.Open(), 0xDB);
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
							List<string> lines = StreamUtils.StreamReadAllLines(() => entry.Open()).ToList();

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
							SeqUtils.ReplaceSeqCommandValue(() => entry.Open(), 0xDB, tbMainVolume.Value);
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
			string ootrCLIPath = Properties.Settings.Default.OOTRCLIPPath;
			if (File.Exists(ootrCLIPath)) {

				// Get the necesary paths
				string ootrFolder = Path.GetDirectoryName(ootrCLIPath);
				string songtestPath = ootrFolder + "\\data\\Music\\_zmusicmanager-songtest.ootrs";
				string outputRom = ootrFolder + "\\Output\\_zmusicmanager-songtest.z64";
				string ootrSettingsPath = AppDomain.CurrentDomain.BaseDirectory + "\\ootr-songtest-settings.json";
				string ootrCosmeticPlandoPath = AppDomain.CurrentDomain.BaseDirectory + "\\ootr-songtest-cosmeticplando.json";
				string pythonPath = WinUtils.GetPythonPath();

				// First, we copy our current opened file to the OoTR music folder
				File.Copy(FileName, songtestPath, true);

				// We also change the internal name of the song for easy matching
				using (ZipArchive archive = ZipFile.Open(songtestPath, ZipArchiveMode.Update)) {
					var metaEntry = archive.Entries.Where(entry => entry.Name.EndsWith(".meta")).FirstOrDefault();
					List<string> lines = StreamUtils.StreamReadAllLines(() => metaEntry.Open()).ToList();
					lines[0] = "_zmusicmanager-songtest";
					lines[2] = "Bgm";

					// Write all the lines to the entry
					using (var entryStream = metaEntry.Open()) {
						entryStream.SetLength(0); // We truncate the file before writing
						using (var writer = new StreamWriter(entryStream)) {
							foreach (string line in lines) writer.WriteLine(line);
						}
					}
				}
		
				// We also copy the cosmetic plando file to the OoTR music folder
				File.Copy(ootrCosmeticPlandoPath, ootrFolder + "\\ootr-songtest-cosmeticplando.json", true);

				// Next, we create the rom using OoT python CLI
				var sb = new StringBuilder();
				using (Process romCreationProcess = new Process()) {

					romCreationProcess.StartInfo.FileName = pythonPath;
					romCreationProcess.StartInfo.Arguments = ootrCLIPath + " --settings \"" + ootrSettingsPath + "\"";

					// Redirect output
					/*romCreationProcess.StartInfo.RedirectStandardOutput = true;
					romCreationProcess.StartInfo.RedirectStandardError = true;
					romCreationProcess.OutputDataReceived += (s, args) => sb.AppendLine(args.Data);
					romCreationProcess.ErrorDataReceived += (s, args) => sb.AppendLine(args.Data);*/
					romCreationProcess.StartInfo.UseShellExecute = false;

					romCreationProcess.Start();
					//romCreationProcess.BeginOutputReadLine();
					//romCreationProcess.BeginErrorReadLine();
					romCreationProcess.WaitForExit();
					// TODO: Check if the generation was succesful
				}

				// Now we open the rom we just created
				string output = sb.ToString();
				Process.Start(outputRom);

				// And for cleanup, we remove the song from the music folder so we don't disturb normal usage of the randomizer
				File.Delete(songtestPath);

			} else {
				var result = SetupOoTCustomMusicStarter();
				if(result == DialogResult.OK) btnPreview_Click(sender, e);
			}
		}

		
		// Converts OOTRS to MMRS
		protected override void ConvertFile(string path) {
			// Open the file in update mode
			using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update)) {

				// First check if it uses custom samples
				bool containsCustomSamples = archive.Entries.Any(e => e.Name.EndsWith(".zsound"));
				if (containsCustomSamples) throw new NotSupportedException("This sequence contains custom samples, and those are currently supported in MMR.");

				string bankId = "";
				string musicGroups = "";
				string sequenceType = "";

				// Recopile the data from the meta file
				var metaEntry = archive.Entries.Where(e => e.Name.EndsWith(".meta")).FirstOrDefault();
				using (var reader = new StreamReader(metaEntry.Open())) {
					string line;
					int lineIndex = 0;
					while ((line = reader.ReadLine()) != null) {
						if (lineIndex == 1) bankId = line;
						else if (lineIndex == 2) sequenceType = line;
						else if (lineIndex == 3) musicGroups = line;
						lineIndex++;
					}
				}

				// Remake the seq file to a zseq file and rename the bank to map to the MM custom bank
				string mmBank = ConversionTools.OoTBank2MMBank(bankId);
				var seqAndBankEntries = archive.Entries.Where(e => e.Name.EndsWith(".seq") || e.Name.EndsWith(".zbank") || e.Name.EndsWith(".bankmeta")).ToList();
				foreach(var currentEntry in seqAndBankEntries) {
					// Copy the current file, but with the new bank as it's name
					string extension = Path.GetExtension(currentEntry.Name);
					if (extension == ".seq") extension = ".zseq";

					var newEntry = archive.CreateEntry(mmBank + extension);
					using (var a = currentEntry.Open())
					using (var b = newEntry.Open()) a.CopyTo(b);
				}
					

				// Create the categories.txt file
				var categoriesEntry = archive.CreateEntry("categories.txt");
				using (var ce = categoriesEntry.Open()) {
					using (var writer = new StreamWriter(ce)) {
						writer.Write(ConversionTools.OoTMusicGroups2MMCategories(musicGroups, sequenceType));
					}
				}

				// Clean the ootrs files
				metaEntry.Delete();
				foreach(var e in seqAndBankEntries) e.Delete();
			}

			// We are finished!
		}

	}
}
