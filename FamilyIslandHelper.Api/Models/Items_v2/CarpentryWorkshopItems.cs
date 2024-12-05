using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Spoon : ProducibleItem
	{
		public override string Name => "Ложка";
		public override int LevelWhenAppears => 1;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(3);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 5),
				(new Stone(), 8)
			};
	}

	public class Crest : ProducibleItem
	{
		public override string Name => "Гребень";
		public override int LevelWhenAppears => 26;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(10);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 12),
				(new Clay(), 9)
			};
	}

	public class Stool : ProducibleItem
	{
		public override string Name => "Табуретка";
		public override int LevelWhenAppears => 29;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(43);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new SmoothBoard(), 2),
				(new Wood(), 15)
			};
	}

	public class Stairs : ProducibleItem
	{
		public override string Name => "Лестница";
		public override int LevelWhenAppears => 30;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stick(), 25),
				(new Rope(), 5)
			};
	}
}