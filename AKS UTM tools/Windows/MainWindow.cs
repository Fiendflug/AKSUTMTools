using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AKS_UTM_tools.Entities;

namespace AKS_UTM_tools
{
    public partial class MainWindow : Form
    {
        private SshConnection ssh;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ssh = new SshConnection(@"C:\putty.exe", @" -ssh -N -L 3306:localhost:3306 kineev@192.168.192.12 -pw rootISroot");
        }

        private void buttonSshConnection_Click(object sender, EventArgs e)
        {
            ssh.ConnectToServer();
        }

        private void buttonCloseSshConnection_Click(object sender, EventArgs e)
        {
            ssh.Disconnect();
        }
    }
}
