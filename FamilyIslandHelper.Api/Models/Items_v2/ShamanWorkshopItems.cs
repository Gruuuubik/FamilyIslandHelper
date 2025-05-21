using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Ocher : ProducibleItem
	{
		public override string Name => "Охра";
		public override int LevelWhenAppears => 90;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(45);
		public override Building BuildingToCreate => new ShamanWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Clay(), 20),
				(new Stick(), 15),
				(new Grass(), 22)
			};
	}
}