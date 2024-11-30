using FamilyIslandHelper.Api.Helpers;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FamilyIslandHelper.Desktop
{
	public partial class MainForm : Form
	{
		private const string FolderWithPictures = "Pictures";
		private readonly string folderWithItemsPictures = Path.Combine(FolderWithPictures, "Items");
		private readonly string folderWithBuildingsPictures = Path.Combine(FolderWithPictures, "Buildings");

		private readonly Dictionary<string, int> dictImagesIndexes = new Dictionary<string, int>();

		private bool showListOfComponents = false;

		private Item selectedItem1, selectedItem2;

		public MainForm()
		{
			InitializeComponent();

			cb_showListOfComponents.Checked = showListOfComponents;

			InitBuildings();

			ShowListOfItemsForBuildings();

			tv_Components1.ImageList = GetImageList();
			tv_Components2.ImageList = GetImageList();
		}

		private void InitBuildings()
		{
			var buildingsImagesPaths = Directory.GetFiles(folderWithBuildingsPictures).ToList();
			InitBuildingsPanels(buildingsImagesPaths, 1, pnl_Buildings1);
			InitBuildingsPanels(buildingsImagesPaths, 2, pnl_Buildings2);
		}

		private void AddInfoToListBox(string itemName, int itemCount)
		{
			var info = ItemHelper.GetInfoAboutItem(itemName, itemCount, showListOfComponents);

			if (lb_Components.Items.Count > 0)
			{
				lb_Components.Items.Add(string.Empty);
			}

			var item = ItemHelper.FindItemByName(itemName);

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

			var item = ItemHelper.CreateProducibleItem(itemTypeString);

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
			var itemsPaths = Directory.GetFiles(Path.Combine(folderWithItemsPictures, buildingName)).ToList();
			var ratio = BuildingHelper.CreateBuilding(buildingName).ProduceRatio.ToString();

			if (panelNumber == 1)
			{
				tv_Components1.Nodes.Clear();
				lbl_Ratio1.Text = "Ratio: " + ratio;

				InitItemsPanels(itemsPaths, panelNumber, pnl_Items1);
			}
			else if (panelNumber == 2)
			{
				tv_Components2.Nodes.Clear();
				lbl_Ratio2.Text = "Ratio: " + ratio;

				InitItemsPanels(itemsPaths, panelNumber, pnl_Items2);
			}
		}

		private void ShowListOfItemsForBuildings()
		{
			lb_Components.Items.Clear();

			var buildingsImagesPaths = Directory.GetFiles(folderWithBuildingsPictures).ToList();
			var buildingName = BuildingHelper.GetBuildingNameByPath(buildingsImagesPaths.FirstOrDefault());

			(pnl_Buildings1.Controls[0] as Panel).BorderStyle = BorderStyle.FixedSingle;
			(pnl_Buildings2.Controls[0] as Panel).BorderStyle = BorderStyle.FixedSingle;

			ShowListOfItemsForBuilding(buildingName, 1);
			ShowListOfItemsForBuilding(buildingName, 2);
		}

		private void InitItemsPanels(IReadOnlyList<string> itemsPaths, int panelNumber, Control pnlItems)
		{
			var panels = new Control[itemsPaths.Count];
			const int size = 50;

			for (var i = 0; i < itemsPaths.Count; i++)
			{
				var itemName = ItemHelper.GetItemNameByPath(itemsPaths[i]);

				var panel = new Panel
				{
					Tag = itemName + "_" + panelNumber,
					Size = new Size(size, size),
					BackgroundImage = Image.FromFile(itemsPaths[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += pnl_Item_MouseDown;

				new ToolTip().SetToolTip(panel, ItemHelper.CreateProducibleItem(itemName).Name);

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

			ProducibleItem GetItem(Control p) => ItemHelper.CreateProducibleItem(p.Tag.ToString().Split('_')[0]);
		}

		private void InitBuildingsPanels(IReadOnlyList<string> buildingsPaths, int panelNumber, Control pnlItems)
		{
			var panels = new Control[buildingsPaths.Count];
			const int size = 55;
			const int padding = 5;

			for (var i = 0; i < buildingsPaths.Count; i++)
			{
				var buildingName = BuildingHelper.GetBuildingNameByPath(buildingsPaths[i]);

				var panel = new Panel
				{
					Tag = buildingName + "_" + panelNumber,
					Size = new Size(size, size),
					BackgroundImage = Image.FromFile(buildingsPaths[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += pnl_Building_MouseDown;

				new ToolTip().SetToolTip(panel, BuildingHelper.CreateBuilding(buildingName).Name);

				panels[i] = panel;
			}

			for (var i = 0; i < panels.Length; i++)
			{
				panels[i].Location = new Point(padding + ((size + padding) * i), 10);
			}

			pnlItems.Controls.Clear();
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

			var buildingsNames = BuildingHelper.GetBuildingsNames();

			var counter = 0;
			var itemPath = Directory.GetFiles(folderWithItemsPictures).FirstOrDefault();
			dictImagesIndexes.Add(ItemHelper.GetItemNameByPath(itemPath), counter);
			imageList.Images.Add(Image.FromFile(itemPath));
			counter++;

			foreach (var buildingName in buildingsNames)
			{
				var itemsPaths = Directory.GetFiles(Path.Combine(folderWithItemsPictures, buildingName)).ToList();

				for (var i = 0; i < itemsPaths.Count; i++)
				{
					dictImagesIndexes.Add(ItemHelper.GetItemNameByPath(itemsPaths[i]), counter);
					imageList.Images.Add(Image.FromFile(itemsPaths[i]));
					counter++;
				}
			}

			var resourcesPaths = Directory.GetFiles(Path.Combine(FolderWithPictures, "Resources")).ToList();

			for (var i = 0; i < resourcesPaths.Count; i++)
			{
				dictImagesIndexes.Add(ItemHelper.GetItemNameByPath(resourcesPaths[i]), counter);
				imageList.Images.Add(Image.FromFile(resourcesPaths[i]));
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
				selectedItem1 = ItemHelper.FindItemByName(itemName);
				AddInfoToListBox(itemName, Convert.ToInt32(num_Item1Count.Value));
			}

			if (tv_Components2.SelectedNode != null)
			{
				var itemName = tv_Components2.SelectedNode.Name;
				selectedItem2 = ItemHelper.FindItemByName(itemName);
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

		private void cb_showListOfComponents_CheckedChanged(object sender, EventArgs e)
		{
			showListOfComponents = cb_showListOfComponents.Checked;

			UpdateInfo();
		}
	}
}
