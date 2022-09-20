namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESEmptyShelfQuery
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
            this.button_EmptyShelfQuery = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_lotIdCarrierId = new System.Windows.Forms.Label();
            this.textBox_lotIdCarrierId = new System.Windows.Forms.TextBox();
            this.label_craneId = new System.Windows.Forms.Label();
            this.textBox_craneId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_EmptyShelfQuery
            // 
            this.button_EmptyShelfQuery.Location = new System.Drawing.Point(243, 52);
            this.button_EmptyShelfQuery.Name = "button_EmptyShelfQuery";
            this.button_EmptyShelfQuery.Size = new System.Drawing.Size(146, 125);
            this.button_EmptyShelfQuery.TabIndex = 0;
            this.button_EmptyShelfQuery.Text = "send";
            this.button_EmptyShelfQuery.UseVisualStyleBackColor = true;
            this.button_EmptyShelfQuery.Click += new System.EventHandler(this.button_EmptyShelfQuery_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(75, 70);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(136, 67);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_lotIdCarrierId
            // 
            this.label_lotIdCarrierId.AutoSize = true;
            this.label_lotIdCarrierId.Location = new System.Drawing.Point(14, 105);
            this.label_lotIdCarrierId.Name = "label_lotIdCarrierId";
            this.label_lotIdCarrierId.Size = new System.Drawing.Size(104, 18);
            this.label_lotIdCarrierId.TabIndex = 1;
            this.label_lotIdCarrierId.Text = "lotIdCarrierId";
            // 
            // textBox_lotIdCarrierId
            // 
            this.textBox_lotIdCarrierId.Location = new System.Drawing.Point(136, 102);
            this.textBox_lotIdCarrierId.Name = "textBox_lotIdCarrierId";
            this.textBox_lotIdCarrierId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotIdCarrierId.TabIndex = 2;
            // 
            // label_craneId
            // 
            this.label_craneId.AutoSize = true;
            this.label_craneId.Location = new System.Drawing.Point(58, 140);
            this.label_craneId.Name = "label_craneId";
            this.label_craneId.Size = new System.Drawing.Size(60, 18);
            this.label_craneId.TabIndex = 1;
            this.label_craneId.Text = "craneId";
            // 
            // textBox_craneId
            // 
            this.textBox_craneId.Location = new System.Drawing.Point(137, 137);
            this.textBox_craneId.Name = "textBox_craneId";
            this.textBox_craneId.Size = new System.Drawing.Size(100, 29);
            this.textBox_craneId.TabIndex = 2;
            // 
            // WESEmptyShelfQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 239);
            this.Controls.Add(this.textBox_craneId);
            this.Controls.Add(this.label_craneId);
            this.Controls.Add(this.textBox_lotIdCarrierId);
            this.Controls.Add(this.label_lotIdCarrierId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_EmptyShelfQuery);
            this.Name = "WESEmptyShelfQuery";
            this.Text = "EmptyShelfQuery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_EmptyShelfQuery;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_lotIdCarrierId;
        private System.Windows.Forms.TextBox textBox_lotIdCarrierId;
        private System.Windows.Forms.Label label_craneId;
        private System.Windows.Forms.TextBox textBox_craneId;
    }
}