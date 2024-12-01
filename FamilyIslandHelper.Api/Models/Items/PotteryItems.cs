using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Resources;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Bowl : ProducibleItem
	{
		public override string Name => "Миска";
		public override int LevelWhenAppears => 10;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(9);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 3)
			};
	}

	public class Pot : ProducibleItem
	{
		public override string Name => "Горшок";
		public override int LevelWhenAppears => 18;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Bowl(), 2)
			};
	}

	public class Jug : ProducibleItem
	{
		public override string Name => "Кувшин";
		public override int LevelWhenAppears => 27;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(90);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pot(), 2),
				(new Ocher(), 1)
			};
	}

	public class Amphora : ProducibleItem
	{
		public override string Name => "Амфора";
		public override int LevelWhenAppears => 39;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Jug(), 1),
				(new Paints(), 1),
				(new Resin(), 1)
			};
	}

	public class Flashlight : ProducibleItem
	{
		public override string Name => "Фонарик";
		public override int LevelWhenAppears => 58;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new SunflowerOil(), 7),
				(new Shingles(), 10)
			};
	}
}
