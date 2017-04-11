using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace DGenerator.Data.SSH
{
    public static class SSHWorker
    {
        static SSHConnectConfig ConnectConfig { get; set; }
        public static SshClient Worker { get; set; }
        static ConnectionInfo WorkerConnectionInfo { get; set; }
        //public static bool IsConnected { get; set; }

        static SSHWorker()
        {
            ConnectConfig = new SSHConnectConfig
            {
                ServerHost = "192.168.1.102",
                ServerPort = 22,
                ServerForwardingPortPort = 3306,
                ServerUsername = "root",
                ServerPassword = "rootISroot"
            };

            WorkerConnectionInfo = new ConnectionInfo(ConnectConfig.ServerHost, ConnectConfig.ServerUsername,
                new PasswordAuthenticationMethod(ConnectConfig.ServerUsername, ConnectConfig.ServerPassword));
        }

        public static void Connect()
        {
            Worker = new SshClient(WorkerConnectionInfo);
            Worker.Connect();
            var tunnelPort = new ForwardedPortLocal("localhost", ConnectConfig.ServerHost, ConnectConfig.ServerPort);
            Worker.AddForwardedPort(tunnelPort);

            tunnelPort.Exception += delegate (object sender, ExceptionEventArgs e)
            {
                Console.WriteLine(e.Exception.ToString());
            };
            tunnelPort.Start();
        }

        public static void Disconnect()
        {
            if (Worker != null)
                Worker.Disconnect();
        }
    }
}
