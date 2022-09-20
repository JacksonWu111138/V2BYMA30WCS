using Mirle.Def;
using Mirle.Middle.DB_Proc;
using Mirle.Structure;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Middle
{
    public class MidHost
    {
        private WebApiConfig AgvApi_Config = new WebApiConfig();
        private DeviceInfo[] _PCBA = new DeviceInfo[2];
        private DeviceInfo[] _Box = new DeviceInfo[3];
        private WebAPI.V2BYMA30.clsHost api = new WebAPI.V2BYMA30.clsHost();
        private string sDeviceID_AGV = "";
        private readonly clsHost db;
        private System.Timers.Timer timRead = new System.Timers.Timer();
        private bool bOnline = true;
        public MidHost(List<ConveyorInfo> conveyors, WebApiConfig AgvApiConfig, DeviceInfo[] PCBA, DeviceInfo[] Box, 
            string DeviceID_AGV, string DeviceID_Tower, clsDbConfig config, WebApiConfig AgvApi_Config, WebApiConfig TowerApi_Config)
        {
            db = new clsHost(config, PCBA, Box, conveyors, DeviceID_AGV, DeviceID_Tower, AgvApi_Config, TowerApi_Config);
            AgvApi_Config = AgvApiConfig;
            _PCBA = PCBA;
            _Box = Box;
            sDeviceID_AGV = DeviceID_AGV;

            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = true; timRead.Interval = 500;
        }

        public bool Online
        {
            get { return bOnline; }
            set { bOnline = value; }
        }

        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            timRead.Enabled = false;
            try
            {
                if (bOnline)
                {
                    db.GetMiddleCmd().MiddleCmd_Proc();
                    db.GetEquCmd().FunEquCmdFinish_Proc();
                }
            }
            catch (Exception ex)
            {
                int errorLine = new System.Diagnostics.StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                clsWriLog.Log.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, errorLine.ToString() + ":" + ex.Message);
            }
            finally
            {
                timRead.Enabled = true;
            }
        }

        /// <summary>
        /// 取得Buffer PLC上的命令序號
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public int GetBufferCmd(ConveyorInfo buffer)
        {
            BufferStatusQueryInfo info = new BufferStatusQueryInfo { bufferId = buffer.BufferName };
            BufferStatusReply reply = new BufferStatusReply();
            if (api.GetBufferStatusQuery().FunReport(info, buffer.API.IP, ref reply))
            {
                return Convert.ToInt32(reply.jobId);
            }
            else return -1;
        }

        /// <summary>
        /// 確認是否是入庫Ready
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CheckIsInReady(DeviceInfo Device, Location location, ref string sCmdSno)
        {
            ConveyorInfo conveyor = new ConveyorInfo();
            foreach(var floor in Device.Floors)
            {
                bool bGet = false;
                foreach(var con in floor.Group_IN)
                {
                    if(con.BufferName == location.LocationId)
                    {
                        conveyor = con;
                        bGet = true;
                        break;
                    }
                }

                if (bGet) break;
            }

            return CheckIsInReady(conveyor, ref sCmdSno);
        }

        /// <summary>
        /// 確認是否是入庫Ready
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public bool CheckIsInReady(ConveyorInfo buffer, ref string sCmdSno)
        {
            BufferStatusQueryInfo info = new BufferStatusQueryInfo { bufferId = buffer.BufferName };
            BufferStatusReply reply = new BufferStatusReply();
            if (api.GetBufferStatusQuery().FunReport(info, buffer.API.IP, ref reply))
            {
                sCmdSno = reply.jobId.Trim().PadLeft(5, '0');
                int.TryParse(reply.ready, out var ready);
                if (ready == (int)clsEnum.ControllerApi.Ready.InReady) return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// 確認是否是入庫Ready
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public bool CheckIsInReady(ConveyorInfo buffer)
        {
            BufferStatusQueryInfo info = new BufferStatusQueryInfo { bufferId = buffer.BufferName };
            BufferStatusReply reply = new BufferStatusReply();
            if (api.GetBufferStatusQuery().FunReport(info, buffer.API.IP, ref reply))
            {
                int.TryParse(reply.ready, out var ready);
                if (ready == (int)clsEnum.ControllerApi.Ready.InReady) return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// 確認是否是出庫Ready
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CheckIsOutReady(DeviceInfo Device, Location location)
        {
            ConveyorInfo conveyor = new ConveyorInfo();
            foreach (var floor in Device.Floors)
            {
                bool bGet = false;
                foreach (var con in floor.Group_OUT)
                {
                    if (con.BufferName == location.LocationId)
                    {
                        conveyor = con;
                        bGet = true;
                        break;
                    }
                }

                if (bGet) break;
            }

            return CheckIsOutReady(conveyor);
        }

        /// <summary>
        /// 確認是否是出庫Ready
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public bool CheckIsOutReady(ConveyorInfo buffer)
        {
            BufferStatusQueryInfo info = new BufferStatusQueryInfo { bufferId = buffer.BufferName };
            BufferStatusReply reply = new BufferStatusReply();
            if (api.GetBufferStatusQuery().FunReport(info, buffer.API.IP, ref reply))
            {
                int.TryParse(reply.ready, out var ready);
                if (ready == (int)clsEnum.ControllerApi.Ready.OutReady) return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// 確認該Buffer是否荷有
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="IsLoad">是否荷有</param>
        /// <returns></returns>
        public bool CheckIsLoad(ConveyorInfo buffer, ref bool IsLoad)
        {
            BufferStatusQueryInfo info = new BufferStatusQueryInfo { bufferId = buffer.BufferName };
            BufferStatusReply reply = new BufferStatusReply();
            if (api.GetBufferStatusQuery().FunReport(info, buffer.API.IP, ref reply))
            {
                if (reply.isLoad == clsConstValue.YesNo.Yes) IsLoad = true;
                else IsLoad = false;

                return true;
            }
            else return false;
        }
    }
}
