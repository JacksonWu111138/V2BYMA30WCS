using System.Collections.Generic;
using Mirle.Def;

namespace Mirle.MapController.DB_Proc
{
    public class clsHost
    {
        private readonly clsProc proc;
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

        public clsHost(clsDbConfig config)
        {
            proc = new clsProc(config);
        }

        public clsProc GetProc() => proc;
    }
}
