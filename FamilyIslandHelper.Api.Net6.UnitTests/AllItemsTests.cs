using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models;
using Xunit;

namespace FamilyIslandHelper.Api.Net6.UnitTests
{
	public class AllItemsTests : BaseTest
	{
		private ItemHelper itemHelper;

		[Theory]
		[InlineData(ApiVersion.v1)]
		[InlineData(ApiVersion.v2)]
		public void When_GetAllResources_Then_AllResourcesHaveImages(ApiVersion apiVersion)
		{
			itemHelper = new ItemHelper(apiVersion);

			var actualResourcesNames = ClassHelper.GetClassesNames(itemHelper.ResourcesNamespace)
				.Where(n => n != nameof(BuildingInfo)).OrderBy(i => i);

			var resourcesPaths = Directory.GetFiles(itemHelper.FolderWithResourcesPictures);
			var expectedResourcesNames = resourcesPaths.Select(r => r.Split('.').First().Split(pathSeparator).Last()).OrderBy(i => i);

			Assert.Equal(expectedResourcesNames, actualResourcesNames);
		}

		public static IEnumerable<object[]> GetAllItemsNames_TestData()
		{
			yield return new object[] { ApiVersion.v1, "Pottery", new[] { "Amphora", "Bowl", "Flashlight", "Jug", "Pot" } };
			yield return new object[] { ApiVersion.v2, "Pottery", new[] { "Amphora", "Bowl", "Jug", "Pot" } };
		}

		[Theory]
		[MemberData(nameof(GetAllItemsNames_TestData))]
		public void When_GetAllItemsNames_Then_AllItemsHavePictures(ApiVersion apiVersion, string buildingClassName, IEnumerable<string> expectedItemsNames)
		{
			itemHelper = new ItemHelper(apiVersion);

			var itemsPaths = Directory.GetFiles(Path.Combine(itemHelper.FolderWithItemsPictures, buildingClassName));

			var actualItemsNames = itemsPaths.Select(ip => ip.Split('.').First().Split(pathSeparator).Last()).OrderBy(i => i);

			Assert.Equal(expectedItemsNames, actualItemsNames);
		}
	}
}
