using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Scraper : ProducibleItem
	{
		public override string Name => "Скребок";
		public override int LevelWhenAppears => 3;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(2);
		public override Building BuildingToCreate => new Workshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Stone(), 2)
		};
	}

	public class Axe : ProducibleItem
	{
		public override string Name => "Топор";
		public override int LevelWhenAppears => 12;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(8);
		public override Building BuildingToCreate => new Workshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Stone(), 6),
			(new Grass(), 4),
			(new Stick(), 4)
		};
	}

	public class Knife : ProducibleItem
	{
		public override string Name => "Нож";
		public override int LevelWhenAppears => 16;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(19);
		public override Building BuildingToCreate => new Workshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Iron(), 2),
			(new Grass(), 6),
			(new Stick(), 4)
		};
	}

	public class Brick : ProducibleItem
	{
		public override string Name => "Кирпич";
		public override int LevelWhenAppears => 19;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Workshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Stone(), 10),
			(new Clay(), 9)
		};
	}
}
