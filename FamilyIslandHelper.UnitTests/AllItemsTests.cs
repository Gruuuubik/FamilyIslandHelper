using FamilyIslandHelper.Models.Buildings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
			var actualBuildingsNames = GetStaticClassesNames(relativePathToBuildings);

			var buildingsDirectories = Directory.GetDirectories(folderWithPictures);
			var expectedBuildingsNames = buildingsDirectories.Select(b => b.Split('\\').Last());

			Assert.Equal(expectedBuildingsNames, actualBuildingsNames);
		}

		public static IEnumerable<object[]> BuildingsClassesProvider
		{
			get
			{
				var buildingsClasses = GetStaticClasses(relativePathToBuildings);

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

		private static IEnumerable<Type> GetStaticClasses(string nameSpace)
		{
			var assemblyName = nameSpace.Split('.').First();
			var assembly = Assembly.Load(assemblyName);

			return assembly.GetTypes()
				.Where(type => type.Namespace == nameSpace && type.IsAbstract && type.IsSealed);
		}

		private static IEnumerable<string> GetStaticClassesNames(string nameSpace)
		{
			return GetStaticClasses(nameSpace).Select(type => type.Name);
		}

		[Theory]
		[InlineData("Loom", "Lace", typeof(Loom.Lace))]
		public void When_TryToCreateItem_Then_ReturnCorrectItem(string buildingName, string itemTypeString, Type expectedItemType)
		{
			var item = ItemCreator.CreateItem(buildingName, itemTypeString);

			Assert.Equal(expectedItemType, item.GetType());
		}
	}
}
