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
    public partial class WESCarrierShelfReport : Form
    {
        public WESCarrierShelfReport()
        {
            InitializeComponent();
        }

        private void button_CarrierShelfReport_Click(object sender, EventArgs e)
        {
            CarrierShelfReportInfo info = new CarrierShelfReportInfo
            {
                jobId = textBox_jobId.Text,
                shelfId = textBox_shelfId.Text,
                shelfStatus = textBox_shelfStatus.Text,
                carrierId = textBox_carrierId.Text,
                disableLocation = textBox_disableLocation.Text
            };
            if (!clsAPI.GetAPI().GetCarrierShelfReport().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Carrier Shelf Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Carrier Shelf Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
