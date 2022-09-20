namespace Mirle.WebAPI.Test.WES.testingList
{
    partial class WESWCSCancel
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
            this.button_WCSCancel = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_lotIdCarrierId = new System.Windows.Forms.Label();
            this.textBox_lotIdCarrierId = new System.Windows.Forms.TextBox();
            this.label_cancelType = new System.Windows.Forms.Label();
            this.textBox_cancelType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_WCSCancel
            // 
            this.button_WCSCancel.Location = new System.Drawing.Point(294, 51);
            this.button_WCSCancel.Name = "button_WCSCancel";
            this.button_WCSCancel.Size = new System.Drawing.Size(149, 111);
            this.button_WCSCancel.TabIndex = 0;
            this.button_WCSCancel.Text = "send";
            this.button_WCSCancel.UseVisualStyleBackColor = true;
            this.button_WCSCancel.Click += new System.EventHandler(this.button_WCSCancel_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(99, 65);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(160, 62);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(100, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_lotIdCarrierId
            // 
            this.label_lotIdCarrierId.AutoSize = true;
            this.label_lotIdCarrierId.Location = new System.Drawing.Point(38, 100);
            this.label_lotIdCarrierId.Name = "label_lotIdCarrierId";
            this.label_lotIdCarrierId.Size = new System.Drawing.Size(104, 18);
            this.label_lotIdCarrierId.TabIndex = 1;
            this.label_lotIdCarrierId.Text = "lotIdCarrierId";
            // 
            // textBox_lotIdCarrierId
            // 
            this.textBox_lotIdCarrierId.Location = new System.Drawing.Point(160, 97);
            this.textBox_lotIdCarrierId.Name = "textBox_lotIdCarrierId";
            this.textBox_lotIdCarrierId.Size = new System.Drawing.Size(100, 29);
            this.textBox_lotIdCarrierId.TabIndex = 2;
            // 
            // label_cancelType
            // 
            this.label_cancelType.AutoSize = true;
            this.label_cancelType.Location = new System.Drawing.Point(55, 135);
            this.label_cancelType.Name = "label_cancelType";
            this.label_cancelType.Size = new System.Drawing.Size(87, 18);
            this.label_cancelType.TabIndex = 1;
            this.label_cancelType.Text = "cancelType";
            // 
            // textBox_cancelType
            // 
            this.textBox_cancelType.Location = new System.Drawing.Point(160, 132);
            this.textBox_cancelType.Name = "textBox_cancelType";
            this.textBox_cancelType.Size = new System.Drawing.Size(100, 29);
            this.textBox_cancelType.TabIndex = 2;
            // 
            // WESWCSCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 199);
            this.Controls.Add(this.textBox_cancelType);
            this.Controls.Add(this.label_cancelType);
            this.Controls.Add(this.textBox_lotIdCarrierId);
            this.Controls.Add(this.label_lotIdCarrierId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_WCSCancel);
            this.Name = "WESWCSCancel";
            this.Text = "WCSCancel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_WCSCancel;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_lotIdCarrierId;
        private System.Windows.Forms.TextBox textBox_lotIdCarrierId;
        private System.Windows.Forms.Label label_cancelType;
        private System.Windows.Forms.TextBox textBox_cancelType;
    }
}