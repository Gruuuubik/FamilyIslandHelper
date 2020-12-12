using FamilyIslandHelper.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FamilyIslandHelper
{
	public partial class Form1 : Form
	{
		private const string folderWithPictures = "Pictures";
		private string currentBuildingName;

		private readonly Dictionary<string, int> dictImagesIndexes = new Dictionary<string, int>();

		public Form1()
		{
			InitializeComponent();

			InitBuildings();

			treeView1.ImageList = GetImageList();
		}

		private void InitBuildings()
		{
			cb_Buildings.Items.AddRange(GetBuildingsNames());
			cb_Buildings.SelectedIndex = 0;
		}

		private string[] GetBuildingsNames()
		{
			var buildingsDirectories = Directory.GetDirectories(folderWithPictures);
			var buildingsNames = buildingsDirectories.Select(b => b.Split('\\').Last()).ToArray();

			return buildingsNames;
		}

		private void InitPanels(List<string> itemsPathes)
		{
			pnl_Main.Controls.Clear();

			for (var i = 0; i < itemsPathes.Count; i++)
			{
				var panel = new Panel
				{
					Tag = GetItemNameByPath(itemsPathes[i]),
					Size = new Size(60, 60),
					BackgroundImage = Image.FromFile(itemsPathes[i]),
					BackgroundImageLayout = ImageLayout.Stretch,
					Cursor = Cursors.Hand,
					Location = new Point(10 + 80 * i, 10)
				};

				panel.MouseDown += new MouseEventHandler(pnl_Item_MouseDown);

				pnl_Main.Controls.Add(panel);
			}
		}

		private void AddInfoToListBox(string buildingName, string itemTypeString)
		{
			var item = ItemCreator.CreateItem(buildingName, itemTypeString);

			listBox1.Items.Clear();
			listBox1.Items.Add(item.ToString());

			if (item is ProducableItem)
			{
				var producableItem = item as ProducableItem;

				listBox1.Items.Add("");
				listBox1.Items.Add("Components:");

				foreach (var componentInfo in producableItem.ComponentsInfo(0))
				{
					listBox1.Items.Add(componentInfo);
				}

				listBox1.Items.Add("");
				listBox1.Items.Add("Итого: " + producableItem.TotalProduceTime);
			}
		}

		private void AddInfoToTreeView(string buildingName, string itemTypeString)
		{
			var item = ItemCreator.CreateItem(buildingName, itemTypeString);

			treeView1.Nodes.Clear();

			var imageIndex = GetImageIndex(itemTypeString);
			var treeNode = new TreeNode(item.Name, imageIndex, imageIndex)
			{
				Name = item.GetType().Name
			};

			treeView1.Nodes.Add(treeNode);

			AddItemComponentsToItemNode(treeView1.Nodes[0], item);

			treeView1.ExpandAll();
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

			AddInfoToTreeView(currentBuildingName, itemTypeString);
			//AddInfoToListBox(currentBuildingName, itemTypeString);
		}

		private void cb_Buildings_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentBuildingName = cb_Buildings.SelectedItem.ToString();
			listBox1.Items.Clear();

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

			var buildingsNames = GetBuildingsNames();

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
	}
}
