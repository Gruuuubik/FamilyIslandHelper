using FamilyIslandHelper.Api.Helpers;
using FluentAssertions;
using Xunit;

namespace FamilyIslandHelper.Api.Net6.UnitTests
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
		[InlineData(ApiVersion.v1)]
		[InlineData(ApiVersion.v2)]
		public void When_GetAllBuildingsNames_Then_AllBuildingsHaveFolders(ApiVersion apiVersion)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			var actualBuildingsNames = buildingHelper.GetBuildingsNames();

			var buildingsDirectories = Directory.GetDirectories(new ItemHelper(apiVersion).FolderWithItemsPictures);
			var expectedBuildingsNames = buildingsDirectories.Select(b => b.Split(pathSeparator).Last());

			actualBuildingsNames.Should().Equal(expectedBuildingsNames);
		}

		[Theory]
		[InlineData(ApiVersion.v1, "Mill", new[] { "GoatFood", "ChickenFood", "Ocher", "Flour", "SunflowerOil", "Syrup", "CowFood" })]
		[InlineData(ApiVersion.v2, "Forge", new[] { "Needle", "Hammer" })]
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
		[InlineData(ApiVersion.v1, "Knocker", new[] { "Pictures", "Buildings", "Knocker.png" })]
		[InlineData(ApiVersion.v2, "Knocker", new[] { "Pictures_v2", "Buildings", "Knocker.png" })]
		public void When_GetBuildingImagePathByName_Then_ReturnCorrectValue(ApiVersion apiVersion, string buildingName, string[] expectedPath)
		{
			buildingHelper = new BuildingHelper(apiVersion);

			var actualPath = buildingHelper.GetBuildingImagePathByName(buildingName);

			Assert.Equal(Path.Combine(expectedPath), actualPath);
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
	}
}
