﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WebAPI.Event.U2NMMA30.Models
{
    public class CmdDoubleStorageReply : ReplyCode
    {
        public string reelId { get; set; }
        public string newLoc { get; set; }
    }
}
