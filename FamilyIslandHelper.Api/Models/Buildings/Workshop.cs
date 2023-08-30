using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public static class Workshop
	{
		public static string Name = "Мастерская";
		private const double ProduceRatio = 1.5;

		public class Scraper : ProducableItem
		{
			public override string Name => "Скребок";
			public override int LevelWhenAppears => 3;
			public override TimeSpan ProduceTime => TimeSpan.FromSeconds(4 * 60 / ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 2)
			};
		}

		public class Axe : ProducableItem
		{
			public override string Name => "Топор";
			public override int LevelWhenAppears => 12;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15 / ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 3),
				(new Loom.Lace(), 1),
				(new Stick(), 2)
			};
		}

		public class Knife : ProducableItem
		{
			public override string Name => "Нож";
			public override int LevelWhenAppears => 16;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30 / ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Scraper(), 2),
				(new Loom.Lace(), 1),
				(new Stick(), 1)
			};
		}

		public class Brick : ProducableItem
		{
			public override string Name => "Кирпич";
			public override int LevelWhenAppears => 19;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 3),
				(new Clay(), 5)
			};
		}
	}
}
