using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.SSH
{
    public class SSHConnectConfig
    {
        public string ServerHost { get; set; }
        public uint ServerPort { get; set; }
        public uint ServerForwardingPortPort { get; set; }
        public string ServerUsername { get; set; }
        public string ServerPassword { get; set; }
    }
}
