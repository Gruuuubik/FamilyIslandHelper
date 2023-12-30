using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class CarpentryWorkshop : Building
	{
		public override string Name => "Столярная мастерская";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Needle(),
			new Stairs(),
			new Crest(),
			new Stool(),
			new Paints(),
			new Pipe(),
			new Tambourine(),
			new Barrel(),
			new WoodenBeam(),
			new LeatherBall(),
			new Incense()
		};
	}
}