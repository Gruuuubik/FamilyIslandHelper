using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Items;
using System;
using System.Collections.Generic;
using Xunit;

namespace FamilyIslandHelper.Api.UnitTests
{
	public class ProducibleItemTests
	{
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
		public void Given_ProducibleItem_When_ToString_Then_ReturnCorrectValue(ProducibleItem producibleItem, int itemsCount, string expectedStringResult)
		{
			var actualStringResult = producibleItem.ToString(itemsCount);

			Assert.Equal(expectedStringResult, actualStringResult);
		}

		public static IEnumerable<object[]> GetProperties_TestData()
		{
			yield return new object[] { new CarpentryWorkshop().Items };
			yield return new object[] { new JewelryWorkshop().Items };
			yield return new object[] { new Knocker().Items };
			yield return new object[] { new Loom().Items };
			yield return new object[] { new MeteoriteForge().Items };
			yield return new object[] { new Mill().Items };
			yield return new object[] { new Mixer().Items };
			yield return new object[] { new Pottery().Items };
			yield return new object[] { new Sawmill().Items };
			yield return new object[] { new ShamanWorkshop().Items };
			yield return new object[] { new Smelter().Items };
			yield return new object[] { new Tannery().Items };
			yield return new object[] { new Workshop().Items };
		}

		[Theory]
		[MemberData(nameof(GetProperties_TestData))]
		public void Given_ProducibleItem_When_GetProperties_Then_ReturnNotNullValues(List<ProducibleItem> producibleItems)
		{
			Assert.All(producibleItems, (item) => Assert.NotNull(item.Name));
			Assert.All(producibleItems, (item) => Assert.InRange(item.LevelWhenAppears, 1, 100));
			Assert.All(producibleItems, (item) => Assert.InRange(item.OriginalProduceTime, TimeSpan.FromSeconds(1), TimeSpan.FromHours(20)));
			Assert.All(producibleItems, (item) => Assert.NotNull(item.BuildingToCreate));
			Assert.All(producibleItems, (item) => Assert.NotEmpty(item.Components));
		}
	}
}
