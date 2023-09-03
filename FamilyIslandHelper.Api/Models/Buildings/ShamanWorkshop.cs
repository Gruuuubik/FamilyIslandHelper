using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class ShamanWorkshop : Building
	{
		public override string Name => "Мастерская шамана";
		public override double ProduceRatio => 1;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new SapphireBracelet()
		};
	}
}