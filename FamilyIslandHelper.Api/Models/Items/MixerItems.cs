using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Soap : ProducibleItem
	{
		public override string Name => "Мыло";
		public override int LevelWhenAppears => 19;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Mixer();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Shell(), 1),
			(new Clay(), 2),
			(new Egg(), 1)
		};
	}

	public class Butter : ProducibleItem
	{
		public override string Name => "Масло";
		public override int LevelWhenAppears => 21;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Mixer();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Milk(), 2)
		};
	}

	public class Cheese : ProducibleItem
	{
		public override string Name => "Сыр";
		public override int LevelWhenAppears => 25;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Mixer();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Salt(), 1),
			(new Butter(), 1)
		};
	}

	public class BluePaint : ProducibleItem
	{
		public override string Name => "Синяя краска";
		public override int LevelWhenAppears => 28;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new Mixer();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new BlueOre(), 3),
			(new Resin(), 1)
		};
	}
}