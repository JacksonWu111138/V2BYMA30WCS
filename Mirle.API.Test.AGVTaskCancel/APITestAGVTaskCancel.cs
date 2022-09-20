using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.Def;
using Mirle.Def.U2NMMA30;
using Mirle.DataBase;
using Mirle.Middle.DB_Proc;
using Mirle.Structure;
using Mirle.WebAPI.V2BYMA30.Function;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.DB.Object;
using Mirle.WebAPI.V2BYMA30;
using Mirle.Logger;

namespace Mirle.WebAPI.Test.AGVTaskCancel
{
    public partial class APITestAGVTaskCancel : Form
    {
        private V2BYMA30.clsHost api;
        private Middle.DB_Proc.clsTool tool;
        private clsDbConfig _config = new clsDbConfig();
        private WebApiConfig AGVApi_config = new WebApiConfig();

        public APITestAGVTaskCancel()
        {
        }

        public APITestAGVTaskCancel(WebApiConfig aGVApi_config)
        {
            InitializeComponent();
            AGVApi_config = aGVApi_config;
        }

        private void ButtonTaskCancel_Click(object sender, EventArgs e)
        {
            if (textBoxjobId.Text == "")
            {
                MessageBox.Show("空jobId", "Task Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string strEM = "";
                if (!clsDB_Proc.GetDB_Object().GetProc().FunAGVTaskCancel(textBoxjobId.Text, ref strEM, AGVApi_config.IP))
                    MessageBox.Show(strEM, "Task Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
