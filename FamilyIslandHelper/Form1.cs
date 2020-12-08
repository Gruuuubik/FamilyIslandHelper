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
					Tag = itemsPathes[i].Split('.').First().Split('\\').Last(),
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

		private void AddInfo(string buildingName, string itemTypeString)
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

		private void pnl_Item_MouseDown(object sender, MouseEventArgs e)
		{
			var itemTypeString = ((Panel) sender).Tag.ToString();

			AddInfo(currentBuildingName, itemTypeString);
		}

		private void cb_Buildings_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentBuildingName = cb_Buildings.SelectedItem.ToString();
			listBox1.Items.Clear();

			var itemsPathes = Directory.GetFiles($"{folderWithPictures}\\{currentBuildingName}").ToList();

			InitPanels(itemsPathes);
		}
	}
}
