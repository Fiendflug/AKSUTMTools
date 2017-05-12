using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.IO;

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
        public delegate void StatusDelegate(string statusMessage);

        public event TransferStatus OneFileTransfered;
        public event StatusDelegate ChangeStatusEvent;

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
                    //Status = "Соединение с сервером установлено";
                    ChangeStatusEvent("Соединение с сервером установлено");
                }
                else
                {
                    //Status = "Соединение с сервером было установлено ранее";
                    ChangeStatusEvent("Соединение с сервером было установлено ранее");
                }
            }
            catch(SocketException exc)
            {
                //Status = "Произошла ошибка на сокете. Возможно сервер не отвечает. Проверьте журнал";
                ChangeStatusEvent("Произошла ошибка на сокете. Возможно сервер не отвечает. Проверьте настройки приложения и журнал");
            }
            catch(SshConnectionException exc)
            {
                //Status = exc.Message;
                ChangeStatusEvent("Проблема при инициализации SSH-соединения. Проверьте настройки приложения и журнал");
            }
            catch(SshAuthenticationException exc)
            {
                //Status = "Проищошла ошибка аутентификации. Проерьте журнал";
                ChangeStatusEvent("Произошла ошибка аутентификации. Проерьте настройки приложения и журнал");
            }
            catch(SshOperationTimeoutException exc)
            {
                //Status = exc.Message;
                ChangeStatusEvent("Превышен интервал ожидания. Проверьте настройки приложения и журнал");
            }
            catch(SshException exc)
            {
                //Status = exc.Message;
                ChangeStatusEvent("Проблема с SSH-соединением. Проверьте журнал");
            }
            catch(Exception exc)
            {
                ChangeStatusEvent("Неизвестная ошибка. Проверьте журнал для получения подробной информации");
            }
        }

        public void Disconnect()
        {
            try
            {
                if (SshWorker.IsConnected)
                {
                    SshWorker.Disconnect();
                    //Status = "Соединение разорвано по инициативе пользователя";
                    ChangeStatusEvent("Соединение разорвано по инициативе пользователя");
                }
                else
                {
                    //Status = "Соединение на данный момент уже разорвано";
                    ChangeStatusEvent("Соединение на данный момент уже разорвано");
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
                ChangeStatusEvent("Приступаю к передаче CDR-файлов на сервер");
                foreach (var cdr in localPaths)
                {
                    var fileName = cdr.Split('\\');
                    using (var uplfileStream = File.OpenRead(cdr))
                    {
                        SftpWorker.UploadFile(uplfileStream, fileName[fileName.Length - 1], true);
                    }
                    ChangeStatusEvent("Передаю файл " + Path.GetFileName(cdr) + " на сервер");
                    OneFileTransfered();                    
                }
                SftpWorker.Disconnect();
            }
            catch(SshOperationTimeoutException exc)
            {
                //Status = exc.Message;
                ChangeStatusEvent("Превышен интервал ожидания. Проверьте настройки приложения и журнал");
            }
            catch(ArgumentException exc)
            {
                ChangeStatusEvent("Некорректный путь на сервере либо отсутсвуют права на запись. Проверьте настройки приложения и журнал");
            }
            catch(Exception exc)
            {
                ChangeStatusEvent("Неизвестная ошибка. Проверьте журнал для получения подробной информации");
            }
        }
    }
}
