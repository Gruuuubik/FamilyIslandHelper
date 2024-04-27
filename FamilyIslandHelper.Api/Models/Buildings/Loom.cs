using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Loom : Building
	{
		public override string Name => "Ткацкий станок";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Lace(),
			new Wattle(),
			new Rope(),
			new Gloves(),
			new Sackcloth(),
			new Cloth(),
			new Necklace(),
			new PicnicBasket(),
			new WickerBasket(),
			new DreamCatcher(),
			new DyedFabric()
		};
	}
}