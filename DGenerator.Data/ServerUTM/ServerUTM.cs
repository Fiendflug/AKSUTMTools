using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace DGenerator.Data.ServerUTM
{
    public class ServerUTM
    {
        public ServerConnectionInfo ServerConnectInfo { get; set; }
        SshClient SshWorker { get; set; }
        SftpClient SftpWorker { get; set; }
        ConnectionInfo SshWorkerConnectionInfo { get; set; }
        PasswordAuthenticationMethod PasswordAuth { get; set; }
        KeyboardInteractiveAuthenticationMethod KeyboardInteractiveAuth { get; set; }
        public string Status { get; set; } //Статус перенести в то место где будет образение к базе данных
        
        public delegate void TransferStatus();
        public event TransferStatus OneFileTransfered;

        public ServerUTM(ServerConnectionInfo settings)
        {
            ServerConnectInfo = settings;

            OneFileTransfered = delegate { };

            PasswordAuth = new PasswordAuthenticationMethod(ServerConnectInfo.ServerUsername, ServerConnectInfo.ServerPassword);
            KeyboardInteractiveAuth = new KeyboardInteractiveAuthenticationMethod(ServerConnectInfo.ServerUsername);

            SshWorkerConnectionInfo = new ConnectionInfo(ServerConnectInfo.ServerHost, ServerConnectInfo.ServerUsername,
                PasswordAuth, KeyboardInteractiveAuth);

            KeyboardInteractiveAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);

            SshWorker = new SshClient(SshWorkerConnectionInfo);
            SftpWorker = new SftpClient(SshWorkerConnectionInfo);
        }

        public void Connect()
        {
            try
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
                else
                {
                    Status = "Соединение с сервером было установлено ранее";
                }
            }
            catch(SshConnectionException exc)
            {
                Status = exc.Message;
            }
            catch(SshAuthenticationException exc)
            {
                Status = exc.Message;
            }
            catch(SshOperationTimeoutException exc)
            {
                Status = exc.Message;
            }
            catch(SshException exc)
            {
                Status = exc.Message;
            }
        }

        public void Disconnect()
        {
            try
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
            catch(SshException exc)
            {
                Status = exc.Message;
            }
        }

        void HandleKeyEvent(object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = ServerConnectInfo.ServerPassword;
                }
            }
        }

        public void TransferCDR(string[] localPaths, string remotePath)
        {
            try
            {
                if (!SftpWorker.IsConnected)
                    SftpWorker.Connect();

                SftpWorker.ChangeDirectory(remotePath);
                foreach (var cdr in localPaths)
                {
                    var fileName = cdr.Split('\\');
                    using (var uplfileStream = System.IO.File.OpenRead(cdr))
                    {
                        SftpWorker.UploadFile(uplfileStream, fileName[fileName.Length - 1], true);
                    }
                    OneFileTransfered();
                }
                SftpWorker.Disconnect();
            }
            catch(SshOperationTimeoutException exc)
            {
                Status = exc.Message;
            }
        }
    }
}
