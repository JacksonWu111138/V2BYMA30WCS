﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class TransferCommandDoneInfo : BaseInfo
    {
        public string binId { get; set; }
        public string carrierType { get; set; }
    }
}
