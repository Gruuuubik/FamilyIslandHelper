using FamilyIslandHelper.Models;
using FamilyIslandHelper.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FamilyIslandHelper
{
	public partial class MainForm : Form
	{
		private const string folderWithPictures = "Pictures";
		private bool ShowListOfComponents = false;

		private readonly Dictionary<string, int> dictImagesIndexes = new Dictionary<string, int>();

		public MainForm()
		{
			InitializeComponent();

			cb_showListOfComponents.Checked = ShowListOfComponents;

			InitBuildings();

			ShowListOfItemsForBuildings();

			tv_Components1.ImageList = GetImageList();
			tv_Components2.ImageList = GetImageList();
		}

		private void InitBuildings()
		{
			cb_Buildings1.DataSource = GetBuildingsClasses();
			cb_Buildings1.DisplayMember = "Name";
			cb_Buildings1.ValueMember = "Value";

			cb_Buildings2.DataSource = GetBuildingsClasses();
			cb_Buildings2.DisplayMember = "Name";
			cb_Buildings2.ValueMember = "Value";

			cb_Buildings1.SelectedIndexChanged += new EventHandler(this.cb_Buildings_SelectedIndexChanged);
			cb_Buildings2.SelectedIndexChanged += new EventHandler(this.cb_Buildings_SelectedIndexChanged);
		}

		private List<BuildingInfo> GetBuildingsClasses()
		{
			var buildingsClasses = ItemHelper.GetClasses("FamilyIslandHelper.Models.Buildings", true).ToList();

			return buildingsClasses.Select(bc => new BuildingInfo { Value = bc.Name, Name = bc.GetFields()[0].GetValue(null).ToString() }).ToList();
		}

		private void AddInfoToListBox(string itemName)
		{
			var item = ItemHelper.FindItemByName(itemName);
			
			if (lb_Components.Items.Count > 0)
			{
				lb_Components.Items.Add("");
			}

			lb_Components.Items.Add(item.ToString());

			if (item is ProducableItem)
			{
				var producableItem = item as ProducableItem;

				if (ShowListOfComponents)
				{
					lb_Components.Items.Add("");
					lb_Components.Items.Add("Components:");

					foreach (var componentInfo in producableItem.ComponentsInfo(0))
					{
						lb_Components.Items.Add(componentInfo);
					}
				}

				lb_Components.Items.Add("");
				lb_Components.Items.Add("Итого времени на производство: " + producableItem.TotalProduceTime);
			}
		}

		private void AddInfoToTreeView(TreeView tv_Components, Item item, string itemTypeString)
		{
			tv_Components.Nodes.Clear();

			var imageIndex = GetImageIndex(itemTypeString);
			var treeNode = new TreeNode(item.Name, imageIndex, imageIndex)
			{
				Name = item.GetType().Name
			};

			tv_Components.Nodes.Add(treeNode);

			AddItemComponentsToItemNode(tv_Components.Nodes[0], item);

			tv_Components.ExpandAll();

			tv_Components.SelectedNode = tv_Components.Nodes[0];
		}

		private void AddItemComponentsToItemNode(TreeNode parentTreeNode, Item item)
		{
			if (item is ProducableItem)
			{
				var producableItem = item as ProducableItem;

				for (var i = 0; i < producableItem.Components.Count; i++)
				{
					var childComponent = producableItem.Components[i];
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
			var panelNumber = ((Panel)sender).Tag.ToString().Split('_')[1];

			if (panelNumber == "1")
			{
				ShowInfoForItem((Panel)sender, cb_Buildings1.SelectedValue.ToString(), tv_Components1);
			}
			else if (panelNumber == "2")
			{
				ShowInfoForItem((Panel)sender, cb_Buildings2.SelectedValue.ToString(), tv_Components2);
			}
		}

		private void ShowInfoForItem(Panel itemPanel, string currentBuildingName, TreeView tv_Components)
		{
			var panelTag = itemPanel.Tag.ToString();
			var panelInfo = panelTag.Split('_');
			var itemTypeString = panelInfo[0];
			lb_Components.Items.Clear();

			var item = ItemHelper.CreateProducableItem(currentBuildingName, itemTypeString);

			AddInfoToTreeView(tv_Components, item, itemTypeString);
		}

		private void cb_Buildings_SelectedIndexChanged(object sender, EventArgs e)
		{
			var comboBox = ((ComboBox)sender);
			ShowListOfItemsForBuilding(comboBox.SelectedValue.ToString(), int.Parse(comboBox.Tag.ToString()));
		}

		private void ShowListOfItemsForBuilding(string buildingName, int panelNumber)
		{
			var itemsPathes = Directory.GetFiles($"{folderWithPictures}\\{buildingName}").ToList();

			if (panelNumber == 1)
			{
				tv_Components1.Nodes.Clear();

				InitPanels(itemsPathes, panelNumber, pnl_Items1, buildingName);
			}
			else if (panelNumber == 2)
			{
				tv_Components2.Nodes.Clear();

				InitPanels(itemsPathes, panelNumber, pnl_Items2, buildingName);
			}
		}

		private void ShowListOfItemsForBuildings()
		{
			lb_Components.Items.Clear();

			ShowListOfItemsForBuilding(cb_Buildings1.SelectedValue.ToString(), 1);
			ShowListOfItemsForBuilding(cb_Buildings2.SelectedValue.ToString(), 2);
		}

		private void InitPanels(List<string> itemsPathes, int panelNumber, Panel pnl_Items, string buildingName)
		{
			var panels = new Control[itemsPathes.Count];
			const int size = 40;

			for (var i = 0; i < itemsPathes.Count; i++)
			{
				var panel = new Panel
				{
					Tag = GetItemNameByPath(itemsPathes[i]) + "_" + panelNumber,
					Size = new Size(size, size),
					BackgroundImage = Image.FromFile(itemsPathes[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += new MouseEventHandler(pnl_Item_MouseDown);

				panels[i] = panel;
			}

			ProducableItem getItem(Control p) => ItemHelper.CreateProducableItem(buildingName, p.Tag.ToString().Split('_')[0]);
			panels = panels.OrderBy(p => getItem(p).LevelWhenAppears).ThenBy(p => getItem(p).TotalProduceTime).ToArray();

			for (var i = 0; i < panels.Length; i++)
			{
				panels[i].Location = new Point(5 + (size + 5) * i, 10);
			}

			pnl_Items.Controls.Clear();
			pnl_Items.Controls.AddRange(panels);
		}

		private ImageList GetImageList()
		{
			dictImagesIndexes.Clear();

			var imageList = new ImageList
			{
				ImageSize = new Size(30, 30)
			};

			var buildingsNames = ItemHelper.GetClassesNames("FamilyIslandHelper.Models.Buildings", true).ToArray();

			var counter = 0;
			var itemPath = Directory.GetFiles(folderWithPictures).FirstOrDefault();
			dictImagesIndexes.Add(GetItemNameByPath(itemPath), counter);
			imageList.Images.Add(Image.FromFile(itemPath));
			counter++;

			foreach (var buildingName in buildingsNames)
			{
				var itemsPathes = Directory.GetFiles($"{folderWithPictures}\\{buildingName}").ToList();

				for (var i = 0; i < itemsPathes.Count; i++)
				{
					dictImagesIndexes.Add(GetItemNameByPath(itemsPathes[i]), counter);
					imageList.Images.Add(Image.FromFile(itemsPathes[i]));
					counter++;
				}
			}

			var resourcesPathes = Directory.GetFiles("Resources").ToList();

			for (var i = 0; i < resourcesPathes.Count; i++)
			{
				dictImagesIndexes.Add(GetItemNameByPath(resourcesPathes[i]), counter);
				imageList.Images.Add(Image.FromFile(resourcesPathes[i]));
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

		private string GetItemNameByPath(string itemPath)
		{
			return itemPath.Split('.').First().Split('\\').Last();
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
				AddInfoToListBox(tv_Components1.SelectedNode.Name);
			}

			if (tv_Components2.SelectedNode != null)
			{
				AddInfoToListBox(tv_Components2.SelectedNode.Name);
			}
		}

		private void rb_Ratio_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton)sender;

			if (radioButton.Checked)
			{
				GlobalSettings.ProduceRatio = double.Parse(radioButton.Text);

				UpdateInfo();
			}
		}

		private void cb_showListOfComponents_CheckedChanged(object sender, EventArgs e)
		{
			ShowListOfComponents = cb_showListOfComponents.Checked;

			UpdateInfo();
		}
	}
}
