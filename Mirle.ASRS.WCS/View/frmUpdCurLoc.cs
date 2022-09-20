using Mirle.DB.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.ASRS.WCS.View
{
    public partial class frmUpdCurLoc : Form
    {
        public frmUpdCurLoc(string CmdSno, string CurDeviceID, string CurLoc)
        {
            InitializeComponent();

            txtCmdSno.Text = CmdSno.Trim();
            txtCurDeviceID.Text = CurDeviceID.Trim();
            txtCurLoc.Text = CurLoc.Trim();
        }

        private void frmUpdCurLoc_Load(object sender, EventArgs e)
        {

        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtCurDeviceID.Text = "";
            txtCurLoc.Text = "";
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if(
                (!string.IsNullOrWhiteSpace(txtCurDeviceID.Text) &&
                 string.IsNullOrWhiteSpace(txtCurLoc.Text)) ||
                (string.IsNullOrWhiteSpace(txtCurDeviceID.Text) &&
                 !string.IsNullOrWhiteSpace(txtCurLoc.Text))
              )
            {
                MessageBox.Show("CurLoc跟CurDeviceID只能同時有值或沒值", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateCurLoc(txtCmdSno.Text.Trim(), txtCurDeviceID.Text.Trim(), txtCurLoc.Text.Trim()))
            {
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, $"手動修改CurLoc成功 => <CmdSno>{txtCmdSno.Text} <CurLoc>{txtCurLoc.Text}");
                MessageBox.Show("修改成功");
            }
            else
            {
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Error, $"NG: 手動修改CurLoc失敗 => <CmdSno>{txtCmdSno.Text} <CurLoc>{txtCurLoc.Text}");
                MessageBox.Show("更新失敗！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
