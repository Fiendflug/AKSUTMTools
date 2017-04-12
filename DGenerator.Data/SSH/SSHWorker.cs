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
        static PasswordAuthenticationMethod PasswordAuth { get; set; }
        static KeyboardInteractiveAuthenticationMethod KeyboardInteractiveAuth { get; set; }

        static SSHWorker()
        {
            ConnectConfig = new SSHConnectConfig
            {
                ServerHost = "192.168.100.1",
                ServerPort = 22,
                ServerForwardingPortPort = 3306,
                ServerUsername = "kineev",
                ServerPassword = "rootISroot"
            };

            PasswordAuth = new PasswordAuthenticationMethod(ConnectConfig.ServerUsername, ConnectConfig.ServerPassword);
            KeyboardInteractiveAuth = new KeyboardInteractiveAuthenticationMethod(ConnectConfig.ServerUsername);

            WorkerConnectionInfo = new ConnectionInfo(ConnectConfig.ServerHost, ConnectConfig.ServerUsername,
                PasswordAuth, KeyboardInteractiveAuth);

            KeyboardInteractiveAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);

            Worker = new SshClient(WorkerConnectionInfo);
        }

        public static void Connect()
        {
            
            Worker.Connect();
            var tunnelPort = new ForwardedPortLocal("localhost", ConnectConfig.ServerHost, ConnectConfig.ServerPort);
            Worker.AddForwardedPort(tunnelPort);

            tunnelPort.Exception += delegate (object sender, ExceptionEventArgs e)
            {
                Console.WriteLine(e.Exception.ToString());
            };
            tunnelPort.Start();
        }

        static void HandleKeyEvent(Object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = ConnectConfig.ServerPassword;
                }
            }
        }

        public static void Disconnect()
        {
            if (Worker != null)
                Worker.Disconnect();
        }
    }
}
