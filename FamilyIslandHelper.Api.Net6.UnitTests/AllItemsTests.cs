using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models;
using Xunit;

namespace FamilyIslandHelper.Api.Net6.UnitTests
{
	public class AllItemsTests : BaseTest
	{
		[Fact]
		public void When_GetAllResources_Then_AllResourcesHaveImages()
		{
			var actualResourcesNames = ClassHelper.GetClassesNames("FamilyIslandHelper.Api.Models.Resources")
				.Where(n => n != nameof(BuildingInfo)).OrderBy(i => i);

			var resourcesPaths = Directory.GetFiles(Path.Combine(BaseHelper.FolderWithPictures, "Resources"));
			var expectedResourcesNames = resourcesPaths.Select(r => r.Split('.').First().Split(pathSeparator).Last()).OrderBy(i => i);

			Assert.Equal(expectedResourcesNames, actualResourcesNames);
		}

		public static IEnumerable<object[]> GetAllItemsNames_TestData()
		{
			yield return new object[] { "Pottery", new[] { "Amphora", "Bowl", "Flashlight", "Jug", "Pot" } };
		}

		[Theory]
		[MemberData(nameof(GetAllItemsNames_TestData))]
		public void When_GetAllItemsNames_Then_AllItemsHavePictures(string buildingClassName, IEnumerable<string> expectedItemsNames)
		{
			var itemsPaths = Directory.GetFiles(Path.Combine(ItemHelper.FolderWithItemsPictures, buildingClassName));

			var actualItemsNames = itemsPaths.Select(ip => ip.Split('.').First().Split(pathSeparator).Last()).OrderBy(i => i);

			Assert.Equal(expectedItemsNames, actualItemsNames);
		}
	}
}
