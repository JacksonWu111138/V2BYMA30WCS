namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlTaskCancel
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
            this.button_TaskCancel = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_TaskCancel
            // 
            this.button_TaskCancel.Location = new System.Drawing.Point(250, 76);
            this.button_TaskCancel.Name = "button_TaskCancel";
            this.button_TaskCancel.Size = new System.Drawing.Size(112, 69);
            this.button_TaskCancel.TabIndex = 0;
            this.button_TaskCancel.Text = "send";
            this.button_TaskCancel.UseVisualStyleBackColor = true;
            this.button_TaskCancel.Click += new System.EventHandler(this.button_TaskCancel_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(30, 101);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(90, 98);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(139, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // CtrlTaskCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 194);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_TaskCancel);
            this.Name = "CtrlTaskCancel";
            this.Text = "TaskCancel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_TaskCancel;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
    }
}