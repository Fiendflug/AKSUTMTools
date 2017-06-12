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
        DataService DataAccess { get; set; }
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

            DataAccess = DataService.GetInstance();
            DataAccess.ChangeStatusEvent += ChangeStatus;
            DataAccess.FillDataSetEvent += FinishFillDataSetForGridView;

            Period = PeriodService.GetInstance();
            Period.ShowPeriodEvent += ChangePeriodStatus;
            ChangePeriodStatus();
        }

        // SSH connection to UTM server controls section

        private void ButtonSshConnection_Click(object sender, EventArgs e)
        {            
            ConnectUtmServer.Connect();      
            if(!ConnectUtmServer.IsConnected) // TEMPORARY
                DataAccess.FillDataGridView();
        }

        void ButtonCloseSshConnection_Click(object sender, EventArgs e)
        {       
            ConnectUtmServer.Disconnect();
            EmptyDataGrid();
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

        // Data grid view groups controls

        private void buttonShowLegalClients_Click(object sender, EventArgs e)
        {
            if (!ConnectUtmServer.IsConnected)
                ConnectUtmServer.Connect();
            DataAccess.FillDataGridView("civil");
        }

        private void buttonShowOrganizationClients_Click(object sender, EventArgs e)
        {
            if (!ConnectUtmServer.IsConnected)
                ConnectUtmServer.Connect();
            DataAccess.FillDataGridView("legal");
        }

        // Data methods section
        
        void EmptyDataGrid()
        {
            mainDataGrid.DataSource = null;
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

        // Settings methods section

        void ShowSettingsForm()
        {
            SettingsWindow settingsFormDialog = new SettingsWindow();
            if (settingsFormDialog.ShowDialog() == DialogResult.OK)
            {
                //ConnectUtmServer.RefreshConnectionSettings(); Обнаовляем комменкт
                ChangeStatus("Конфигурация приложения успешно изменена");
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

        void FinishFillDataSetForGridView()
        {
            BeginInvoke((Action)delegate
            {
                if(DataAccess.DataGrid != null)
                {                    
                    mainDataGrid.DataSource = DataAccess.DataGrid.Tables[0];
                }                    
            });
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
                StatusLabel.Text = Status;
            });
        }

        void ChangePeriodStatus()
        {
            periodLabel.Text = "Расчетный период - " +
                Period.LabeledPeriod.ToString("MMMM") + " " + Period.LabeledPeriod.Year.ToString();
        }

        // Data Grid View styles mmethods and events

        private void mainDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var index = e.RowIndex;
            var indexStr = (index + 1).ToString();
            object header = mainDataGrid.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                mainDataGrid.Rows[index].HeaderCell.Value = indexStr;            
        }

        // Settings control

        void SettingsButton_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private void SettingsTopMenu_Click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        // Common controls section

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuitTopMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
