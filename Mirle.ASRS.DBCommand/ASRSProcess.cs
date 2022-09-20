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
    public class ASRSProcess : IStocker
    {
        private clsEnum.CmdType.CraneType craneType;
        private int _stockerId;
        private readonly List<ICrane> _cranes = new List<ICrane>();
        public ASRSProcess(clsDbConfig dbConfig, clsDbConfig dbConfig_WMS, clsPlcConfig plcConfig, DeviceInfo Device, MapHost Router, MidHost middle, SignalHost CrnSignal)
        {
            Initial(dbConfig, dbConfig_WMS);
            craneType = plcConfig.CraneType;
            _stockerId = int.Parse(Device.DeviceID);
            _cranes.Add(new CraneProcess(1, wcs, wms, plcConfig, Device, Router, middle, CrnSignal));

            if (craneType == clsEnum.CmdType.CraneType.Daul)
                _cranes.Add(new CraneProcess(2, wcs, wms, plcConfig, Device, Router, middle, CrnSignal));
        }

        public clsEnum.CmdType.CraneType CraneType => craneType;
        public int Id => _stockerId;
        public IEnumerable<ICrane> GetCranes()
        {
            return _cranes.AsReadOnly();
        }

        public ICrane GetCrane(int craneNo)
        {
            return GetCranes().FirstOrDefault(x => x.CraneNo == craneNo);
        }

        private clsHost wcs;
        private DB.WMS.Proc.clsHost wms;
        public clsHost GetWCS() => wcs;
        public DB.WMS.Proc.clsHost GetWMS() => wms;

       private void Initial(clsDbConfig dbConfig, clsDbConfig dbConfig_WMS)
        {
            wcs = new clsHost(dbConfig, new WebApiConfig(), new WebApiConfig());
            wms = new DB.WMS.Proc.clsHost(dbConfig_WMS);
        }
    }
}
