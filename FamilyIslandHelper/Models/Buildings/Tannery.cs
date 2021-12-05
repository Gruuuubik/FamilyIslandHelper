using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Buildings
{
	public static class Tannery
	{
		public static string Name = "Кожевенная";

		public class Leather : ProducableItem
		{
			public override string Name => "Кожа";
			public override int LevelWhenAppears => 24;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(60 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Skin(), 2),
				(new Mill.Ocher(), 1)
			};
		}

		public class Papyrus : ProducableItem
		{
			public override string Name => "Папирус";
			public override int LevelWhenAppears => 36;
			public override TimeSpan ProduceTime => TimeSpan.FromMinutes(180 / GlobalSettings.ProduceRatio);

			public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Leather(),2),
				(new Mill.Ocher(), 1)
			};
		}
	}
}
