using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	//Мастерская
	public static class Workshop
	{
		public static string Name = "Мастерская";

		public class Scraper : ProducableItem
		{
			public override string Name => "Скребок";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(4);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 2)
			};
		}

		public class Axe : ProducableItem
		{
			public override string Name => "Топор";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15);

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
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30);

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
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 3),
				(new Clay(), 5)
			};
		}
	}
}
