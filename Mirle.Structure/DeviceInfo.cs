using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Structure
{
    public class DeviceInfo
    {
        public string DeviceID { get; set; }
        /// <summary>
        /// 樓層List
        /// </summary>
        public List<FloorInfo> Floors { get; set; }
    }
}
