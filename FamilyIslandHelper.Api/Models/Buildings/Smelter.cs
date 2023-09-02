using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Smelter : Building
	{
		public override string Name => "Плавильня";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Resin(),
			new Coal(),
			new Gold(),
			new Shingles(),
			new BurntBrick(),
			new Nails()
		};
	}
}