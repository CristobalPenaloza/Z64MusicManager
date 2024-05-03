using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z64MusicManager.Utils {
	class WinUtils {
		public static string GetPythonPath(string requiredVersion = "", string maxVersion = "") {
			string[] possiblePythonLocations = new string[3] {
				@"HKLM\SOFTWARE\Python\PythonCore\",
				@"HKCU\SOFTWARE\Python\PythonCore\",
				@"HKLM\SOFTWARE\Wow6432Node\Python\PythonCore\"
		};

			//Version number, install path
			Dictionary<string, string> pythonLocations = new Dictionary<string, string>();

			foreach (string possibleLocation in possiblePythonLocations) {
				string regKey = possibleLocation.Substring(0, 4),
							 actualPath = possibleLocation.Substring(5);
				RegistryKey theKey = regKey == "HKLM" ? Registry.LocalMachine : Registry.CurrentUser;
				RegistryKey theValue = theKey.OpenSubKey(actualPath);
				if (theValue == null) continue;

				foreach (var v in theValue.GetSubKeyNames())
					if (theValue.OpenSubKey(v) is RegistryKey productKey)
						try {
							string pythonExePath = productKey.OpenSubKey("InstallPath").GetValue("ExecutablePath").ToString();

							// Comment this in to get (Default) value instead
							// string pythonExePath = productKey.OpenSubKey("InstallPath").GetValue("").ToString();

							if (pythonExePath != null && pythonExePath != "") {
								//Console.WriteLine("Got python version; " + v + " at path; " + pythonExePath);
								pythonLocations.Add(v.ToString(), pythonExePath);
							}
						} catch {
							//Install path doesn't exist
						}
			}

			if (pythonLocations.Count > 0) {
				Version desiredVersion = new Version(requiredVersion == "" ? "0.0.1" : requiredVersion);
				Version maxPVersion = new Version(maxVersion == "" ? "999.999.999" : maxVersion);

				string highestVersion = "", highestVersionPath = "";

				foreach (KeyValuePair<string, string> pVersion in pythonLocations) {
					//TODO; if on 64-bit machine, prefer the 64 bit version over 32 and vice versa
					int index = pVersion.Key.IndexOf("-"); //For x-32 and x-64 in version numbers
					string formattedVersion = index > 0 ? pVersion.Key.Substring(0, index) : pVersion.Key;

					System.Version thisVersion = new System.Version(formattedVersion);
					int comparison = desiredVersion.CompareTo(thisVersion),
							maxComparison = maxPVersion.CompareTo(thisVersion);

					if (comparison <= 0) {
						//Version is greater or equal
						if (maxComparison >= 0) {
							desiredVersion = thisVersion;

							highestVersion = pVersion.Key;
							highestVersionPath = pVersion.Value;
						}
						//else
						//    Console.WriteLine("Version is too high; " + maxComparison.ToString());
					}
					//else
					//    Console.WriteLine("Version (" + pVersion.Key + ") is not within the spectrum.");$
				}

				//Console.WriteLine(highestVersion);
				//Console.WriteLine(highestVersionPath);
				return highestVersionPath;
			}

			return "";
		}

	}
}
