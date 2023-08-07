using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public static class Pottery
	{
		public static string Name = "Гончарная";

		public class Bowl : ProducableItem
		{
			public override string Name => "Миска";
			public override int LevelWhenAppears => 10;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(9 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 3)
			};
		}

		public class Pot : ProducableItem
		{
			public override string Name => "Горшок";
			public override int LevelWhenAppears => 18;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Bowl(), 2)
			};
		}

		public class Jug : ProducableItem
		{
			public override string Name => "Кувшин";
			public override int LevelWhenAppears => 27;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(90 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pot(), 2),
				(new Mill.Ocher(), 1)
			};
		}

		public class Amphora : ProducableItem
		{
			public override string Name => "Амфора";
			public override int LevelWhenAppears => 39;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Jug(), 1),
				(new CarpentryWorkshop.Paints(), 1),
				(new Smelter.Resin(), 1)
			};
		}

		public class Flashlight : ProducableItem
		{
			public override string Name => "Фонарик";
			public override int LevelWhenAppears => 58;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Candle(), 5),
				(new Mill.SunflowerOil(), 7),
				(new Smelter.Shingles(), 10)
			};
		}
	}
}
