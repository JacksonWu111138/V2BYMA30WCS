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

namespace Mirle.WebAPI.Test.Controllers.ApiList
{
    public partial class CtrlRetrieveTransferInfo : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlRetrieveTransferInfo()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void button_RetrieveTransferInfo_Click(object sender, EventArgs e)
        {
            RetrieveTransferInfo info = new RetrieveTransferInfo
            {
                jobId = textBox_jobId.Text,
                reelId = textBox_reelId.Text,
                fromShelfId = textBox_fromshelfId.Text,
                toPortId = textBox_toPortId.Text,
                rackLocation = textBox_rackLocation.Text,
                largest = textBox_largest.Text,
                priority = textBox_priority.Text
            };
            if (!clsAPI.GetAPI().GetRetrieveTransfer().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Retrieve Transfer Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Retrieve Transfer Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
