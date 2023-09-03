using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class RuneStone : ProducibleItem
	{
		public override string Name => "Рунный камень";
		public override int LevelWhenAppears => 62;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(6);
		public override Building BuildingToCreate => new ShamanWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new StoneBlock(), 3),
				(new Knife(), 5),
				(new BluePaint(), 1),
			};
	}
}