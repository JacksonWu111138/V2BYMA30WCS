using Mirle.Def;
using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Object.Table
{
    public class clsCmd_Mst
    {
        public static int FunCheckHasCommand(string sLoc, ref CmdMstInfo cmd) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunCheckHasCommand(sLoc, ref cmd);
        public static int FunCheckHasCommand(string sLoc, string sCmdSts, ref DataTable dtTmp) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunCheckHasCommand(sLoc, sCmdSts, ref dtTmp);
        public static int FunGetCmdMst_Grid_AutoUpFile(ref DataTable dtTmp) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunGetCmdMst_Grid_AutoUpFile(ref dtTmp);
        public static bool FunGetCommand(string sCmdSno, ref CmdMstInfo cmd) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunGetCommand(sCmdSno, ref cmd);
        public static int FunGetCommand_byBoxID(string sBoxID, ref CmdMstInfo cmd) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunGetCommand_byBoxID(sBoxID, ref cmd);
        public static bool FunUpdateRemark(string sCmdSno, string sRemark) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateRemark(sCmdSno, sRemark);
        public static bool FunUpdateCmdSts(string sCmdSno, string sCmdSts, string sRemark) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateCmdSts(sCmdSno, sCmdSts, sRemark);
        public static bool FunUpdateStnNo(string sCmdSno, string sStnNo, string sRemark) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateStnNo(sCmdSno, sStnNo, sRemark);
        public static bool FunUpdateCurLoc(string sCmdSno, string sCurDeviceID, string sCurLoc) => clsDB_Proc.GetDB_Object().GetCmd_Mst().FunUpdateCurLoc(sCmdSno, sCurDeviceID, sCurLoc);
    }
}
