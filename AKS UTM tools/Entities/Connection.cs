using System;
using System.Diagnostics;
using System.IO;


namespace AKS_UTM_tools.Entities
{
    public abstract class Connection
    {
        protected bool IsConnected { get; set; }
        protected string ConnectionArguments { get; set; }
        protected string ProcessPath { get; set; }
        protected string ProcessName { get; set; }
        public abstract void ConnectToServer();

        public void Disconnect()
        {
            foreach (var process in Process.GetProcessesByName(ProcessName))
            {
                process.Kill();
            }
            IsConnected = false;
        }

        protected Connection(string processPath, string connectionArguments)
        {
            IsConnected = false;
            ProcessPath = processPath;
            ProcessName = Path.GetFileNameWithoutExtension(ProcessPath);
            ConnectionArguments = connectionArguments;
        }
    }
}
