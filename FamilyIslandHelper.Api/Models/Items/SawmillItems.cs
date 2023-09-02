using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Stakes : ProducibleItem
	{
		public override string Name => "Колья";
		public override int LevelWhenAppears => 5;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(9);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Wood(), 2),
			(new Scraper(), 1)
		};
	}

	public class UnedgedBoard : ProducibleItem
	{
		public override string Name => "Доска необрезная";
		public override int LevelWhenAppears => 8;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Wood(), 4),
			(new Scraper(), 1)
		};
	}

	public class EdgedBoard : ProducibleItem
	{
		public override string Name => "Доска обрезная";
		public override int LevelWhenAppears => 20;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new UnedgedBoard(), 2),
			(new Resin(), 1)
		};
	}

	public class Trough : ProducibleItem
	{
		public override string Name => "Корыто";
		public override int LevelWhenAppears => 52;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new WoodenBeam(), 2),
			(new WhitePaint(), 3)
		};
	}
}
