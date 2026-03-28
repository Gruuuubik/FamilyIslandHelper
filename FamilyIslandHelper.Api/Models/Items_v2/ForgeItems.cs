using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Needle : ProducibleItem
	{
		public override string Name => "Игла";
		public override int LevelWhenAppears => 14;
		public override Building BuildingToCreate => new Forge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 4),
				(new Grass(), 6)
			};
	}

	public class Hammer : ProducibleItem
	{
		public override string Name => "Молот";
		public override int LevelWhenAppears => 67;
		public override Building BuildingToCreate => new Forge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Iron(), 7),
			(new Stone(), 5),
			(new Wood(), 7)
		};
	}

	public class Glass : ProducibleItem
	{
		public override string Name => "Стекло";
		public override int LevelWhenAppears => 79;
		public override Building BuildingToCreate => new Forge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Stone(), 30),
			(new Stick(), 32),
			(new Wood(), 30)
		};
	}

	public class Lock : ProducibleItem
	{
		public override string Name => "Замок";
		public override int LevelWhenAppears => 85;
		public override Building BuildingToCreate => new Forge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new IronIngot(), 2),
			(new Stick(), 35),
			(new Stone(), 30)
		};
	}
}