using FamilyIslandHelper.Api;
using FamilyIslandHelper.Api.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FamilyIslandHelper.Api.Helpers;

namespace FamilyIslandHelper
{
	public partial class MainForm : Form
	{
		private const string FolderWithPictures = "Pictures";
		private bool showListOfComponents = false;

		private Item selectedItem1, selectedItem2;

		private readonly Dictionary<string, int> dictImagesIndexes = new Dictionary<string, int>();

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
			cb_Buildings1.DataSource = BuildingHelper.GetBuildingsClasses();
			cb_Buildings1.DisplayMember = "Name";
			cb_Buildings1.ValueMember = "Value";

			cb_Buildings2.DataSource = BuildingHelper.GetBuildingsClasses();
			cb_Buildings2.DisplayMember = "Name";
			cb_Buildings2.ValueMember = "Value";

			cb_Buildings1.SelectedIndexChanged += this.cb_Buildings_SelectedIndexChanged;
			cb_Buildings2.SelectedIndexChanged += this.cb_Buildings_SelectedIndexChanged;
		}

		private void AddInfoToListBox(string itemName)
		{
			var item = ItemHelper.FindItemByName(itemName);
			
			if (lb_Components.Items.Count > 0)
			{
				lb_Components.Items.Add("");
			}

			lb_Components.Items.Add(item.ToString());

			if (item is ProducibleItem producibleItem)
			{
				if (showListOfComponents)
				{
					lb_Components.Items.Add("");
					lb_Components.Items.Add("Components:");

					foreach (var componentInfo in producibleItem.ComponentsInfo(0))
					{
						lb_Components.Items.Add(componentInfo);
					}
				}

				lb_Components.Items.Add("");
				lb_Components.Items.Add("Итого времени на производство: " + producibleItem.TotalProduceTime);
			}
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
				ShowInfoForItem(panelTag, tv_Components1);
			}
			else if (panelNumber == 2)
			{
				ShowInfoForItem(panelTag, tv_Components2);
			}
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
			var comboBox = ((ComboBox)sender);
			ShowListOfItemsForBuilding(comboBox.SelectedValue.ToString(), int.Parse(comboBox.Tag.ToString()));
		}

		private void ShowListOfItemsForBuilding(string buildingName, int panelNumber)
		{
			var itemsPaths = Directory.GetFiles($"{FolderWithPictures}\\{buildingName}").ToList();
			var ratio = BuildingHelper.CreateBuilding(buildingName).ProduceRatio.ToString();

			if (panelNumber == 1)
			{
				tv_Components1.Nodes.Clear();
				lbl_Ratio1.Text = ratio;

				InitPanels(itemsPaths, panelNumber, pnl_Items1);
			}
			else if (panelNumber == 2)
			{
				tv_Components2.Nodes.Clear();
				lbl_Ratio2.Text = ratio;

				InitPanels(itemsPaths, panelNumber, pnl_Items2);
			}
		}

		private void ShowListOfItemsForBuildings()
		{
			lb_Components.Items.Clear();

			ShowListOfItemsForBuilding(cb_Buildings1.SelectedValue.ToString(), 1);
			ShowListOfItemsForBuilding(cb_Buildings2.SelectedValue.ToString(), 2);
		}

		private void InitPanels(IReadOnlyList<string> itemsPaths, int panelNumber, Control pnlItems)
		{
			var panels = new Control[itemsPaths.Count];
			const int size = 40;

			for (var i = 0; i < itemsPaths.Count; i++)
			{
				var panel = new Panel
				{
					Tag = ItemHelper.GetItemNameByPath(itemsPaths[i]) + "_" + panelNumber,
					Size = new Size(size, size),
					BackgroundImage = Image.FromFile(itemsPaths[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += pnl_Item_MouseDown;

				panels[i] = panel;
			}

			panels = panels.OrderBy(p => GetItem(p).LevelWhenAppears).ThenBy(p => GetItem(p).TotalProduceTime).ToArray();

			for (var i = 0; i < panels.Length; i++)
			{
				panels[i].Location = new Point(5 + (size + 5) * i, 10);
			}

			pnlItems.Controls.Clear();
			pnlItems.Controls.AddRange(panels);
			return;

			ProducibleItem GetItem(Control p) => ItemHelper.CreateProducibleItem(p.Tag.ToString().Split('_')[0]);
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
			var itemPath = Directory.GetFiles(FolderWithPictures).FirstOrDefault();
			dictImagesIndexes.Add(ItemHelper.GetItemNameByPath(itemPath), counter);
			imageList.Images.Add(Image.FromFile(itemPath));
			counter++;

			foreach (var buildingName in buildingsNames)
			{
				var itemsPaths = Directory.GetFiles($"{FolderWithPictures}\\{buildingName}").ToList();

				for (var i = 0; i < itemsPaths.Count; i++)
				{
					dictImagesIndexes.Add(ItemHelper.GetItemNameByPath(itemsPaths[i]), counter);
					imageList.Images.Add(Image.FromFile(itemsPaths[i]));
					counter++;
				}
			}

			var resourcesPaths = Directory.GetFiles("Resources").ToList();

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
				AddInfoToListBox(itemName);
			}

			if (tv_Components2.SelectedNode != null)
			{
				var itemName = tv_Components2.SelectedNode.Name;
				selectedItem2 = ItemHelper.FindItemByName(itemName);
				AddInfoToListBox(itemName);
			}

			if (selectedItem1 != null && selectedItem2 != null)
			{
				lb_Components.Items.Add("");
				lb_Components.Items.Add(ItemHelper.CompareItems(selectedItem1, Convert.ToInt32(num_Item1Count.Value), selectedItem2, Convert.ToInt32(num_Item2Count.Value)));
			}
		}

		private void num_Item1Count_ValueChanged(object sender, EventArgs e)
		{
			UpdateInfo();
		}

		private void num_Item2Count_ValueChanged(object sender, EventArgs e)
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
