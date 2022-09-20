using Mirle.Def;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mirle.WebAPI.V2BYMA30.Function
{
    public class LotPutawayCheck
    {
        public bool FunReport(LotPutawayCheckInfo info, string IP)
        {
            try
            {
                string strJson = JsonConvert.SerializeObject(info);
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, strJson);
                string sLink = $"http://{IP}/LOT_PUTAWAY_CHECK";
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Debug, $"URL: {sLink}");
                string re = clsTool.HttpPost(sLink, strJson);
                clsWriLog.Log.FunWriLog(WriLog.clsLog.Type.Trace, re);
                var info_controller = (LotPutawayCheckReply)Newtonsoft.Json.Linq.JObject.Parse(re).ToObject(typeof(LotPutawayCheckReply));
                if (info_controller.returnCode == clsConstValue.ApiReturnCode.Success) return true;
                else if (info_controller.returnCode == clsConstValue.ApiReturnCode.Waitretry)
                {
                    Thread.Sleep(30000);
                    return FunReport(info, IP);
                }
                else return false;
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return false;
            }
        }
    }
}
