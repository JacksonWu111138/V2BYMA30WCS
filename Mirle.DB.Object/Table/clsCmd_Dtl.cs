using Mirle.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.Object.Table
{
    public class clsCmd_Dtl
    {
        public static bool FunReadCmdDtl(CmdMstInfo cmd, ref List<LocDtlInfo> locDtls,
           ref List<TrnLogInfo> trnLogs, ref List<MoldUseLogInfo> moldUseLogs)
           => clsDB_Proc.GetDB_Object().GetCmd_Dtl().FunReadCmdDtl(cmd, ref locDtls, ref trnLogs, ref moldUseLogs);
    }
}
