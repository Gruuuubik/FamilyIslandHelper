using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class BuildingTimber : ProducibleItem
	{
		public override string Name => "Строительный брус";
		public override int LevelWhenAppears => 1;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(40);
		public override Building BuildingToCreate => new Bench();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 15),
				(new Stick(), 15),
				(new Knife(), 4)
			};
	}

	public class Barrel : ProducibleItem
	{
		public override string Name => "Бочка";
		public override int LevelWhenAppears => 40;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Bench();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 17),
				(new Nails(), 2),
				(new Clay(), 22)
			};
	}
}
