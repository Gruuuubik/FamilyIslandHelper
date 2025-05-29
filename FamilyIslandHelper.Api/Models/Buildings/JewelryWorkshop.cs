using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class JewelryWorkshop : Building
	{
		public override string Name => "Ювелирная мастерская";
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new SapphireBracelet(),
			new GemNecklace(),
			new AmethystPendant(),
			new EmeraldRing(),
			new PearlEarrings(),
			new CrystalLotus()
		};
	}
}