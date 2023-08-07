using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FamilyIslandHelper.Api
{
	public static class ItemHelper
	{
		private static string MainNamespace = "FamilyIslandHelper.Api";

		public static string GetItemNameByPath(string itemPath)
		{
			return itemPath.Split('.').First().Split('\\').Last();
		}

		public static List<BuildingInfo> GetBuildingsClasses()
		{
			var buildingsClasses = GetClasses($"{MainNamespace}.Models.Buildings", true).ToList();

			return buildingsClasses.Select(bc => new BuildingInfo { Value = bc.Name, Name = bc.GetFields()[0].GetValue(null).ToString() }).ToList();
		}

		public static ProducableItem CreateProducableItem(string buildingName, string itemTypeString)
		{
			var buildingType = Type.GetType($"{MainNamespace}.Models.Buildings.{buildingName}", true);
			var itemType = buildingType.GetNestedType(itemTypeString);

			return Activator.CreateInstance(itemType) as ProducableItem;
		}

		public static Item CreateResourceItem(string itemTypeString)
		{
			var resourcesClasses = GetClasses($"{MainNamespace}.Models", false);

			var resourceItemType = resourcesClasses.FirstOrDefault(rc => rc.Name == itemTypeString);

			return Activator.CreateInstance(resourceItemType) as ResourceItem;
		}

		public static IEnumerable<Type> GetClasses(string nameSpace, bool isStatic)
		{
			var assemblyName = string.Join(".", nameSpace.Split('.').Take(2));
			var assembly = Assembly.Load(assemblyName);

			return assembly.GetTypes()
				.Where(type => type.Namespace == nameSpace && (!isStatic || (type.IsAbstract && type.IsSealed)));
		}

		public static IEnumerable<string> GetClassesNames(string nameSpace, bool isStatic)
		{
			return GetClasses(nameSpace, isStatic).Select(type => type.Name);
		}

		public static Item FindItemByName(string itemName)
		{
			Item item = null;
			var buildingsClasses = GetClasses($"{MainNamespace}.Models.Buildings", true);

			foreach (var buildingClass in buildingsClasses)
			{
				var itemType = buildingClass.GetNestedTypes().Where(t => t.IsClass && t.Name == itemName).FirstOrDefault();

				if (itemType != null)
				{
					item = CreateProducableItem(buildingClass.Name, itemType.Name);
					break;
				}
			}

			if (item == null)
			{
				item = CreateResourceItem(itemName);
			}

			return item;
		}

		public static IEnumerable<string> GetItemsOfBuilding(string buildingName)
		{
			var buildingType = Type.GetType($"{MainNamespace}.Models.Buildings.{buildingName}", true);
			var itemsNames = buildingType.GetNestedTypes().Where(t => t.IsClass).Select(t => t.Name).OrderBy(i => i);

			return itemsNames;
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
			else if (item1 is ProducableItem producableItem1)
			{
				cost1 = producableItem1.ProduceEnergyCost;
				time1 = producableItem1.TotalProduceTime;
			}

			if (item2 is ResourceItem resourceItem2)
			{
				cost2 = resourceItem2.EnergyCost;
			}
			else if (item2 is ProducableItem producableItem2)
			{
				cost2 = producableItem2.ProduceEnergyCost;
				time2 = producableItem2.TotalProduceTime;
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
