using System;
using Mirle.Def;
using System.Windows.Forms;
using Mirle.Structure;
using Mirle.Structure.Info;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Mirle.DB.Object
{
    public class clsDB_Proc
    {
        private static Proc.clsHost wcs;
        private static WMS.Proc.clsHost wms;
        public static void Initial(clsDbConfig dbConfig, clsDbConfig dbConfig_WMS, WebApiConfig wmsApi, WebApiConfig TowerApi_Config)
        {
            wcs = new Proc.clsHost(dbConfig, wmsApi, TowerApi_Config);
            wms = new WMS.Proc.clsHost(dbConfig_WMS);
        }

        public static Proc.clsHost GetDB_Object() => wcs;
        public static WMS.Proc.clsHost GetWmsDB_Object() => wms;
        public static bool DBConn => Proc.clsHost.IsConn;
        public static bool DBConn_WMS => WMS.Proc.clsHost.IsConn;
        public static int FunSelectNeedToTeach(int MaxCount, ref DataTable dtTmp) => wcs.GetL2LCount().FunSelectNeedToTeach(MaxCount, ref dtTmp);
    }
}
