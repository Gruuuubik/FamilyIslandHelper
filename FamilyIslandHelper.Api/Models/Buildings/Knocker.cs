using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Knocker : Building
	{
		public override string Name => "Стучалка";
		public override double ProduceRatio => 2;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new StoneBlock(),
			new LimestoneBlock(),
			new Beams(),
			new PalmBeams(),
			new Millstone()
		};
	}
}
