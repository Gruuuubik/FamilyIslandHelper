using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FamilyIslandHelper
{
	public static class ItemHelper
	{
		public static ProducableItem CreateProducableItem(string buildingName, string itemTypeString)
		{
			var buildingType = Type.GetType($"FamilyIslandHelper.Models.Buildings.{buildingName}", true);
			var itemType = buildingType.GetNestedType(itemTypeString);

			return Activator.CreateInstance(itemType) as ProducableItem;
		}

		public static Item CreateResourceItem(string itemTypeString)
		{
			var resourcesClasses = GetClasses("FamilyIslandHelper.Models", false);

			var resourceItemType = resourcesClasses.FirstOrDefault(rc => rc.Name == itemTypeString);

			return Activator.CreateInstance(resourceItemType) as ResourceItem;
		}

		public static IEnumerable<Type> GetClasses(string nameSpace, bool isStatic)
		{
			var assemblyName = nameSpace.Split('.').First();
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
			var buildingsClasses = GetClasses("FamilyIslandHelper.Models.Buildings", true);

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
			var buildingType = Type.GetType($"FamilyIslandHelper.Models.Buildings.{buildingName}", true);
			var itemsNames = buildingType.GetNestedTypes().Where(t => t.IsClass).Select(t => t.Name).OrderBy(i => i);

			return itemsNames;
		}
	}
}
