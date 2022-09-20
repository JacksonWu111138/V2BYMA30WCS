using Mirle.DataBase;
using Mirle.Def;
using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Proc
{
    public class clsCmd_Dtl
    {
        private clsDbConfig _config = new clsDbConfig();
        private Fun.clsCMD_DTL CMD_DTL = new Fun.clsCMD_DTL();
        public clsCmd_Dtl(clsDbConfig config)
        {
            _config = config;
        }

        public bool FunReadCmdDtl(CmdMstInfo cmd, ref List<LocDtlInfo> locDtls,
           ref List<TrnLogInfo> trnLogs, ref List<MoldUseLogInfo> moldUseLogs)
        {
            try
            {
                using (var db = clsGetDB.GetDB(_config))
                {
                    int iRet = clsGetDB.FunDbOpen(db);
                    if (iRet == DBResult.Success)
                    {
                        return CMD_DTL.FunReadCmdDtl(cmd, ref locDtls, ref trnLogs, ref moldUseLogs, db);
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
                return false;
            }
        }
    }
}
