using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class GoatFood : ProducibleItem
	{
		public override string Name => "Корм для коз";
		public override int LevelWhenAppears => 4;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(1);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2),
				(new Potherb(), 2)
			};
	}

	public class ChickenFood : ProducibleItem
	{
		public override string Name => "Корм для кур";
		public override int LevelWhenAppears => 7;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromSeconds(150);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2),
				(new Corn(), 2)
			};
	}

	public class Flour : ProducibleItem
	{
		public override string Name => "Мука";
		public override int LevelWhenAppears => 33;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(40);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wheat(), 5),
				(new Stone(), 6)
			};
	}

	public class CowFood : ProducibleItem
	{
		public override string Name => "Корм для коровы";
		public override int LevelWhenAppears => 50;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(18);
		public override Building BuildingToCreate => new Mill();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Potherb(), 12),
				(new Tomato(), 9)
			};
	}
}