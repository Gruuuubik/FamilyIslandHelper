using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class Soap : ProducibleItem
	{
		public override string Name => "Мыло";
		public override int LevelWhenAppears => 19;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(25);
		public override Building BuildingToCreate => new Mixer();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Clay(), 15),
			(new Egg(), 2)
		};
	}

	public class Butter : ProducibleItem
	{
		public override string Name => "Масло";
		public override int LevelWhenAppears => 21;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(60);
		public override Building BuildingToCreate => new Mixer();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Milk(), 3)
		};
	}
}