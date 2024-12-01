using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Resources;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Resin : ProducibleItem
	{
		public override string Name => "Смола";
		public override int LevelWhenAppears => 17;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cone(), 3),
				(new Wood(), 2)
			};
	}

	public class Coal : ProducibleItem
	{
		public override string Name => "Уголь";
		public override int LevelWhenAppears => 22;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 3),
				(new Stick(), 3)
			};
	}

	public class Gold : ProducibleItem
	{
		public override string Name => "Золото";
		public override int LevelWhenAppears => 22;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new GoldOre(), 5),
				(new Coal(), 1)
			};
	}

	public class Shingles : ProducibleItem
	{
		public override string Name => "Черепица";
		public override int LevelWhenAppears => 32;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new EdgedBoard(), 1),
				(new Clay(), 5),
				(new Coal(), 1)
			};
	}

	public class BurntBrick : ProducibleItem
	{
		public override string Name => "Обожженный кирпич";
		public override int LevelWhenAppears => 35;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Brick(), 3),
				(new Coal(), 1)
			};
	}

	public class Nails : ProducibleItem
	{
		public override string Name => "Гвозди";
		public override int LevelWhenAppears => 35;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new CopperOre(), 7),
				(new Axe(), 1),
				(new Poison(), 1)
			};
	}
}
