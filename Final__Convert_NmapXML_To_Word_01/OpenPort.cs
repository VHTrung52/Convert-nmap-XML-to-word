using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final__Convert_NmapXML_To_Word_01
{
    class OpenPort
    {
        public string portID;
        public string serviceName;

        public OpenPort(string portID, string serviceName)
        {
            this.portID = portID;
            this.serviceName = serviceName;
        }
    }
}
