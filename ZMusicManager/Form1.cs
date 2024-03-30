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

namespace ZMusicManager {
	public partial class Form1 : Form {
		public string FileName;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			OpenCurrentFile();
		}

		private void OpenCurrentFile() {
			Text = "ZMusic Manager";
			if (!string.IsNullOrEmpty(FileName)) Text = Path.GetFileName(FileName) + " - " + Text;

			// TODO: GET ZIPPER LIBRARY
			// TODO: FILL OUT FORM
		}

		private void btnOpen_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = "C:\\"; // <-- TODO: SAVE THE LAST USED FOLDER CROSS SESSION
			ofd.Filter = "Ocarina of Time Radomizer Sound Files (*.ootrs)|*.ootrs";
			ofd.RestoreDirectory = true;

			// We show the open file dialog
			DialogResult result = ofd.ShowDialog();

			if (result == DialogResult.OK) {
				FileName = ofd.FileName;
				OpenCurrentFile();
			}
		}
	}
}
