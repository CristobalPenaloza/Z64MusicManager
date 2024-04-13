using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z64MusicManager
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			string[] args = Environment.GetCommandLineArgs();

			MainForm form;
			if(args.Length > 1) {
				string fileName = args[1];
				if (fileName.EndsWith(".ootrs")) form = new OoTRForm();
				else form = new MMRForm();

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
