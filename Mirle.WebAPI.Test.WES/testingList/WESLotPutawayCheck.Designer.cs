namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotPutawayCheck
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
            this.button_LotPutawayCheck = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_portId = new System.Windows.Forms.Label();
            this.textBox_portId = new System.Windows.Forms.TextBox();
            this.label_lotId = new System.Windows.Forms.Label();
            this.textBox_lotId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LotPutawayCheck
            // 
            this.button_LotPutawayCheck.Location = new System.Drawing.Point(248, 67);
            this.button_LotPutawayCheck.Name = "button_LotPutawayCheck";
            this.button_LotPutawayCheck.Size = new System.Drawing.Size(83, 105);
            this.button_LotPutawayCheck.TabIndex = 0;
            this.button_LotPutawayCheck.Text = "send";
            this.button_LotPutawayCheck.UseVisualStyleBackColor = true;
            this.button_LotPutawayCheck.Click += new System.EventHandler(this.button_LotPutawayCheck_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(42, 75);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(105, 72);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_portId
            // 
            this.label_portId.AutoSize = true;
            this.label_portId.Location = new System.Drawing.Point(42, 110);
            this.label_portId.Name = "label_portId";
            this.label_portId.Size = new System.Drawing.Size(49, 18);
            this.label_portId.TabIndex = 1;
            this.label_portId.Text = "portId";
            // 
            // textBox_portId
            // 
            this.textBox_portId.Location = new System.Drawing.Point(105, 107);
            this.textBox_portId.Name = "textBox_portId";
            this.textBox_portId.Size = new System.Drawing.Size(100, 29);
            this.textBox_portId.TabIndex = 2;
            // 
            // label_lotId
            // 
            this.label_lotId.AutoSize = true;
            this.label_lotId.Location = new System.Drawing.Point(42, 145);
            this.label_lotId.Name = "label_lotId";
            this.label_lotId.Size = new System.Drawing.Size(40, 18);
            this.label_lotId.TabIndex = 1;
            this.label_lotId.Text = "lotId";
            // 
            // textBox_lotId
            // 
            this.textBox_lotId.Location = new System.Drawing.Point(105, 142);
            this.textBox_lotId.Name = "textBox_lotId";
            this.textBox_lotId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotId.TabIndex = 2;
            // 
            // WESLotPutawayCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 285);
            this.Controls.Add(this.textBox_lotId);
            this.Controls.Add(this.label_lotId);
            this.Controls.Add(this.textBox_portId);
            this.Controls.Add(this.label_portId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_LotPutawayCheck);
            this.Name = "WESLotPutawayCheck";
            this.Text = "LotPutawayCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LotPutawayCheck;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_portId;
        private System.Windows.Forms.TextBox textBox_portId;
        private System.Windows.Forms.Label label_lotId;
        private System.Windows.Forms.TextBox textBox_lotId;
    }
}