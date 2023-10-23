using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models.Abstract;
using FamilyIslandHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyIslandHelper.Web.Controllers
{
	public class HomeController : Controller
	{
		private ViewModel viewModel;

		private readonly List<string> buildingsNames = BuildingHelper.GetBuildingsNames().ToList();

		[HttpGet]
		public IActionResult Index()
		{
			var buildingName1 = buildingsNames.First();

			var items1 = BuildingHelper.GetItemsOfBuilding(buildingName1).ToList();

			var itemName1 = items1.First();

			viewModel = new ViewModel
			{
				BuildingsNames = buildingsNames,
				BuildingProduceRatio = BuildingHelper.CreateBuilding(buildingName1).ProduceRatio,
				BuildingName = buildingName1,
				ShowListOfComponents = false,
				Items = items1,
				ItemName = itemName1,
				ItemCount = 1,
				ItemInfo = GetInfoAboutItem(itemName1, 1, false)
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Index(ViewModel viewModel)
		{
			if (viewModel == null)
			{
				throw new ArgumentNullException(nameof(viewModel));
			}

			var items1 = BuildingHelper.GetItemsOfBuilding(viewModel.BuildingName).ToList();

			viewModel.BuildingsNames = buildingsNames;
			viewModel.ItemInfo = GetInfoAboutItem(viewModel.ItemName, viewModel.ItemCount, viewModel.ShowListOfComponents);
			viewModel.Items = items1;
			viewModel.BuildingProduceRatio = BuildingHelper.CreateBuilding(viewModel.BuildingName).ProduceRatio;

			return View(viewModel);
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