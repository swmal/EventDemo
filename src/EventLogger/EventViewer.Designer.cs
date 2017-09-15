namespace EventLogger
{
    partial class EventViewer
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
            this.textBox_Payload = new System.Windows.Forms.TextBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Payload
            // 
            this.textBox_Payload.Location = new System.Drawing.Point(13, 90);
            this.textBox_Payload.Multiline = true;
            this.textBox_Payload.Name = "textBox_Payload";
            this.textBox_Payload.ReadOnly = true;
            this.textBox_Payload.Size = new System.Drawing.Size(607, 345);
            this.textBox_Payload.TabIndex = 0;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(545, 445);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 1;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // EventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 480);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.textBox_Payload);
            this.Name = "EventViewer";
            this.Text = "EventViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Payload;
        private System.Windows.Forms.Button button_Close;
    }
}