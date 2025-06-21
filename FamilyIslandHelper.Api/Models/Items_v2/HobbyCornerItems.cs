using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	internal class Scissors : ProducibleItem
	{
		public override string Name => "Ножницы";
		public override int LevelWhenAppears => 110;
		public override Building BuildingToCreate => new HobbyCorner();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 35),
				(new Stone(), 25),
				(new Iron(), 30)
			};
	}
}
