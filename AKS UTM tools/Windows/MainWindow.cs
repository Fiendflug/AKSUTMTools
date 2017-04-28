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
        SettingsService Settings { get; set; }
        CdrService Cdr { get; set; }
        ServerConnectService ConnectUtmServer { get; set; }

        
        public MainWindow()
        {
            InitializeComponent();
        }

        void MainWindow_Load(object sender, EventArgs e)
        {
            Settings = new SettingsService();
            ConnectUtmServer = ServerConnectService.GetInstance();                             
        }

        // SSH connection to UTM server controls section

        private void ButtonSshConnection_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = ConnectUtmServer.Connect();
        }

        void ButtonCloseSshConnection_Click(object sender, EventArgs e)
        {       
            StatusLabel.Text = ConnectUtmServer.Disconnect();
        }

        void ConnectToServerTopMenu_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = ConnectUtmServer.Connect();
        }

        void DisconnectServerTopMenu_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = ConnectUtmServer.Disconnect();
        }

        // CDR controls section

        void ConvertCdrButton_Click(object sender, EventArgs e)
        {
            ConvertCdr();
        }

        private void TransferCdrToServerButton_Click(object sender, EventArgs e)
        {
            TransferCdr();
        }

        void ViewCdrInFolderButton_Click(object sender, EventArgs e)
        {
            if (Cdr == null)
                Cdr = new CdrService(null);
            Cdr.View();
        }

        void ConvertCdrTopMenu_Click(object sender, EventArgs e)
        {
            ConvertCdr();
        }

        private void TransferCdrToServerTopMenu_Click(object sender, EventArgs e)
        {
            TransferCdr();
        }

        void ViewCdrInFolderTopMenu_Click(object sender, EventArgs e)
        {
            if (Cdr == null)
                Cdr = new CdrService(null);
            Cdr.View();
        }

        // CDR methods section

        void ConvertCdr()
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

        void TransferCdr()
        {
            openFileDialog.Reset();
            openFileDialog.FileName = "*.cdr";
            openFileDialog.Filter = "Файлы статистики в UTM формате|*.cdr";
            openFileDialog.InitialDirectory = Settings.GetSetting("LocalCdrPath");
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Maximum = openFileDialog.FileNames.Length;

                Cdr = new CdrService(openFileDialog.FileNames);

                Cdr.TransferOneCdrEvent += ChangeCdrTransferProgress;
                Cdr.CurrentTaskFinished += FinishCdrTransfer;
                Cdr.Transfer();
            }
        }

        // Progress Info Section

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

        void ChangeCdrTransferProgress()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value++;
                StatusLabel.Text = "Передаю CDR-файлы на сервер";
            });
        }

        void FinishCdrTransfer()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value = 0;
                StatusLabel.Text = "Все CDR-файлы были успешно переданы на сервер";
            });
            if (Cdr != null)
            {
                Cdr.TransferOneCdrEvent -= ChangeCdrTransferProgress;
                Cdr.CurrentTaskFinished -= FinishCdrTransfer;
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
