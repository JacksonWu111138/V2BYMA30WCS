namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    partial class CtrlTransferCommandRequest
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_TransferCommandRequest = new System.Windows.Forms.Button();
            this.label_jobId = new System.Windows.Forms.Label();
            this.textBox_jobId = new System.Windows.Forms.TextBox();
            this.label_binId = new System.Windows.Forms.Label();
            this.textBox_binId = new System.Windows.Forms.TextBox();
            this.label_carrierType = new System.Windows.Forms.Label();
            this.textBox_carrierType = new System.Windows.Forms.TextBox();
            this.label_source = new System.Windows.Forms.Label();
            this.textBox_source = new System.Windows.Forms.TextBox();
            this.label_destination = new System.Windows.Forms.Label();
            this.textBox_destination = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "E800C",
            "LIFT4C",
            "LIFT5C"});
            this.comboBox1.Location = new System.Drawing.Point(79, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 26);
            this.comboBox1.TabIndex = 0;
            // 
            // button_TransferCommandRequest
            // 
            this.button_TransferCommandRequest.Location = new System.Drawing.Point(347, 122);
            this.button_TransferCommandRequest.Name = "button_TransferCommandRequest";
            this.button_TransferCommandRequest.Size = new System.Drawing.Size(136, 115);
            this.button_TransferCommandRequest.TabIndex = 1;
            this.button_TransferCommandRequest.Text = "send";
            this.button_TransferCommandRequest.UseVisualStyleBackColor = true;
            this.button_TransferCommandRequest.Click += new System.EventHandler(this.button_TransferCommandRequest_Click);
            // 
            // label_jobId
            // 
            this.label_jobId.AutoSize = true;
            this.label_jobId.Location = new System.Drawing.Point(63, 96);
            this.label_jobId.Name = "label_jobId";
            this.label_jobId.Size = new System.Drawing.Size(43, 18);
            this.label_jobId.TabIndex = 2;
            this.label_jobId.Text = "jobId";
            // 
            // textBox_jobId
            // 
            this.textBox_jobId.Location = new System.Drawing.Point(151, 93);
            this.textBox_jobId.Name = "textBox_jobId";
            this.textBox_jobId.Size = new System.Drawing.Size(155, 29);
            this.textBox_jobId.TabIndex = 3;
            // 
            // label_binId
            // 
            this.label_binId.AutoSize = true;
            this.label_binId.Location = new System.Drawing.Point(63, 135);
            this.label_binId.Name = "label_binId";
            this.label_binId.Size = new System.Drawing.Size(43, 18);
            this.label_binId.TabIndex = 2;
            this.label_binId.Text = "binId";
            // 
            // textBox_binId
            // 
            this.textBox_binId.Location = new System.Drawing.Point(151, 132);
            this.textBox_binId.Name = "textBox_binId";
            this.textBox_binId.Size = new System.Drawing.Size(155, 29);
            this.textBox_binId.TabIndex = 3;
            // 
            // label_carrierType
            // 
            this.label_carrierType.AutoSize = true;
            this.label_carrierType.Location = new System.Drawing.Point(17, 170);
            this.label_carrierType.Name = "label_carrierType";
            this.label_carrierType.Size = new System.Drawing.Size(89, 18);
            this.label_carrierType.TabIndex = 2;
            this.label_carrierType.Text = "carrierType";
            // 
            // textBox_carrierType
            // 
            this.textBox_carrierType.Location = new System.Drawing.Point(151, 167);
            this.textBox_carrierType.Name = "textBox_carrierType";
            this.textBox_carrierType.Size = new System.Drawing.Size(155, 29);
            this.textBox_carrierType.TabIndex = 3;
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Location = new System.Drawing.Point(53, 205);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(53, 18);
            this.label_source.TabIndex = 2;
            this.label_source.Text = "source";
            // 
            // textBox_source
            // 
            this.textBox_source.Location = new System.Drawing.Point(151, 202);
            this.textBox_source.Name = "textBox_source";
            this.textBox_source.Size = new System.Drawing.Size(155, 29);
            this.textBox_source.TabIndex = 3;
            // 
            // label_destination
            // 
            this.label_destination.AutoSize = true;
            this.label_destination.Location = new System.Drawing.Point(23, 240);
            this.label_destination.Name = "label_destination";
            this.label_destination.Size = new System.Drawing.Size(83, 18);
            this.label_destination.TabIndex = 2;
            this.label_destination.Text = "destination";
            // 
            // textBox_destination
            // 
            this.textBox_destination.Location = new System.Drawing.Point(151, 237);
            this.textBox_destination.Name = "textBox_destination";
            this.textBox_destination.Size = new System.Drawing.Size(155, 29);
            this.textBox_destination.TabIndex = 3;
            // 
            // CtrlTransferCommandRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 333);
            this.Controls.Add(this.textBox_destination);
            this.Controls.Add(this.label_destination);
            this.Controls.Add(this.textBox_source);
            this.Controls.Add(this.label_source);
            this.Controls.Add(this.textBox_carrierType);
            this.Controls.Add(this.label_carrierType);
            this.Controls.Add(this.textBox_binId);
            this.Controls.Add(this.label_binId);
            this.Controls.Add(this.textBox_jobId);
            this.Controls.Add(this.label_jobId);
            this.Controls.Add(this.button_TransferCommandRequest);
            this.Controls.Add(this.comboBox1);
            this.Name = "CtrlTransferCommandRequest";
            this.Text = "TransferCommandRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_TransferCommandRequest;
        private System.Windows.Forms.Label label_jobId;
        private System.Windows.Forms.TextBox textBox_jobId;
        private System.Windows.Forms.Label label_binId;
        private System.Windows.Forms.TextBox textBox_binId;
        private System.Windows.Forms.Label label_carrierType;
        private System.Windows.Forms.TextBox textBox_carrierType;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.TextBox textBox_source;
        private System.Windows.Forms.Label label_destination;
        private System.Windows.Forms.TextBox textBox_destination;
    }
}