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
    public partial class CtrlRemoteLocalRequest : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlRemoteLocalRequest()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void button_RemoteLocalRequest_Click(object sender, EventArgs e)
        {
            RemoteLocalRequestInfo info = new RemoteLocalRequestInfo
            {
                jobId = textBox_jobId.Text,
                chipSTKCId = textBox_chipSTKCId.Text,
                controlQuery = textBox_controlQuery.Text
            };
            if (!clsAPI.GetAPI().GetRemoteLocalRequest().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Remote Local Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Remote Local Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
