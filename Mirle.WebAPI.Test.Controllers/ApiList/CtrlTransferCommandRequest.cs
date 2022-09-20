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
    public partial class CtrlTransferCommandRequest : Form
    {
        public static WebApiConfig Apiconfig = new WebApiConfig();
        public static WebApiConfig _TowerApi_Config = new WebApiConfig();
        public static WebApiConfig _E04Api_Config = new WebApiConfig();
        public static WebApiConfig _E05Api_Config = new WebApiConfig();
        public CtrlTransferCommandRequest()
        {
            _TowerApi_Config = clsAPI.GetTowerApiConfig();
            _E04Api_Config = clsAPI.GetE04ApiConfig();
            _E05Api_Config = clsAPI.GetE05ApiConfig();
            InitializeComponent();
        }

        private void button_TransferCommandRequest_Click(object sender, EventArgs e)
        {
            bool ctrltype = true;
            switch (comboBox1.SelectedItem)
            {
                case "E800C":
                    Apiconfig = _TowerApi_Config;
                    break;
                case "LIFT4C":
                    Apiconfig = _E04Api_Config;
                    break;
                case "LIFT5C":
                    Apiconfig = _E05Api_Config;
                    break;

                default:
                    ctrltype = false;
                    MessageBox.Show($"未選擇對象controller", "Buffer Roll Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            if(ctrltype)
            {
                TransferCommandRequestInfo info = new TransferCommandRequestInfo
                {
                    jobId = textBox_jobId.Text,
                    binId = textBox_binId.Text,
                    carrierType = textBox_carrierType.Text,
                    source = textBox_source.Text,
                    destination = textBox_destination.Text
                };
                if (!clsAPI.GetAPI().GetTransferCommandRequest().FunReport(info, Apiconfig.IP))
                {
                    MessageBox.Show($"失敗, jobId:{info.jobId}.", "Transfer Command Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"成功, jobId:{info.jobId}.", "Transfer Command Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
