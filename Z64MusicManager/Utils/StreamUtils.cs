using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z64MusicManager.Utils {
	class StreamUtils {

		public static IEnumerable<string> StreamReadAllLines(Func<Stream> streamProvider) {
			using (var reader = new StreamReader(streamProvider())) {
				string line;
				while ((line = reader.ReadLine()) != null) {
					yield return line;
				}
			}
		}

	}
}
