using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FamilyIslandHelper.Api.Helpers
{
	public class ItemHelper : BaseHelper
	{
		private readonly string itemsNamespace;

		public ItemHelper(ApiVersion apiVersion) : base(apiVersion)
		{
			itemsNamespace = $"{MainNamespace}.Models.Items{Prefix}";

			FolderWithResourcesPictures = Path.Combine(FolderWithPictures, "Resources");
			FolderWithItemsPictures = Path.Combine(FolderWithPictures, "Items");
			ResourcesNamespace = $"{MainNamespace}.Models.Resources{Prefix}";
		}

		public string FolderWithResourcesPictures { get; }
		public string FolderWithItemsPictures { get; }
		public string ResourcesNamespace { get; }

		public ProducibleItem CreateProducibleItem(string itemTypeString)
		{
			var itemType = Type.GetType($"{itemsNamespace}.{itemTypeString}", true);

			return Activator.CreateInstance(itemType) as ProducibleItem;
		}

		public ResourceItem CreateResourceItem(string itemTypeString)
		{
			var resourceItemType = Type.GetType($"{ResourcesNamespace}.{itemTypeString}", true);

			return Activator.CreateInstance(resourceItemType) as ResourceItem;
		}

		public Item FindItemByName(string itemName)
		{
			if (itemName == null)
			{
				throw new ArgumentNullException(nameof(itemName));
			}

			var itemType = ClassHelper.GetClasses(itemsNamespace).FirstOrDefault(t => t.Name == itemName);

			if (itemType != null)
			{
				return CreateProducibleItem(itemType.Name);
			}

			itemType = ClassHelper.GetClasses(ResourcesNamespace).FirstOrDefault(t => t.Name == itemName);

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

		public List<string> GetInfoAboutItem(string itemName, int itemCount, bool showListOfComponents)
		{
			var info = new List<string>();

			var item = FindItemByName(itemName);

			info.Add(item.ToString(itemCount));

			if (item is ProducibleItem producibleItem)
			{
				if (showListOfComponents)
				{
					info.Add(string.Empty);
					info.Add("Components:");

					info.AddRange(producibleItem.ComponentsInfo(0, itemCount));
				}

				info.Add(string.Empty);
				info.Add("Итого времени на производство: " + TimeSpan.FromSeconds(producibleItem.TotalProduceTime.TotalSeconds * itemCount));
			}

			return info;
		}

		public string GetItemImagePathByName(string buildingName, string itemName)
		{
			return Path.Combine(FolderWithItemsPictures, buildingName, itemName + ImageExtension);
		}

		public List<string> GetResourcesNames()
		{
			return ClassHelper.GetClassesNames(ResourcesNamespace).ToList();
		}

		public string GetResourceImagePathByName(string resourceName)
		{
			return Path.Combine(FolderWithResourcesPictures, resourceName + ImageExtension);
		}
	}
}
