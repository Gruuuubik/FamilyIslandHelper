using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Mill
	{
		public static string Name = "Мельница";

		public class GoatFood : ProducableItem
		{
			public override string Name => "Корм для коз";
			public override TimeSpan ProduceTime => TimeSpan.FromSeconds(3 * 60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2),
				(new Potherb(), 4)
			};
		}

		public class ChickenFood : ProducableItem
		{
			public override string Name => "Корм для кур";
			public override TimeSpan ProduceTime => TimeSpan.FromSeconds(5 * 60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clover(), 1),
				(new Corn(), 4)
			};
		}

		public class Ocher : ProducableItem
		{
			public override string Name => "Охра";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pottery.Bowl(), 1),
				(new CopperOre(), 2)
			};
		}

		public class Flour : ProducableItem
		{
			public override string Name => "Мука";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(45 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wheat(), 5),
				(new Stone(), 2)
			};
		}
	}
}
