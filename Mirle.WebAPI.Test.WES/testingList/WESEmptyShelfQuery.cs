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

namespace Mirle.WebAPI.Test.WES.testingList
{
    public partial class WESEmptyShelfQuery : Form
    {
        public WESEmptyShelfQuery()
        {
            InitializeComponent();
        }

        private void button_EmptyShelfQuery_Click(object sender, EventArgs e)
        {
            EmptyShelfQueryInfo info = new EmptyShelfQueryInfo
            {
                jobId = textBox_jobId.Text,
                lotIdCarrierId = textBox_lotIdCarrierId.Text,
                craneId = textBox_craneId.Text
            };

            EmptyShelfQueryReply reply = new EmptyShelfQueryReply();
            if (!clsAPI.GetAPI().GetEmptyShelfQuery().FunReport(info, ref reply, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Empty Shelf Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Empty Shelf Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
