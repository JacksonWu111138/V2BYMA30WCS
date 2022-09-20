using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.Def;
using Mirle.DB.Object;

namespace Mirle.WebAPI.Test.WES.testingList
{
    public partial class WESCarrierShelfComplete : Form
    {
        public WESCarrierShelfComplete()
        {
            InitializeComponent();
        }

        private void label_carrierId_Click(object sender, EventArgs e)
        {

        }

        private void label_jobId_Click(object sender, EventArgs e)
        {

        }

        private void button_CarrierShelfComplete_Click(object sender, EventArgs e)
        {
            CarrierShelfCompleteInfo info = new CarrierShelfCompleteInfo
            {
                jobId = textBox_jobId.Text,
                carrierId = textBox_carrierId.Text,
                shelfId = textBox_shelfId.Text,
                emptyTransfer = textBox_emptyTransfer.Text
            };
            if (!clsAPI.GetAPI().GetCarrierShelfComplete().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier Shelf Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier Shelf Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
