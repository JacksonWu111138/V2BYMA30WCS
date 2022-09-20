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
    public partial class CtrlRackTurn : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlRackTurn()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetAgvcApiConfig();
        }

        private void button_RackTurn_Click(object sender, EventArgs e)
        {
            RackTurnInfo info = new RackTurnInfo
            {
                jobId = textBox_jobId.Text,
                location = textBox_location.Text,
                rackId = textBox_rackId.Text
            };
            if (!clsAPI.GetAPI().GetRackTurn().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Rack Turn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Rack Turn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
