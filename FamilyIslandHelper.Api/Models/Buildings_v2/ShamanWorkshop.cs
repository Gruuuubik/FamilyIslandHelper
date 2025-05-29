using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings_v2
{
	public class ShamanWorkshop : Building
	{
		public override string Name => "Мастерская шамана";
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Ocher()
		};
	}
}