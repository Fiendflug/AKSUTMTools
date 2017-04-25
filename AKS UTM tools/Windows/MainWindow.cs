using DGenerator.Data.ServerUTM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        void MainWindow_Load(object sender, EventArgs e)
        {
                             
        }

        // SSH connection to UTM server controls section

        private void ButtonSshConnection_Click(object sender, EventArgs e)
        {
            ServerUTM.Connect();
            StatusLabel.Text = ServerUTM.Status;
        }

        void ButtonCloseSshConnection_Click(object sender, EventArgs e)
        {
            ServerUTM.Disconnect();
            StatusLabel.Text = ServerUTM.Status;
        }

        void ConnectToServerTopMenu_Click(object sender, EventArgs e)
        {
            ServerUTM.Connect();
            StatusLabel.Text = ServerUTM.Status;
        }

        void DisconnectServerTopMenu_Click(object sender, EventArgs e)
        {
            ServerUTM.Disconnect();
            StatusLabel.Text = ServerUTM.Status;
            //ServerUTM.TransferCDR(new string[]
            //{ @"C:\Bills\Files\Tests\test.txt",  @"C:\Bills\Files\Tests\test1.txt", @"C:\Bills\Files\Tests\test2.txt"}, "/usr/cdr_for_utm/");
        }

        // CDR controls section

        void ConvertCdrButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();
            openFileDialog.FileName = "*.log";
            openFileDialog.Filter = "Log файлы сатистики|*.log";
            openFileDialog.Multiselect = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Maximum = openFileDialog.FileNames.Length;
                Cdr = new CdrService(openFileDialog.FileNames);
                Cdr.ConvertOneCdrEvent += ChangeCdrConvertProgress;
                Cdr.CurrentTaskFinished += FininshCdrConvert;
                Cdr.Convert();                
            }
        }

        void ViewCdrInFolderButton_Click(object sender, EventArgs e)
        {
            if (Cdr == null)
                Cdr = new CdrService(null);
            Cdr.View();
        }

        void ChangeCdrConvertProgress()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value++;
                StatusLabel.Text = "Конвертирую CDR в формат UTM5";
            });
        }

        void FininshCdrConvert()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value = 0;
                StatusLabel.Text = "Все CDR-файлы были успешно сконвертированы";
            });
            if (Cdr != null)
            {
                Cdr.ConvertOneCdrEvent -= ChangeCdrConvertProgress;
                Cdr.CurrentTaskFinished -= FininshCdrConvert;
            }
        }

        // Settings control

        void SettingsButton_Click(object sender, EventArgs e)
        {
            new SettingsWindow().ShowDialog();
        }

        // Common section

        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
                          
        }
    }
}
