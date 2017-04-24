using DGenerator.Data.ServerUTM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGenerator.Service.Services;

namespace AKS_UTM_tools
{
    public partial class MainWindow : Form
    {
        CdrService Cdr { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {                 
        }

        // SSH connection to UTM server controls section

        private void ButtonSshConnection_Click(object sender, EventArgs e)
        {
            ServerUTM.Connect();
            StatusLabel.Text = ServerUTM.Status;
        }

        private void ButtonCloseSshConnection_Click(object sender, EventArgs e)
        {
            ServerUTM.Disconnect();
            StatusLabel.Text = ServerUTM.Status;
        }

        private void ConnectToServerTopMenu_Click(object sender, EventArgs e)
        {
            ServerUTM.Connect();
            StatusLabel.Text = ServerUTM.Status;
        }

        private void DisconnectServerTopMenu_Click(object sender, EventArgs e)
        {
            ServerUTM.Disconnect();
            StatusLabel.Text = ServerUTM.Status;
            //ServerUTM.TransferCDR(new string[]
            //{ @"C:\Bills\Files\Tests\test.txt",  @"C:\Bills\Files\Tests\test1.txt", @"C:\Bills\Files\Tests\test2.txt"}, "/usr/cdr_for_utm/");
        }

        // CDR controls section

        private void ConvertCdrButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cdr = new CdrService(openFileDialog.FileNames);
                Cdr.Convert();
            }
        }

        // Settings control

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            new SettingsWindow().ShowDialog();
        }
    }
}
