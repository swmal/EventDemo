namespace EventLogger
{
    partial class EventLoggerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_Events = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Exchange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoutingKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_CloseAbort = new System.Windows.Forms.Button();
            this.button_Replay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listView_Events);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Events";
            // 
            // listView_Events
            // 
            this.listView_Events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.TimeStamp,
            this.Exchange,
            this.RoutingKey});
            this.listView_Events.FullRowSelect = true;
            this.listView_Events.Location = new System.Drawing.Point(19, 21);
            this.listView_Events.Name = "listView_Events";
            this.listView_Events.Size = new System.Drawing.Size(415, 148);
            this.listView_Events.TabIndex = 1;
            this.listView_Events.UseCompatibleStateImageBehavior = false;
            this.listView_Events.View = System.Windows.Forms.View.Details;
            this.listView_Events.SelectedIndexChanged += new System.EventHandler(this.listView_Events_SelectedIndexChanged);
            this.listView_Events.DoubleClick += new System.EventHandler(this.listView_Events_DoubleClick);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 70;
            // 
            // TimeStamp
            // 
            this.TimeStamp.Text = "Timestamp";
            this.TimeStamp.Width = 100;
            // 
            // Exchange
            // 
            this.Exchange.Text = "Exchange";
            this.Exchange.Width = 72;
            // 
            // RoutingKey
            // 
            this.RoutingKey.Text = "Routing key";
            this.RoutingKey.Width = 70;
            // 
            // button_CloseAbort
            // 
            this.button_CloseAbort.Location = new System.Drawing.Point(366, 342);
            this.button_CloseAbort.Name = "button_CloseAbort";
            this.button_CloseAbort.Size = new System.Drawing.Size(100, 23);
            this.button_CloseAbort.TabIndex = 1;
            this.button_CloseAbort.Text = "Close/Abort";
            this.button_CloseAbort.UseVisualStyleBackColor = true;
            this.button_CloseAbort.Click += new System.EventHandler(this.button_CloseAbort_Click);
            // 
            // button_Replay
            // 
            this.button_Replay.Location = new System.Drawing.Point(266, 342);
            this.button_Replay.Name = "button_Replay";
            this.button_Replay.Size = new System.Drawing.Size(94, 23);
            this.button_Replay.TabIndex = 2;
            this.button_Replay.Text = "Replay";
            this.button_Replay.UseVisualStyleBackColor = true;
            this.button_Replay.Click += new System.EventHandler(this.button_Replay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.BackColor = System.Drawing.Color.White;
            this.label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Status.Location = new System.Drawing.Point(12, 111);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(59, 20);
            this.label_Status.TabIndex = 3;
            this.label_Status.Text = "label2";
            // 
            // EventLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(479, 370);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button_Replay);
            this.Controls.Add(this.button_CloseAbort);
            this.Controls.Add(this.groupBox1);
            this.Name = "EventLoggerForm";
            this.Text = "Event logger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView_Events;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader TimeStamp;
        private System.Windows.Forms.ColumnHeader Exchange;
        private System.Windows.Forms.ColumnHeader RoutingKey;
        private System.Windows.Forms.Button button_CloseAbort;
        private System.Windows.Forms.Button button_Replay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Status;
    }
}

