using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure.Info
{
    public class TransferBatch : TransferCommand
    {
        public string BatchID { get; set; }

        public void Clear()
        {
            BatchID = "";
            CommandID = "";
            CmdMode = "";
            Priority = 0;
            CarrierID = "";
            Loc = "";
            NewLoc = "";
            Remark = "";
            StnNo = "";
            BackupPortID = "";
            TicketId = "";
        }
    }
}
