using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMusicManager {
	class Utils {

		public static IEnumerable<string> StreamReadAllLines(Stream stream) {
			using (var reader = new StreamReader(stream)) {
				string line;
				while ((line = reader.ReadLine()) != null) {
					yield return line;
				}
			}
		}

		public static int SearchSeqCommandValue(Stream stream, int commandId) {
			int foundIndex;
			return SearchSeqCommandValue(stream, commandId, out foundIndex);
		}
		public static int SearchSeqCommandValue(Stream stream, int commandId, out int foundIndex) {
			using (var reader = new BinaryReader(stream)) {
				// Search thru the whole file until we find the command
				try {
					for (int i = 0; true; i++) {
						if (reader.ReadByte() == commandId) {

							// Since we found the command, get the next byte: that should be the value!
							foundIndex = i + 1;
							return reader.ReadByte();
						}
					}
				} catch (EndOfStreamException) {
					foundIndex = -1;
					return 0;
				}
			}
		}

		public static void ReplaceSeqCommandValue(Func<Stream> streamProvider, int commandId, int value) {
			int indexOfCommand;
			SearchSeqCommandValue(streamProvider(), commandId, out indexOfCommand);

			// Don't modify the seq if we do not find the command
			if (indexOfCommand < 0) return;

			using (var writer = new BinaryWriter(streamProvider())) {
				writer.Seek(indexOfCommand, SeekOrigin.Begin);
				writer.Write((byte)value);
			}
		}

	}
}
