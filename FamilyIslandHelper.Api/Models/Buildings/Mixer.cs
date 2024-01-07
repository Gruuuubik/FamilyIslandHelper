using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Mixer : Building
	{
		public override string Name => "Мешалка";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Soap(),
			new Butter(),
			new Cheese(),
			new BluePaint(),
			new LemonOil()
		};
	}
}