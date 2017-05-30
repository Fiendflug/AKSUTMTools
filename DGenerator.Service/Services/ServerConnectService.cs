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

        SettingsService AllSettings { get; set; }
        ServerConnectionInfo Settings { get; set; }
        ServerUTM Server { get; set; } 

        string[] CdrsForTransfer { get; set; }

        public delegate void TransferProgress();
        public delegate void ChangeStatusDelegate(string statusMessage);

        public event TransferProgress CdrTransferEvent;
        public event ChangeStatusDelegate ChangeStatusEvent;

        public bool IsConnected { get; set; }

        private ServerConnectService()
        {
            AllSettings = new SettingsService();
            Settings = new ServerConnectionInfo
            {
                ServerHost = AllSettings.GetSetting("ServerHost"),
                ServerPort = uint.Parse(AllSettings.GetSetting("ServerPort")),
                ServerForwardingPort = uint.Parse(AllSettings.GetSetting("DatabasePort")),
                ServerUsername = AllSettings.GetSetting("ServerUser"),
                ServerPassword = AllSettings.GetSetting("ServerPassword"),
                HostForForwarding = AllSettings.GetSetting("DatabaseHost")
            };

            CdrTransferEvent = delegate { };
            ChangeStatusEvent = delegate { };

            Server = new ServerUTM(Settings);

            Server.OneFileTransfered += CdrTransfered;
            Server.ChangeStatusEvent += ChangeStatus;
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

        public void Connect()
        {            
            Server.Connect();
            IsConnected = true;            
        }

        public void Disconnect()
        {            
            Server.Disconnect();
            IsConnected = false;
        }

        public void Transfer()
        {
            Server.TransferCDR(CdrsForTransfer, AllSettings.GetSetting("RemoteCdrPath"));
        }

        public void RefreshConnectionSettings()
        {
            Settings = new ServerConnectionInfo
            {
                ServerHost = AllSettings.GetSetting("ServerHost"),
                ServerPort = uint.Parse(AllSettings.GetSetting("ServerPort")),
                ServerForwardingPort = uint.Parse(AllSettings.GetSetting("DatabasePort")),
                ServerUsername = AllSettings.GetSetting("ServerUser"),
                ServerPassword = AllSettings.GetSetting("ServerPassword")
            };
            Server = new ServerUTM(Settings);
        }

        void ChangeStatus(string statusMesasge)
        {
            ChangeStatusEvent(statusMesasge);
        }

        void CdrTransfered()
        {
            CdrTransferEvent();
        }
    }
}
