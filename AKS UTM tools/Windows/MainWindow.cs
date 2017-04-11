using DGenerator.Data.SSH;
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

        private void buttonSshConnection_Click(object sender, EventArgs e)
        {
            SSHWorker.Connect();
            if (SSHWorker.Worker != null)
                StatusLabel.Text = "Подключено к серверу";
        }

        private void buttonCloseSshConnection_Click(object sender, EventArgs e)
        {
            SSHWorker.Disconnect();
            if (SSHWorker.Worker != null)
                StatusLabel.Text = "Не подключено к серверу";
        }
    }
}
