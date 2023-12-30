using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace FamilyIslandHelper.Api.UnitTests
{
	public class AllItemsTests
	{
		private const string FolderWithPictures = "Pictures";

		[Theory]
		[InlineData(13)]
		public void When_GetBuildingsClasses_Then_ReturnCorrectCollection(int expectedCount)
		{
			var actualBuildingsClasses = BuildingHelper.GetBuildingsClasses();

			Assert.Equal(expectedCount, actualBuildingsClasses.Count);
			Assert.All(actualBuildingsClasses, (bc) => Assert.NotNull(bc));
		}

		[Fact]
		public void When_GetAllBuildingsNames_Then_AllBuildingsHaveFolders()
		{
			var actualBuildingsNames = BuildingHelper.GetBuildingsNames();

			var buildingsDirectories = Directory.GetDirectories(FolderWithPictures);
			var expectedBuildingsNames = buildingsDirectories.Select(b => b.Split('\\').Last());

			Assert.Equal(expectedBuildingsNames, actualBuildingsNames);
		}

		[Theory]
		[InlineData("Lace", typeof(Lace))]
		[InlineData("Cone", typeof(Cone))]
		public void When_FindItemByName_Then_ReturnCorrectItem(string itemName, Type expectedItemType)
		{
			var actualItem = ItemHelper.FindItemByName(itemName);

			Assert.Equal(expectedItemType, actualItem.GetType());
		}

		[Fact]
		public void When_GetAllResources_Then_AllResourcesHaveImages()
		{
			var actualResourcesNames = ClassHelper.GetClassesNames("FamilyIslandHelper.Api.Models")
				.Where(n => n != nameof(BuildingInfo)).OrderBy(i => i);

			var resourcesPaths = Directory.GetFiles("Resources");
			var expectedResourcesNames = resourcesPaths.Select(r => r.Split('.').First().Split('\\').Last()).OrderBy(i => i);

			Assert.Equal(expectedResourcesNames, actualResourcesNames);
		}

		public static IEnumerable<object[]> GetAllItemsNames_TestData()
		{
			yield return new object[] { new Pottery().GetType(), new[] { "Amphora", "Bowl", "Flashlight", "Jug", "Pot" } };
		}

		[Theory]
		[MemberData(nameof(GetAllItemsNames_TestData))]
		public void When_GetAllItemsNames_Then_AllItemsHavePictures(Type buildingClass, IEnumerable<string> expectedItemsNames)
		{
			var itemsPaths = Directory.GetFiles($"{FolderWithPictures}\\{buildingClass.Name}");
			var actualItemsNames = itemsPaths.Select(ip => ip.Split('.').First().Split('\\').Last()).OrderBy(i => i);

			Assert.Equal(expectedItemsNames, actualItemsNames);
		}

		[Theory]
		[InlineData("Lace", typeof(Lace))]
		public void When_TryToCreateProducibleItem_Then_ReturnCorrectProducibleItem(string itemTypeString, Type expectedItemType)
		{
			var item = ItemHelper.CreateProducibleItem(itemTypeString);

			Assert.Equal(expectedItemType, item.GetType());
		}

		public static IEnumerable<object[]> GetProduceTime_TestData()
		{
			yield return new object[] { nameof(Sackcloth), TimeSpan.FromMinutes(40) };
		}

		[Theory]
		[MemberData(nameof(GetProduceTime_TestData))]
		public void When_GetProduceTime_Then_ReturnCorrectValue(string itemTypeString, TimeSpan expectedProduceTime)
		{
			var item = ItemHelper.CreateProducibleItem(itemTypeString);

			Assert.Equal(expectedProduceTime, item.ProduceTime);
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
		public void When_TryToGetItemsOfBuilding_Then_ReturnCorrectItems(string buildingName, IEnumerable<string> expectedItems)
		{
			var actualItems = BuildingHelper.GetItemsOfBuilding(buildingName);

			Assert.Equal(expectedItems, actualItems);
		}

		public static IEnumerable<object[]> CompareItemsWithDifferentCount_TestData()
		{
			yield return new object[] { new Lace(), 2, new Lace(), 2,
				"2 'Шнурок' и 2 'Шнурок' равны по энергии. 2 'Шнурок' и 2 'Шнурок' равны по времени производства." };

			yield return new object[] { new Rope(), 5, new Wattle(), 3,
				"3 'Плетень' выгоднее, чем 5 'Верёвка' по энергии." };
		}

		[Theory]
		[MemberData(nameof(CompareItemsWithDifferentCount_TestData))]
		public void When_Compare2ItemsWithDifferentCount_Then_ReturnCorrectValue(Item item1, int count1, Item item2, int count2, string expectedMessage)
		{
			var actualMessage = ItemHelper.CompareItems(item1, count1, item2, count2);

			Assert.Equal(expectedMessage, actualMessage);
		}

		public static IEnumerable<object[]> CompareItems_TestData()
		{
			yield return new object[] { new Lace(), new Lace(),
				"1 'Шнурок' и 1 'Шнурок' равны по энергии. 1 'Шнурок' и 1 'Шнурок' равны по времени производства." };

			yield return new object[] { new Rope(), new Wattle(),
				"1 'Верёвка' выгоднее, чем 1 'Плетень' по энергии." };
		}

		[Theory]
		[MemberData(nameof(CompareItems_TestData))]
		public void When_Compare2Items_Then_ReturnCorrectValue(Item item1, Item item2, string expectedMessage)
		{
			var actualMessage = ItemHelper.CompareItems(item1, item2);

			Assert.Equal(expectedMessage, actualMessage);
		}

		public static IEnumerable<object[]> TotalProduceTime_TestData()
		{
			yield return new object[] { new Rope(), TimeSpan.FromSeconds(2360) };
		}

		[Theory]
		[MemberData(nameof(TotalProduceTime_TestData))]
		public void Given_ProducibleItem_When_GetTotalProduceTime_Then_ReturnCorrectValue(ProducibleItem producibleItem1, TimeSpan expectedTotalProduceTime)
		{
			var actualTotalProduceTime = producibleItem1.TotalProduceTime;

			Assert.Equal(expectedTotalProduceTime, actualTotalProduceTime);
		}

		public static IEnumerable<object[]> ComponentsInfo_TestData()
		{
			yield return new object[] { new Rope(), 1, new List<string>
			{
				"\tШнурок(00:01:40, 4 энергии) - 3 шт.",
				"\t\tТрава(6 энергии) - 6 шт.",
				"\tИгла(00:10:00, 24 энергии) - 1 шт.",
				"\t\tКоготь - 1 шт.",
				"\t\tСкребок(00:02:40, 20 энергии) - 1 шт.",
				"\t\t\tКамень(10 энергии) - 2 шт.",
				"\t\tШнурок(00:01:40, 4 энергии) - 1 шт.",
				"\t\t\tТрава(2 энергии) - 2 шт."
			} };
			yield return new object[] { new Rope(), 3, new List<string>
			{
				"\tШнурок(00:05:00, 12 энергии) - 9 шт.",
				"\t\tТрава(18 энергии) - 18 шт.",
				"\tИгла(00:30:00, 72 энергии) - 3 шт.",
				"\t\tКоготь - 3 шт.",
				"\t\tСкребок(00:08:00, 60 энергии) - 3 шт.",
				"\t\t\tКамень(30 энергии) - 6 шт.",
				"\t\tШнурок(00:05:00, 12 энергии) - 3 шт.",
				"\t\t\tТрава(6 энергии) - 6 шт."
			} };
		}

		[Theory]
		[MemberData(nameof(ComponentsInfo_TestData))]
		public void Given_ProducibleItem_When_GetComponentsInfo_Then_ReturnCorrectValue(ProducibleItem producibleItem, int itemsCount, List<string> expectedComponentsInfo)
		{
			var actualTotalProduceTime = producibleItem.ComponentsInfo(0, itemsCount);

			Assert.Equal(expectedComponentsInfo, actualTotalProduceTime);
		}

		public static IEnumerable<object[]> ToString_TestData()
		{
			yield return new object[] { new Rope(), 1, "Верёвка(00:20:00, 36 энергии)" };
			yield return new object[] { new Rope(), 3, "Верёвка(01:00:00, 108 энергии)" };
		}

		[Theory]
		[MemberData(nameof(ToString_TestData))]
		public void Given_ProducibleItem_When_ToString_Then_ReturnCorrectValue(ProducibleItem producibleItem1, int itemsCount, string expectedStringResult)
		{
			var actualStringResult = producibleItem1.ToString(itemsCount);

			Assert.Equal(expectedStringResult, actualStringResult);
		}
	}
}
