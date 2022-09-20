namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlNewCarrierToStage
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
            this.button_NewCarrierToStage = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_carrierId = new System.Windows.Forms.Label();
            this.textBox_carrierId = new System.Windows.Forms.TextBox();
            this.label_stagePosition = new System.Windows.Forms.Label();
            this.textBox_stagePosition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_NewCarrierToStage
            // 
            this.button_NewCarrierToStage.Location = new System.Drawing.Point(353, 67);
            this.button_NewCarrierToStage.Name = "button_NewCarrierToStage";
            this.button_NewCarrierToStage.Size = new System.Drawing.Size(125, 128);
            this.button_NewCarrierToStage.TabIndex = 0;
            this.button_NewCarrierToStage.Text = "send";
            this.button_NewCarrierToStage.UseVisualStyleBackColor = true;
            this.button_NewCarrierToStage.Click += new System.EventHandler(this.button_NewCarrierToStage_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(91, 87);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 1;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(171, 84);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(155, 29);
            this.textBox_jobId.TabIndex = 2;
            // 
            // label_carrierId
            // 
            this.label_carrierId.AutoSize = true;
            this.label_carrierId.Location = new System.Drawing.Point(65, 122);
            this.label_carrierId.Name = "label_carrierId";
            this.label_carrierId.Size = new System.Drawing.Size(69, 18);
            this.label_carrierId.TabIndex = 1;
            this.label_carrierId.Text = "carrierId";
            // 
            // textBox_carrierId
            // 
            this.textBox_carrierId.Location = new System.Drawing.Point(171, 119);
            this.textBox_carrierId.Name = "textBox_carrierId";
            this.textBox_carrierId.Size = new System.Drawing.Size(155, 29);
            this.textBox_carrierId.TabIndex = 2;
            // 
            // label_stagePosition
            // 
            this.label_stagePosition.AutoSize = true;
            this.label_stagePosition.Location = new System.Drawing.Point(39, 157);
            this.label_stagePosition.Name = "label_stagePosition";
            this.label_stagePosition.Size = new System.Drawing.Size(99, 18);
            this.label_stagePosition.TabIndex = 1;
            this.label_stagePosition.Text = "stagePosition";
            // 
            // textBox_stagePosition
            // 
            this.textBox_stagePosition.Location = new System.Drawing.Point(171, 154);
            this.textBox_stagePosition.Name = "textBox_stagePosition";
            this.textBox_stagePosition.Size = new System.Drawing.Size(155, 29);
            this.textBox_stagePosition.TabIndex = 2;
            // 
            // CtrlNewCarrierToStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 243);
            this.Controls.Add(this.textBox_stagePosition);
            this.Controls.Add(this.label_stagePosition);
            this.Controls.Add(this.textBox_carrierId);
            this.Controls.Add(this.label_carrierId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_NewCarrierToStage);
            this.Name = "CtrlNewCarrierToStage";
            this.Text = "NewCarrierToStage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_NewCarrierToStage;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_carrierId;
        private System.Windows.Forms.TextBox textBox_carrierId;
        private System.Windows.Forms.Label label_stagePosition;
        private System.Windows.Forms.TextBox textBox_stagePosition;
    }
}