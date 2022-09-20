namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlRackTurn
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
            this.button_RackTurn = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.label_rackId = new System.Windows.Forms.Label();
            this.textBox_rackId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_RackTurn
            // 
            this.button_RackTurn.Location = new System.Drawing.Point(309, 56);
            this.button_RackTurn.Name = "button_RackTurn";
            this.button_RackTurn.Size = new System.Drawing.Size(127, 109);
            this.button_RackTurn.TabIndex = 0;
            this.button_RackTurn.Text = "send";
            this.button_RackTurn.UseVisualStyleBackColor = true;
            this.button_RackTurn.Click += new System.EventHandler(this.button_RackTurn_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(57, 67);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(135, 64);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(141, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(37, 102);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(63, 18);
            this.label_location.TabIndex = 1;
            this.label_location.Text = "location";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(135, 99);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(141, 29);
            this.textBox_location.TabIndex = 2;
            // 
            // label_rackId
            // 
            this.label_rackId.AutoSize = true;
            this.label_rackId.Location = new System.Drawing.Point(48, 137);
            this.label_rackId.Name = "label_rackId";
            this.label_rackId.Size = new System.Drawing.Size(52, 18);
            this.label_rackId.TabIndex = 1;
            this.label_rackId.Text = "rackId";
            // 
            // textBox_rackId
            // 
            this.textBox_rackId.Location = new System.Drawing.Point(135, 134);
            this.textBox_rackId.Name = "textBox_rackId";
            this.textBox_rackId.Size = new System.Drawing.Size(141, 29);
            this.textBox_rackId.TabIndex = 2;
            // 
            // CtrlRackTurn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 230);
            this.Controls.Add(this.textBox_rackId);
            this.Controls.Add(this.label_rackId);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_RackTurn);
            this.Name = "CtrlRackTurn";
            this.Text = "RackTurn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RackTurn;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.Label label_rackId;
        private System.Windows.Forms.TextBox textBox_rackId;
    }
}