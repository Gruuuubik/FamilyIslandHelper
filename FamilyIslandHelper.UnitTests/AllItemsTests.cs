using FamilyIslandHelper.Models;
using FamilyIslandHelper.Models.Buildings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace FamilyIslandHelper.UnitTests
{
	public class AllItemsTests
	{
		private const string folderWithPictures = "Pictures";
		private const string relativePathToBuildings = "FamilyIslandHelper.Models.Buildings";

		[Fact]
		public void When_GetAllBuildingsNames_Then_AllBuildingsHaveFolders()
		{
			var actualBuildingsNames = ItemHelper.GetClassesNames(relativePathToBuildings, true);

			var buildingsDirectories = Directory.GetDirectories(folderWithPictures);
			var expectedBuildingsNames = buildingsDirectories.Select(b => b.Split('\\').Last());

			Assert.Equal(expectedBuildingsNames, actualBuildingsNames);
		}

		[Theory]
		[InlineData("Lace", typeof(Loom.Lace))]
		public void When_FindItemByName_Then_ReturnCorrectItem(string itemName, Type expectedItemType)
		{
			var actualItem = ItemHelper.FindItemByName(itemName);

			Assert.Equal(expectedItemType, actualItem.GetType());
		}

		[Fact]
		public void When_GetAllResources_Then_AllResourcesHaveImages()
		{
			var actualResourcesNames = ItemHelper.GetClassesNames("FamilyIslandHelper.Models", false)
				.Where(n => n != "BuildingInfo" && n != "GlobalSettings").OrderBy(i => i);

			var resourcesPathes = Directory.GetFiles("Resources");
			var expectedResourcesNames = resourcesPathes.Select(r => r.Split('.').First().Split('\\').Last()).OrderBy(i => i);

			Assert.Equal(expectedResourcesNames, actualResourcesNames);
		}

		public static IEnumerable<object[]> BuildingsClassesProvider
		{
			get
			{
				var buildingsClasses = ItemHelper.GetClasses(relativePathToBuildings, true);

				return buildingsClasses.Select(b => new object[] { b });
			}
		}

		[Theory]
		[MemberData(nameof(BuildingsClassesProvider))]
		public void When_GetAllTemsNames_Then_AllItemsHavePictures(Type buildingClass)
		{
			var expectedItemsNames = buildingClass.GetNestedTypes().Where(t => t.IsClass).Select(t => t.Name).OrderBy(i => i);

			var itemsPathes = Directory.GetFiles($"{folderWithPictures}\\{buildingClass.Name}");
			var actualItemsNames = itemsPathes.Select(ip => ip.Split('.').First().Split('\\').Last()).OrderBy(i => i);

			Assert.Equal(expectedItemsNames, actualItemsNames);
		}

		[Theory]
		[InlineData("Loom", "Lace", typeof(Loom.Lace))]
		public void When_TryToCreateProducableItem_Then_ReturnCorrectProducableItem(string buildingName, string itemTypeString, Type expectedItemType)
		{
			var item = ItemHelper.CreateProducableItem(buildingName, itemTypeString);

			Assert.Equal(expectedItemType, item.GetType());
		}

		[Theory]
		[InlineData("Stone", typeof(Stone))]
		public void When_TryToCreateResourceItem_Then_ReturnCorrectResourceItem(string itemTypeString, Type expectedItemType)
		{
			var item = ItemHelper.CreateResourceItem(itemTypeString);

			Assert.Equal(expectedItemType, item.GetType());
		}

		[Theory]
		[InlineData("Mill", new[] { "ChickenFood", "CowFood", "Flour", "GoatFood", "Ocher", "SunflowerOil", "Syrup" })]
		public void When_TryToGetItemsOfBuulding_Then_ReturnCorrectItems(string buildingName, IEnumerable<string> expectedItems)
		{
			var actualItems = ItemHelper.GetItemsOfBuilding(buildingName);

			Assert.Equal(expectedItems, actualItems);
		}
	}
}
