using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Items;
using Xunit;

namespace FamilyIslandHelper.Api.Net6.UnitTests
{
	public class ItemHelperTests : BaseTest
	{
		private const string FolderWithPictures = "Pictures";

		[Theory]
		[InlineData(new[] { "Pictures", "CarpentryWorkshop", "Barrel.png" }, "Barrel")]
		public void When_GetItemNameByPath_Then_ReturnCorrectItemName(string[] itemPath, string expectedIteName)
		{
			var actualItemName = ItemHelper.GetItemNameByPath(Path.Combine(itemPath));

			Assert.Equal(expectedIteName, actualItemName);
		}

		[Theory]
		[InlineData("itemName")]
		public void When_FindItemByNameWithNullParameter_Then_ThrowsException(string expectedParamName)
		{
			var exception = Assert.Throws<ArgumentNullException>(() => ItemHelper.FindItemByName(null));

			Assert.Equal(expectedParamName, exception.ParamName);
		}

		[Theory]
		[InlineData("Lace", typeof(Lace))]
		[InlineData("Cone", typeof(Cone))]
		public void When_FindItemByName_Then_ReturnCorrectItem(string itemName, Type expectedItemType)
		{
			var actualItem = ItemHelper.FindItemByName(itemName);

			Assert.Equal(expectedItemType, actualItem.GetType());
		}

		[Theory]
		[InlineData("Cone123", null)]
		public void When_FindItemByNameForNotExistedItem_Then_ReturnNull(string itemName, Item expectedItem)
		{
			var actualItem = ItemHelper.FindItemByName(itemName);

			Assert.Equal(expectedItem, actualItem);
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

		public static IEnumerable<object[]> CompareItemsWithDifferentCount_TestData()
		{
			yield return new object[] { new Lace(), 2, new Lace(), 2,
				"2 'Шнурок' и 2 'Шнурок' равны по энергии. 2 'Шнурок' и 2 'Шнурок' равны по времени производства." };

			yield return new object[] { new Rope(), 5, new Wattle(), 3,
				"3 'Плетень' выгоднее, чем 5 'Верёвка' по энергии." };

			yield return new object[] { new Stone(), 5, new Grass(), 3,
				"3 'Трава' выгоднее, чем 5 'Камень' по энергии." };

			yield return new object[] { new Scraper(), 1, new Lace(), 5,
				"1 'Скребок' и 5 'Шнурок' равны по энергии. 1 'Скребок' выгоднее, чем 5 'Шнурок' по времени производства." };

			yield return new object[] { new Lace(), 5, new Scraper(), 1,
				"5 'Шнурок' и 1 'Скребок' равны по энергии. 1 'Скребок' выгоднее, чем 5 'Шнурок' по времени производства." };
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

		public static IEnumerable<object[]> GetInfoAboutItem_TestData()
		{
			yield return new object[] { "Lace", 1, false,
				new List<string>
				{
					"Шнурок(00:01:40, 4 энергии)",
					"",
					"Итого времени на производство: 00:01:40"
				}
			};

			yield return new object[] { "Lace", 1, true,
				new List<string>
				{
					"Шнурок(00:01:40, 4 энергии)",
					"",
					"Components:", "\tТрава(2 энергии) - 2 шт.",
					"",
					"Итого времени на производство: 00:01:40"
				}
			};
		}

		[Theory]
		[MemberData(nameof(GetInfoAboutItem_TestData))]
		public void When_GetInfoAboutItem_Then_ReturnCorrectValue(string itemName, int itemCount, bool showListOfComponents, List<string> expectedInfo)
		{
			var actualInfo = ItemHelper.GetInfoAboutItem(itemName, itemCount, showListOfComponents);

			Assert.Equal(expectedInfo, actualInfo);
		}
	}
}
