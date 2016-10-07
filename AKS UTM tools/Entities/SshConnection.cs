using System.Diagnostics;
using System.Windows.Forms;
using AKS_UTM_tools.Properties;

namespace AKS_UTM_tools.Entities
{
    public class SshConnection : Connection
    {
        public SshConnection(string processPath, string connectionArguments) : base(processPath, connectionArguments)
        {
            
        }

        public override void ConnectToServer()
        {
            if (Process.GetProcessesByName(ProcessName).Length == 0 & !IsConnected)
            {
                Process process = new Process
                {
                    StartInfo =
                    {
                        FileName = ProcessPath,
                        Arguments = ConnectionArguments
                    }
                };
                process.Start();
                IsConnected = true;
            }
            else
            {
                MessageBox.Show(Resources.SshWarningMessage, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
