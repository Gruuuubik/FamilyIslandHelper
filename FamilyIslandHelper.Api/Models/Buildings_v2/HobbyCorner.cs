using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class HobbyCorner : Building
	{
		public override string Name => "Уголок хобби";

		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Scissors()
		};
	}
}
