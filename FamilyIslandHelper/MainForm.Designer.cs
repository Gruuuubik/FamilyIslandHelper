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
			this.cb_Buildings1 = new System.Windows.Forms.ComboBox();
			this.cb_showListOfComponents = new System.Windows.Forms.CheckBox();
			this.gb_Component1 = new System.Windows.Forms.GroupBox();
			this.num_Item1Count = new System.Windows.Forms.NumericUpDown();
			this.tv_Components1 = new System.Windows.Forms.TreeView();
			this.pnl_Items1 = new System.Windows.Forms.Panel();
			this.lb_Components = new System.Windows.Forms.ListBox();
			this.gb_Component2 = new System.Windows.Forms.GroupBox();
			this.num_Item2Count = new System.Windows.Forms.NumericUpDown();
			this.tv_Components2 = new System.Windows.Forms.TreeView();
			this.pnl_Items2 = new System.Windows.Forms.Panel();
			this.cb_Buildings2 = new System.Windows.Forms.ComboBox();
			this.gb_Component1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_Item1Count)).BeginInit();
			this.gb_Component2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_Item2Count)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_Buildings1
			// 
			this.cb_Buildings1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Buildings1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_Buildings1.FormattingEnabled = true;
			this.cb_Buildings1.Location = new System.Drawing.Point(18, 33);
			this.cb_Buildings1.Name = "cb_Buildings1";
			this.cb_Buildings1.Size = new System.Drawing.Size(229, 32);
			this.cb_Buildings1.TabIndex = 4;
			this.cb_Buildings1.Tag = "1";
			// 
			// cb_showListOfComponents
			// 
			this.cb_showListOfComponents.AutoSize = true;
			this.cb_showListOfComponents.Location = new System.Drawing.Point(281, 12);
			this.cb_showListOfComponents.Name = "cb_showListOfComponents";
			this.cb_showListOfComponents.Size = new System.Drawing.Size(212, 24);
			this.cb_showListOfComponents.TabIndex = 10;
			this.cb_showListOfComponents.Text = "ShowListOfComponents";
			this.cb_showListOfComponents.UseVisualStyleBackColor = true;
			this.cb_showListOfComponents.CheckedChanged += new System.EventHandler(this.cb_showListOfComponents_CheckedChanged);
			// 
			// gb_Component1
			// 
			this.gb_Component1.Controls.Add(this.num_Item1Count);
			this.gb_Component1.Controls.Add(this.tv_Components1);
			this.gb_Component1.Controls.Add(this.pnl_Items1);
			this.gb_Component1.Controls.Add(this.cb_Buildings1);
			this.gb_Component1.Location = new System.Drawing.Point(12, 37);
			this.gb_Component1.Name = "gb_Component1";
			this.gb_Component1.Size = new System.Drawing.Size(475, 662);
			this.gb_Component1.TabIndex = 13;
			this.gb_Component1.TabStop = false;
			this.gb_Component1.Text = "Component1";
			// 
			// num_Item1Count
			// 
			this.num_Item1Count.Location = new System.Drawing.Point(341, 36);
			this.num_Item1Count.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.num_Item1Count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Item1Count.Name = "num_Item1Count";
			this.num_Item1Count.Size = new System.Drawing.Size(120, 26);
			this.num_Item1Count.TabIndex = 7;
			this.num_Item1Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Item1Count.ValueChanged += new System.EventHandler(this.num_Item1Count_ValueChanged);
			// 
			// tv_Components1
			// 
			this.tv_Components1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tv_Components1.ItemHeight = 30;
			this.tv_Components1.Location = new System.Drawing.Point(18, 201);
			this.tv_Components1.Name = "tv_Components1";
			this.tv_Components1.Size = new System.Drawing.Size(443, 440);
			this.tv_Components1.TabIndex = 6;
			this.tv_Components1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Components_AfterSelect);
			// 
			// pnl_Items1
			// 
			this.pnl_Items1.AutoScroll = true;
			this.pnl_Items1.Location = new System.Drawing.Point(18, 77);
			this.pnl_Items1.Name = "pnl_Items1";
			this.pnl_Items1.Size = new System.Drawing.Size(443, 100);
			this.pnl_Items1.TabIndex = 5;
			// 
			// lb_Components
			// 
			this.lb_Components.FormattingEnabled = true;
			this.lb_Components.HorizontalScrollbar = true;
			this.lb_Components.ItemHeight = 20;
			this.lb_Components.Location = new System.Drawing.Point(497, 37);
			this.lb_Components.Margin = new System.Windows.Forms.Padding(4);
			this.lb_Components.Name = "lb_Components";
			this.lb_Components.Size = new System.Drawing.Size(333, 644);
			this.lb_Components.TabIndex = 14;
			// 
			// gb_Component2
			// 
			this.gb_Component2.Controls.Add(this.num_Item2Count);
			this.gb_Component2.Controls.Add(this.tv_Components2);
			this.gb_Component2.Controls.Add(this.pnl_Items2);
			this.gb_Component2.Controls.Add(this.cb_Buildings2);
			this.gb_Component2.Location = new System.Drawing.Point(845, 37);
			this.gb_Component2.Name = "gb_Component2";
			this.gb_Component2.Size = new System.Drawing.Size(475, 661);
			this.gb_Component2.TabIndex = 14;
			this.gb_Component2.TabStop = false;
			this.gb_Component2.Text = "Component2";
			// 
			// num_Item2Count
			// 
			this.num_Item2Count.Location = new System.Drawing.Point(341, 36);
			this.num_Item2Count.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.num_Item2Count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Item2Count.Name = "num_Item2Count";
			this.num_Item2Count.Size = new System.Drawing.Size(120, 26);
			this.num_Item2Count.TabIndex = 8;
			this.num_Item2Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Item2Count.ValueChanged += new System.EventHandler(this.num_Item2Count_ValueChanged);
			// 
			// tv_Components2
			// 
			this.tv_Components2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tv_Components2.ItemHeight = 30;
			this.tv_Components2.Location = new System.Drawing.Point(18, 201);
			this.tv_Components2.Name = "tv_Components2";
			this.tv_Components2.Size = new System.Drawing.Size(443, 440);
			this.tv_Components2.TabIndex = 6;
			this.tv_Components2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Components_AfterSelect);
			// 
			// pnl_Items2
			// 
			this.pnl_Items2.AutoScroll = true;
			this.pnl_Items2.Location = new System.Drawing.Point(18, 77);
			this.pnl_Items2.Name = "pnl_Items2";
			this.pnl_Items2.Size = new System.Drawing.Size(443, 100);
			this.pnl_Items2.TabIndex = 5;
			// 
			// cb_Buildings2
			// 
			this.cb_Buildings2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Buildings2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_Buildings2.FormattingEnabled = true;
			this.cb_Buildings2.Location = new System.Drawing.Point(18, 33);
			this.cb_Buildings2.Name = "cb_Buildings2";
			this.cb_Buildings2.Size = new System.Drawing.Size(229, 32);
			this.cb_Buildings2.TabIndex = 4;
			this.cb_Buildings2.Tag = "2";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1334, 711);
			this.Controls.Add(this.gb_Component2);
			this.Controls.Add(this.lb_Components);
			this.Controls.Add(this.gb_Component1);
			this.Controls.Add(this.cb_showListOfComponents);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FamilyIslandHelper";
			this.gb_Component1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num_Item1Count)).EndInit();
			this.gb_Component2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num_Item2Count)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox cb_Buildings1;
		private System.Windows.Forms.CheckBox cb_showListOfComponents;
		private System.Windows.Forms.GroupBox gb_Component1;
		private System.Windows.Forms.Panel pnl_Items1;
		private System.Windows.Forms.TreeView tv_Components1;
		private System.Windows.Forms.ListBox lb_Components;
		private System.Windows.Forms.GroupBox gb_Component2;
		private System.Windows.Forms.TreeView tv_Components2;
		private System.Windows.Forms.Panel pnl_Items2;
		private System.Windows.Forms.ComboBox cb_Buildings2;
        private System.Windows.Forms.NumericUpDown num_Item1Count;
        private System.Windows.Forms.NumericUpDown num_Item2Count;
    }
}

