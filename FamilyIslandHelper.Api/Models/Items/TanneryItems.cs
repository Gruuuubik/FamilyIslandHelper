using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class Leather : ProducibleItem
	{
		public override string Name => "Кожа";
		public override int LevelWhenAppears => 24;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Skin(), 2),
			(new Ocher(), 1)
		};
	}

	public class Papyrus : ProducibleItem
	{
		public override string Name => "Папирус";
		public override int LevelWhenAppears => 36;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(3);
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Leather(), 2),
			(new Ocher(), 1)
		};
	}

	public class WhitePaint : ProducibleItem
	{
		public override string Name => "Белая краска";
		public override int LevelWhenAppears => 44;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Limestone(), 6),
			(new SunflowerOil(), 3)
		};
	}
}
