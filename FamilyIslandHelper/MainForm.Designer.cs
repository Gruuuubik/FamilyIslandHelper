namespace FamilyIslandHelper
{
	partial class MainForm
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
			this.rb_Ratio_1_0 = new System.Windows.Forms.RadioButton();
			this.rb_Ratio_1_2 = new System.Windows.Forms.RadioButton();
			this.rb_Ratio_1_5 = new System.Windows.Forms.RadioButton();
			this.cb_showListOfComponents = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(489, 212);
			this.listBox1.Margin = new System.Windows.Forms.Padding(4);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(664, 372);
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
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// rb_Ratio_1_0
			// 
			this.rb_Ratio_1_0.AutoSize = true;
			this.rb_Ratio_1_0.Location = new System.Drawing.Point(732, 15);
			this.rb_Ratio_1_0.Name = "rb_Ratio_1_0";
			this.rb_Ratio_1_0.Size = new System.Drawing.Size(43, 20);
			this.rb_Ratio_1_0.TabIndex = 7;
			this.rb_Ratio_1_0.Text = "1,0";
			this.rb_Ratio_1_0.UseVisualStyleBackColor = true;
			this.rb_Ratio_1_0.CheckedChanged += new System.EventHandler(this.rb_Ratio_CheckedChanged);
			// 
			// rb_Ratio_1_2
			// 
			this.rb_Ratio_1_2.AutoSize = true;
			this.rb_Ratio_1_2.Location = new System.Drawing.Point(792, 15);
			this.rb_Ratio_1_2.Name = "rb_Ratio_1_2";
			this.rb_Ratio_1_2.Size = new System.Drawing.Size(43, 20);
			this.rb_Ratio_1_2.TabIndex = 8;
			this.rb_Ratio_1_2.TabStop = true;
			this.rb_Ratio_1_2.Text = "1,2";
			this.rb_Ratio_1_2.UseVisualStyleBackColor = true;
			this.rb_Ratio_1_2.CheckedChanged += new System.EventHandler(this.rb_Ratio_CheckedChanged);
			// 
			// rb_Ratio_1_5
			// 
			this.rb_Ratio_1_5.AutoSize = true;
			this.rb_Ratio_1_5.Checked = true;
			this.rb_Ratio_1_5.Location = new System.Drawing.Point(851, 15);
			this.rb_Ratio_1_5.Name = "rb_Ratio_1_5";
			this.rb_Ratio_1_5.Size = new System.Drawing.Size(43, 20);
			this.rb_Ratio_1_5.TabIndex = 9;
			this.rb_Ratio_1_5.TabStop = true;
			this.rb_Ratio_1_5.Text = "1,5";
			this.rb_Ratio_1_5.UseVisualStyleBackColor = true;
			this.rb_Ratio_1_5.CheckedChanged += new System.EventHandler(this.rb_Ratio_CheckedChanged);
			// 
			// cb_showListOfComponents
			// 
			this.cb_showListOfComponents.AutoSize = true;
			this.cb_showListOfComponents.Location = new System.Drawing.Point(489, 180);
			this.cb_showListOfComponents.Name = "cb_showListOfComponents";
			this.cb_showListOfComponents.Size = new System.Drawing.Size(169, 20);
			this.cb_showListOfComponents.TabIndex = 10;
			this.cb_showListOfComponents.Text = "ShowListOfComponents";
			this.cb_showListOfComponents.UseVisualStyleBackColor = true;
			this.cb_showListOfComponents.CheckedChanged += new System.EventHandler(this.cb_showListOfComponents_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 611);
			this.Controls.Add(this.cb_showListOfComponents);
			this.Controls.Add(this.rb_Ratio_1_5);
			this.Controls.Add(this.rb_Ratio_1_2);
			this.Controls.Add(this.rb_Ratio_1_0);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.cb_Buildings);
			this.Controls.Add(this.pnl_Main);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FamilyIslandHelper";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Panel pnl_Main;
		private System.Windows.Forms.ComboBox cb_Buildings;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.RadioButton rb_Ratio_1_0;
		private System.Windows.Forms.RadioButton rb_Ratio_1_2;
		private System.Windows.Forms.RadioButton rb_Ratio_1_5;
		private System.Windows.Forms.CheckBox cb_showListOfComponents;
	}
}

