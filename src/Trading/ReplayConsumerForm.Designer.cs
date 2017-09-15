namespace Trading
{
    partial class ReplayConsumerForm
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
            this.button_Consume = new System.Windows.Forms.Button();
            this.label_EventStatus = new System.Windows.Forms.Label();
            this.button_Quit = new System.Windows.Forms.Button();
            this.label_ConnectionStatus = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Consume
            // 
            this.button_Consume.Location = new System.Drawing.Point(12, 218);
            this.button_Consume.Name = "button_Consume";
            this.button_Consume.Size = new System.Drawing.Size(95, 23);
            this.button_Consume.TabIndex = 0;
            this.button_Consume.Text = "Consume";
            this.button_Consume.UseVisualStyleBackColor = true;
            this.button_Consume.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_EventStatus
            // 
            this.label_EventStatus.AutoSize = true;
            this.label_EventStatus.Location = new System.Drawing.Point(58, 67);
            this.label_EventStatus.Name = "label_EventStatus";
            this.label_EventStatus.Size = new System.Drawing.Size(137, 17);
            this.label_EventStatus.TabIndex = 1;
            this.label_EventStatus.Text = "Consumed events: 0";
            // 
            // button_Quit
            // 
            this.button_Quit.Location = new System.Drawing.Point(120, 218);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(75, 23);
            this.button_Quit.TabIndex = 2;
            this.button_Quit.Text = "Replay";
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // label_ConnectionStatus
            // 
            this.label_ConnectionStatus.AutoSize = true;
            this.label_ConnectionStatus.Location = new System.Drawing.Point(61, 30);
            this.label_ConnectionStatus.Name = "label_ConnectionStatus";
            this.label_ConnectionStatus.Size = new System.Drawing.Size(78, 17);
            this.label_ConnectionStatus.TabIndex = 3;
            this.label_ConnectionStatus.Text = "Status: idle";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(202, 218);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 4;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // ReplayConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_ConnectionStatus);
            this.Controls.Add(this.button_Quit);
            this.Controls.Add(this.label_EventStatus);
            this.Controls.Add(this.button_Consume);
            this.Name = "ReplayConsumerForm";
            this.Text = "ReplayForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Consume;
        private System.Windows.Forms.Label label_EventStatus;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Label label_ConnectionStatus;
        private System.Windows.Forms.Button button_Close;
    }
}