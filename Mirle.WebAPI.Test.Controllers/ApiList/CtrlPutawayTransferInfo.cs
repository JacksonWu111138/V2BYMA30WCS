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
    public partial class CtrlPutawayTransferInfo : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlPutawayTransferInfo()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void button_PutawayTransferInfo_Click(object sender, EventArgs e)
        {
            PutawayTransferInfo info = new PutawayTransferInfo
            {
                jobId = textBox_jobId.Text,
                reelId = textBox_reelId.Text,
                lotSize = textBox_lotSize.Text,
                toShelfId = textBox_toShelfId.Text,
            };
            if (!clsAPI.GetAPI().GetPutawayTransfer().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Putaway Transfer Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Putaway Transfer Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
