using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class CarpentryWorkshop : Building
	{
		public override string Name => "Столярная мастерская";
		public override double ProduceRatio => 1;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Spoon(),
			new Crest(),
			new Stool(),
			new Stairs()
		};
	}
}