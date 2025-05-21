using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Gold : ProducibleItem
	{
		public override string Name => "Золото";
		public override int LevelWhenAppears => 22;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(40);
		public override Building BuildingToCreate => new AlchemistLaboratory();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 25),
				(new Clay(), 10),
				(new Wood(), 10)
			};
	}

	public class Emerald : ProducibleItem
	{
		public override string Name => "Изумруд";
		public override int LevelWhenAppears => 79;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(40);
		public override Building BuildingToCreate => new AlchemistLaboratory();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Iron(), 10),
				(new Stone(), 12),
				(new Wood(), 6)
			};
	}
}
