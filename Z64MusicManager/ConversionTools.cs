using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z64MusicManager {
	class ConversionTools {

		public static string OoTBank2MMBank(string ootBank) {
			switch (ootBank) {
				case "0x03": return "3"; // Hyrule Field
				case "0x05": return "4"; // Market
				case "0x08": return "5"; // Kakariko Village (Guitar)
				case "0x09": return "6"; // Fairy Fountain
				case "0x0D": return "7"; // Lon Lon Ranch
				case "0x11": return "8"; // Horse Race
				case "0x12": return "9"; // Warp Songs
				case "0x14": return "A"; // Shooting Gallery
				case "0x15": return "B"; // Zora's Domain
				case "0x16": return "C"; // Shop
				case "0x1C": return "D"; // Lakeside Laboratory
				case "0x1D": return "E"; // Kotake and Koume
				case "0x23": return "F"; // Fanfares
				case "0x24": return "10"; // Owl
				default: return "28"; // For all the rest we need a custom bank
			}
		}

		public static string OoTMusicGroups2MMCategories(string musicGroups, string sequenceType) {
			List<int> categories = new List<int>();
			List<string> mg = musicGroups.Split(',').ToList();

			// We map high-specifity groups to MM categories, for a better fit.
			// Is still HIGHLY recommended that the creator fine tune this...

			if(sequenceType.ToLower() == "bgm") {
				if (mg.Contains("Fields")) categories.Add(0); // Field
				else if (mg.Contains("Town")) categories.Add(1); // Towns
				else if (mg.Contains("ChildDungeon") || mg.Contains("AncientDungeon") || mg.Contains("MysticalDungeon") || mg.Contains("SpookyDungeon")) categories.Add(2); // Dungeon
				else if (mg.Contains("SalesArea") || mg.Contains("House")) categories.Add(3); // Indoors
				else if (mg.Contains("Fun")) categories.Add(4); // Minigame
				else if (mg.Contains("SmallFight") || mg.Contains("VillainTheme")) categories.Add(5); // Action
				else if (mg.Contains("MagicalPlace") || mg.Contains("WindmillHut")) categories.Add(6); // Calm
				else if (mg.Contains("BossFight") || mg.Contains("FinalFight")) categories.Add(7); // Boss fight
				else if (mg.Contains("HeroTheme")) categories.Add(16); // Special
				

			} else if (sequenceType.ToLower() == "fanfare") {
				if (mg.Contains("ItemFanfare") || mg.Contains("SuccessFanfare") || mg.Contains("UtilitySong"))
					categories.Add(8); // Item get, Minigame win, Soaring CS
				else if (mg.Contains("GameOver")) categories.Add(9); // Game over
				else if (mg.Contains("BigFanfare") || mg.Contains("WarpSong")) categories.Add(10); // Area clear
			}

			// We make sure there are no duplicates, and they are on the right order
			return string.Join(",", categories.Distinct().OrderBy(x => x));
		}

	}
}
