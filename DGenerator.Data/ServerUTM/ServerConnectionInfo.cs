using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.ServerUTM
{
    public class ServerConnectionInfo
    {
        public string ServerHost { get; set; }
        public uint ServerPort { get; set; }
        public uint ServerForwardingPort { get; set; }
        public string ServerUsername { get; set; }
        public string ServerPassword { get; set; }
        public string HostForForwarding { get; set; }
    }
}
