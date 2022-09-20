using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Def
{
    public class clsPlcConfig
    {
        public int MaxStn { get; set; }
        public string DeviceNo { get; set; }
        public int MPLCNo { get; set; }
        public string MPLCIP { get; set; }
        public int MPLCPort { get; set; }
        public int MPLCTimeout { get; set; }
        public bool WritePLCRawData { get; set; }
        public bool UseMCProtocol { get; set; }
        public bool InMemorySimulator { get; set; }
        /// <summary>
        /// (選用) 大循環的最多荷有數
        /// </summary>
        public int CycleCount_Max { get; set; } = 0;
        public clsEnum.CmdType.CraneType CraneType { get; set; } = clsEnum.CmdType.CraneType.Single;
        public clsEnum.CmdType.ForkType ForkType { get; set; } = clsEnum.CmdType.ForkType.SingleFork;
        public clsEnum.CmdType.LocType LocType { get; set; } = clsEnum.CmdType.LocType.Skip;
        public clsEnum.CmdType.CV_Type CV_Type { get; set; } = clsEnum.CmdType.CV_Type.Single;
    }
}
