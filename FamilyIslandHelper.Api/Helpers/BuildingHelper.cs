using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyIslandHelper.Api.Helpers
{
	public static class BuildingHelper
	{
		public static readonly string BuildingsNamespace = $"{MainNamespace}.Models.Buildings";
		private const string MainNamespace = "FamilyIslandHelper.Api";

		public static string GetBuildingNameByPath(string itemPath)
		{
#if LINUX
			var pathSeparator = '/';
#else
			var pathSeparator = '\\';
#endif
			return itemPath.Split('.').First().Split(pathSeparator).Last();
		}

		public static List<BuildingInfo> GetBuildingsClasses()
		{
			var buildingsClasses = ClassHelper.GetClasses(BuildingsNamespace);

			return buildingsClasses.Select(bc => new BuildingInfo
			{
				Value = bc.Name,
				Name = CreateBuilding(bc.Name).Name
			}).ToList();
		}

		public static Building CreateBuilding(string buildingName)
		{
			if (buildingName == null)
			{
				throw new ArgumentNullException(nameof(buildingName));
			}

			var buildingType = Type.GetType($"{BuildingsNamespace}.{buildingName}", true);
			return Activator.CreateInstance(buildingType) as Building;
		}

		public static IEnumerable<string> GetBuildingsNames()
		{
			return ClassHelper.GetClassesNames(BuildingsNamespace);
		}

		public static IEnumerable<string> GetItemsOfBuilding(string buildingName)
		{
			var building = CreateBuilding(buildingName);

			return building.Items.OrderBy(i => i.LevelWhenAppears).ThenBy(i => i.TotalProduceTime).Select(i => i.GetType().Name);
		}
	}
}
