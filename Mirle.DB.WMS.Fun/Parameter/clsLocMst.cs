using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.DB.WMS.Fun.Parameter
{
    public class clsLocMst
    {
        public const string TableName = "R_WMS_LOCATION";
        public class Column
        {
            public const string Loc = "LOCATION_CODE";
            public const string LocDD = "BORTHER_LOCATION_CODE";
            public const string BoxID = "PRODUCT_CODE";
            public const string EquNo = "CRANE";
            public const string BAY = "BAY";
            public const string LEVEL = "LEVEL";
            public const string ROW = "ROW";
        }
    }
}
