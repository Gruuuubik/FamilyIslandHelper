using FamilyIslandHelper.Api.Models.Abstract;
using System.Collections.Generic;
using System;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public static class MeteoriteForge
	{
		public static string Name = "Метеоритная кузница";

		public class IronIngot : ProducableItem
		{
			public override string Name => "Железный слиток";
			public override int LevelWhenAppears => 45;
			public override TimeSpan ProduceTime => TimeSpan.FromHours(1 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 5),
				(new Smelter.Coal(), 2)
			};
		}

		public class IronPipe : ProducableItem
		{
			public override string Name => "Железная труба";
			public override int LevelWhenAppears => 47;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(75 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 7),
				(new Poison(), 3)
			};
		}

		public class IronPlate : ProducableItem
		{
			public override string Name => "Железная пластина";
			public override int LevelWhenAppears => 54;
			public override TimeSpan ProduceTime => TimeSpan.FromHours(2 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new IronIngot(), 7),
				(new Lazurite(), 2),
				(new Workshop.Axe(), 4)
			};
		}

		public class Hammer : ProducableItem
		{
			public override string Name => "Молот";
			public override int LevelWhenAppears => 67;
			public override TimeSpan ProduceTime => TimeSpan.FromHours(5 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new IronIngot(), 2),
				(new CarpentryWorkshop.WoodenBeam(), 1),
				(new Tannery.Leather(), 3)
			};
		}
	}
}
