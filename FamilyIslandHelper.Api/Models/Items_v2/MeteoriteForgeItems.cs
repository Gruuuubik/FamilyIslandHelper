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
					(new Iron(), 17),
					(new Clay(), 7),
					(new Wood(), 17)
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
			(new IronIngot(), 3),
			(new Clay(), 12),
			(new Grass(), 12)
		};
	}

	public class IronPipe : ProducibleItem
	{
		public override string Name => "Железная труба";
		public override int LevelWhenAppears => 65;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(60);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new SteelSheet(), 2),
			(new Stone(), 22),
			(new Grass(), 25)
		};
	}
}