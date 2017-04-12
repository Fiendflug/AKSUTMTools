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

namespace AKS_UTM_tools
{
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
           
        }

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
    }
}
