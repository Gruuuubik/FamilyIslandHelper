using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public static class Knocker
	{
		public static string Name = "Стучалка";

		public class StoneBlock : ProducableItem
		{
			public override string Name => "Каменный блок";
			public override int LevelWhenAppears => 30;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 5),
				(new Shell(), 3)
			};
		}

		public class LimestoneBlock : ProducableItem
		{
			public override string Name => "Известняковый блок";
			public override int LevelWhenAppears => 33;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(10 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Limestone(), 6),
				(new Stone(), 5)
			};
		}

		public class Beams : ProducableItem
		{
			public override string Name => "Брус";
			public override int LevelWhenAppears => 34;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(120 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 10),
				(new Workshop.Axe(), 2),
				(new Smelter.Resin(), 1)
			};
		}

		public class PalmBeams : ProducableItem
		{
			public override string Name => "Пальмовый брус";
			public override int LevelWhenAppears => 37;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new PalmLog(), 10),
				(new PalmLeaf(), 3),
				(new Workshop.Knife(), 1)
			};
		}

		public class Millstone : ProducableItem
		{
			public override string Name => "Жернов";
			public override int LevelWhenAppears => 43;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new StoneBlock(), 1),
				(new Loom.Gloves(), 1)
			};
		}
	}
}
