using FamilyIslandHelper.Models;
using System;

namespace FamilyIslandHelper
{
	public static class ItemCreator
	{
		public static Item CreateItem(string buildingName, string itemTypeString)
		{
			var buildingType = Type.GetType($"FamilyIslandHelper.Models.Buildings.{buildingName}", true);
			var itemType = buildingType.GetNestedType(itemTypeString);

			return Activator.CreateInstance(itemType) as Item;
		}
	}
}
