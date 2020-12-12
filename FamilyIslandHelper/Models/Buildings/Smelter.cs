﻿using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Smelter
	{
		public static string Name = "Плавильня";

		public class Resin : ProducableItem
		{
			public override string Name => "Смола";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(15);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Cone(), 3),
				(new Wood(), 2)
			};
		}

		public class Coal : ProducableItem
		{
			public override string Name => "Уголь";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(30);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 3),
				(new Stick(), 3)
			};
		}

		public class Gold : ProducableItem
		{
			public override string Name => "Золото";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new GoldOre(), 5),
				(new Coal(), 1)
			};
		}

		public class Shingles : ProducableItem
		{
			public override string Name => "Черепица";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(120);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sawmill.EdgedBoard(), 1),
				(new Clay(), 5),
				(new Coal(), 1)
			};
		}

		public class Nails : ProducableItem
		{
			public override string Name => "Гвозди";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new CopperOre(), 7),
				(new Workshop.Axe(), 1),
				(new Poison(), 1)
			};
		}

		public class BurntBrick : ProducableItem
		{
			public override string Name => "Обоженый кирпич";
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Coal(), 1),
				(new Workshop.Brick(), 3)
			};
		}
	}
}
