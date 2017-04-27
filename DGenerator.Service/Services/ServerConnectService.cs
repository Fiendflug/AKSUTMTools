using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGenerator.Data.ServerUTM;

namespace DGenerator.Service.Services
{
    public class ServerConnectService
    {
        static ServerConnectService Instance { get; set; }

        ServerConnectionInfo Settings { get; set; }
        ServerUTM Server { get; set; }

        string[] CdrsForTransfer { get; set; }

        public delegate void TransferProgress();
        public event TransferProgress CdrTransferEvent;

        private ServerConnectService()
        {
            Settings = new ServerConnectionInfo
            {
                ServerHost = "192.168.100.1",
                ServerPort = 22,
                ServerForwardingPortPort = 3306,
                ServerUsername = "kineev",
                ServerPassword = "rootISroot"
            };

            CdrTransferEvent = delegate { };

            Server = new ServerUTM(Settings);
            Server.OneFileTransfered += CdrTransfered;
        }

        public static ServerConnectService GetInstance()
        {
            if (Instance == null)
                Instance = new ServerConnectService();
            return Instance;
        }

        public static ServerConnectService GetInstance(string[] filePathsForTransfer)
        {
            if (Instance == null)
                Instance = new ServerConnectService();
            Instance.CdrsForTransfer = filePathsForTransfer;
            return Instance;
        }

        public string Connect()
        {
            Server.Connect();
            return Server.Status;
        }

        public string Disconnect()
        {
            Server.Disconnect();
            return Server.Status;
        }

        public void Transfer()
        {
            Server.TransferCDR(CdrsForTransfer, "/usr/cdr_for_utm/");
        }

        void CdrTransfered()
        {
            CdrTransferEvent();            
        }
    }
}
