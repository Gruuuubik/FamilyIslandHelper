using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Loom
	{
		public static string Name = "Ткацкий станок";

		public class Lace : ProducableItem
		{
			public override string Name => "Шнурок";
			public override int LevelWhenAppears => 2;
			public override TimeSpan ProduceTime => TimeSpan.FromSeconds(150 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2)
			};
		}

		public class Wattle : ProducableItem
		{
			public override string Name => "Плетень";
			public override int LevelWhenAppears => 4;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(6 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stick(), 3),
				(new Lace(), 1)
			};
		}

		public class Rope : ProducableItem
		{
			public override string Name => "Верёвка";
			public override int LevelWhenAppears => 15;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Lace(), 3),
				(new CarpentryWorkshop.Needle(), 1)
			};
		}

		public class Gloves : ProducableItem
		{
			public override string Name => "Перчатки";
			public override int LevelWhenAppears => 15;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Skin(), 2)
			};
		}

		public class Sackcloth : ProducableItem
		{
			public override string Name => "Мешковина";
			public override int LevelWhenAppears => 26;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cotton(), 5),
				(new CarpentryWorkshop.Crest(), 1)
			};
		}

		public class Cloth : ProducableItem
		{
			public override string Name => "Ткань";
			public override int LevelWhenAppears => 38;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sackcloth(), 2),
				(new Mixer.BluePaint(), 1)
			};
		}

		public class Necklace : ProducableItem
		{
			public override string Name => "Ожерелье";
			public override int LevelWhenAppears => 42;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Amber(), 5),
				(new Emerald(), 3),
				(new CarpentryWorkshop.Needle(), 1)
			};
		}
	}
}
