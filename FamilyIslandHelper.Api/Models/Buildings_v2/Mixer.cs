using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class Mixer : Building
	{
		public override string Name => "Мешалка";
		public override double ProduceRatio => 2;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Soap(),
			new Butter()
		};
	}
}