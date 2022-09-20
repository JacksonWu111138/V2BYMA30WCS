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
    public partial class WESCarrierTransferComplete : Form
    {
        public WESCarrierTransferComplete()
        {
            InitializeComponent();
        }

        private void button_CarrierTransferComplete_Click(object sender, EventArgs e)
        {
            CarrierTransferCompleteInfo info = new CarrierTransferCompleteInfo
            {
                jobId = textBox_jobId.Text,
                carrierId = textBox_carrierId.Text,
                location = textBox_location.Text
            };
            if (!clsAPI.GetAPI().GetCarrierTransferComplete().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
