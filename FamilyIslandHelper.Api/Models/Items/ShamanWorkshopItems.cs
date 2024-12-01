using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Resources;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class RuneStone : ProducibleItem
	{
		public override string Name => "Рунный камень";
		public override int LevelWhenAppears => 62;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(6);
		public override Building BuildingToCreate => new ShamanWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new StoneBlock(), 3),
				(new Knife(), 5),
				(new BluePaint(), 1),
			};
	}

	public class FlowerWreath : ProducibleItem
	{
		public override string Name => "Цветочный венок";
		public override int LevelWhenAppears => 64;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new ShamanWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Necklace(), 1),
				(new Heather(), 10),
				(new MeadowGrass(), 10),
			};
	}

	public class FragrantBouquet : ProducibleItem
	{
		public override string Name => "Душистый букет";
		public override int LevelWhenAppears => 66;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(30);
		public override Building BuildingToCreate => new ShamanWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new MeadowGrass(), 10),
				(new Papyrus(), 1),
				(new LotusFlower(), 10),
			};
	}
}