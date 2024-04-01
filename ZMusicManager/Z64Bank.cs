﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMusicManager {
	public class Z64Bank {
		public string Id;
		public string Name;

		public static List<Z64Bank> OoTBanks = new List<Z64Bank> {
			new Z64Bank{ Id = "0x03", Name = "0x03 - Main Orchestra/Hyrule Field" },
			new Z64Bank{ Id = "0x04", Name = "0x04 - Deku Tree" },
			new Z64Bank{ Id = "0x05", Name = "0x05 - Market" },
			new Z64Bank{ Id = "0x06", Name = "0x06 - Title Screen" },
			new Z64Bank{ Id = "0x07", Name = "0x07 - Jabu Jabu's Belly" },
			new Z64Bank{ Id = "0x08", Name = "0x08 - Kakariko Village (Guitar)" },
			new Z64Bank{ Id = "0x09", Name = "0x09 - Fairy Fountain" },
			new Z64Bank{ Id = "0x0A", Name = "0x0A - Fire Temple" },
			new Z64Bank{ Id = "0x0B", Name = "0x0B - Dodongo's Cavern" },
			new Z64Bank{ Id = "0x0C", Name = "0x0C - Forest Temple" },
			new Z64Bank{ Id = "0x0D", Name = "0x0D - Lon Lon Ranch" },
			new Z64Bank{ Id = "0x0E", Name = "0x0E - Goron City" },
			new Z64Bank{ Id = "0x0F", Name = "0x0F - Kokiri Forest" },
			new Z64Bank{ Id = "0x10", Name = "0x10 - Spirit Temple" },
			new Z64Bank{ Id = "0x11", Name = "0x11 - Horse Race" },
			new Z64Bank{ Id = "0x12", Name = "0x12 - Warp Songs" },
			new Z64Bank{ Id = "0x13", Name = "0x13 - Goddess Cutscene" },
			new Z64Bank{ Id = "0x14", Name = "0x14 - Shooting Gallery" },
			new Z64Bank{ Id = "0x15", Name = "0x15 - Zora's Domain" },
			new Z64Bank{ Id = "0x16", Name = "0x16 - Shop" },
			new Z64Bank{ Id = "0x17", Name = "0x17 - Ice Cavern" },
			new Z64Bank{ Id = "0x18", Name = "0x18 - Shadow Temple" },
			new Z64Bank{ Id = "0x19", Name = "0x19 - Water Temple" },
			new Z64Bank{ Id = "0x1A", Name = "0x1A - Piano (Unused)" },
			new Z64Bank{ Id = "0x1B", Name = "0x1B - Gerudo Valley" },
			new Z64Bank{ Id = "0x1C", Name = "0x1C - Lakeside Laboratory" },
			new Z64Bank{ Id = "0x1D", Name = "0x1D - Kotake and Koume" },
			new Z64Bank{ Id = "0x1E", Name = "0x1E - Ganon's Castle (Organ)" },
			new Z64Bank{ Id = "0x1F", Name = "0x1F - Inside Ganon's Castle" },
			new Z64Bank{ Id = "0x20", Name = "0x20 - Ganondorf Battle" },
			new Z64Bank{ Id = "0x21", Name = "0x21 - Ending Sequence 1" },
			new Z64Bank{ Id = "0x22", Name = "0x22 - Ending Sequence 2" },
			new Z64Bank{ Id = "0x23", Name = "0x23 - Fanfares" },
			new Z64Bank{ Id = "0x24", Name = "0x24 - Owl" },
			new Z64Bank{ Id = "-", Name = "Custom Bank" },
		};

		public override string ToString() {
			return Name;
		}
	}
}