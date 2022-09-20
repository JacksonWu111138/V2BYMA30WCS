namespace Mirle.WebAPI.Test.AGVTaskCancel
{
    partial class APITestAGVTaskCancel
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonTaskCancel = new System.Windows.Forms.Button();
            this.jobId = new System.Windows.Forms.Label();
            this.textBoxjobId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonTaskCancel
            // 
            this.ButtonTaskCancel.Location = new System.Drawing.Point(172, 174);
            this.ButtonTaskCancel.Name = "ButtonTaskCancel";
            this.ButtonTaskCancel.Size = new System.Drawing.Size(118, 40);
            this.ButtonTaskCancel.TabIndex = 0;
            this.ButtonTaskCancel.Text = "Task Cancel";
            this.ButtonTaskCancel.UseVisualStyleBackColor = true;
            this.ButtonTaskCancel.Click += new System.EventHandler(this.ButtonTaskCancel_Click);
            // 
            // jobId
            // 
            this.jobId.AutoSize = true;
            this.jobId.Font = new System.Drawing.Font("新細明體", 12F);
            this.jobId.Location = new System.Drawing.Point(56, 144);
            this.jobId.Name = "jobId";
            this.jobId.Size = new System.Drawing.Size(57, 24);
            this.jobId.TabIndex = 1;
            this.jobId.Text = "jobId";
            // 
            // textBoxjobId
            // 
            this.textBoxjobId.Location = new System.Drawing.Point(119, 139);
            this.textBoxjobId.Name = "textBoxjobId";
            this.textBoxjobId.Size = new System.Drawing.Size(171, 29);
            this.textBoxjobId.TabIndex = 2;
            // 
            // APITestAGVTaskCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 340);
            this.Controls.Add(this.textBoxjobId);
            this.Controls.Add(this.jobId);
            this.Controls.Add(this.ButtonTaskCancel);
            this.Name = "APITestAGVTaskCancel";
            this.Text = "APITest_AGVTaskCancel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonTaskCancel;
        private System.Windows.Forms.Label jobId;
        private System.Windows.Forms.TextBox textBoxjobId;
    }
}

