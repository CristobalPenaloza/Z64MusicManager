using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZMusicManager
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
			//string fileName = args[1]; // <-- TODO: CHECK IF FILENAME EXISTS, AND ADD IT TO THE FORM VIA CONSTRUCTOR

			// TODO: CREATE MULTIPLE FORMS FOR MMRS FILES
			Application.Run(new Form1());
		}
	}
}
