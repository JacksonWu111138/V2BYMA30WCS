using System.Collections.Generic;
using Mirle.Def;
using Mirle.Structure;

namespace Mirle.Middle.DB_Proc
{
    public class clsHost
    {
        private clsMiddleCmd middleCmd;
        private clsEquCmd equCmd;
        private static object _Lock = new object();
        private static bool _IsConn = false;
        public static bool IsConn
        {
            get { return _IsConn; }
            set
            {
                lock(_Lock)
                {
                    _IsConn = value;
                }
            }
        }

        public clsHost(clsDbConfig config, DeviceInfo[] PCBA, DeviceInfo[] Box, List<ConveyorInfo> conveyors, 
            string DeviceID_AGV, string DeviceID_Tower, WebApiConfig AgvApi_Config, WebApiConfig TowerApi_Config)
        {
            middleCmd = new clsMiddleCmd(config, PCBA, Box, conveyors, DeviceID_AGV, DeviceID_Tower, AgvApi_Config, TowerApi_Config);
            equCmd = new clsEquCmd(config);
        }

        public clsMiddleCmd GetMiddleCmd() => middleCmd;
        public clsEquCmd GetEquCmd() => equCmd;
    }
}
