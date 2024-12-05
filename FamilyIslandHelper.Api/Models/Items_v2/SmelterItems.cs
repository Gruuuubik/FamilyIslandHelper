using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Resin : ProducibleItem
	{
		public override string Name => "Смола";
		public override int LevelWhenAppears => 17;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(16);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 9),
				(new Stick(), 15)
			};
	}

	public class IronIngot : ProducibleItem
	{
		public override string Name => "Железный слиток";
		public override int LevelWhenAppears => 20;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(24);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 15),
				(new Wood(), 15),
				(new Stone(), 12)
			};
	}

	public class Coal : ProducibleItem
	{
		public override string Name => "Уголь";
		public override int LevelWhenAppears => 22;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new Smelter();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Wood(), 15),
				(new Stick(), 18)
			};
	}
}
