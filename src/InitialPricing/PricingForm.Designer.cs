namespace InitialPricing
{
    partial class PricingForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView_Products = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.panel_MessageReceived = new System.Windows.Forms.Panel();
            this.button_SetPrice = new System.Windows.Forms.Button();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Product = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_State = new System.Windows.Forms.Label();
            this.groupBox_Products = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox_Products.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_Products);
            this.groupBox2.Location = new System.Drawing.Point(32, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 165);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Products";
            // 
            // listView_Products
            // 
            this.listView_Products.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Product,
            this.State,
            this.Price});
            this.listView_Products.FullRowSelect = true;
            this.listView_Products.Location = new System.Drawing.Point(12, 22);
            this.listView_Products.Name = "listView_Products";
            this.listView_Products.Size = new System.Drawing.Size(253, 119);
            this.listView_Products.TabIndex = 0;
            this.listView_Products.UseCompatibleStateImageBehavior = false;
            this.listView_Products.View = System.Windows.Forms.View.Details;
            this.listView_Products.SelectedIndexChanged += new System.EventHandler(this.listView_Products_SelectedIndexChanged);
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
            // State
            // 
            this.State.Text = "State";
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
            // button_SetPrice
            // 
            this.button_SetPrice.Location = new System.Drawing.Point(184, 110);
            this.button_SetPrice.Name = "button_SetPrice";
            this.button_SetPrice.Size = new System.Drawing.Size(75, 23);
            this.button_SetPrice.TabIndex = 1;
            this.button_SetPrice.Text = "Set Price";
            this.button_SetPrice.UseVisualStyleBackColor = true;
            this.button_SetPrice.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(182, 44);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(83, 22);
            this.textBox_Price.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price";
            // 
            // label_Product
            // 
            this.label_Product.AutoSize = true;
            this.label_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Product.Location = new System.Drawing.Point(12, 44);
            this.label_Product.Name = "label_Product";
            this.label_Product.Size = new System.Drawing.Size(0, 17);
            this.label_Product.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "State";
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_State.Location = new System.Drawing.Point(12, 88);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(46, 17);
            this.label_State.TabIndex = 6;
            this.label_State.Text = "State";
            // 
            // groupBox_Products
            // 
            this.groupBox_Products.Controls.Add(this.label_State);
            this.groupBox_Products.Controls.Add(this.label3);
            this.groupBox_Products.Controls.Add(this.label_Product);
            this.groupBox_Products.Controls.Add(this.label2);
            this.groupBox_Products.Controls.Add(this.label1);
            this.groupBox_Products.Controls.Add(this.textBox_Price);
            this.groupBox_Products.Controls.Add(this.button_SetPrice);
            this.groupBox_Products.Location = new System.Drawing.Point(32, 29);
            this.groupBox_Products.Name = "groupBox_Products";
            this.groupBox_Products.Size = new System.Drawing.Size(288, 139);
            this.groupBox_Products.TabIndex = 2;
            this.groupBox_Products.TabStop = false;
            this.groupBox_Products.Text = "Product";
            // 
            // PricingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 373);
            this.Controls.Add(this.panel_MessageReceived);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_Products);
            this.Name = "PricingForm";
            this.Text = "Pricing";
            this.groupBox2.ResumeLayout(false);
            this.groupBox_Products.ResumeLayout(false);
            this.groupBox_Products.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_Products;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Product;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_MessageReceived;
        private System.Windows.Forms.Button button_SetPrice;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.GroupBox groupBox_Products;
    }
}

