using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public static class Sawmill
	{
		public static string Name = "Лесопилка";

		public class Stakes : ProducableItem
		{
			public override string Name => "Колья";
			public override int LevelWhenAppears => 5;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(9 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 2),
				(new Workshop.Scraper(), 1)
			};
		}

		public class UnedgedBoard : ProducableItem
		{
			public override string Name => "Доска необрезная";
			public override int LevelWhenAppears => 8;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 4),
				(new Workshop.Scraper(), 1)
			};
		}

		public class EdgedBoard : ProducableItem
		{
			public override string Name => "Доска обрезная";
			public override int LevelWhenAppears => 20;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new UnedgedBoard(), 2),
				(new Smelter.Resin(), 1)
			};
		}

		public class Trough : ProducableItem
		{
			public override string Name => "Корыто";
			public override int LevelWhenAppears => 52;
			public override TimeSpan ProduceTime => TimeSpan.FromHours(3 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new CarpentryWorkshop.WoodenBeam(), 2),
				(new Tannery.WhitePaint(), 3)
			};
		}
	}
}
