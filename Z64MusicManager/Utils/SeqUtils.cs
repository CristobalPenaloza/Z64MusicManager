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

		// We know the end of the header, by checking it's end and if its continued by a section start
		public const byte END = 0xFF;
		public const byte SECTION_START = 0xC4;

		// Other commands to check to prevent issues...
		// Eventually implement every command, so we can check properly
		public const byte INIT_CHAN = 0xD7;
		public const byte DISABLE_CHAN = 0xD6;

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

		// Falla porque el comando anterior es un INITCHAN (0xD7)
		// DISABLECHAN (0xD6)


		public static TimeSpan CalculateDuration(Func<Stream> streamProvider) {
			List<TempoChange> tempos = new List<TempoChange>();
			using (var reader = new BinaryReader(streamProvider())) {
				try {
					byte currentTempo = 120; // We use default MIDI tempo. Pretty sure MM uses this!
					bool foundEnd = false;
					while (true) {
						byte b = reader.ReadByte();

						// If we find any of these commands, advance the reader to not disrupt anything else
						// These are not "variables", so we always read 2 bytes
						if(b == INIT_CHAN || b == DISABLE_CHAN) {
							reader.ReadBytes(2);
						}

						// If we find a tempo command, then we changed tempo!
						if (b == TEMPO) {
							currentTempo = reader.ReadByte();
						}

						// If we find a delay (or timestamp, or ticks), we add it to the list with our current tempo
						if (b == DELAY) {
							// TODO: MAKE THIS A UTIL METHOD, TO READ "VARIABLE" VALUES
							// Delay is a "variable" type of data, meaning it can be multiple bytes long.
							// How seq64 handles it:
							// https://github.com/sauraen/seq64/blob/47500ab1bbf93eeaad35806ff6a13163cc11538a/Source/SeqFile.cpp#L4783
							// We need to replicate that exact same behaviour

							// We read the first byte
							ushort delay = reader.ReadByte();

							// If the most significant bit is 1, it means this value is spread in two bytes!
							if ((delay & 0x80) == 0x80) {
								delay &= 0x7F; // We remove the leftmost bit, since thats just a flag, not part of the actual value
								delay <<= 8; // We shift the value to the left to make space for the next byte

								// Finally, we read the next byte and add it
								ushort nextByte = reader.ReadByte();
								delay |= nextByte;
							}

							tempos.Add(new TempoChange(currentTempo, delay));
						}

						// Also search for when a section ends and another sections starts... That means the end of the header!
						// We do it in separate checks because FF can be the value of another command
						if (b == END) {
							foundEnd = true;

						} else if (foundEnd) {
							if (b == SECTION_START) break;
							else foundEnd = false;
						}
					}
				} catch (EndOfStreamException) {
					return TimeSpan.Zero;
				}
			}

			// Now we can calculate the duration of the song
			TimeSpan duration = TimeSpan.Zero;
			foreach (var tempo in tempos) {
				if(tempo.Tempo == 0) continue; // Avoid division by 0
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
