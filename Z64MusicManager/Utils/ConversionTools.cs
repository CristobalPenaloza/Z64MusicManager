using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Z64MusicManager.Utils {
	class ConversionTools {

		// BANKS
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
		public static string MMBank2OoTBank(string mmBank) {
			switch (mmBank) {
				case "3": return "0x03";
				case "4": return "0x05";
				case "5": return "0x08";
				case "6": return "0x09";
				case "7": return "0x0D";
				case "8": return "0x11";
				case "9": return "0x12";
				case "A": return "0x14";
				case "B": return "0x15";
				case "C": return "0x16";
				case "D": return "0x1C";
				case "E": return "0x1D";
				case "F": return "0x23";
				case "10": return "0x24";
				default: return "-"; // For all the rest we need a custom bank
			}
		}

		// MUSIC GROUPS / CATEGORIES
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

		public static string MMCategories2OoTMusicGroups(List<int> categories) {
			List<string> musicGroups = new List<string>();

			// We map using https://thesounddefense.github.io/musicgroups/ using the exact locations mapped to the high-specifity groups mapped in the method above
			foreach (int category in categories) {
				switch (category) {
					case 0: // Field -> Fields
						musicGroups.AddRange("HyruleField,LostWoods,GerudoValley,Fields,Outdoors,Overworld".Split(','));
						break;
					case 1: // Towns -> Town
						musicGroups.AddRange("Market,CastleCourtyard,ZorasDomain,GoronCity,KokiriForest,LonLonRanch,KakarikoAdult,KakarikoChild,Town,Outdoors,Overworld".Split(','));
						break;
					case 2: // Dungeon -> ChildDungeon,AncientDungeon,MysticalDungeon,SpookyDungeon
						musicGroups.AddRange("InsideDekuTree,DodongosCavern,JabuJabu,ForestTemple,IceCavern,FireTemple,WaterTemple,SpiritTemple,ShadowTemple,CastleUnderground,CastleEscape,ChildDungeon,AncientDungeon,MysticalDungeon,SpookyDungeon,AdultDungeon,Dungeon".Split(','));
						break;
					case 3: // Indoors -> House,SalesArea
						musicGroups.AddRange("House,Shop,PotionShop,SalesArea,Indoors,Overworld".Split(','));
						break;
					case 4: // Minigame -> Fun
						musicGroups.AddRange("Mini-game,HorseRace,ShootingGallery,Fun,Outdoors,Indoors,Overworld".Split(','));
						break;
					case 5: // Action -> SmallFight,VillainTheme
						musicGroups.AddRange("Battle,MinibossBattle,GanondorfTheme,KotakeAndKoume,IngoTheme,SmallFight,VillainTheme,Fight,CharacterTheme".Split(','));
						break;
					case 6: // Calm -> MagicalPlace,WindmillHut
						musicGroups.AddRange("WindmillHut,FairyFountain,TempleOfTime,ChamberOfTheSages,MagicalPlace,Indoors,Overworld".Split(','));
						break;
					case 7: // Boss fight -> BossFight,FinalFight
						musicGroups.AddRange("BossBattle,FireBoss,GanondorfBattle,GanonBattle,BossFight,FinalFight,BigFight,Fight".Split(','));
						break;
					case 8: // Item get, Minigame win, Soaring CS -> ItemFanfare,SuccessFanfare,UtilitySong
						musicGroups.AddRange("ItemGet,HeartContainerGet,HeartPieceGet,SpiritStoneGet,MedallionGet,LearnSong,BossDefeated,EscapeFromRanch,EponaRaceGoal,TreasureChest,ZeldaTurnsAround,DoorOfTime,MasterSword,SariasSong,SunsSong,SongOfTime,SongOfStorms,EponasSong,ZeldasLullaby,ItemFanfare,SuccessFanfare,BigFanfare,UtilitySong,EventFanfare,SongFanfare".Split(','));
						break;
					case 9: // Game over -> GameOver
						musicGroups.AddRange("GameOver,EventFanfare".Split(','));
						break;
					case 10: // Area clear -> BigFanfare,WarpSong
						musicGroups.AddRange("TreasureChest,MasterSword,DoorOfTime,GanondorfAppears,PreludeOfLight,BoleroOfFire,MinuetOfForest,SerenadeOfWater,RequiemOfSpirit,NocturneOfShadow,BigFanfare,WarpSong,EventFanfare,SongFanfare".Split(','));
						break;
					case 16: // Special -> HeroTheme
						musicGroups.AddRange("TitleTheme,ZeldaTheme,SheikTheme,DekuTree,KaeporaGaebora,FairyFlying,HeroTheme,CharacterTheme".Split(','));
						break;
				}
			}
			
			return string.Join(",", musicGroups.Distinct());
		}

		public static string OoTSequenceTypeFromMMCategories(List<int> categories) {
			if (categories.Contains(8) || categories.Contains(9) || categories.Contains(10)) return "Fanfare";
			else return "Bgm";
		}




		// Bank reconstruction stuff!
		// https://github.com/OoTRandomizer/OoT-Randomizer/blob/35c60e9747852e8d63c2b91e4a392f35e59786fe/Audiobank.py


	}
}
