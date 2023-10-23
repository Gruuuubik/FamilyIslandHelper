using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyIslandHelper.Web.Controllers
{
	public class CompareController : Controller
	{
		private CompareViewModel compareViewModel;

		private readonly List<string> buildingsNames = BuildingHelper.GetBuildingsNames().ToList();

		[HttpGet]
		public IActionResult Index()
		{
			var buildingName1 = buildingsNames.First();
			var buildingName2 = buildingsNames.First();

			var items1 = BuildingHelper.GetItemsOfBuilding(buildingName1).ToList();
			var items2 = BuildingHelper.GetItemsOfBuilding(buildingName2).ToList();

			var itemName1 = items1.First();
			var itemName2 = items2.First();

			compareViewModel = new CompareViewModel
			{
				BuildingsNames = buildingsNames,
				Building1ProduceRatio = BuildingHelper.CreateBuilding(buildingName1).ProduceRatio,
				Building2ProduceRatio = BuildingHelper.CreateBuilding(buildingName2).ProduceRatio,
				BuildingName1 = buildingName1,
				BuildingName2 = buildingName2,
				ShowListOfComponents = false,
				Items1 = items1,
				ItemName1 = itemName1,
				ItemCount1 = 1,
				ItemInfo1 = GetInfoAboutItem(itemName1, 1, false),
				Items2 = items2,
				ItemName2 = itemName2,
				ItemCount2 = 1,
				ItemInfo2 = GetInfoAboutItem(itemName2, 1, false)
			};

			return View(compareViewModel);
		}

		[HttpPost]
		public IActionResult Index(CompareViewModel compareViewModel)
		{
			if (compareViewModel == null)
			{
				throw new ArgumentNullException(nameof(compareViewModel));
			}

			compareViewModel.BuildingsNames = buildingsNames;

			var items1 = BuildingHelper.GetItemsOfBuilding(compareViewModel.BuildingName1).ToList();
			var items2 = BuildingHelper.GetItemsOfBuilding(compareViewModel.BuildingName2).ToList();

			compareViewModel.ItemInfo1 = GetInfoAboutItem(compareViewModel.ItemName1, compareViewModel.ItemCount1, compareViewModel.ShowListOfComponents);
			compareViewModel.ItemInfo2 = GetInfoAboutItem(compareViewModel.ItemName2, compareViewModel.ItemCount2, compareViewModel.ShowListOfComponents);

			compareViewModel.Items1 = items1;
			compareViewModel.Items2 = items2;

			compareViewModel.Building1ProduceRatio = BuildingHelper.CreateBuilding(compareViewModel.BuildingName1).ProduceRatio;
			compareViewModel.Building2ProduceRatio = BuildingHelper.CreateBuilding(compareViewModel.BuildingName2).ProduceRatio;

			return View(compareViewModel);
		}

		private static string GetInfoAboutItem(string itemName, int itemCount, bool showListOfComponents)
		{
			if (itemName == null)
			{
				throw new ArgumentNullException(nameof(itemName));
			}

			var item = ItemHelper.FindItemByName(itemName);

			var info = item.ToString(itemCount);

			if (item is ProducibleItem producibleItem)
			{
				if (showListOfComponents)
				{
					info += "\n";
					info += "Components:\n";

					foreach (var componentInfo in producibleItem.ComponentsInfo(0, itemCount))
					{
						info += componentInfo + "\n";
					}
				}

				info += "\n";
				info += "Итого времени на производство: " + TimeSpan.FromSeconds(producibleItem.TotalProduceTime.TotalSeconds * itemCount) + "\n";
			}

			return info;
		}
	}
}