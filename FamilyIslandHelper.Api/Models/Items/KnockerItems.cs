using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Resources;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class StoneBlock : ProducibleItem
	{
		public override string Name => "Каменный блок";
		public override int LevelWhenAppears => 30;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 5),
				(new Shell(), 3)
			};
	}

	public class LimestoneBlock : ProducibleItem
	{
		public override string Name => "Известняковый блок";
		public override int LevelWhenAppears => 33;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(10);
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Limestone(), 6),
				(new Stone(), 5)
			};
	}

	public class Beams : ProducibleItem
	{
		public override string Name => "Брус";
		public override int LevelWhenAppears => 34;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 10),
				(new Axe(), 2),
				(new Resin(), 1)
			};
	}

	public class PalmBeams : ProducibleItem
	{
		public override string Name => "Пальмовый брус";
		public override int LevelWhenAppears => 37;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new PalmLog(), 10),
				(new PalmLeaf(), 3),
				(new Knife(), 1)
			};
	}

	public class Millstone : ProducibleItem
	{
		public override string Name => "Жернов";
		public override int LevelWhenAppears => 43;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new StoneBlock(), 1),
				(new Gloves(), 1)
			};
	}
}