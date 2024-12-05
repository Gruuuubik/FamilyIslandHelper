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
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(8);
		public override Building BuildingToCreate => new Forge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(),8),
				(new Grass(), 12)
			};
	}

	public class Hammer : ProducibleItem
	{
		public override string Name => "Молот";
		public override int LevelWhenAppears => 67;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new Forge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Iron(), 14),
			(new Stone(), 10),
			(new Wood(), 15)
		};
	}
}