using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZMusicManager {
	public partial class MainForm : Form {
		public string FileName;
		public bool UnsavedChanges = false;

		public MainForm() {
			InitializeComponent();
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



		// GENERAL METHODS AND EVENT HANDLERS

		protected void ProcUnsavedChanges(object sender, EventArgs e) {
			if (!UnsavedChanges) {
				Text = "*" + Text;
				UnsavedChanges = true;
			}
		}

		private void btnNew_Click(object sender, EventArgs e) {
			NewFile();
		}

		protected void NewFile() {
			CleanForm();
			Text = "Untitled - ZMusic Manager";
			UnsavedChanges = false;
			FileName = null;
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			ofd.Filter = "ZSound Files(*.ootrs;*.mmrs)|*.ootrs;*.mmrs|All files (*.*)|*.*";
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

		private void OpenCurrentFile() {
			// If the current file is empty or if it's NOT a compatible file, we try to create a new file
			if (string.IsNullOrWhiteSpace(FileName) || (!FileName.EndsWith(".ootrs") && !FileName.EndsWith(".mmrs"))) {
				NewFile();
				return;
			}
			
			if (FileName.EndsWith(".ootrs")) {
				// We change the current form to be an OoTR form
				if (Name == "OoTRForm") FillFormWithCurrentFile();
				else {
					OoTRForm ootrForm = null;
					foreach(OoTRForm form in Application.OpenForms.OfType<OoTRForm>()) ootrForm = form;
					if (ootrForm == null) ootrForm = new OoTRForm();

					ootrForm.FileName = FileName;
					ootrForm.Location = Location;
					ootrForm.StartPosition = FormStartPosition.Manual;
					ootrForm.FillFormWithCurrentFile();
					ootrForm.Show();
					Hide();
				}

			} else if (FileName.EndsWith(".mmrs")) {
				// We change the current form to be an MMR form
				if (Name == "MMRForm") FillFormWithCurrentFile();
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
				}
				
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			SaveFile(FileName);
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

		// TODO: OPEN OOTRS FILES https://stackoverflow.com/questions/2144370/winform-application-to-launch-and-read-from-a-file-with-custom-extension




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
			string caption = "Custom music starter not setup!";
			string text = "To preview OOTRS files on emulator:\n\n1. Download NewSoupVi's custom music starter script from the Help button and set it up.\n\n2. Press OK on this message box, and select the CustomMusicStarter.bat file that you set up earlier.\n\n3. Enjoy! ";
			DialogResult mbResult = MessageBox.Show(
				text, caption, MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0,
				"https://github.com/NewSoupVi/ootr-custom-music-starter");

			if (mbResult == DialogResult.OK) {
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
				ofd.Filter = "CustomMusicStarter.bat|CustomMusicStarter.bat";
				ofd.RestoreDirectory = true;

				// We show the open file dialog
				DialogResult ofdResult = ofd.ShowDialog();
				if (ofdResult == DialogResult.OK) {
					Properties.Settings.Default.OoTMusicStarterPath = ofd.FileName;
					return DialogResult.OK;
				}
			}

			return DialogResult.None;
		}
	}
}
