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

			treeView1.ImageList = GetImageList();
		}

		private void InitBuildings()
		{
			cb_Buildings.DataSource = GetBuildingsClasses();
			cb_Buildings.DisplayMember = "Name";
			cb_Buildings.ValueMember = "Value";

			cb_Buildings.SelectedIndex = 0;
		}

		private List<BuildingInfo> GetBuildingsClasses()
		{
			var buildingsClasses = ItemHelper.GetClasses("FamilyIslandHelper.Models.Buildings", true).ToList();

			return buildingsClasses.Select(bc => new BuildingInfo { Value = bc.Name, Name = bc.GetFields()[0].GetValue(null).ToString() }).ToList();
		}

		private void InitPanels(List<string> itemsPathes)
		{
			var panels = new Control[itemsPathes.Count];

			for (var i = 0; i < itemsPathes.Count; i++)
			{
				var panel = new Panel
				{
					Tag = GetItemNameByPath(itemsPathes[i]),
					Size = new Size(60, 60),
					BackgroundImage = Image.FromFile(itemsPathes[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand
				};

				panel.MouseDown += new MouseEventHandler(pnl_Item_MouseDown);

				panels[i] = panel;
			}

			panels = panels.OrderBy(p => ItemHelper.CreateProducableItem(cb_Buildings.SelectedValue.ToString(), p.Tag.ToString()).LevelWhenAppears)
				.ThenBy(p => ItemHelper.CreateProducableItem(cb_Buildings.SelectedValue.ToString(), p.Tag.ToString()).TotalProduceTime).ToArray();

			for (var i = 0; i < panels.Length; i++)
			{
				panels[i].Location = new Point(10 + 80 * i, 10);
			}

			pnl_Main.Controls.Clear();
			pnl_Main.Controls.AddRange(panels);
		}

		private void AddInfoToListBox(string itemName)
		{
			var item = ItemHelper.FindItemByName(itemName);

			listBox1.Items.Clear();
			listBox1.Items.Add(item.ToString());

			if (item is ProducableItem)
			{
				var producableItem = item as ProducableItem;

				if (ShowListOfComponents)
				{
					listBox1.Items.Add("");
					listBox1.Items.Add("Components:");

					foreach (var componentInfo in producableItem.ComponentsInfo(0))
					{
						listBox1.Items.Add(componentInfo);
					}
				}

				listBox1.Items.Add("");
				listBox1.Items.Add("Итого времени на производство: " + producableItem.TotalProduceTime);
			}
		}

		private void AddInfoToTreeView(Item item, string itemTypeString)
		{
			treeView1.Nodes.Clear();

			var imageIndex = GetImageIndex(itemTypeString);
			var treeNode = new TreeNode(item.Name, imageIndex, imageIndex)
			{
				Name = item.GetType().Name
			};

			treeView1.Nodes.Add(treeNode);

			AddItemComponentsToItemNode(treeView1.Nodes[0], item);

			treeView1.ExpandAll();

			treeView1.SelectedNode = treeView1.Nodes[0];
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
			var itemTypeString = ((Panel) sender).Tag.ToString();
			listBox1.Items.Clear();

			var currentBuildingName = cb_Buildings.SelectedValue.ToString();
			var item = ItemHelper.CreateProducableItem(currentBuildingName, itemTypeString);

			AddInfoToTreeView(item, itemTypeString);
		}

		private void cb_Buildings_SelectedIndexChanged(object sender, EventArgs e)
		{
			var currentBuildingName = cb_Buildings.SelectedValue.ToString();
			listBox1.Items.Clear();
			treeView1.Nodes.Clear();

			var itemsPathes = Directory.GetFiles($"{folderWithPictures}\\{currentBuildingName}").ToList();

			InitPanels(itemsPathes);
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

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			AddInfoToListBox(treeView1.SelectedNode.Name);
		}

		private void rb_Ratio_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton)sender;

			if (radioButton.Checked)
			{
				GlobalSettings.ProduceRatio = double.Parse(radioButton.Text);

				if (treeView1.SelectedNode != null)
				{
					AddInfoToListBox(treeView1.SelectedNode.Name);
				}
			}
		}

		private void cb_showListOfComponents_CheckedChanged(object sender, EventArgs e)
		{
			ShowListOfComponents = cb_showListOfComponents.Checked;

			if (treeView1.SelectedNode != null)
			{
				AddInfoToListBox(treeView1.SelectedNode.Name);
			}
		}
	}
}
