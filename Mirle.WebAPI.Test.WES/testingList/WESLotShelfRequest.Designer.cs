namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESLotShelfRequest
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
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_fromShelfId = new System.Windows.Forms.Label();
            this.textBox_fromShelfId = new System.Windows.Forms.TextBox();
            this.label_toShelfId = new System.Windows.Forms.Label();
            this.textBox_toShelfId = new System.Windows.Forms.TextBox();
            this.button_LotShelfRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(121, 75);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            this.label_jobId.Click += new System.EventHandler(this.label_jobId_Click);
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(182, 72);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            this.textBox_jobId.TextChanged += new System.EventHandler(this.textBox_jobId_TextChanged);
            // 
            // label_fromShelfId
            // 
            this.label_fromShelfId.AutoSize = true;
            this.label_fromShelfId.Location = new System.Drawing.Point(73, 111);
            this.label_fromShelfId.Name = "label_fromShelfId";
            this.label_fromShelfId.Size = new System.Drawing.Size(91, 18);
            this.label_fromShelfId.TabIndex = 1;
            this.label_fromShelfId.Text = "fromShelfId";
            this.label_fromShelfId.Click += new System.EventHandler(this.label_jobId_Click);
            // 
            // textBox_fromShelfId
            // 
            this.textBox_fromShelfId.Location = new System.Drawing.Point(182, 108);
            this.textBox_fromShelfId.Name = "textBox_fromShelfId";
            this.textBox_fromShelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_fromShelfId.TabIndex = 2;
            this.textBox_fromShelfId.TextChanged += new System.EventHandler(this.textBox_jobId_TextChanged);
            // 
            // label_toShelfId
            // 
            this.label_toShelfId.AutoSize = true;
            this.label_toShelfId.Location = new System.Drawing.Point(93, 143);
            this.label_toShelfId.Name = "label_toShelfId";
            this.label_toShelfId.Size = new System.Drawing.Size(71, 18);
            this.label_toShelfId.TabIndex = 1;
            this.label_toShelfId.Text = "toShelfId";
            this.label_toShelfId.Click += new System.EventHandler(this.label_jobId_Click);
            // 
            // textBox_toShelfId
            // 
            this.textBox_toShelfId.Location = new System.Drawing.Point(182, 140);
            this.textBox_toShelfId.Name = "textBox_toShelfId";
            this.textBox_toShelfId.Size = new System.Drawing.Size(100, 29);
            this.textBox_toShelfId.TabIndex = 2;
            this.textBox_toShelfId.TextChanged += new System.EventHandler(this.textBox_jobId_TextChanged);
            // 
            // button_LotShelfRequest
            // 
            this.button_LotShelfRequest.Location = new System.Drawing.Point(311, 70);
            this.button_LotShelfRequest.Name = "button_LotShelfRequest";
            this.button_LotShelfRequest.Size = new System.Drawing.Size(117, 99);
            this.button_LotShelfRequest.TabIndex = 3;
            this.button_LotShelfRequest.Text = "send";
            this.button_LotShelfRequest.UseVisualStyleBackColor = true;
            this.button_LotShelfRequest.Click += new System.EventHandler(this.button_LotShelfRequest_Click);
            // 
            // WESLotShelfRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 226);
            this.Controls.Add(this.button_LotShelfRequest);
            this.Controls.Add(this.textBox_toShelfId);
            this.Controls.Add(this.label_toShelfId);
            this.Controls.Add(this.textBox_fromShelfId);
            this.Controls.Add(this.label_fromShelfId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Name = "WESLotShelfRequest";
            this.Text = "LotShelfRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_fromShelfId;
        private System.Windows.Forms.TextBox textBox_fromShelfId;
        private System.Windows.Forms.Label label_toShelfId;
        private System.Windows.Forms.TextBox textBox_toShelfId;
        private System.Windows.Forms.Button button_LotShelfRequest;
    }
}