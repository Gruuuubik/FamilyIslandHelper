using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Resources;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Needle : ProducibleItem
	{
		public override string Name => "Игла";
		public override int LevelWhenAppears => 14;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(15);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Claw(), 1),
				(new Scraper(), 1),
				(new Lace(), 1)
			};
	}

	public class Stairs : ProducibleItem
	{
		public override string Name => "Лестница";
		public override int LevelWhenAppears => 20;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stick(), 10),
				(new Rope(), 2)
			};
	}

	public class Crest : ProducibleItem
	{
		public override string Name => "Гребень";
		public override int LevelWhenAppears => 26;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new EdgedBoard(), 1),
				(new Knife(), 1)
			};
	}

	public class Stool : ProducibleItem
	{
		public override string Name => "Табуретка";
		public override int LevelWhenAppears => 29;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new UnedgedBoard(), 3),
				(new Knife(), 2),
				(new Resin(), 1)
			};
	}

	public class Paints : ProducibleItem
	{
		public override string Name => "Краски";
		public override int LevelWhenAppears => 31;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Ocher(), 2),
				(new BluePaint(), 1),
				(new Ash(), 1)
			};
	}

	public class Pipe : ProducibleItem
	{
		public override string Name => "Труба";
		public override int LevelWhenAppears => 31;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new PalmLog(), 7),
				(new Poison(), 3)
			};
	}

	public class Tambourine : ProducibleItem
	{
		public override string Name => "Бубен";
		public override int LevelWhenAppears => 39;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(6);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Papyrus(), 2),
				(new Needle(), 3),
				(new Shell(), 20)
			};
	}

	public class Barrel : ProducibleItem
	{
		public override string Name => "Бочка";
		public override int LevelWhenAppears => 40;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(6);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new EdgedBoard(), 5),
				(new Resin(), 2),
				(new Rope(), 3)
			};
	}

	public class WoodenBeam : ProducibleItem
	{
		public override string Name => "Деревянная балка";
		public override int LevelWhenAppears => 46;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(45);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Resin(), 5),
				(new Nails(), 2),
				(new PalmBeams(), 2)
			};
	}

	public class LeatherBall : ProducibleItem
	{
		public override string Name => "Кожаный мяч";
		public override int LevelWhenAppears => 51;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Papyrus(), 3),
				(new PalmBeams(), 4)
			};
	}

	public class Incense : ProducibleItem
	{
		public override string Name => "Благовония";
		public override int LevelWhenAppears => 60;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new CarpentryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new LemonOil(), 2),
				(new Stick(), 30),
				(new Sackcloth(), 3)
			};
	}
}