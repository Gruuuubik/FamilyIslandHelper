using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Scraper : ProducibleItem
	{
		public override string Name => "Скребок";
		public override int LevelWhenAppears => 3;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(4);
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
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Workshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Stone(), 3),
			(new Lace(), 1),
			(new Stick(), 2)
		};
	}

	public class Knife : ProducibleItem
	{
		public override string Name => "Нож";
		public override int LevelWhenAppears => 16;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Workshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Scraper(), 2),
			(new Lace(), 1),
			(new Stick(), 1)
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
			(new Stone(), 3),
			(new Clay(), 5)
		};
	}
}
