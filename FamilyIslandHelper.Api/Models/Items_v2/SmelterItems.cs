using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Resin : ProducibleItem
	{
		public override string Name => "Смола";
		public override int LevelWhenAppears => 17;
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 4),
				(new Stick(), 7)
			};
	}

	public class IronIngot : ProducibleItem
	{
		public override string Name => "Железный слиток";
		public override int LevelWhenAppears => 20;
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 7),
				(new Wood(), 7),
				(new Stone(), 6)
			};
	}

	public class Coal : ProducibleItem
	{
		public override string Name => "Уголь";
		public override int LevelWhenAppears => 22;
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 7),
				(new Stick(), 12)
			};
	}

	public class SteelSheet : ProducibleItem
	{
		public override string Name => "Стальной лист";
		public override int LevelWhenAppears => 90;
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 12),
				(new Stone(), 12),
				(new Clay(), 15)
			};
	}
}
