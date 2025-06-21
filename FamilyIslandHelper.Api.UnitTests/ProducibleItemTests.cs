using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Api.Models.Buildings;
using FamilyIslandHelper.Api.Models.Items;
using Xunit;

namespace FamilyIslandHelper.Api.UnitTests
{
	public class ProducibleItemTests : BaseTest
	{
		public static IEnumerable<object[]> ComponentsInfo_TestData()
		{
			yield return new object[] { new Rope(), 1, new List<string>
			{
				"\tШнурок(4 энергии) - 3 шт.",
				"\t\tТрава(6 энергии) - 6 шт.",
				"\tИгла(24 энергии) - 1 шт.",
				"\t\tКоготь - 1 шт.",
				"\t\tСкребок(20 энергии) - 1 шт.",
				"\t\t\tКамень(10 энергии) - 2 шт.",
				"\t\tШнурок(4 энергии) - 1 шт.",
				"\t\t\tТрава(2 энергии) - 2 шт."
			} };
			yield return new object[] { new Rope(), 3, new List<string>
			{
				"\tШнурок(12 энергии) - 9 шт.",
				"\t\tТрава(18 энергии) - 18 шт.",
				"\tИгла(72 энергии) - 3 шт.",
				"\t\tКоготь - 3 шт.",
				"\t\tСкребок(60 энергии) - 3 шт.",
				"\t\t\tКамень(30 энергии) - 6 шт.",
				"\t\tШнурок(12 энергии) - 3 шт.",
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
			yield return new object[] { new Rope(), 1, "Верёвка(36 энергии)" };
			yield return new object[] { new Rope(), 3, "Верёвка(108 энергии)" };
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

			yield return new object[] { new Models.Buildings_v2.AlchemistLaboratory().Items };
			yield return new object[] { new Models.Buildings_v2.Bench().Items };
			yield return new object[] { new Models.Buildings_v2.CarpentryWorkshop().Items };
			yield return new object[] { new Models.Buildings_v2.Forge().Items };
			yield return new object[] { new Models.Buildings_v2.GlassWorkshop().Items };
			yield return new object[] { new Models.Buildings_v2.HobbyCorner().Items };
			yield return new object[] { new Models.Buildings_v2.JewelryWorkshop().Items };
			yield return new object[] { new Models.Buildings_v2.Kiln().Items };
			yield return new object[] { new Models.Buildings_v2.Knocker().Items };
			yield return new object[] { new Models.Buildings_v2.Loom().Items };
			yield return new object[] { new Models.Buildings_v2.MeteoriteForge().Items };
			yield return new object[] { new Models.Buildings_v2.Mill().Items };
			yield return new object[] { new Models.Buildings_v2.Mixer().Items };
			yield return new object[] { new Models.Buildings_v2.Pottery().Items };
			yield return new object[] { new Models.Buildings_v2.Sawmill().Items };
			yield return new object[] { new Models.Buildings_v2.SewingWorkshop().Items };
			yield return new object[] { new Models.Buildings_v2.ShamanWorkshop().Items };
			yield return new object[] { new Models.Buildings_v2.Smelter().Items };
			yield return new object[] { new Models.Buildings_v2.Tannery().Items };
			yield return new object[] { new Models.Buildings_v2.Workshop().Items };
		}

		[Theory]
		[MemberData(nameof(GetProperties_TestData))]
		public void Given_ProducibleItem_When_GetProperties_Then_ReturnNotNullValues(List<ProducibleItem> producibleItems)
		{
			Assert.All(producibleItems, (item) => Assert.NotNull(item.Name));
			Assert.All(producibleItems, (item) => Assert.InRange(item.LevelWhenAppears, 1, 150));
			Assert.All(producibleItems, (item) => Assert.NotNull(item.BuildingToCreate));
			Assert.All(producibleItems, (item) => Assert.NotEmpty(item.Components));
		}
	}
}
