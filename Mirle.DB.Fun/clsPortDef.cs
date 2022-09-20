using System;
using System.Collections.Generic;
using Mirle.Def;
using System.Data;
using Mirle.DataBase;

namespace Mirle.DB.Fun
{
    public class clsPortDef
    {
        private List<Element_Port> glstPort = new List<Element_Port>();

        public List<Element_Port> GetLstPort()
        {
            return glstPort;
        }
    }
}
