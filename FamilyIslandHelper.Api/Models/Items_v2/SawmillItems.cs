using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Stakes : ProducibleItem
	{
		public override string Name => "Колья";
		public override int LevelWhenAppears => 5;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(2);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Stick(), 3)
		};
	}

	public class Board : ProducibleItem
	{
		public override string Name => "Доска";
		public override int LevelWhenAppears => 8;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Wood(), 8),
			(new Scraper(), 2)
		};
	}

	public class SmoothBoard : ProducibleItem
	{
		public override string Name => "Гладкая доска";
		public override int LevelWhenAppears => 20;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(46);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Wood(), 12),
			(new Axe(), 2),
			(new Resin(), 2)
		};
	}

	public class Beams : ProducibleItem
	{
		public override string Name => "Брус";
		public override int LevelWhenAppears => 34;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(54);
		public override Building BuildingToCreate => new Sawmill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Axe(), 6),
				(new Stick(), 20),
				(new Clay(), 18)
			};
	}
}
