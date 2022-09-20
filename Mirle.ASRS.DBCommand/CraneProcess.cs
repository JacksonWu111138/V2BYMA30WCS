using Mirle.Def;
using Mirle.Stocker.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using Mirle.Structure;
using System.Threading.Tasks;
using Mirle.MapController;
using Mirle.Middle;
using Mirle.EccsSignal;
using Mirle.DB.Proc;

namespace Mirle.ASRS.DBCommand
{
    public class CraneProcess : ICrane
    {
        private readonly List<IFork> _forks = new List<IFork>();
        public CraneProcess(int craneNo, clsHost wcs, DB.WMS.Proc.clsHost wms, clsPlcConfig plcConfig, DeviceInfo Device, MapHost Router, MidHost middle, SignalHost CrnSignal)
        {
            CraneNo = craneNo;
            ForkType = plcConfig.ForkType;
            _forks.Add(new ForkProcess(1, wcs, wms, plcConfig, Device, Router, middle, CrnSignal));

            if (ForkType == clsEnum.CmdType.ForkType.TwinFork)
                _forks.Add(new ForkProcess(2, wcs, wms, plcConfig, Device, Router, middle, CrnSignal));
        }

        public int CraneNo { get; }
        public clsEnum.CmdType.ForkType ForkType { get; }
        public IEnumerable<IFork> GetForks()
        {
            return _forks.AsReadOnly();
        }

        public IFork GetFork(int forkNo)
        {
            return GetForks().FirstOrDefault(x => x.ForkNo == forkNo);
        }
    }
}
