using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class Loom : Building
	{
		public override string Name => "Ткацкий станок";
		public override double ProduceRatio => 1;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Lace(),
			new Rope(),
			new LeatherСord(),
			new Basket()
		};
	}
}