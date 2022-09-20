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
    public partial class WESMagazineLoadRequest : Form
    {
        public WESMagazineLoadRequest()
        {
            InitializeComponent();
        }

        private void button_MagazineLoadRequest_Click(object sender, EventArgs e)
        {
            MagazineLoadRequestInfo info = new MagazineLoadRequestInfo
            {
                jobId = textBox_jobId.Text,
                location = textBox_location.Text
            };
            if (!clsAPI.GetAPI().GetMagazineLoadRequest().FunReport(info, clsAPI.GetWesApiConfig().IP))
            {
                MessageBox.Show($"失敗, jobId:{info.jobId}.", "Magazine Load Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"成功, jobId:{info.jobId}.", "Magazine Load Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
