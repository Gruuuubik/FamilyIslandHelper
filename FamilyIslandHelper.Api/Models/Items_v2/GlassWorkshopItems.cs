using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	internal class StainedGlass : ProducibleItem
	{
		public override string Name => "Витраж";
		public override int LevelWhenAppears => 100;
		public override Building BuildingToCreate => new GlassWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 40),
				(new Glass(), 2),
				(new Clay(), 30)
			};
	}
}
