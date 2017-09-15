namespace Reservation
{
    partial class ResForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView_Inventory = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Allotment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.panel_MessageReceived = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_Bookings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_Book = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip_Book.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_Inventory);
            this.groupBox2.Location = new System.Drawing.Point(32, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 150);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventory";
            // 
            // listView_Inventory
            // 
            this.listView_Inventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Product,
            this.Allotment,
            this.Price});
            this.listView_Inventory.FullRowSelect = true;
            this.listView_Inventory.Location = new System.Drawing.Point(12, 22);
            this.listView_Inventory.Name = "listView_Inventory";
            this.listView_Inventory.Size = new System.Drawing.Size(253, 112);
            this.listView_Inventory.TabIndex = 0;
            this.listView_Inventory.UseCompatibleStateImageBehavior = false;
            this.listView_Inventory.View = System.Windows.Forms.View.Details;
            this.listView_Inventory.SelectedIndexChanged += new System.EventHandler(this.listView_Products_SelectedIndexChanged);
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
            // Allotment
            // 
            this.Allotment.Text = "Allot.";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 52;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close/Abort";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_MessageReceived
            // 
            this.panel_MessageReceived.Location = new System.Drawing.Point(52, 7);
            this.panel_MessageReceived.Name = "panel_MessageReceived";
            this.panel_MessageReceived.Size = new System.Drawing.Size(239, 16);
            this.panel_MessageReceived.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView_Bookings);
            this.groupBox1.Location = new System.Drawing.Point(29, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 165);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bookings";
            // 
            // listView_Bookings
            // 
            this.listView_Bookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.listView_Bookings.FullRowSelect = true;
            this.listView_Bookings.Location = new System.Drawing.Point(12, 22);
            this.listView_Bookings.Name = "listView_Bookings";
            this.listView_Bookings.Size = new System.Drawing.Size(253, 119);
            this.listView_Bookings.TabIndex = 0;
            this.listView_Bookings.UseCompatibleStateImageBehavior = false;
            this.listView_Bookings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price";
            this.columnHeader4.Width = 52;
            // 
            // contextMenuStrip_Book
            // 
            this.contextMenuStrip_Book.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Book.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem});
            this.contextMenuStrip_Book.Name = "contextMenuStrip_Book";
            this.contextMenuStrip_Book.Size = new System.Drawing.Size(113, 28);
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.bookToolStripMenuItem.Text = "Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // ResForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel_MessageReceived);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ResForm";
            this.Text = "Reservation";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip_Book.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_Inventory;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Product;
        private System.Windows.Forms.ColumnHeader Allotment;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_MessageReceived;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView_Bookings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Book;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
    }
}

