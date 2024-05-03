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
	public partial class MainForm : Form {
		public string FileName;
		public bool UnsavedChanges = false;

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			btnConvert.Text = "Convert to " + (Name == "OoTRForm" ? "MMRS" : "OOTRS");
		}


		// VIRTUAL METHODS
		protected virtual void CleanForm() {
			throw new NotImplementedException();
		}

		protected virtual void FillFormWithCurrentFile() {
			throw new NotImplementedException();
		}

		protected virtual void SaveFile(string path) {
			throw new NotImplementedException();
		}

		protected virtual void ConvertFile(string path) {
			throw new NotImplementedException();
		}



		// GENERAL METHODS AND EVENT HANDLERS

		protected void ProcUnsavedChanges(object sender, EventArgs e) {
			if (!UnsavedChanges) {
				Text = "*" + Text;
				UnsavedChanges = true;
			}
		}

		private void btnNewOOTRSFile_Click(object sender, EventArgs e) {
			var form = SwapForm("OoTRForm");
			form.NewFile();
		}

		private void btnNewMMRSFile_Click(object sender, EventArgs e) {
			var form = SwapForm("MMRForm");
			form.NewFile();
		}

		protected void NewFile() {
			CleanForm();
			Text = "Untitled - Z64 Music Manager";
			UnsavedChanges = false;
			FileName = null;
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			ofd.Filter = "Z64 Sound Files(*.ootrs;*.mmrs)|*.ootrs;*.mmrs|All files (*.*)|*.*";
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

		private MainForm SwapForm(string formType) {
			if(formType == "OoTRForm") {
				if (Name == "OoTRForm") return this;
				else {
					OoTRForm ootrForm = null;
					foreach (OoTRForm form in Application.OpenForms.OfType<OoTRForm>()) ootrForm = form;
					if (ootrForm == null) ootrForm = new OoTRForm();

					ootrForm.FileName = FileName;
					ootrForm.Location = Location;
					ootrForm.StartPosition = FormStartPosition.Manual;
					ootrForm.FillFormWithCurrentFile();
					ootrForm.Show();
					Hide();

					return ootrForm;
				}

			} else {
				if (Name == "MMRForm") return this;
				else {
					MMRForm mmrForm = null;
					foreach (MMRForm form in Application.OpenForms.OfType<MMRForm>()) mmrForm = form;
					if (mmrForm == null) mmrForm = new MMRForm();

					mmrForm.FileName = FileName;
					mmrForm.FillFormWithCurrentFile();
					mmrForm.Location = Location;
					mmrForm.StartPosition = FormStartPosition.Manual;
					mmrForm.Show();
					Hide();

					return mmrForm;
				}
			}
		}

		public void OpenCurrentFile() {
			// If the current file is empty or if it's NOT a compatible file, we try to create a new file
			if (string.IsNullOrWhiteSpace(FileName) || (!FileName.EndsWith(".ootrs") && !FileName.EndsWith(".mmrs"))) {
				NewFile();
				return;
			}

			var form = SwapForm(FileName.EndsWith(".ootrs") ? "OoTRForm" : "MMRForm");
			form.FillFormWithCurrentFile();
		}

		private void btnSave_Click(object sender, EventArgs e) {
			// If the file exists, we just save over it
			if (File.Exists(FileName)) SaveFile(FileName);

			// If it doesn't, we treat it as a new file
			else btnSaveAs_Click(sender, e);
		}

		private void btnSaveAs_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			sfd.Filter = (Name == "OoTRForm") ?
				"Ocarina of Time Radomizer Sound Files (*.ootrs)|*.ootrs" :
				"Majora's Mask Radomizer Sound Files (*.mmrs)|*.mmrs";
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

		private void btnExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Exit();
		}




		// [HELP] menu

		private void btnDJGithub_Click(object sender, EventArgs e) {
			ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/DaruniasJoy/OoT-Custom-Sequences");
			Process.Start(sInfo);
		}

		private void btnDJDiscord_Click(object sender, EventArgs e) {
			ProcessStartInfo sInfo = new ProcessStartInfo("https://discord.gg/EVpd499gkS");
			Process.Start(sInfo);
		}

		private void btnGuideCreatingMusicFiles_Click(object sender, EventArgs e) {
			ProcessStartInfo sInfo = new ProcessStartInfo("https://gist.github.com/TheSoundDefense/128c933b629e972835afb25692f9cc2d");
			Process.Start(sInfo);
		}

		private void btnSetupOoTCustomMusicStarter_Click(object sender, EventArgs e) {
			SetupOoTCustomMusicStarter();
		}

		protected DialogResult SetupOoTCustomMusicStarter() {
			// TODO: Make this an original form, instead of this hacky messagebox.
			string caption = "OOT custom music starter not setup!";
			string text = "To preview OOTRS files on emulator:\n\n"
				+ "1. Download and install an n64 emulator, and set it up so it opens .z64 files by default.\n\n"
				+ "2. Download and setup OoT Randomizer.\n\n"
				+ "3. Make sure OoT Randomizer can generate games (provide the necessary ROM).\n\n"
				+ "4. Press OK on this message box, and select the OoTRandomizer.py file that's inside your instalation of OoT Randomizer"
				+ "5. Enjoy! ";
			DialogResult mbResult = MessageBox.Show(
				text, caption, MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0);

			if (mbResult == DialogResult.OK) {
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
				ofd.Filter = "OoTRandomizer.py|OoTRandomizer.py";
				ofd.RestoreDirectory = true;

				// We show the open file dialog
				DialogResult ofdResult = ofd.ShowDialog();
				if (ofdResult == DialogResult.OK) {
					Properties.Settings.Default.OOTRCLIPPath = ofd.FileName;
					Properties.Settings.Default.Save();
					return DialogResult.OK;
				}
			}

			return DialogResult.None;
		}

		private void btnSetupMMCustomMusicStarter_Click(object sender, EventArgs e) {
			SetupMMCustomMusicStarter();
		}

		protected DialogResult SetupMMCustomMusicStarter() {
			string caption = "MM custom music starter not setup!";
			string text = "To preview MMRS files on emulator:\n\n"
				+ "1. Download and install an n64 emulator, and set it up so it opens .z64 files by default.\n\n"
				+ "2. Download and setup MM Randomizer.\n\n"
				+ "3. Make sure you have in your MM Randomizer default settings.json file an input ROM selected and custom music enabled.\n\n"
				+ "4. Press OK on this message box, and select the MMR.CLI.exe file that is inside your instalation of MM Randomizer.\n\n"
				+ "5. Enjoy! ";

			DialogResult mbResult = MessageBox.Show(
				text, caption, MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

			if (mbResult == DialogResult.OK) {
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
				ofd.Filter = "MMR.CLI.exe|MMR.CLI.exe";
				ofd.RestoreDirectory = true;

				// We show the open file dialog
				DialogResult ofdResult = ofd.ShowDialog();
				if (ofdResult == DialogResult.OK) {
					Properties.Settings.Default.MMRCLIPath = ofd.FileName;
					Properties.Settings.Default.Save();
					return DialogResult.OK;
				}
			}

			return DialogResult.None;
		}


		// CONVERSION

		private void btnConvert_Click(object sender, EventArgs e) {

			// First, we save the current staged changes
			SaveFile(FileName);
			
			// Now we do a small check to see if we have a custom bank
			// If we do, notify the user about it...
			using (ZipArchive archive = ZipFile.OpenRead(FileName)) {
				if(archive.Entries.Any(en => en.Name.EndsWith(".zbank"))) {
					DialogResult dr = MessageBox.Show("This file contains custom banks!\n\nThe conversion will work, but it'll probably just sound like garbled noise. You will need to manually create a new custom bank for it to sound correctly.\n\nDo you wish to continue?", "Custom bank warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					if (dr == DialogResult.Cancel) return;
				}
			}

			// Do an immediate Save As in the inverted file type of this form
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			sfd.FileName = Path.GetFileNameWithoutExtension(FileName);
			sfd.Filter = (Name == "OoTRForm") ?
				"Majora's Mask Radomizer Sound Files (*.mmrs)|*.mmrs" :
				"Ocarina of Time Radomizer Sound Files (*.ootrs)|*.ootrs";
			sfd.RestoreDirectory = true;
			
			DialogResult result = sfd.ShowDialog();
			if (result == DialogResult.OK) {

				try {
					// Copy the current file to the new location
					File.Copy(FileName, sfd.FileName, true);

					// Now we convert on the new copied file
					ConvertFile(sfd.FileName);

				
				} catch(Exception ex) {
					// If there's any error in the process, we delete the new file
					MessageBox.Show("We couldn't convert this file, because of the following error: " + ex.Message, "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					File.Delete(sfd.FileName);
					return;
				}
				
				// Finally, we open the converted file
				FileName = sfd.FileName;
				OpenCurrentFile();
			}

		}

		private void btnBulkConvertToOOTRS_Click(object sender, EventArgs e) {
			// TODO: NEW FORM...
		}

		private void btnBulkConvertToMMRS_Click(object sender, EventArgs e) {
			// TODO: NEW FORM...
		}

		private void btnAbout_Click(object sender, EventArgs e) {
			AboutForm aboutForm = new AboutForm();
			aboutForm.Show();
		}

		
	}
}
