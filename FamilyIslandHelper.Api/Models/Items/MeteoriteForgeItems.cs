using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Resources;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class IronIngot : ProducibleItem
	{
		public override string Name => "Железный слиток";
		public override int LevelWhenAppears => 45;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Iron(), 5),
			(new Coal(), 2)
		};
	}

	public class IronPipe : ProducibleItem
	{
		public override string Name => "Железная труба";
		public override int LevelWhenAppears => 47;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(75);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Iron(), 7),
			(new Poison(), 3)
		};
	}

	public class IronPlate : ProducibleItem
	{
		public override string Name => "Железная пластина";
		public override int LevelWhenAppears => 54;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new IronIngot(), 7),
			(new Lazurite(), 2),
			(new Axe(), 4)
		};
	}

	public class Hammer : ProducibleItem
	{
		public override string Name => "Молот";
		public override int LevelWhenAppears => 67;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(5);
		public override Building BuildingToCreate => new MeteoriteForge();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new IronIngot(), 2),
			(new WoodenBeam(), 1),
			(new Leather(), 3)
		};
	}
}