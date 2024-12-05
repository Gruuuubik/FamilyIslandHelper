using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
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
}
