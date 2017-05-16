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
using System.Globalization;

namespace AKS_UTM_tools
{
    public partial class MainWindow : Form
    {
        SettingsService Settings { get; set; }
        CdrService Cdr { get; set; }
        ServerConnectService ConnectUtmServer { get; set; }
        PeriodService Period { get; set; }

        string Status { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        void MainWindow_Load(object sender, EventArgs e)
        {
            Settings = new SettingsService();            

            ConnectUtmServer = ServerConnectService.GetInstance();
            ConnectUtmServer.ChangeStatusEvent += ChangeStatus;

            Period = PeriodService.GetInstance();
            Period.ShowPeriodEvent += ChangePeriodStatus;
            ChangePeriodStatus();
        }

        // SSH connection to UTM server controls section

        private void ButtonSshConnection_Click(object sender, EventArgs e)
        {            
            ConnectUtmServer.Connect();
        }

        void ButtonCloseSshConnection_Click(object sender, EventArgs e)
        {       
            ConnectUtmServer.Disconnect();
        }

        void ConnectToServerTopMenu_Click(object sender, EventArgs e)
        {
            ConnectUtmServer.Connect();
        }

        void DisconnectServerTopMenu_Click(object sender, EventArgs e)
        {
            ConnectUtmServer.Disconnect();
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

        void ZipCdrButton_Click(object sender, EventArgs e)
        {
            ArchiveCdr();
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

        private void ZipCdrTopMenu_Click(object sender, EventArgs e)
        {
            ArchiveCdr();
        }

        // Period controls section

        private void PeriodButton_Click(object sender, EventArgs e)
        {
            SetPeriod();
        }

        private void PeriodTopMenu_Click(object sender, EventArgs e)
        {
            SetPeriod();
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
                Cdr.ChangeStatusEvent += ChangeStatus;
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
                Cdr.ChangeStatusEvent += ChangeStatus;
                Cdr.CurrentTaskFinished += FinishCdrTransfer;
                Cdr.Transfer();
            }
        }

        void ArchiveCdr()
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
                Cdr.ZipOneCdrEvent += ChangeCdrArchiveProgress;
                Cdr.ChangeStatusEvent += ChangeStatus;
                Cdr.CurrentTaskFinished += FinishCdrArchive;
                Cdr.Archive();
            }
        }

        // Period methods section

        void SetPeriod()
        {
            PeriodWindow periodFormDialog = new PeriodWindow();
            if (periodFormDialog.ShowDialog() == DialogResult.OK)
            {
                Period.SetCurrentPeriod(periodFormDialog.dateTimePicker.Value);
            }
        }

        // Progressinfo section

        void ChangeCdrConvertProgress()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value++;
            });
        }

        void ChangeCdrTransferProgress()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value++;
            });
        }

        void ChangeCdrArchiveProgress()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value++;
            });
        }

        // Finish events Section
        
        void FininshCdrConvert()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value = 0;
                StatusLabel.Text = Status;
            });
            if (Cdr != null)
            {
                Cdr.ConvertOneCdrEvent -= ChangeCdrConvertProgress;
                Cdr.ChangeStatusEvent -= ChangeStatus;
                Cdr.CurrentTaskFinished -= FininshCdrConvert;
            }
        }        

        void FinishCdrTransfer()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value = 0;
                StatusLabel.Text = Status;
            });
            if (Cdr != null)
            {
                Cdr.TransferOneCdrEvent -= ChangeCdrTransferProgress;
                Cdr.CurrentTaskFinished -= FinishCdrTransfer;
            }
        }        

        void FinishCdrArchive()
        {
            BeginInvoke((Action)delegate {
                progressBar.Value = 0;
                StatusLabel.Text = Status;
            });
            if (Cdr != null)
            {
                Cdr.ZipOneCdrEvent -= ChangeCdrArchiveProgress;
                Cdr.ChangeStatusEvent -= ChangeStatus;
                Cdr.CurrentTaskFinished -= FinishCdrArchive;
            }
        }

        // Status info section
        
        void ChangeStatus(string statusMessage)
        {
            BeginInvoke((Action)delegate {
                Status = statusMessage;
                StatusLabel.Text = statusMessage;
            });
        }

        void ChangePeriodStatus()
        {
            periodLabel.Text = "Расчетный период - " +
                Period.LabeledPeriod.ToString("MMMM") + " " + Period.LabeledPeriod.Year.ToString();
        }

        // Settings control

        void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsFormDialog = new SettingsWindow();
            if (settingsFormDialog.ShowDialog() == DialogResult.OK)
            {
                ConnectUtmServer.RefreshConnectionSettings();
                StatusLabel.Text = "Конфигурация приложения успешно изменена";
            }
        }

        // Common section

        void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
                   
        }        
    }
}
