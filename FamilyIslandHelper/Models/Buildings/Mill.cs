using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Mill
	{
		public static string Name = "Мельница";

		public class GoatFood : ProducableItem
		{
			public override string Name => "Корм для коз";
			public override int LevelWhenAppears => 4;
			public override TimeSpan ProduceTime => TimeSpan.FromSeconds(3 * 60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2),
				(new Potherb(), 4)
			};
		}

		public class ChickenFood : ProducableItem
		{
			public override string Name => "Корм для кур";
			public override int LevelWhenAppears => 7;
			public override TimeSpan ProduceTime => TimeSpan.FromSeconds(5 * 60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clover(), 1),
				(new Corn(), 4)
			};
		}

		public class Ocher : ProducableItem
		{
			public override string Name => "Охра";
			public override int LevelWhenAppears => 23;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pottery.Bowl(), 1),
				(new CopperOre(), 2)
			};
		}

		public class Flour : ProducableItem
		{
			public override string Name => "Мука";
			public override int LevelWhenAppears => 33;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(45 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wheat(), 5),
				(new Stone(), 2)
			};
		}

		public class SunflowerOil : ProducableItem
		{
			public override string Name => "Подсолнечное масло";
			public override int LevelWhenAppears => 44;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sunflower(), 5),
				(new Pottery.Jug(), 1),
				(new Knocker.Millstone(), 1)
			};
		}

		public class Syrup : ProducableItem
		{
			public override string Name => "Сироп";
			public override int LevelWhenAppears => 45;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(10 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Heather(), 5),
				(new Workshop.Scraper(), 1)
			};
		}

		public class CowFood : ProducableItem
		{
			public override string Name => "Корм для коровы";
			public override int LevelWhenAppears => 50;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Carrot(), 8),
				(new Grass(), 4),
				(new Potherb(), 16)
			};
		}
	}
}
