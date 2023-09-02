using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Tannery : Building
	{
		public override string Name => "Кожевенная";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Leather(),
			new Papyrus(),
			new WhitePaint()
		};
	}
}