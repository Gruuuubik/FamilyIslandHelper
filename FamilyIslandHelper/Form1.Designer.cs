namespace FamilyIslandHelper
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.pnl_Main = new System.Windows.Forms.Panel();
			this.cb_Buildings = new System.Windows.Forms.ComboBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(489, 180);
			this.listBox1.Margin = new System.Windows.Forms.Padding(4);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(664, 404);
			this.listBox1.TabIndex = 2;
			// 
			// pnl_Main
			// 
			this.pnl_Main.AutoScroll = true;
			this.pnl_Main.Location = new System.Drawing.Point(22, 59);
			this.pnl_Main.Name = "pnl_Main";
			this.pnl_Main.Size = new System.Drawing.Size(1131, 100);
			this.pnl_Main.TabIndex = 3;
			// 
			// cb_Buildings
			// 
			this.cb_Buildings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Buildings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_Buildings.FormattingEnabled = true;
			this.cb_Buildings.Location = new System.Drawing.Point(253, 15);
			this.cb_Buildings.Name = "cb_Buildings";
			this.cb_Buildings.Size = new System.Drawing.Size(229, 26);
			this.cb_Buildings.TabIndex = 4;
			this.cb_Buildings.SelectedIndexChanged += new System.EventHandler(this.cb_Buildings_SelectedIndexChanged);
			// 
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.treeView1.ItemHeight = 30;
			this.treeView1.Location = new System.Drawing.Point(22, 180);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(443, 404);
			this.treeView1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 611);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.cb_Buildings);
			this.Controls.Add(this.pnl_Main);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FamilyIslandHelper";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Panel pnl_Main;
		private System.Windows.Forms.ComboBox cb_Buildings;
		private System.Windows.Forms.TreeView treeView1;
	}
}

