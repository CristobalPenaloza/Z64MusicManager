using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z64MusicManager.Utils {
	class SeqUtils {
		public const byte VOLUME = 0xDB;
		public const byte TEMPO = 0xDD;
		public const byte DELAY = 0xFD;
		public const ushort SECTION = 0xC488;

		public const int PPQN = 48;

		public static int SearchSeqCommandValue(Func<Stream> streamProvider, int commandId) {
			int foundIndex;
			return SearchSeqCommandValue(streamProvider, commandId, out foundIndex);
		}
		public static int SearchSeqCommandValue(Func<Stream> streamProvider, int commandId, out int foundIndex) {
			using (var reader = new BinaryReader(streamProvider())) {
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
			SearchSeqCommandValue(streamProvider, commandId, out indexOfCommand);

			// Don't modify the seq if we do not find the command
			if (indexOfCommand < 0) return;

			using (var writer = new BinaryWriter(streamProvider())) {
				writer.Seek(indexOfCommand, SeekOrigin.Begin);
				writer.Write((byte)value);
			}
		}

		public static TimeSpan CalculateDuration(Func<Stream> streamProvider) {
			List<TempoChange> tempos = new List<TempoChange>();
			using (var reader = new BinaryReader(streamProvider())) {
				try {
					byte currentTempo = 60;
					while (true) {
						byte b = reader.ReadByte();
						// If we find a tempo command, then we changed tempo!
						if (b == TEMPO) {
							currentTempo = reader.ReadByte();
						}

						// If we find a delay (or timestamp, or ticks), we add it to the list with our current tempo
						if (b == DELAY) {
							ushort delay = reader.ReadUInt16BE();
							ushort offsetDelay = (ushort)(delay - 32768); // We substract 0x8000... for some reason all delays have that offset in seq64
							tempos.Add(new TempoChange(currentTempo, offsetDelay));
						}

						// Also search for when a section starts... That means the end of the header!
						if (tempos.Count > 0) {
							if (b == 0xFF) {
								break;
								//if (reader.ReadUInt16BE() == SECTION) break;
							}
						}
					}
				} catch (EndOfStreamException) {
					return TimeSpan.Zero;
				}
			}

			// Now we can calculate the duration of the song
			TimeSpan duration = TimeSpan.Zero;
			foreach (var tempo in tempos) {
				double minutes = (double)tempo.Delay / (PPQN * tempo.Tempo);
				duration += TimeSpan.FromMinutes(minutes);
			}
			return duration;
		}

		public class TempoChange {
			public TempoChange(byte tempo, ushort delay) {
				Tempo = tempo;
				Delay = delay;
			}

			public byte Tempo { get; set; }
			public ushort Delay { get; set; }
		}

	}
}
