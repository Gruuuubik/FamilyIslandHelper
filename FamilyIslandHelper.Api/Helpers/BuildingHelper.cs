using FamilyIslandHelper.Api.Models;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FamilyIslandHelper.Api.Helpers
{
	public class BuildingHelper : BaseHelper
	{
		private readonly string buildingsNamespace;
		private readonly Assembly assembly;

		public BuildingHelper(ApiVersion apiVersion) : base(apiVersion)
		{
			buildingsNamespace = $"{MainNamespace}.Models.Buildings{Prefix}";
			assembly = Assembly.GetExecutingAssembly();
			FolderWithBuildingsPictures = Path.Combine(FolderWithPictures, "Buildings");
		}

		public string FolderWithBuildingsPictures { get; }

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
			return Path.Combine(FolderWithBuildingsPictures, buildingName + ImageExtension);
		}

		public Image GetBuildingImageByName(string buildingName)
		{
			var imagePath = $"{MainNamespace}.{GetBuildingImagePathByName(buildingName)}";
			Image image = null;

			using (var stream = assembly.GetManifestResourceStream(imagePath.Replace("\\", ".")))
			{
				image = Image.FromStream(stream);
			}

			return image;
		}
	}
}
