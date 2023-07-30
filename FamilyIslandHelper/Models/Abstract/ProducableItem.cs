using System;
using System.Collections.Generic;

namespace FamilyIslandHelper.Models.Abstract
{
	public abstract class ProducableItem : Item
	{
		public abstract TimeSpan ProduceTime { get; }

		public abstract List<(Item item, int count)> Components { get; }

		public abstract int LevelWhenAppears { get; }

		public TimeSpan TotalProduceTime
		{
			get
			{
				var totalProduceTime = ProduceTime;

				foreach (var (item, count) in Components)
				{
					if (item is ProducableItem)
					{
						var producableItem = item as ProducableItem;
						totalProduceTime += TimeSpan.FromSeconds(producableItem.TotalProduceTime.TotalSeconds * count);
					}
				}

				return totalProduceTime;

				//return Components.Any()
				//? TimeSpan.FromSeconds(Components.Sum(i => i. .ProduceTime.TotalSeconds))
				//: ProduceTime;

				//public Item GetComponent(Type type)
				//{
				//	return (Item) Components[type];
				//}
			}
		}

		public int ProduceEnergyCost
		{
			get
			{
				var totalEnergyCost = 0;

				foreach (var (item, count) in Components)
				{
					if (item is ProducableItem producableItem)
					{
						totalEnergyCost += producableItem.ProduceEnergyCost * count;
					}
					else if (item is ResourceItem resourceItem)
					{
						totalEnergyCost += resourceItem.EnergyCost * count;
					}
				}

				return totalEnergyCost;
			}
		}

		public List<string> ComponentsInfo(int tabsCount)
		{
			var componentsInfo = new List<string> { };
			var tabs = new string('\t', tabsCount + 1);

			foreach (var (item, count) in Components)
			{
				componentsInfo.Add($"{tabs}{item} - {count} шт.");

				if (item is ProducableItem)
				{
					var producableItem = item as ProducableItem;
					componentsInfo.AddRange(producableItem.ComponentsInfo(tabsCount + 1));
				}
			}

			return componentsInfo;
		}

		public override string ToString()
		{
			return $"{Name}({ProduceTime}, {ProduceEnergyCost} энергии)";
		}
	}
}
