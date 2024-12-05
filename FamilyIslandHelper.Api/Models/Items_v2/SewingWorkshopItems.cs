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
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(2);
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
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(8);
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Lace(), 3),
				(new Stone(), 14),
				(new Stick(), 10)
			};
	}

	public class Gloves : ProducibleItem
	{
		public override string Name => "Перчатки";
		public override int LevelWhenAppears => 15;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(21);
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Needle(), 3),
				(new Lace(), 8),
				(new Skin(), 2)
			};
	}

	public class Cloth : ProducibleItem
	{
		public override string Name => "Ткань";
		public override int LevelWhenAppears => 38;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new SewingWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cotton(), 4),
				(new Crest(), 2)
			};
	}
}
