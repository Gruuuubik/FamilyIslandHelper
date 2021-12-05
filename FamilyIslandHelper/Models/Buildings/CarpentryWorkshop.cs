using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class CarpentryWorkshop
	{
		public static string Name = "Столярная мастерская";

		public class Needle : ProducableItem
		{
			public override string Name => "Игла";
			public override int LevelWhenAppears => 14;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Claw(), 1),
				(new Workshop.Scraper(), 1),
				(new Loom.Lace(), 1)
			};
		}

		public class Stairs : ProducableItem
		{
			public override string Name => "Лестница";
			public override int LevelWhenAppears => 20;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stick(), 10),
				(new Loom.Rope(), 2)
			};
		}

		public class Crest : ProducableItem
		{
			public override string Name => "Гребень";
			public override int LevelWhenAppears => 26;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sawmill.EdgedBoard(), 1),
				(new Workshop.Knife(), 1)
			};
		}

		public class Stool : ProducableItem
		{
			public override string Name => "Табуретка";
			public override int LevelWhenAppears => 29;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(120 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sawmill.UnedgedBoard(), 3),
				(new Workshop.Knife(), 2),
				(new Smelter.Resin(), 1)
			};
		}

		public class Paints : ProducableItem
		{
			public override string Name => "Краски";
			public override int LevelWhenAppears => 31;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Mill.Ocher(), 2),
				(new Mixer.BluePaint(), 1),
				(new Ash(), 1)
			};
		}

		public class Pipe : ProducableItem
		{
			public override string Name => "Труба";
			public override int LevelWhenAppears => 31;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new PalmLog(), 7),
				(new Poison(), 3)
			};
		}

		public class Tambourine : ProducableItem
		{
			public override string Name => "Бубен";
			public override int LevelWhenAppears => 39;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(360 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Tannery.Papyrus(), 2),
				(new Needle(), 3),
				(new Shell(), 20)
			};
		}

		public class Barrel : ProducableItem
		{
			public override string Name => "Бочка";
			public override int LevelWhenAppears => 40;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(360 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sawmill.EdgedBoard(), 5),
				(new Smelter.Resin(), 2),
				(new Loom.Rope(), 3)
			};
		}

		public class WoodenBeam : ProducableItem
		{
			public override string Name => "Деревянная балка";
			public override int LevelWhenAppears => 46;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(45 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Smelter.Resin(), 5),
				(new Smelter.Nails(), 2),
				(new Knocker.PalmBeams(), 2)
			};
		}

		public class LeatherBall : ProducableItem
		{
			public override string Name => "Кожаный мяч";
			public override int LevelWhenAppears => 51;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(120 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Tannery.Papyrus(), 3),
				(new Knocker.PalmBeams(), 4)
			};
		}
	}
}
