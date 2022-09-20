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
    public partial class CtrlTaskCancel : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public CtrlTaskCancel()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetAgvcApiConfig();
        }

        private void button_TaskCancel_Click(object sender, EventArgs e)
        {
            TaskCancelInfo info = new TaskCancelInfo
            {
                jobId = textBox_jobId.Text
            };
            if (!clsAPI.GetAPI().GetTaskCancel().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Task Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Task Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
