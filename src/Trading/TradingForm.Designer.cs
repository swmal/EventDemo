namespace Trading
{
    partial class TradingForm
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
            this.components = new System.ComponentModel.Container();
            this.panel_MessageReceived = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView_Inventory = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NoBookings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Allotment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Yield = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel_EventPublished = new System.Windows.Forms.Panel();
            this.button_Replay = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.contextMenuStrip_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeOffSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeOnSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_MessageReceived
            // 
            this.panel_MessageReceived.Location = new System.Drawing.Point(231, 13);
            this.panel_MessageReceived.Name = "panel_MessageReceived";
            this.panel_MessageReceived.Size = new System.Drawing.Size(107, 24);
            this.panel_MessageReceived.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(20, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Products";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(502, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView_Inventory
            // 
            this.listView_Inventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Product,
            this.NoBookings,
            this.State,
            this.Cost,
            this.InitPrice,
            this.Price,
            this.Allotment,
            this.Yield});
            this.listView_Inventory.FullRowSelect = true;
            this.listView_Inventory.Location = new System.Drawing.Point(26, 80);
            this.listView_Inventory.Name = "listView_Inventory";
            this.listView_Inventory.Size = new System.Drawing.Size(680, 185);
            this.listView_Inventory.TabIndex = 3;
            this.listView_Inventory.UseCompatibleStateImageBehavior = false;
            this.listView_Inventory.View = System.Windows.Forms.View.Details;
            this.listView_Inventory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Inventory_MouseClick);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 25;
            // 
            // Product
            // 
            this.Product.Text = "Product";
            this.Product.Width = 70;
            // 
            // NoBookings
            // 
            this.NoBookings.Text = "Bookings";
            this.NoBookings.Width = 70;
            // 
            // State
            // 
            this.State.Text = "State";
            // 
            // Cost
            // 
            this.Cost.Text = "Cost";
            this.Cost.Width = 40;
            // 
            // InitPrice
            // 
            this.InitPrice.Text = "Init price";
            this.InitPrice.Width = 70;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 40;
            // 
            // Allotment
            // 
            this.Allotment.Text = "Allot";
            // 
            // Yield
            // 
            this.Yield.Text = "Yield adj.";
            // 
            // panel_EventPublished
            // 
            this.panel_EventPublished.Location = new System.Drawing.Point(60, 13);
            this.panel_EventPublished.Name = "panel_EventPublished";
            this.panel_EventPublished.Size = new System.Drawing.Size(107, 24);
            this.panel_EventPublished.TabIndex = 1;
            // 
            // button_Replay
            // 
            this.button_Replay.Location = new System.Drawing.Point(147, 290);
            this.button_Replay.Name = "button_Replay";
            this.button_Replay.Size = new System.Drawing.Size(201, 23);
            this.button_Replay.TabIndex = 4;
            this.button_Replay.Text = "Consume replayed events";
            this.button_Replay.UseVisualStyleBackColor = true;
            this.button_Replay.Click += new System.EventHandler(this.button_Replay_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(398, 290);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 5;
            this.button_Clear.Text = "Clear data";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Status.Location = new System.Drawing.Point(497, 28);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(0, 17);
            this.label_Status.TabIndex = 6;
            this.label_Status.Visible = false;
            // 
            // contextMenuStrip_Options
            // 
            this.contextMenuStrip_Options.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeOffSaleToolStripMenuItem,
            this.takeOnSaleToolStripMenuItem});
            this.contextMenuStrip_Options.Name = "contextMenuStrip_Options";
            this.contextMenuStrip_Options.Size = new System.Drawing.Size(176, 80);
            // 
            // takeOffSaleToolStripMenuItem
            // 
            this.takeOffSaleToolStripMenuItem.Name = "takeOffSaleToolStripMenuItem";
            this.takeOffSaleToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.takeOffSaleToolStripMenuItem.Text = "Take off sale";
            this.takeOffSaleToolStripMenuItem.Click += new System.EventHandler(this.takeOffSaleToolStripMenuItem_Click);
            // 
            // takeOnSaleToolStripMenuItem
            // 
            this.takeOnSaleToolStripMenuItem.Name = "takeOnSaleToolStripMenuItem";
            this.takeOnSaleToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.takeOnSaleToolStripMenuItem.Text = "Take on sale";
            this.takeOnSaleToolStripMenuItem.Click += new System.EventHandler(this.takeOnSaleToolStripMenuItem_Click);
            // 
            // TradingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(750, 319);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Replay);
            this.Controls.Add(this.panel_EventPublished);
            this.Controls.Add(this.listView_Inventory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel_MessageReceived);
            this.Name = "TradingForm";
            this.Text = "Trading";
            this.contextMenuStrip_Options.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_MessageReceived;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView_Inventory;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Product;
        private System.Windows.Forms.ColumnHeader Cost;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Yield;
        private System.Windows.Forms.Panel panel_EventPublished;
        private System.Windows.Forms.ColumnHeader NoBookings;
        private System.Windows.Forms.ColumnHeader Allotment;
        private System.Windows.Forms.ColumnHeader InitPrice;
        private System.Windows.Forms.Button button_Replay;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Options;
        private System.Windows.Forms.ToolStripMenuItem takeOffSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeOnSaleToolStripMenuItem;
    }
}

