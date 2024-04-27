using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class GoatFood : ProducibleItem
	{
		public override string Name => "Корм для коз";
		public override int LevelWhenAppears => 4;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(3);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2),
				(new Potherb(), 4)
			};
	}

	public class ChickenFood : ProducibleItem
	{
		public override string Name => "Корм для кур";
		public override int LevelWhenAppears => 7;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(5);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clover(), 1),
				(new Corn(), 4)
			};
	}

	public class Ocher : ProducibleItem
	{
		public override string Name => "Охра";
		public override int LevelWhenAppears => 23;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Bowl(), 1),
				(new CopperOre(), 2)
			};
	}

	public class Flour : ProducibleItem
	{
		public override string Name => "Мука";
		public override int LevelWhenAppears => 33;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(45);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wheat(), 5),
				(new Stone(), 2)
			};
	}

	public class SunflowerOil : ProducibleItem
	{
		public override string Name => "Подсолнечное масло";
		public override int LevelWhenAppears => 44;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sunflower(), 5),
				(new Jug(), 1),
				(new Millstone(), 1)
			};
	}

	public class Syrup : ProducibleItem
	{
		public override string Name => "Сироп";
		public override int LevelWhenAppears => 45;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(10);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Heather(), 5),
				(new Scraper(), 1)
			};
	}

	public class CowFood : ProducibleItem
	{
		public override string Name => "Корм для коровы";
		public override int LevelWhenAppears => 50;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Carrot(), 8),
				(new Grass(), 4),
				(new Potherb(), 16)
			};
	}
}