﻿using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Buildings
{
	public class Sawmill : Building
	{
		public override string Name => "Лесопилка";
		public override double ProduceRatio => 1.5;
		public override List<ProducibleItem> Items => new List<ProducibleItem>
		{
			new Stakes(),
			new UnedgedBoard(),
			new EdgedBoard(),
			new Trough()
		};
	}
}