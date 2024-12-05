using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class StoneBlock : ProducibleItem
	{
		public override string Name => "Каменный блок";
		public override int LevelWhenAppears => 30;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 15),
				(new Hammer(), 2)
			};
	}
}