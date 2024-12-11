using FamilyIslandHelper.Api;
using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FamilyIslandHelper.Desktop
{
	public partial class MainForm : Form
	{
		private readonly Dictionary<string, int> dictImagesIndexes = new Dictionary<string, int>();

		private bool showListOfComponents = false;

		private Item selectedItem1, selectedItem2;

		private BuildingHelper buildingHelper;
		private ItemHelper itemHelper;

		public MainForm()
		{
			InitializeComponent();

			cb_showListOfComponents.Checked = showListOfComponents;

			InitBuildingAndItems(ApiVersion.v2);
		}

		private void InitBuildingAndItems(ApiVersion apiVersion)
		{
			buildingHelper = new BuildingHelper(apiVersion);
			itemHelper = new ItemHelper(apiVersion);

			var buildingsNames = buildingHelper.GetBuildingsNames();
			InitBuildingsPanels(buildingsNames, 1, pnl_Buildings1);
			InitBuildingsPanels(buildingsNames, 2, pnl_Buildings2);

			ShowListOfItemsForBuildings();

			tv_Components1.ImageList = GetImageList();
			tv_Components2.ImageList = GetImageList();
		}

		private void AddInfoToListBox(string itemName, int itemCount)
		{
			var info = itemHelper.GetInfoAboutItem(itemName, itemCount, showListOfComponents);

			if (lb_Components.Items.Count > 0)
			{
				lb_Components.Items.Add(string.Empty);
			}

			var item = itemHelper.FindItemByName(itemName);

			info.ForEach(i => lb_Components.Items.Add(i));
		}

		private void AddInfoToTreeView(TreeView tvComponents, Item item, string itemTypeString)
		{
			tvComponents.Nodes.Clear();

			var imageIndex = GetImageIndex(itemTypeString);
			var treeNode = new TreeNode(item.Name, imageIndex, imageIndex)
			{
				Name = item.GetType().Name
			};

			tvComponents.Nodes.Add(treeNode);

			AddItemComponentsToItemNode(tvComponents.Nodes[0], item);

			tvComponents.ExpandAll();

			tvComponents.SelectedNode = tvComponents.Nodes[0];
		}

		private void AddItemComponentsToItemNode(TreeNode parentTreeNode, Item item)
		{
			if (item is ProducibleItem producibleItem)
			{
				for (var i = 0; i < producibleItem.Components.Count; i++)
				{
					var childComponent = producibleItem.Components[i];
					var childItem = childComponent.item;

					var imageIndex = GetImageIndex(childItem.GetType().Name);
					var treeNode = new TreeNode($"{childItem.Name}({childComponent.count})", imageIndex, imageIndex)
					{
						Name = childItem.GetType().Name
					};

					parentTreeNode.Nodes.Add(treeNode);

					AddItemComponentsToItemNode(parentTreeNode.Nodes[i], childItem);
				}
			}
		}

		private void pnl_Item_MouseDown(object sender, MouseEventArgs e)
		{
			var itemPanel = sender as Panel;
			var panelTag = itemPanel.Tag.ToString();
			var panelNumber = int.Parse(panelTag.Split('_')[1]);

			if (panelNumber == 1)
			{
				foreach (Panel itemPanel1 in pnl_Items1.Controls)
				{
					itemPanel1.BorderStyle = BorderStyle.None;
				}

				ShowInfoForItem(panelTag, tv_Components1);
			}
			else if (panelNumber == 2)
			{
				foreach (Panel itemPanel2 in pnl_Items2.Controls)
				{
					itemPanel2.BorderStyle = BorderStyle.None;
				}

				ShowInfoForItem(panelTag, tv_Components2);
			}

			itemPanel.BorderStyle = BorderStyle.FixedSingle;
		}

		private void pnl_Building_MouseDown(object sender, MouseEventArgs e)
		{
			var buildingPanel = sender as Panel;
			var panelTag = buildingPanel.Tag.ToString();
			var panelNumber = int.Parse(panelTag.Split('_')[1]);

			if (panelNumber == 1)
			{
				foreach (Panel buildingsPanel1 in pnl_Buildings1.Controls)
				{
					buildingsPanel1.BorderStyle = BorderStyle.None;
				}
			}
			else if (panelNumber == 2)
			{
				foreach (Panel buildingsPanel2 in pnl_Buildings2.Controls)
				{
					buildingsPanel2.BorderStyle = BorderStyle.None;
				}
			}

			ShowListOfItemsForBuilding(panelTag.Split('_')[0], panelNumber);

			buildingPanel.BorderStyle = BorderStyle.FixedSingle;
		}

		private void ShowInfoForItem(string panelTag, TreeView tvComponents)
		{
			var itemTypeString = panelTag.Split('_')[0];
			var panelNumber = int.Parse(panelTag.Split('_')[1]);
			lb_Components.Items.Clear();

			var item = itemHelper.CreateProducibleItem(itemTypeString);

			if (panelNumber == 1)
			{
				selectedItem1 = item;
			}
			else if (panelNumber == 2)
			{
				selectedItem2 = item;
			}

			AddInfoToTreeView(tvComponents, item, itemTypeString);
		}

		private void cb_Buildings_SelectedIndexChanged(object sender, EventArgs e)
		{
			var comboBox = (ComboBox)sender;
			ShowListOfItemsForBuilding(comboBox.SelectedValue.ToString(), int.Parse(comboBox.Tag.ToString()));
		}

		private void ShowListOfItemsForBuilding(string buildingName, int panelNumber)
		{
			var itemsNames = buildingHelper.GetItemsOfBuilding(buildingName);
			var ratio = buildingHelper.CreateBuilding(buildingName).ProduceRatio.ToString();

			if (panelNumber == 1)
			{
				tv_Components1.Nodes.Clear();
				lbl_Ratio1.Text = "Ratio: " + ratio;

				InitItemsPanels(buildingName, itemsNames, panelNumber, pnl_Items1);
			}
			else if (panelNumber == 2)
			{
				tv_Components2.Nodes.Clear();
				lbl_Ratio2.Text = "Ratio: " + ratio;

				InitItemsPanels(buildingName, itemsNames, panelNumber, pnl_Items2);
			}
		}

		private void ShowListOfItemsForBuildings()
		{
			lb_Components.Items.Clear();

			var buildingName = buildingHelper.GetBuildingsNames().FirstOrDefault();

			(pnl_Buildings1.Controls[0] as Panel).BorderStyle = BorderStyle.FixedSingle;
			(pnl_Buildings2.Controls[0] as Panel).BorderStyle = BorderStyle.FixedSingle;

			ShowListOfItemsForBuilding(buildingName, 1);
			ShowListOfItemsForBuilding(buildingName, 2);
		}

		private void InitItemsPanels(string buildingName, IReadOnlyList<string> itemsNames, int panelNumber, Control pnlItems)
		{
			var panels = new Control[itemsNames.Count];
			const int size = 50;

			for (var i = 0; i < itemsNames.Count; i++)
			{
				var panel = new Panel
				{
					Tag = itemsNames[i] + "_" + panelNumber,
					Size = new Size(size, size),
					BackgroundImage = itemHelper.GetItemImageByName(buildingName, itemsNames[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += pnl_Item_MouseDown;

				new ToolTip().SetToolTip(panel, itemHelper.CreateProducibleItem(itemsNames[i]).Name);

				panels[i] = panel;
			}

			panels = panels.OrderBy(p => GetItem(p).LevelWhenAppears).ThenBy(p => GetItem(p).TotalProduceTime).ToArray();

			for (var i = 0; i < panels.Length; i++)
			{
				panels[i].Location = new Point(5 + ((size + 5) * i), 10);
			}

			pnlItems.Controls.Clear();
			pnlItems.Controls.AddRange(panels);
			return;

			ProducibleItem GetItem(Control p) => itemHelper.CreateProducibleItem(p.Tag.ToString().Split('_')[0]);
		}

		private void InitBuildingsPanels(IReadOnlyList<string> buildingsNames, int panelNumber, Control pnlItems)
		{
			var panels = new Control[buildingsNames.Count];
			const int size = 55;
			const int padding = 5;

			pnlItems.Controls.Clear();

			for (var i = 0; i < buildingsNames.Count; i++)
			{
				var panel = new Panel
				{
					Tag = buildingsNames[i] + "_" + panelNumber,
					Size = new Size(size, size),
					BackgroundImage = buildingHelper.GetBuildingImageByName(buildingsNames[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += pnl_Building_MouseDown;

				new ToolTip().SetToolTip(panel, buildingHelper.CreateBuilding(buildingsNames[i]).Name);

				panels[i] = panel;
			}

			for (var i = 0; i < panels.Length; i++)
			{
				panels[i].Location = new Point(padding + ((size + padding) * i), 10);
			}

			pnlItems.Controls.AddRange(panels);
			return;
		}

		private ImageList GetImageList()
		{
			dictImagesIndexes.Clear();

			var imageList = new ImageList
			{
				ImageSize = new Size(30, 30)
			};

			var buildingsNames = buildingHelper.GetBuildingsNames();

			var counter = 0;

			foreach (var buildingName in buildingsNames)
			{
				var itemsNames = buildingHelper.GetItemsOfBuilding(buildingName);

				for (var i = 0; i < itemsNames.Count; i++)
				{
					var itemImage = itemHelper.GetItemImageByName(buildingName, itemsNames[i]);

					dictImagesIndexes.Add(itemsNames[i], counter);

					if (itemImage != null)
					{
						imageList.Images.Add(itemImage);
					}

					counter++;
				}
			}

			var resourcesNames = itemHelper.GetResourcesNames();

			for (var i = 0; i < resourcesNames.Count; i++)
			{
				dictImagesIndexes.Add(resourcesNames[i], counter);
				imageList.Images.Add(itemHelper.GetResourceImageByName(resourcesNames[i]));
				counter++;
			}

			return imageList;
		}

		private int GetImageIndex(string itemName)
		{
			if (!dictImagesIndexes.ContainsKey(itemName))
			{
				return 0;
			}

			return dictImagesIndexes[itemName];
		}

		private void tv_Components_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateInfo();
		}

		private void UpdateInfo()
		{
			lb_Components.Items.Clear();

			if (tv_Components1.SelectedNode != null)
			{
				var itemName = tv_Components1.SelectedNode.Name;
				selectedItem1 = itemHelper.FindItemByName(itemName);
				AddInfoToListBox(itemName, Convert.ToInt32(num_Item1Count.Value));
			}

			if (tv_Components2.SelectedNode != null)
			{
				var itemName = tv_Components2.SelectedNode.Name;
				selectedItem2 = itemHelper.FindItemByName(itemName);
				AddInfoToListBox(itemName, Convert.ToInt32(num_Item2Count.Value));
			}

			if (selectedItem1 != null && selectedItem2 != null)
			{
				lb_Components.Items.Add(string.Empty);
				lb_Components.Items.Add(ItemHelper.CompareItems(selectedItem1, Convert.ToInt32(num_Item1Count.Value), selectedItem2, Convert.ToInt32(num_Item2Count.Value)));
			}
		}

		private void num_ItemCount_ValueChanged(object sender, EventArgs e)
		{
			UpdateInfo();
		}

		private void rb_v1_CheckedChanged(object sender, EventArgs e)
		{
			InitBuildingAndItems(ApiVersion.v1);
		}

		private void rb_v2_CheckedChanged(object sender, EventArgs e)
		{
			InitBuildingAndItems(ApiVersion.v2);
		}

		private void cb_showListOfComponents_CheckedChanged(object sender, EventArgs e)
		{
			showListOfComponents = cb_showListOfComponents.Checked;

			UpdateInfo();
		}
	}
}
