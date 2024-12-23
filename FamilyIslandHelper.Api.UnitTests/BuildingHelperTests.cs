using FamilyIslandHelper.Api.Helpers;
using Xunit;

namespace FamilyIslandHelper.Api.UnitTests
{
	public class BuildingHelperTests : BaseTest
	{
		private BuildingHelper buildingHelper;

		[Theory]
		[InlineData(ApiVersion.v1, 13)]
		[InlineData(ApiVersion.v2, 17)]
		public void When_GetBuildingsClasses_Then_ReturnCorrectCollection(ApiVersion apiVersion, int expectedCount)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			var actualBuildingsClasses = buildingHelper.GetBuildingsClasses();

			Assert.Equal(expectedCount, actualBuildingsClasses.Count);
			Assert.All(actualBuildingsClasses, (bc) => Assert.NotNull(bc));
		}

		[Theory]
		[InlineData(ApiVersion.v1, "Mill", new[] { "GoatFood", "ChickenFood", "Ocher", "Flour", "SunflowerOil", "Syrup", "CowFood" })]
		[InlineData(ApiVersion.v2, "Forge", new[] { "Needle", "Hammer", "Glass" })]
		public void When_TryToGetItemsOfBuilding_Then_ReturnCorrectItems(ApiVersion apiVersion, string buildingName, IEnumerable<string> expectedItems)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			var actualItems = buildingHelper.GetItemsOfBuilding(buildingName);

			Assert.Equal(expectedItems, actualItems);
		}

		[Theory]
		[InlineData("buildingName")]
		public void When_CreateBuildingWithNullParameter_Then_ThrowsException(string expectedParamName)
		{
			buildingHelper = new BuildingHelper(ApiVersion.v1);

			var exception = Assert.Throws<ArgumentNullException>(() => buildingHelper.CreateBuilding(null));

			Assert.Equal(expectedParamName, exception.ParamName);
		}

		[Theory]
		[InlineData(ApiVersion.v1)]
		[InlineData(ApiVersion.v2)]
		public void When_CheckBuildingToCreateForAllItems_Then_ReturnCorrectValue(ApiVersion apiVersion)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			var buildingNames = buildingHelper.GetBuildingsNames();

			foreach (var buildingName in buildingNames)
			{
				var building = buildingHelper.CreateBuilding(buildingName);
				var items = building.Items;

				Assert.Equal(building.Name, items.Select(i => i.BuildingToCreate.Name).Distinct().Single());
			}
		}

		public static IEnumerable<object[]> GetAllBuildingsNames_TestData()
		{
			yield return new object[] { ApiVersion.v1, new[] { "CarpentryWorkshop", "JewelryWorkshop", "Knocker", "Loom", "MeteoriteForge", "Mill", "Mixer", "Pottery", "Sawmill", "ShamanWorkshop", "Smelter", "Tannery", "Workshop" } };
			yield return new object[] { ApiVersion.v2, new[] { "AlchemistLaboratory", "Bench", "CarpentryWorkshop", "Forge", "JewelryWorkshop", "Kiln", "Knocker", "Loom", "MeteoriteForge", "Mill", "Mixer", "Pottery", "Sawmill", "SewingWorkshop", "Smelter", "Tannery", "Workshop" } };
		}

		[Theory]
		[MemberData(nameof(GetAllBuildingsNames_TestData))]
		public void When_GetAllBuildingsNames_Then_AllBuildingsHavePictures(ApiVersion apiVersion, IEnumerable<string> buildingsNames)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			foreach (var buildingName in buildingsNames)
			{
				Assert.NotNull(buildingHelper.GetBuildingImageByName(buildingName));
			}
		}

#if WINDOWS
		[Theory]
		[InlineData(ApiVersion.v1, "Knocker")]
		[InlineData(ApiVersion.v2, "Knocker")]
		public void When_GetBuildingImageByName_Then_ReturnCorrectValue(ApiVersion apiVersion, string buildingName)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			var actualImage = buildingHelper.GetBuildingImageByName(buildingName);

			Assert.Equal(System.Drawing.Imaging.ImageFormat.Png, actualImage.RawFormat);
		}
#endif
	}
}
