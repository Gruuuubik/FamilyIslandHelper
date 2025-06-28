using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Leather : ProducibleItem
	{
		public override string Name => "Кожа";
		public override int LevelWhenAppears => 24;
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Clay(),6),
			(new Skin(), 2),
			(new Stick(), 4)
		};
	}

	public class Papyrus : ProducibleItem
	{
		public override string Name => "Пергамент";
		public override int LevelWhenAppears => 36;
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Skin(), 2),
			(new Grass(), 30),
			(new Clay(), 30)
		};
	}

	public class Cardboard : ProducibleItem
	{
		public override string Name => "Картон";
		public override int LevelWhenAppears => 40;
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Iron(), 15),
			(new Hammer(), 4),
			(new Wood(), 15)
		};
	}

	public class PaintedParchment : ProducibleItem
	{
		public override string Name => "Крашеный пергамент";
		public override int LevelWhenAppears => 100;
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Grass(), 40),
			(new Skin(), 1),
			(new Clay(), 30)
		};
	}
}
