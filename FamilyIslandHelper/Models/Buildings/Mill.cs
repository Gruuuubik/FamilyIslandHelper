using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	//Мельница
	public static class Mill
	{
		public static string Name = "Мельница";

		public class ChickenFood : ProducableItem
		{
			public override string Name => "Корм для кур";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(5);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clover(), 1),
				(new Corn(), 4)
			};
		}

		public class Ocher : ProducableItem
		{
			public override string Name => "Охра";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pottery.Bowl(), 1),
				(new CopperOre(), 2)
			};
		}

		public class Flour : ProducableItem
		{
			public override string Name => "Мука";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(45);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wheat(), 5),
				(new Stone(), 2)
			};
		}
	}
}
