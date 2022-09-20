namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotPutawayComplete
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
            this.button_LotPutawayComplete = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.label_shelfId = new System.Windows.Forms.Label();
            this.textBox_shelfId = new System.Windows.Forms.TextBox();
            this.label_isComplete = new System.Windows.Forms.Label();
            this.textBox_isComplete = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LotPutawayComplete
            // 
            this.button_LotPutawayComplete.Location = new System.Drawing.Point(233, 83);
            this.button_LotPutawayComplete.Name = "button_LotPutawayComplete";
            this.button_LotPutawayComplete.Size = new System.Drawing.Size(105, 61);
            this.button_LotPutawayComplete.TabIndex = 0;
            this.button_LotPutawayComplete.Text = "send";
            this.button_LotPutawayComplete.UseVisualStyleBackColor = true;
            this.button_LotPutawayComplete.Click += new System.EventHandler(this.button_LotPutawayComplete_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(53, 59);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(102, 56);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(53, 94);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 1;
            this.label_lotId.Text = "lotId";
            this.label_lotId.Click += new System.EventHandler(this.label_lotId_Click);
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(102, 91);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotId.TabIndex = 2;
            this.textBox_lotId.TextChanged += new System.EventHandler(this.textBox_lotId_TextChanged);
            // 
            // label_shelfId
            // 
            this.label_shelfId.AutoSize = true;
            this.label_shelfId.Location = new System.Drawing.Point(37, 129);
            this.label_shelfId.Name = "label_shelfId";
            this.label_shelfId.Size = new System.Drawing.Size(56, 18);
            this.label_shelfId.TabIndex = 1;
            this.label_shelfId.Text = "shelfId";
            this.label_shelfId.Click += new System.EventHandler(this.label_lotId_Click);
            // 
            // textBox_shelfId
            // 
            this.textBox_shelfId.Location = new System.Drawing.Point(102, 126);
            this.textBox_shelfId.Name = "textBox_shelfId";
            this.textBox_shelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_shelfId.TabIndex = 2;
            this.textBox_shelfId.TextChanged += new System.EventHandler(this.textBox_lotId_TextChanged);
            // 
            // label_isComplete
            // 
            this.label_isComplete.AutoSize = true;
            this.label_isComplete.Location = new System.Drawing.Point(10, 164);
            this.label_isComplete.Name = "label_isComplete";
            this.label_isComplete.Size = new System.Drawing.Size(86, 18);
            this.label_isComplete.TabIndex = 1;
            this.label_isComplete.Text = "isComplete";
            this.label_isComplete.Click += new System.EventHandler(this.label_lotId_Click);
            // 
            // textBox_isComplete
            // 
            this.textBox_isComplete.Location = new System.Drawing.Point(102, 161);
            this.textBox_isComplete.Name = "textBox_isComplete";
            this.textBox_isComplete.Size = new System.Drawing.Size(100, 29);
            this.textBox_isComplete.TabIndex = 2;
            this.textBox_isComplete.TextChanged += new System.EventHandler(this.textBox_lotId_TextChanged);
            // 
            // WESLotPutawayComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 249);
            this.Controls.Add(this.textBox_isComplete);
            this.Controls.Add(this.label_isComplete);
            this.Controls.Add(this.textBox_shelfId);
            this.Controls.Add(this.label_shelfId);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_LotPutawayComplete);
            this.Name = "WESLotPutawayComplete";
            this.Text = "LotPutawayComplete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LotPutawayComplete;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_lotId;
        private System.Windows.Forms.Label label_shelfId;
        private System.Windows.Forms.TextBox textBox_shelfId;
        private System.Windows.Forms.Label label_isComplete;
        private System.Windows.Forms.TextBox textBox_isComplete;
    }
}