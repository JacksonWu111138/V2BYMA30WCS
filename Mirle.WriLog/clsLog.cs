using System;

using Mirle.Logger;

namespace Mirle.WriLog
{
    public class clsLog
    {
        private string sFileName = "";
        private bool bIsByHour = false;
        public clsLog(string FileName, bool IsByHour)
        {
            sFileName = FileName;
            bIsByHour = IsByHour;
        }

        /// <summary>
        /// For LOG
        /// </summary>
        private Log gobjLog = new Log();
        /// <summary>
        /// 記錄Exception Try Catch
        /// </summary>
        /// <param name="strFunSubName">Function Sub Name</param>
        /// <param name="strMsg">Message</param>
        /// <remarks></remarks>
        public void subWriteExLog(string strFunSubName, string strMsg)
        {
            gobjLog.Error($"{sFileName}_Exception.log", strFunSubName.PadRight(60, ' ') + ":" + strMsg);
        }

        /// <summary>
        /// Write Log
        /// </summary>
        public void FunWriLog(Type type, string sValue)
        {
            try
            {
                switch (type)
                {
                    case Type.Debug:
                        if (bIsByHour)
                            gobjLog.Debug($"{sFileName}_" + DateTime.Now.ToString("yyyyMMddHH") + ".log", sValue);
                        else
                            gobjLog.Debug($"{sFileName}.log", sValue);
                        break;
                    case Type.Error:
                        if (bIsByHour)
                            gobjLog.Error($"{sFileName}_" + DateTime.Now.ToString("yyyyMMddHH") + ".log", sValue);
                        else
                            gobjLog.Error($"{sFileName}.log", sValue);
                        break;
                    case Type.Trace:
                        if (bIsByHour)
                            gobjLog.Trace($"{sFileName}_" + DateTime.Now.ToString("yyyyMMddHH") + ".log", sValue);
                        else
                            gobjLog.Trace($"{sFileName}.log", sValue);
                        break;
                   default:
                        if (bIsByHour)
                            gobjLog.Warning($"{sFileName}_" + DateTime.Now.ToString("yyyyMMddHH") + ".log", sValue);
                        else
                            gobjLog.Warning($"{sFileName}.log", sValue);
                        break;
                }
            }
            catch (Exception ex)
            {
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
            }
        }

        public enum Type
        {
            Trace, Warning, Error, Debug
        }
    }
}
