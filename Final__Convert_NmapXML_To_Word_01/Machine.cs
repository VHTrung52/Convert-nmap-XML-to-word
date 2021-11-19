using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final__Convert_NmapXML_To_Word_01
{
    class Machine
    {
        public string IP;
        public string OpenPorts_Ascending;
        public List<OpenPort> list_OpenPorts;

        public Machine(string IP)
        {
            this.IP = IP;
            list_OpenPorts = new List<OpenPort>();
        }
    }
}
