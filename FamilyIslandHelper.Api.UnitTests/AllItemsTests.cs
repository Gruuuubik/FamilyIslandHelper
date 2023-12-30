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
	}
}
