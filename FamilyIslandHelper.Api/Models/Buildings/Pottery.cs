﻿using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Pottery : Building
	{
		public override string Name => "Гончарная";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Bowl(),
			new Pot(),
			new Jug(),
			new Amphora(),
			new Flashlight()
		};
	}
}