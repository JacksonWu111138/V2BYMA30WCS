using System;
using Mirle.Def;
using System.Windows.Forms;
using Mirle.Structure;
using Mirle.Structure.Info;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Mirle.Middle;

namespace Mirle.DB.Object
{
    public class clsMiddle
    {
        private static MidHost middle;
        public static void Initial(List<ConveyorInfo> conveyors, WebApiConfig AgvApiConfig, DeviceInfo[] PCBA, DeviceInfo[] Box,
            string DeviceID_AGV, string DeviceID_Tower, clsDbConfig config, WebApiConfig AgvApi_Config, WebApiConfig TowerApi_Config)
        {
            middle = new MidHost(conveyors,AgvApiConfig,PCBA,Box,DeviceID_AGV,DeviceID_Tower,config,AgvApi_Config,TowerApi_Config);
        }

        public static MidHost GetMiddle() => middle;
    }
}
