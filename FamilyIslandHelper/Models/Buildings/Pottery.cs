using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Pottery
	{
		public static string Name = "Гончарная";

		public class Bowl : ProducableItem
		{
			public override string Name => "Миска";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(9);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 3)
			};
		}

		public class Pot : ProducableItem
		{
			public override string Name => "Горшок";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Bowl(), 2)
			};
		}

		public class Jug : ProducableItem
		{
			public override string Name => "Кувшин";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(90);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pot(), 2),
				(new Mill.Ocher(), 1)
			};
		}

		public class Amphora : ProducableItem
		{
			public override string Name => "Амфора";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Jug(), 1)
			};
		}
	}
}
