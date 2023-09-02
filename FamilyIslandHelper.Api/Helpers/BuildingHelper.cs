using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyIslandHelper.Api.Helpers
{
	public static class BuildingHelper
	{
		private const string MainNamespace = "FamilyIslandHelper.Api";
		public static readonly string BuildingsNamespace = $"{MainNamespace}.Models.Buildings";

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

			return building.Items.Select(i => i.GetType().Name).OrderBy(i => i);
		}
	}
}
