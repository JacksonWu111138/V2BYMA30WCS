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
    public partial class CtrlControlStatusQuery : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        private ControlStatusQueryInfo info = new ControlStatusQueryInfo { chipSTKCList = new List<ChipSTKCListInfo>()};
        public CtrlControlStatusQuery()
        {
            InitializeComponent();
            Apiconfig = clsAPI.GetTowerApiConfig();
        }

        private void button_ControlStatusQuery_Click(object sender, EventArgs e)
        {
            
            info.jobId = textBox_jobId.Text;

            if (!clsAPI.GetAPI().GetControlStatusQuery().FunReport(info, Apiconfig.IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Control Status Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Control Status Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            ChipSTKCListInfo list = new ChipSTKCListInfo
            {
                chipSTKCId = textBox_chipSTKCId.Text
            };

            info.chipSTKCList.Add(list);
            MessageBox.Show($"加入完成, lotId:{list.chipSTKCId}.", "Control Status Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
