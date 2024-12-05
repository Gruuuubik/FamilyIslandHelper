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
		private readonly string buildingsNamespace;
		private readonly string folderWithBuildingsPictures;

		public BuildingHelper(ApiVersion apiVersion) : base(apiVersion)
		{
			buildingsNamespace = $"{MainNamespace}.Models.Buildings{Prefix}";
			folderWithBuildingsPictures = Path.Combine(FolderWithPictures, "Buildings");
		}

		public List<BuildingInfo> GetBuildingsClasses()
		{
			var buildingsClasses = ClassHelper.GetClasses(buildingsNamespace);

			return buildingsClasses.Select(bc => new BuildingInfo
			{
				Value = bc.Name,
				Name = CreateBuilding(bc.Name).Name
			}).ToList();
		}

		public Building CreateBuilding(string buildingName)
		{
			if (buildingName == null)
			{
				throw new ArgumentNullException(nameof(buildingName));
			}

			var buildingType = Type.GetType($"{buildingsNamespace}.{buildingName}", true);
			return Activator.CreateInstance(buildingType) as Building;
		}

		public List<string> GetBuildingsNames()
		{
			return ClassHelper.GetClassesNames(buildingsNamespace).ToList();
		}

		public List<string> GetItemsOfBuilding(string buildingName)
		{
			var building = CreateBuilding(buildingName);

			return building.Items.OrderBy(i => i.LevelWhenAppears).ThenBy(i => i.TotalProduceTime).Select(i => i.GetType().Name).ToList();
		}

		public string GetBuildingImagePathByName(string buildingName)
		{
			return Path.Combine(folderWithBuildingsPictures, buildingName + ImageExtension);
		}
	}
}
