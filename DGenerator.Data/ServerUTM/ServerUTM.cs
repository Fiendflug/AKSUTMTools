using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace DGenerator.Data.ServerUTM
{
    public static class ServerUTM
    {
        static ServerConnectionInfo ServerConnectInfo { get; set; }
        static SshClient SshWorker { get; set; }
        static SftpClient SftpWorker { get; set; }
        static ConnectionInfo SshWorkerConnectionInfo { get; set; }
        static PasswordAuthenticationMethod PasswordAuth { get; set; }
        static KeyboardInteractiveAuthenticationMethod KeyboardInteractiveAuth { get; set; }
        public static string Status { get; set; } //Статус перенести в то место где будет образение к базе данных

        static ServerUTM()
        {
            ServerConnectInfo = new ServerConnectionInfo
            {
                ServerHost = "192.168.100.1",
                ServerPort = 22,
                ServerForwardingPortPort = 3306,
                ServerUsername = "kineev",
                ServerPassword = "rootISroot"
            };

            PasswordAuth = new PasswordAuthenticationMethod(ServerConnectInfo.ServerUsername, ServerConnectInfo.ServerPassword);
            KeyboardInteractiveAuth = new KeyboardInteractiveAuthenticationMethod(ServerConnectInfo.ServerUsername);

            SshWorkerConnectionInfo = new ConnectionInfo(ServerConnectInfo.ServerHost, ServerConnectInfo.ServerUsername,
                PasswordAuth, KeyboardInteractiveAuth);

            KeyboardInteractiveAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);

            SshWorker = new SshClient(SshWorkerConnectionInfo);
            SftpWorker = new SftpClient(SshWorkerConnectionInfo);
        }

        public static void Connect()
        {
            if (!SshWorker.IsConnected)
            {
                SshWorker.Connect();
                var tunnelPort = new ForwardedPortLocal("localhost", ServerConnectInfo.ServerHost, ServerConnectInfo.ServerPort);
                SshWorker.AddForwardedPort(tunnelPort);

                tunnelPort.Exception += delegate (object sender, ExceptionEventArgs e)
                {
                    Console.WriteLine(e.Exception.ToString());
                };
                tunnelPort.Start();
                Status = "Соединение с сервером установлено";
            }
        }

        public static void Disconnect()
        {
            if (SshWorker.IsConnected)
            {
                SshWorker.Disconnect();
                Status = "Соединение разорвано по инициативе пользователя";
            }
            else
            {
                Status = "Соединение на данный момент уже разорвано";
            }
        }

        static void HandleKeyEvent(object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = ServerConnectInfo.ServerPassword;
                }
            }
        }

        public static void TransferCDR(string[] localPaths, string remotePath)
        {
            if (!SftpWorker.IsConnected)
            {
                SftpWorker.Connect();
                SftpWorker.ChangeDirectory(remotePath);
                foreach(var cdr in localPaths)
                {
                    var fileName = cdr.Split('\\');
                    using (var uplfileStream = System.IO.File.OpenRead(cdr))
                    {
                        SftpWorker.UploadFile(uplfileStream, fileName[fileName.Length - 1], true);
                    }
                }
                SftpWorker.Disconnect();
            }
        }

        public static void RunParse(string[] cdrNames)
        {
            foreach (var cdr in cdrNames)
            {

            }
        }
    }
}
