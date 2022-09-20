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
    public partial class CtrlNewCarrierToStage : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlNewCarrierToStage()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void button_NewCarrierToStage_Click(object sender, EventArgs e)
        {
            NewCarrierToStageInfo info = new NewCarrierToStageInfo
            {
                jobId = textBox_jobId.Text,
                carrierId = textBox_carrierId.Text,
                stagePosition = textBox_stagePosition.Text
            };
            if (!clsAPI.GetAPI().GetNewCarrierToStage().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "New Carrier To Stage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "New Carrier To Stage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
