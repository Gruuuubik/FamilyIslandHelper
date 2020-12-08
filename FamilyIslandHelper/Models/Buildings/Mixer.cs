using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	//Мешалка
	public static class Mixer
	{
		public static string Name = "Мешалка";

		public class Soap : ProducableItem
		{
			public override string Name => "Мыло";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Shell(), 1),
				(new Clay(), 2),
				(new Egg(), 1)
			};
		}

		public class Butter : ProducableItem
		{
			public override string Name => "Масло";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Milk(), 2)
			};
		}

		public class Cheese : ProducableItem
		{
			public override string Name => "Сыр";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Salt(), 1),
				(new Butter(), 1)
			};
		}

		public class BluePaint : ProducableItem
		{
			public override string Name => "Синяя краска";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(120);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new BlueOre(), 3),
				(new Smelter.Resin(), 1)
			};
		}
	}
}
