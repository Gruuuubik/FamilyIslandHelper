using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Nails : ProducibleItem
	{
		public override string Name => "Гвозди";
		public override int LevelWhenAppears => 35;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(25);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
				{
					(new IronIngot(), 2),
					(new Clay(), 15),
					(new Feather(), 1)
				};
	}

	public class IronPlate : ProducibleItem
	{
		public override string Name => "Железная пластина";
		public override int LevelWhenAppears => 54;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new IronIngot(), 2),
			(new Hammer(), 1)
		};
	}
}