using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FamilyIslandHelper.Api.Helpers
{
	public class BuildingHelper : BaseHelper
	{
		public static readonly string BuildingsNamespace = $"{MainNamespace}.Models.Buildings";

		private static readonly string FolderWithBuildingsPictures = Path.Combine(FolderWithPictures, "Buildings");

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

		public static List<string> GetBuildingsNames()
		{
			return ClassHelper.GetClassesNames(BuildingsNamespace).ToList();
		}

		public static List<string> GetItemsOfBuilding(string buildingName)
		{
			var building = CreateBuilding(buildingName);

			return building.Items.OrderBy(i => i.LevelWhenAppears).ThenBy(i => i.TotalProduceTime).Select(i => i.GetType().Name).ToList();
		}

		public static string GetBuildingImagePathByName(string buildingName)
		{
			return Path.Combine(FolderWithBuildingsPictures, buildingName + ImageExtension);
		}
	}
}
