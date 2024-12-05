using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class Sawmill : Building
	{
		public override string Name => "Лесопилка";
		public override double ProduceRatio => 1.8;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Stakes(),
			new Board(),
			new SmoothBoard(),
			new Beams()
		};
	}
}