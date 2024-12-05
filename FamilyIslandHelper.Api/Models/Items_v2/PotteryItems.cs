using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Bowl : ProducibleItem
	{
		public override string Name => "Миска";
		public override int LevelWhenAppears => 10;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(9);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 4)
			};
	}

	public class Pot : ProducibleItem
	{
		public override string Name => "Горшок";
		public override int LevelWhenAppears => 18;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(18);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 10),
				(new Stick(), 8)
			};
	}

	public class Jug : ProducibleItem
	{
		public override string Name => "Кувшин";
		public override int LevelWhenAppears => 27;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(90);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 24),
				(new Stick(), 20),
				(new Gloves(), 1)
			};
	}

	public class Amphora : ProducibleItem
	{
		public override string Name => "Амфора";
		public override int LevelWhenAppears => 39;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(45);
		public override Building BuildingToCreate => new Pottery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 25),
				(new Coal(), 4),
				(new Scraper(), 6)
			};
	}
}
