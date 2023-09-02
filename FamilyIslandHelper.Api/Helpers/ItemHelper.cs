using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Linq;

namespace FamilyIslandHelper.Api.Helpers
{
	public static class ItemHelper
	{
		private const string MainNamespace = "FamilyIslandHelper.Api";
		private static readonly string ItemsNamespace = $"{MainNamespace}.Models.Items";

		public static string GetItemNameByPath(string itemPath)
		{
			return itemPath.Split('.').First().Split('\\').Last();
		}

		public static ProducibleItem CreateProducibleItem(string itemTypeString)
		{
			var itemType = Type.GetType($"{ItemsNamespace}.{itemTypeString}", true);

			return Activator.CreateInstance(itemType) as ProducibleItem;
		}

		public static ResourceItem CreateResourceItem(string itemTypeString)
		{
			var resourceItemType = Type.GetType($"{MainNamespace}.Models.{itemTypeString}", true);

			return Activator.CreateInstance(resourceItemType) as ResourceItem;
		}

		public static Item FindItemByName(string itemName)
		{
			var itemType = ClassHelper.GetClasses(ItemsNamespace).FirstOrDefault(t => t.Name == itemName);

			if (itemType != null)
			{
				return CreateProducibleItem(itemType.Name);
			}

			itemType = ClassHelper.GetClasses($"{MainNamespace}.Models").FirstOrDefault(t => t.Name == itemName);

			if (itemType != null)
			{
				return CreateResourceItem(itemType.Name);
			}

			return null;
		}

		public static string CompareItems(Item item1, Item item2)
		{
			return CompareItems(item1, 1, item2, 1);
		}

		public static string CompareItems(Item item1, int count1, Item item2, int count2)
		{
			var cost1 = 0;
			var cost2 = 0;

			var time1 = TimeSpan.Zero;
			var time2 = TimeSpan.Zero;

			if (item1 is ResourceItem resourceItem1)
			{
				cost1 = resourceItem1.EnergyCost;
			}
			else if (item1 is ProducibleItem producibleItem1)
			{
				cost1 = producibleItem1.ProduceEnergyCost;
				time1 = producibleItem1.TotalProduceTime;
			}

			if (item2 is ResourceItem resourceItem2)
			{
				cost2 = resourceItem2.EnergyCost;
			}
			else if (item2 is ProducibleItem producibleItem2)
			{
				cost2 = producibleItem2.ProduceEnergyCost;
				time2 = producibleItem2.TotalProduceTime;
			}

			cost1 *= count1;
			cost2 *= count2;
			time1 = TimeSpan.FromTicks(time1.Ticks * count1);
			time2 = TimeSpan.FromTicks(time2.Ticks * count2);

			string result;

			if (cost1 < cost2)
			{
				result = $"{count1} '{item1.Name}' выгоднее, чем {count2} '{item2.Name}' по энергии.";
			}
			else if (cost1 > cost2)
			{
				result = $"{count2} '{item2.Name}' выгоднее, чем {count1} '{item1.Name}' по энергии.";
			}
			else
			{
				result = $"{count1} '{item1.Name}' и {count2} '{item2.Name}' равны по энергии.";

				if (time1 < time2)
				{
					result += $" {count1} '{item1.Name}' выгоднее, чем {count2} '{item2.Name}' по времени производства.";
				}
				else if (time1 > time2)
				{
					result += $" {count2} '{item2.Name}' выгоднее, чем {count1} '{item1.Name}' по времени производства.";
				}
				else
				{
					result += $" {count1} '{item1.Name}' и {count2} '{item2.Name}' равны по времени производства.";
				}
			}

			return result;
		}
	}
}
