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
		}

		private void InitBuildings()
		{
			var buildingsDirectories = Directory.GetDirectories(folderWithPictures);
			var buildingsNames = buildingsDirectories.Select(b => b.Split('\\').Last()).ToArray();

			cb_Buildings.Items.AddRange(buildingsNames);
			cb_Buildings.SelectedIndex = 0;
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
			var treeNode = new TreeNode(item.Name, imageIndex, imageIndex);

			treeView1.Nodes.Add(treeNode);

			AddItemComponentsToItemNode(treeView1.Nodes[0], item);

			treeView1.ExpandAll();
		}

		private void AddItemComponentsToItemNode(TreeNode treeNode, Item item)
		{
			if (item is ProducableItem)
			{
				var producableItem = item as ProducableItem;

				for (var i = 0; i < producableItem.Components.Count; i++)
				{
					treeNode.Nodes.Add(producableItem.Components[i].item.Name);

					AddItemComponentsToItemNode(treeNode.Nodes[i], producableItem.Components[i].item);
				}
			}
		}

		private void pnl_Item_MouseDown(object sender, MouseEventArgs e)
		{
			var itemTypeString = ((Panel) sender).Tag.ToString();

			AddInfoToTreeView(currentBuildingName, itemTypeString);
			AddInfoToListBox(currentBuildingName, itemTypeString);
		}

		private void cb_Buildings_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentBuildingName = cb_Buildings.SelectedItem.ToString();
			listBox1.Items.Clear();

			var itemsPathes = Directory.GetFiles($"{folderWithPictures}\\{currentBuildingName}").ToList();

			treeView1.ImageList = GetImageList(itemsPathes);

			InitPanels(itemsPathes);
		}

		private ImageList GetImageList(List<string> itemsPathes)
		{
			dictImagesIndexes.Clear();

			var imageList = new ImageList
			{
				ImageSize = new Size(30, 30)
			};

			for (var i = 0; i < itemsPathes.Count; i++)
			{
				dictImagesIndexes.Add(GetItemNameByPath(itemsPathes[i]), i);

				imageList.Images.Add(Image.FromFile(itemsPathes[i]));
			}

			return imageList;
		}

		private int GetImageIndex(string itemName)
		{
			return dictImagesIndexes[itemName];
		}

		private string GetItemNameByPath(string itemPath)
		{
			return itemPath.Split('.').First().Split('\\').Last();
		}
	}
}
