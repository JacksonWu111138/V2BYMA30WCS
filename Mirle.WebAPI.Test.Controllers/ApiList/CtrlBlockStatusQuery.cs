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
    public partial class CtrlBlockStatusQuery : Form
    {
        private WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlBlockStatusQuery()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_BlockStatusQuery_Click(object sender, EventArgs e)
        {
            BlockStatusQueryInfo info = new BlockStatusQueryInfo
            {
                jobId = textBox_jobId.Text,
                chipSTKCId = textBox_chipSTKCId.Text
            };

            if (!clsAPI.GetAPI().GetBlockStatusQuery().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Block Status Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Block Status Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
