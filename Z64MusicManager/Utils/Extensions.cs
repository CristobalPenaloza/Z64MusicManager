
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z64MusicManager.Utils {
	public static class Extensions {

		// STRING EXTENSIONS
		public static string BeforeMatch(this string input, string match) {
			if (input == null) return null;
			int to = input.IndexOf(match);
			if (to <= 0) return "";
			return input.Substring(0, to);
		}
		public static string Between(this string input, string from, string to) {
			try {
				if (input == null) return null;
				int pFrom = input.IndexOf(from) + from.Length;
				int pTo = input.Substring(pFrom).IndexOf(to);
				if (pTo <= 0) {
					pTo = input.Substring(pFrom).IndexOf("$");
				}
				return input.Substring(pFrom, pTo);
			} catch (Exception) {
				return "";
			}
		}
		public static string AfterMatch(this string input, string match, int count = 1) {
			if (input == null) return null;
			for (int i = 0; i < count; i++) {
				int indexOfMatch = input.IndexOf(match);
				if (indexOfMatch == -1) return input;
				else input = input.Substring(indexOfMatch + match.Length);
			}
			return input;
		}


		// ZIPARCHIVE EXTENSIONS
		public static ZipArchiveEntry CopyToNewEntry(this ZipArchiveEntry entry, string copyName) {
			ZipArchiveEntry copy = entry.Archive.CreateEntry(copyName);
			using (var a = entry.Open())
			using (var b = copy.Open()) a.CopyTo(b);
			return copy;
		}

	}
}
