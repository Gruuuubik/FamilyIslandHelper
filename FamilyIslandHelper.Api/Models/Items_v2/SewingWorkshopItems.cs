using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Wattle : ProducibleItem
	{
		public override string Name => "Плетень";
		public override int LevelWhenAppears => 4;
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 4),
				(new Stick(), 3)
			};
	}

	public class Sackcloth : ProducibleItem
	{
		public override string Name => "Мешковина";
		public override int LevelWhenAppears => 10;
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 4),
				(new Stone(), 7),
				(new Stick(), 5)
			};
	}

	public class Gloves : ProducibleItem
	{
		public override string Name => "Перчатки";
		public override int LevelWhenAppears => 15;
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Needle(), 3),
				(new Grass(), 25)
			};
	}

	public class Cloth : ProducibleItem
	{
		public override string Name => "Ткань";
		public override int LevelWhenAppears => 38;
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cotton(), 4),
				(new Wood(), 12),
				(new Grass(), 20)
			};
	}
}
