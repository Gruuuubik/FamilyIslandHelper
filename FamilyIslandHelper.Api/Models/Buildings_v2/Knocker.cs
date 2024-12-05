using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class Knocker : Building
	{
		public override string Name => "Стучалка";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new StoneBlock()
		};
	}
}
