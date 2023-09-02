using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Workshop : Building
	{
		public override string Name => "Мастерская";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items =>
			new List<ProducibleItem>
			{
				new Scraper(),
				new Axe(),
				new Knife(),
				new Brick()
			};
	}
}