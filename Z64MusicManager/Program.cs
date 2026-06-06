using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Z64MusicManager
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			string[] args = Environment.GetCommandLineArgs();

			MainForm form;
			if (args.Length > 1) {

				string fileName = args.Last();
				if (fileName.EndsWith(".ootrs")) form = new OoTRForm();
				else if (fileName.EndsWith(".mmrs")) form = new MMRForm();
				else {
					MessageBox.Show("Unsupported file type.", "Z64 Music Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				form.FileName = fileName;
				form.OpenCurrentFile();

			} else {
				form = new OoTRForm();
			}


			// TODO: CREATE MULTIPLE FORMS FOR MMRS FILES
			Application.Run(form);
		}
	}
}
