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
			this.cb_showListOfComponents = new System.Windows.Forms.CheckBox();
			this.splitContainer_main = new System.Windows.Forms.SplitContainer();
			this.lbl_Ratio1 = new System.Windows.Forms.Label();
			this.num_Item1Count = new System.Windows.Forms.NumericUpDown();
			this.tv_Components1 = new System.Windows.Forms.TreeView();
			this.pnl_Items1 = new System.Windows.Forms.Panel();
			this.cb_Buildings1 = new System.Windows.Forms.ComboBox();
			this.splitContainer_second = new System.Windows.Forms.SplitContainer();
			this.lb_Components = new System.Windows.Forms.ListBox();
			this.lbl_Ratio2 = new System.Windows.Forms.Label();
			this.num_Item2Count = new System.Windows.Forms.NumericUpDown();
			this.tv_Components2 = new System.Windows.Forms.TreeView();
			this.pnl_Items2 = new System.Windows.Forms.Panel();
			this.cb_Buildings2 = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
			this.splitContainer_main.Panel1.SuspendLayout();
			this.splitContainer_main.Panel2.SuspendLayout();
			this.splitContainer_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_Item1Count)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_second)).BeginInit();
			this.splitContainer_second.Panel1.SuspendLayout();
			this.splitContainer_second.Panel2.SuspendLayout();
			this.splitContainer_second.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_Item2Count)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_showListOfComponents
			// 
			this.cb_showListOfComponents.AutoSize = true;
			this.cb_showListOfComponents.Location = new System.Drawing.Point(281, 12);
			this.cb_showListOfComponents.Name = "cb_showListOfComponents";
			this.cb_showListOfComponents.Size = new System.Drawing.Size(168, 20);
			this.cb_showListOfComponents.TabIndex = 10;
			this.cb_showListOfComponents.Text = "ShowListOfComponents";
			this.cb_showListOfComponents.UseVisualStyleBackColor = true;
			this.cb_showListOfComponents.CheckedChanged += new System.EventHandler(this.cb_showListOfComponents_CheckedChanged);
			// 
			// splitContainer_main
			// 
			this.splitContainer_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer_main.Location = new System.Drawing.Point(16, 38);
			this.splitContainer_main.Name = "splitContainer_main";
			// 
			// splitContainer_main.Panel1
			// 
			this.splitContainer_main.Panel1.Controls.Add(this.lbl_Ratio1);
			this.splitContainer_main.Panel1.Controls.Add(this.num_Item1Count);
			this.splitContainer_main.Panel1.Controls.Add(this.tv_Components1);
			this.splitContainer_main.Panel1.Controls.Add(this.pnl_Items1);
			this.splitContainer_main.Panel1.Controls.Add(this.cb_Buildings1);
			this.splitContainer_main.Panel1MinSize = 475;
			// 
			// splitContainer_main.Panel2
			// 
			this.splitContainer_main.Panel2.Controls.Add(this.splitContainer_second);
			this.splitContainer_main.Panel2MinSize = 900;
			this.splitContainer_main.Size = new System.Drawing.Size(1400, 661);
			this.splitContainer_main.SplitterDistance = 475;
			this.splitContainer_main.SplitterWidth = 10;
			this.splitContainer_main.TabIndex = 15;
			// 
			// lbl_Ratio1
			// 
			this.lbl_Ratio1.AutoSize = true;
			this.lbl_Ratio1.Location = new System.Drawing.Point(262, 26);
			this.lbl_Ratio1.Name = "lbl_Ratio1";
			this.lbl_Ratio1.Size = new System.Drawing.Size(62, 16);
			this.lbl_Ratio1.TabIndex = 13;
			this.lbl_Ratio1.Text = "Ratio: 1.5";
			// 
			// num_Item1Count
			// 
			this.num_Item1Count.Location = new System.Drawing.Point(356, 23);
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
			this.num_Item1Count.Size = new System.Drawing.Size(102, 22);
			this.num_Item1Count.TabIndex = 12;
			this.num_Item1Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Item1Count.ValueChanged += new System.EventHandler(this.num_Item1Count_ValueChanged);
			// 
			// tv_Components1
			// 
			this.tv_Components1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tv_Components1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tv_Components1.ItemHeight = 30;
			this.tv_Components1.Location = new System.Drawing.Point(15, 188);
			this.tv_Components1.Name = "tv_Components1";
			this.tv_Components1.Size = new System.Drawing.Size(443, 452);
			this.tv_Components1.TabIndex = 11;
			this.tv_Components1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Components_AfterSelect);
			// 
			// pnl_Items1
			// 
			this.pnl_Items1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnl_Items1.AutoScroll = true;
			this.pnl_Items1.Location = new System.Drawing.Point(15, 64);
			this.pnl_Items1.Name = "pnl_Items1";
			this.pnl_Items1.Size = new System.Drawing.Size(443, 100);
			this.pnl_Items1.TabIndex = 10;
			// 
			// cb_Buildings1
			// 
			this.cb_Buildings1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Buildings1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_Buildings1.FormattingEnabled = true;
			this.cb_Buildings1.Location = new System.Drawing.Point(15, 20);
			this.cb_Buildings1.Name = "cb_Buildings1";
			this.cb_Buildings1.Size = new System.Drawing.Size(229, 26);
			this.cb_Buildings1.TabIndex = 9;
			this.cb_Buildings1.Tag = "1";
			// 
			// splitContainer_second
			// 
			this.splitContainer_second.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer_second.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_second.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_second.Name = "splitContainer_second";
			// 
			// splitContainer_second.Panel1
			// 
			this.splitContainer_second.Panel1.Controls.Add(this.lb_Components);
			this.splitContainer_second.Panel1MinSize = 400;
			// 
			// splitContainer_second.Panel2
			// 
			this.splitContainer_second.Panel2.Controls.Add(this.lbl_Ratio2);
			this.splitContainer_second.Panel2.Controls.Add(this.num_Item2Count);
			this.splitContainer_second.Panel2.Controls.Add(this.tv_Components2);
			this.splitContainer_second.Panel2.Controls.Add(this.pnl_Items2);
			this.splitContainer_second.Panel2.Controls.Add(this.cb_Buildings2);
			this.splitContainer_second.Panel2MinSize = 475;
			this.splitContainer_second.Size = new System.Drawing.Size(915, 661);
			this.splitContainer_second.SplitterDistance = 430;
			this.splitContainer_second.SplitterWidth = 10;
			this.splitContainer_second.TabIndex = 0;
			// 
			// lb_Components
			// 
			this.lb_Components.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lb_Components.FormattingEnabled = true;
			this.lb_Components.HorizontalScrollbar = true;
			this.lb_Components.ItemHeight = 16;
			this.lb_Components.Location = new System.Drawing.Point(0, 0);
			this.lb_Components.Margin = new System.Windows.Forms.Padding(4);
			this.lb_Components.Name = "lb_Components";
			this.lb_Components.Size = new System.Drawing.Size(428, 659);
			this.lb_Components.TabIndex = 16;
			// 
			// lbl_Ratio2
			// 
			this.lbl_Ratio2.AutoSize = true;
			this.lbl_Ratio2.Location = new System.Drawing.Point(265, 26);
			this.lbl_Ratio2.Name = "lbl_Ratio2";
			this.lbl_Ratio2.Size = new System.Drawing.Size(62, 16);
			this.lbl_Ratio2.TabIndex = 14;
			this.lbl_Ratio2.Text = "Ratio: 1.5";
			// 
			// num_Item2Count
			// 
			this.num_Item2Count.Location = new System.Drawing.Point(362, 23);
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
			this.num_Item2Count.Size = new System.Drawing.Size(99, 22);
			this.num_Item2Count.TabIndex = 13;
			this.num_Item2Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_Item2Count.ValueChanged += new System.EventHandler(this.num_Item2Count_ValueChanged);
			// 
			// tv_Components2
			// 
			this.tv_Components2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tv_Components2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tv_Components2.ItemHeight = 30;
			this.tv_Components2.Location = new System.Drawing.Point(18, 188);
			this.tv_Components2.Name = "tv_Components2";
			this.tv_Components2.Size = new System.Drawing.Size(443, 456);
			this.tv_Components2.TabIndex = 12;
			this.tv_Components2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Components_AfterSelect);
			// 
			// pnl_Items2
			// 
			this.pnl_Items2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnl_Items2.AutoScroll = true;
			this.pnl_Items2.Location = new System.Drawing.Point(18, 64);
			this.pnl_Items2.Name = "pnl_Items2";
			this.pnl_Items2.Size = new System.Drawing.Size(443, 100);
			this.pnl_Items2.TabIndex = 11;
			// 
			// cb_Buildings2
			// 
			this.cb_Buildings2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Buildings2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_Buildings2.FormattingEnabled = true;
			this.cb_Buildings2.Location = new System.Drawing.Point(18, 20);
			this.cb_Buildings2.Name = "cb_Buildings2";
			this.cb_Buildings2.Size = new System.Drawing.Size(229, 26);
			this.cb_Buildings2.TabIndex = 10;
			this.cb_Buildings2.Tag = "2";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1434, 711);
			this.Controls.Add(this.splitContainer_main);
			this.Controls.Add(this.cb_showListOfComponents);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FamilyIslandHelper";
			this.splitContainer_main.Panel1.ResumeLayout(false);
			this.splitContainer_main.Panel1.PerformLayout();
			this.splitContainer_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
			this.splitContainer_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num_Item1Count)).EndInit();
			this.splitContainer_second.Panel1.ResumeLayout(false);
			this.splitContainer_second.Panel2.ResumeLayout(false);
			this.splitContainer_second.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_second)).EndInit();
			this.splitContainer_second.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num_Item2Count)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox cb_showListOfComponents;
		private System.Windows.Forms.SplitContainer splitContainer_main;
		private System.Windows.Forms.Label lbl_Ratio1;
		private System.Windows.Forms.NumericUpDown num_Item1Count;
		private System.Windows.Forms.TreeView tv_Components1;
		private System.Windows.Forms.Panel pnl_Items1;
		private System.Windows.Forms.ComboBox cb_Buildings1;
		private System.Windows.Forms.SplitContainer splitContainer_second;
		private System.Windows.Forms.ListBox lb_Components;
		private System.Windows.Forms.Label lbl_Ratio2;
		private System.Windows.Forms.NumericUpDown num_Item2Count;
		private System.Windows.Forms.TreeView tv_Components2;
		private System.Windows.Forms.Panel pnl_Items2;
		private System.Windows.Forms.ComboBox cb_Buildings2;
	}
}

