using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Knocker
	{
		public static string Name = "Стучалка";

		public class StoneBlock : ProducableItem
		{
			public override string Name => "Каменный блок";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 5),
				(new Shell(), 3)
			};
		}

		public class Beams : ProducableItem
		{
			public override string Name => "Брус";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(120);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 10),
				(new Workshop.Axe(), 2),
				(new Smelter.Resin(), 1)
			};
		}
	}
}
