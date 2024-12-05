using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class Mill : Building
	{
		public override string Name => "Мельница";
		public override double ProduceRatio => 1.2;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new GoatFood(),
			new ChickenFood(),
			new Flour(),
			new CowFood()
		};
	}
}