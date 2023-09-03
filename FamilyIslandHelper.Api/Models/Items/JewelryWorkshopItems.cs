using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Items
{
	public class SapphireBracelet : ProducibleItem
	{
		public override string Name => "Сапфировый браслет";
		public override int LevelWhenAppears => 37;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(75);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Sapphire(), 1),
				(new Silverine(), 2),
				(new Cloth(), 1),
			};
	}

	public class GemNecklace : ProducibleItem
	{
		public override string Name => "Самоцветное ожерелье";
		public override int LevelWhenAppears => 39;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(75);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Gem(), 3),
				(new Lace(), 2),
				(new Claw(), 3)
			};
	}

	public class AmethystPendant : ProducibleItem
	{
		public override string Name => "Аметистовый кулон";
		public override int LevelWhenAppears => 38;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromHours(1);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Amethyst(), 9),
				(new Lace(), 4),
				(new Silverine(), 9)
			};
	}

	public class EmeraldRing : ProducibleItem
	{
		public override string Name => "Изумрудное кольцо";
		public override int LevelWhenAppears => 37;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(75);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Silverine(), 3),
				(new Emerald(), 2)
			};
	}

	public class PearlEarrings : ProducibleItem
	{
		public override string Name => "Жемчужные сережки";
		public override int LevelWhenAppears => 20;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(75);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
			{
				(new Pearl(), 3),
				(new Gold(), 2)
			};
	}

	public class CrystalLotus : ProducibleItem
	{
		public override string Name => "Хрустальный лотос";
		public override int LevelWhenAppears => 63;
		public override TimeSpan OriginalProduceTime => TimeSpan.FromMinutes(1);
		public override Building BuildingToCreate => new JewelryWorkshop();

		public override List<(Item item, int count)> Components => new List<(Item item, int count)>
		{
			(new Amethyst(), 1),
			(new Sapphire(), 1),
			(new Gold(), 1)
		};
	}
}
