﻿using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Sawmill
	{
		public static string Name = "Лесопилка";

		public class Stakes : ProducableItem
		{
			public override string Name => "Колья";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(9);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 2),
				(new Workshop.Scraper(), 1)
			};
		}

		public class UnedgedBoard : ProducableItem
		{
			public override string Name => "Доска необрезная";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 4),
				(new Workshop.Scraper(), 1)
			};
		}

		public class EdgedBoard : ProducableItem
		{
			public override string Name => "Доска обрезная";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new UnedgedBoard(), 2),
				(new Smelter.Resin(), 1)
			};
		}
	}
}
