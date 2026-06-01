using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Z64MusicManager
{
	public partial class SettingsForm : Form
	{
		public SettingsForm() {
			InitializeComponent();
			LoadForm();
		}

		private void LoadForm() {
			// Load the current user settings into the form
			txtBizhawkPath.Text = Properties.Settings.Default.BizhawkPath;
			txtMMRCLIPath.Text = Properties.Settings.Default.MMRCLIPath;
			txtOOTRCLIPath.Text = Properties.Settings.Default.OOTRCLIPPath;
		}

		private void btnBizhawkPath_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			ofd.Filter = "EmuHawk.exe|EmuHawk.exe";
			ofd.RestoreDirectory = true;

			// We show the open file dialog
			DialogResult ofdResult = ofd.ShowDialog();
			if (ofdResult == DialogResult.OK) {
				Properties.Settings.Default.BizhawkPath = ofd.FileName;
				Properties.Settings.Default.Save();
				LoadForm();
			}
		}

		private void btnMMRCLIPath_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			ofd.Filter = "MMR.CLI.exe|MMR.CLI.exe";
			ofd.RestoreDirectory = true;

			// We show the open file dialog
			DialogResult ofdResult = ofd.ShowDialog();
			if (ofdResult == DialogResult.OK) {
				Properties.Settings.Default.MMRCLIPath = ofd.FileName;
				Properties.Settings.Default.Save();
				LoadForm();
			}
		}

		private void btnOOTRCLIPath_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Properties.Settings.Default.LastPath ?? "C:\\";
			ofd.Filter = "OoTRandomizer.py|OoTRandomizer.py";
			ofd.RestoreDirectory = true;

			// We show the open file dialog
			DialogResult ofdResult = ofd.ShowDialog();
			if (ofdResult == DialogResult.OK) {
				Properties.Settings.Default.OOTRCLIPPath = ofd.FileName;
				Properties.Settings.Default.Save();
				LoadForm();
			}
		}

		private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e) {
			Properties.Settings.Default.BizhawkPath = txtBizhawkPath.Text;
			Properties.Settings.Default.MMRCLIPath = txtMMRCLIPath.Text;
			Properties.Settings.Default.OOTRCLIPPath = txtOOTRCLIPath.Text;
			Properties.Settings.Default.Save();
		}
	}
}
