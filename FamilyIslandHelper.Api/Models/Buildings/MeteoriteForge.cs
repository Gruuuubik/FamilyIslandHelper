using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class MeteoriteForge : Building
	{
		public override string Name => "Метеоритная кузница";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new IronIngot(),
			new IronPipe(),
			new IronPlate(),
			new Hammer()
		};
	}
}