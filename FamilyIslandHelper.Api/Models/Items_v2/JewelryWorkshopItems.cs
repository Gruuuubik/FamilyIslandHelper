using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Earrings : ProducibleItem
	{
		public override string Name => "Серьги";
		public override int LevelWhenAppears => 37;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Gold(), 2),
				(new Axe(), 4)
			};
	}

	public class Bracelet : ProducibleItem
	{
		public override string Name => "Браслет";
		public override int LevelWhenAppears => 60;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(35);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Emerald(), 3),
				(new Clay(), 25),
				(new Hammer(), 1)
			};
	}
}
