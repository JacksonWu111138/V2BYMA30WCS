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
    public partial class CtrlRackRequest : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlRackRequest()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetAgvcApiConfig();
        }

        private void button_RackRequest_Click(object sender, EventArgs e)
        {
            RackRequestInfo info = new RackRequestInfo
            {
                jobId = textBox_jobId.Text,
                location = textBox_location.Text
            };
            if (!clsAPI.GetAPI().GetRackRequest().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Rack Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Rack Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
