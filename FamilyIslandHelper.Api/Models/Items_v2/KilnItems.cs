using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class BurntBrick : ProducibleItem
	{
		public override string Name => "Обожженный кирпич";
		public override int LevelWhenAppears => 35;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(45);
		public override Building BuildingToCreate => new Kiln();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Brick(), 3)
			};
	}

	public class Shingles : ProducibleItem
	{
		public override string Name => "Черепица";
		public override int LevelWhenAppears => 46;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new Kiln();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 20)
			};
	}
}