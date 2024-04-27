using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System.Collections.Generic;
using System;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Lace : ProducibleItem
	{
		public override string Name => "Шнурок";
		public override int LevelWhenAppears => 2;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromSeconds(150);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Grass(), 2)
			};
	}

	public class Wattle : ProducibleItem
	{
		public override string Name => "Плетень";
		public override int LevelWhenAppears => 4;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(6);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stick(), 3),
				(new Lace(), 1)
			};
	}

	public class Rope : ProducibleItem
	{
		public override string Name => "Верёвка";
		public override int LevelWhenAppears => 15;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Lace(), 3),
				(new Needle(), 1)
			};
	}

	public class Gloves : ProducibleItem
	{
		public override string Name => "Перчатки";
		public override int LevelWhenAppears => 15;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Skin(), 2)
			};
	}

	public class Sackcloth : ProducibleItem
	{
		public override string Name => "Мешковина";
		public override int LevelWhenAppears => 26;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cotton(), 5),
				(new Crest(), 1)
			};
	}

	public class Cloth : ProducibleItem
	{
		public override string Name => "Ткань";
		public override int LevelWhenAppears => 38;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sackcloth(), 2),
				(new BluePaint(), 1)
			};
	}

	public class Necklace : ProducibleItem
	{
		public override string Name => "Ожерелье";
		public override int LevelWhenAppears => 42;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Amber(), 5),
				(new Emerald(), 3),
				(new Needle(), 1)
			};
	}

	public class PicnicBasket : ProducibleItem
	{
		public override string Name => "Корзинка для пикника";
		public override int LevelWhenAppears => 57;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new WickerBasket(), 1),
				(new Wheat(), 24),
				(new Pepper(), 12)
			};
	}

	public class WickerBasket : ProducibleItem
	{
		public override string Name => "Плетеная корзинка";
		public override int LevelWhenAppears => 57;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wattle(), 3),
				(new Stick(), 4),
				(new Rope(), 5)
			};
	}

	public class DreamCatcher : ProducibleItem
	{
		public override string Name => "Ловец снов";
		public override int LevelWhenAppears => 59;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(2);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Feather(), 10),
				(new Amber(), 4),
				(new Needle(), 1)
			};
	}

	public class DyedFabric : ProducibleItem
	{
		public override string Name => "Окрашенная ткань";
		public override int LevelWhenAppears => 61;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(4);
		public override Building BuildingToCreate => new Loom();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cloth(), 2),
				(new Paints(), 1)
			};
	}
}