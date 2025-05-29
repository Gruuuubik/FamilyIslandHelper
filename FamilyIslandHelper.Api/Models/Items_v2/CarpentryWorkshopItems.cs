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
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 6),
				(new Clay(), 4)
			};
	}

	public class Stool : ProducibleItem
	{
		public override string Name => "Табуретка";
		public override int LevelWhenAppears => 29;
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new SmoothBoard(), 2),
				(new Wood(), 7)
			};
	}

	public class Stairs : ProducibleItem
	{
		public override string Name => "Лестница";
		public override int LevelWhenAppears => 30;
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stick(), 12),
				(new Grass(), 32),
				(new Stone(), 27)
			};
	}
}