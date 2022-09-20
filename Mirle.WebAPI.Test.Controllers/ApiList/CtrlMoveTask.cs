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
    public partial class CtrlMoveTask : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlMoveTask()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetAgvcApiConfig();
        }

        private void label_toLoc_Click(object sender, EventArgs e)
        {

        }

        private void textBox_toLoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_MoveTask_Click(object sender, EventArgs e)
        {
            MoveTaskInfo info = new MoveTaskInfo
            {
                jobId = textBox_jobId.Text,
                fromLoc = textBox_fromLoc.Text,
                toLoc = textBox_toLoc.Text,
                carrierType = textBox_carrierType.Text
            };
            if (!clsAPI.GetAPI().GetMoveTask().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Move Task", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Move Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
