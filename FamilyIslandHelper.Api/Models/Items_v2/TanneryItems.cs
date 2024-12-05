using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Leather : ProducibleItem
	{
		public override string Name => "Кожа";
		public override int LevelWhenAppears => 24;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(20);
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Clay(), 12),
			(new Skin(), 2),
			(new Stakes(), 3)
		};
	}

	public class Papyrus : ProducibleItem
	{
		public override string Name => "Пергамент";
		public override int LevelWhenAppears => 36;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(70);
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Skin(), 5),
			(new Sackcloth(), 3),
			(new Soap(), 3)
		};
	}

	public class Cardboard : ProducibleItem
	{
		public override string Name => "Картон";
		public override int LevelWhenAppears => 40;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(112);
		public override Building BuildingToCreate => new Tannery();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Skin(), 6),
			(new IronPlate(), 2)
		};
	}
}
