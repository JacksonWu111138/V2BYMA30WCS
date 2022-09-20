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
    public partial class CtrlCVReceiveNewBinCmd : Form
    {
        private WebApiConfig Apiconfig = new WebApiConfig();
        public static WebApiConfig _TowerApi_Config = new WebApiConfig();
        public static WebApiConfig _BoxApi_Config = new WebApiConfig();
        public static WebApiConfig _PcbaApi_Config = new WebApiConfig();
        public static WebApiConfig _SmtcApi_Config = new WebApiConfig();
        public static WebApiConfig _OsmtcApi_Config = new WebApiConfig();
        public static WebApiConfig _E04Api_Config = new WebApiConfig();
        public static WebApiConfig _E05Api_Config = new WebApiConfig();
        public CtrlCVReceiveNewBinCmd()
        {
            _TowerApi_Config = clsAPI.GetTowerApiConfig();
            _BoxApi_Config = clsAPI.GetBoxApiConfig();
            _PcbaApi_Config = clsAPI.GetPcbaApiConfig();
            _SmtcApi_Config = clsAPI.GetStmcApiConfig();
            _OsmtcApi_Config = clsAPI.GetOsmtcApiConfig();
            _E04Api_Config = clsAPI.GetE04ApiConfig();
            _E05Api_Config = clsAPI.GetE05ApiConfig();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_CVReceiveNewBinCmd_Click(object sender, EventArgs e)
        {
            bool ctrltype = true;
            switch (comboBox1.SelectedItem)
            {
                case "E800C":
                    Apiconfig = _TowerApi_Config;
                    break;
                case "SMTC":
                    Apiconfig = _SmtcApi_Config;
                    break;
                case "LIFT4C":
                    Apiconfig = _E04Api_Config;
                    break;
                case "LIFT5C":
                    Apiconfig = _E05Api_Config;
                    break;
                case "B800C":
                    Apiconfig = _BoxApi_Config;
                    break;
                case "M800C":
                    Apiconfig = _PcbaApi_Config;
                    break;
                case "OSMTC":
                    Apiconfig = _OsmtcApi_Config;
                    break;

                default:
                    ctrltype = false;
                    MessageBox.Show($"未選擇對象controller", "Buffer Roll Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            if(ctrltype)
            {
                CVReceiveNewBinCmdInfo info = new CVReceiveNewBinCmdInfo
                {
                    jobId = textBox_jobId.Text,
                    bufferId = textBox_bufferId.Text,
                    carrierType = textBox_carrierType.Text
                };
                if (!clsAPI.GetAPI().GetCV_ReceiveNewBinCmd().FunReport(info, Apiconfig.IP))
                {
                    MessageBox.Show($"失敗, jobId:{info.jobId}.", "CV Receive New Bin Cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"成功, jobId:{info.jobId}.", "CV Receive New Bin Cmd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
