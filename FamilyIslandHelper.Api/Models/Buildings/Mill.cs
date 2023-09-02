using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Mill : Building
	{
		public override string Name => "Мельница";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new GoatFood(),
			new ChickenFood(),
			new Ocher(),
			new Flour(),
			new SunflowerOil(),
			new Syrup(),
			new CowFood()
		};
	}
}