using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FamilyIslandHelper.Api.UnitTests")]

namespace FamilyIslandHelper.Api.Models.Abstract
{
	public abstract class ProducibleItem : Item
	{
		public abstract List<(Item item, int count)> Components { get; }

		public abstract int LevelWhenAppears { get; }

		public abstract Building BuildingToCreate { get; }

		public int ProduceEnergyCost
		{
			get
			{
				var totalEnergyCost = 0;

				foreach (var (item, count) in Components)
				{
					if (item is ProducibleItem producibleItem)
					{
						totalEnergyCost += producibleItem.ProduceEnergyCost * count;
					}
					else if (item is ResourceItem resourceItem)
					{
						totalEnergyCost += resourceItem.EnergyCost * count;
					}
				}

				return totalEnergyCost;
			}
		}

		public List<string> ComponentsInfo(int tabsCount, int itemCount)
		{
			var componentsInfo = new List<string>();
			var tabs = new string('\t', tabsCount + 1);

			foreach (var (item, count) in Components)
			{
				componentsInfo.Add($"{tabs}{item.ToString(itemCount)} - {count * itemCount} шт.");

				if (item is ProducibleItem producibleItem)
				{
					componentsInfo.AddRange(producibleItem.ComponentsInfo(tabsCount + 1, itemCount * count));
				}
			}

			return componentsInfo;
		}

		public override string ToString(int itemCount)
		{
			return $"{Name}({ProduceEnergyCost * itemCount} энергии)";
		}

		public override string ToString()
		{
			return $"{Name}({ProduceEnergyCost} энергии)";
		}
	}
}
