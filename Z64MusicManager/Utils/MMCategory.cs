using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z64MusicManager.Utils {
	class MMCategory {
		public string Id;
		public string Name;

		public static List<MMCategory> GeneralBgmCategories = new List<MMCategory>() {
			new MMCategory{ Id = "0", Name = "Field" },
			new MMCategory{ Id = "1", Name = "Towns" },
			new MMCategory{ Id = "2", Name = "Dungeon" },
			new MMCategory{ Id = "3", Name = "Indoors" },
			new MMCategory{ Id = "4", Name = "Minigame" },
			new MMCategory{ Id = "5", Name = "Action events" },
			new MMCategory{ Id = "6", Name = "Calm events" },
			new MMCategory{ Id = "7", Name = "Boss fights" },
			new MMCategory{ Id = "16", Name = "Special" },
		};

		public static List<MMCategory> GeneralFanfareCategories = new List<MMCategory>() {
			new MMCategory{ Id = "8", Name = "Item get" },
			new MMCategory{ Id = "9", Name = "Game over" },
			new MMCategory{ Id = "10", Name = "Area clear" },
		};


		// SPECIFICS
		// Source: https://github.com/ZoeyZolotova/mm-rando/blob/dev/MMR.Randomizer/Resources/SEQS.txt

		public static List<MMCategory> SpecificBgmCategories = new List<MMCategory>() {

			// 0 - Field
			new MMCategory{ Id = "102", Name = "Termina Field" },
			new MMCategory{ Id = "113", Name = "Snowhead Mountains" },
			new MMCategory{ Id = "110", Name = "Greay Bay Coast" },
			new MMCategory{ Id = "111", Name = "Ikana Canyon" },
			new MMCategory{ Id = "10C", Name = "Southern Swamp" },

			// 1 - Towns
			new MMCategory{ Id = "115", Name = "Clocktown Day 1" },
			new MMCategory{ Id = "116", Name = "Clocktown Day 2" },
			new MMCategory{ Id = "117", Name = "Clocktown Day 3" },
			new MMCategory{ Id = "130", Name = "Goron City" },
			new MMCategory{ Id = "12F", Name = "Romani Ranch" },
			new MMCategory{ Id = "136", Name = "Zora Hall" },
			new MMCategory{ Id = "112", Name = "Deku Palace" },
			new MMCategory{ Id = "13B", Name = "Caves" },

			// 2 - Dungeon
			new MMCategory{ Id = "165", Name = "Snowhead Temple" },
			new MMCategory{ Id = "166", Name = "Great Bay Temple" },
			new MMCategory{ Id = "114", Name = "Pirate Fortress" },
			new MMCategory{ Id = "16F", Name = "Ikana Castle" },
			new MMCategory{ Id = "106", Name = "Stone Tower" },
			new MMCategory{ Id = "107", Name = "Inverted Stone Tower" },
			new MMCategory{ Id = "11C", Name = "Woodfall Temple" },

			// 3 - Indoor
			new MMCategory{ Id = "105", Name = "Clock Tower" },
			new MMCategory{ Id = "12E", Name = "Guru-Guru" },
			new MMCategory{ Id = "13C", Name = "Milk Bar" },
			new MMCategory{ Id = "11F", Name = "House" },
			new MMCategory{ Id = "144", Name = "Shop" },
			new MMCategory{ Id = "146", Name = "Shooting Gallery" },
			new MMCategory{ Id = "12C", Name = "Marine Research Laboratory" },
			new MMCategory{ Id = "13A", Name = "Astral Observatory" },
			new MMCategory{ Id = "127", Name = "Music Box" },

			// 4 - Minigame
			new MMCategory{ Id = "126", Name = "Goron Race" },
			new MMCategory{ Id = "125", Name = "Minigame" },
			new MMCategory{ Id = "172", Name = "Cremia's Carriage" }, // Wagon Ride
			new MMCategory{ Id = "10E", Name = "Boat Cruise" },
			new MMCategory{ Id = "140", Name = "Horse Race" },

			// 5 - Action events
			new MMCategory{ Id = "131", Name = "Mayor's Meeting" },
			new MMCategory{ Id = "10D", Name = "Aliens" },
			new MMCategory{ Id = "150", Name = "Swordman's School" },
			new MMCategory{ Id = "10F", Name = "Sharp's Curse" },
			new MMCategory{ Id = "103", Name = "Chase" },
			new MMCategory{ Id = "11A", Name = "Combat" },
			new MMCategory{ Id = "17B", Name = "Majora's Theme" }, // Mask Reveal

			// 6 - Calm events
			new MMCategory{ Id = "104", Name = "Skull Kid" },
			new MMCategory{ Id = "128", Name = "Fairy Fountain" },
			new MMCategory{ Id = "118", Name = "File Select" },
			new MMCategory{ Id = "173", Name = "Keaton's Quiz" },
			new MMCategory{ Id = "145", Name = "Kaepora Gaebora" },
			new MMCategory{ Id = "143", Name = "Magic Hag's Potion Shop" },
			new MMCategory{ Id = "142", Name = "Gorman Track" },
			new MMCategory{ Id = "13E", Name = "Woods of Mystery" },
			new MMCategory{ Id = "129", Name = "Zelda's Theme" },
			new MMCategory{ Id = "17D", Name = "Tatl & Tael's Reunion" }, // Reunion
			new MMCategory{ Id = "10B", Name = "Song of Healing" },
			new MMCategory{ Id = "12D", Name = "Giant's Theme" },

			// 7 - Boss fights
			new MMCategory{ Id = "138", Name = "Miniboss" },
			new MMCategory{ Id = "11B", Name = "Boss" },
			new MMCategory{ Id = "16B", Name = "Majora's Mask Battle" },
			new MMCategory{ Id = "16A", Name = "Majora's Incarnation Battle" },
			new MMCategory{ Id = "169", Name = "Majora's Wrath Battle" },

			// 16 - Special
			new MMCategory{ Id = "170", Name = "Giants Cutscene" },
			new MMCategory{ Id = "176", Name = "Title Screen" },
			new MMCategory{ Id = "16C", Name = "Japas's Bass Practice" },
			new MMCategory{ Id = "16D", Name = "Tijo's Drum Practice" },
			new MMCategory{ Id = "16E", Name = "Evan's Piano Practice" },
			new MMCategory{ Id = "157", Name = "Final Hours" },
			new MMCategory{ Id = "171", Name = "Kamaro Dance (Item)" },
			new MMCategory{ Id = "12A", Name = "Kamaro Dance (Rosa Sisters)" },
		};

		public static List<MMCategory> SpecificFanfareCategories = new List<MMCategory>() {
			// 8 - Item get
			new MMCategory{ Id = "122", Name = "Item Get" },
			new MMCategory{ Id = "124", Name = "Heart Get" },
			new MMCategory{ Id = "137", Name = "Mask Get" },
			new MMCategory{ Id = "139", Name = "Small Item Get" },
			new MMCategory{ Id = "13D", Name = "Meet" }, // ???
			new MMCategory{ Id = "13F", Name = "Goron Win" },
			new MMCategory{ Id = "141", Name = "Horse Win" },
			new MMCategory{ Id = "152", Name = "Song Get" },
			new MMCategory{ Id = "155", Name = "Soar" },
			new MMCategory{ Id = "177", Name = "Dungeon Open" },
			new MMCategory{ Id = "119", Name = "Clear (Short)" },

			// 9 - Game over
			new MMCategory{ Id = "108", Name = "Chase Fail" },
			new MMCategory{ Id = "109", Name = "Fail" },
			new MMCategory{ Id = "120", Name = "Game Over" },

			// 10 - Area clear
			new MMCategory{ Id = "121", Name = "Boss Down" },
			new MMCategory{ Id = "178", Name = "Dungeon Clear (Short)" },
			new MMCategory{ Id = "179", Name = "Dungeon Clear (Long)" },
			new MMCategory{ Id = "17E", Name = "Moon Clear" },
			new MMCategory{ Id = "17C", Name = "Giants Leave" },

			// ???
			new MMCategory{ Id = "12B", Name = "Opening Chest" },
		};

	}
}
