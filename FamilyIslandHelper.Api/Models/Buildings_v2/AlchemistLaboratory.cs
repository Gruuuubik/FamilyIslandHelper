using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class AlchemistLaboratory : Building
	{
		public override string Name => "Лаборатория алхимика";
		public override double ProduceRatio => 1;

		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Gold()
		};
	}
}
