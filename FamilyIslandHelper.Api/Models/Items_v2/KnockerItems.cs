using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings_v2;
using FamilyIslandHelper.Api.Models.Resources_v2;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items_v2
{
	public class StoneBlock : ProducibleItem
	{
		public override string Name => "Каменный блок";
		public override int LevelWhenAppears => 30;
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 15),
				(new Iron(), 15),
				(new Wood(), 15)
			};
	}

	public class StoneTile : ProducibleItem
	{
		public override string Name => "Каменная плитка";
		public override int LevelWhenAppears => 70;
		public override Building BuildingToCreate => new Knocker();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Stone(), 20),
				(new Nails(), 3),
				(new Stick(), 15)
			};
	}
}