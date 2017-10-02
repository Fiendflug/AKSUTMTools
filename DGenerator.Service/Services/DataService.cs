using DGenerator.Data.DataAccess;
using DGenerator.Data.Models;
using DGenerator.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Service.Services
{
    public class DataService
    {
        static DataService Insatance { get; set; }
        DatabaseUTM Connect { get; set; }
        DatabaseConnectionInfo ConnectionInfo { get; set; }
        SettingsService Settings { get; set; }
        PeriodService Period { get; set; }

        public delegate void ChangeStatusDelegate(string statusMessage);
        public delegate void FinishFillDataSet();

        public event ChangeStatusDelegate ChangeStatusEvent;
        public event FinishFillDataSet FillDataSetEvent;

        public DataSet DataGrid { get; set; }

        private DataService()
        {
            Settings = new SettingsService();
            ConnectionInfo = new DatabaseConnectionInfo()
            {
                DatabaseHost = Settings.GetSetting("DatabaseHost"),
                DatabaseName = Settings.GetSetting("DatabaseName"),
                DatabasePort = Settings.GetSetting("DatabasePort"),
                DatabaseUser = Settings.GetSetting("DatabaseUser"),
                DatabasePassword = Settings.GetSetting("DatabasePassword")
            };
            Period = PeriodService.GetInstance();
            Connect = new DatabaseUTM(ConnectionInfo);
            
            ChangeStatusEvent = delegate { };
            FillDataSetEvent = delegate { };
            Connect.ChangeStatusEvent += ChangeStatus;
        }

        public static DataService GetInstance()
        {
            if (Insatance == null)
                Insatance = new DataService();
            return Insatance;
        }

        public void ConnectDatabase()
        {
            Connect.Connect();
        }

        public void FillDataGridView(string groupName = null)
        {
            Task.Factory.StartNew(() =>
            {
                DataGrid = Connect.GetUsersForDataGrid(groupName);
            }).ContinueWith((f) => 
            {
                FinishFillDataGrid();
            });
        }

        public BaseReport GenerateBaseReport()
        {
            return null;
        }

        void GenerateBill(CurrentPeriod period, string group)
        {
            var clientsInfo = Connect.GetAllCilentsInfo(period.StartPeriod, period.EndPeriod);
            List<string> allClients = null;
            var fileName = ""; // ДОДЕЛАТЬ
            var lineCount = 0;
            foreach(var client in clientsInfo)
            {
                if(client.Group == group)
                {
                    allClients.Add(string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", 
                            lineCount, client.Account, client.Login, client.ContractNumber, client.FullName, client.MGSumm, client.PeriodicSumm, client.TotalSumm
                        ));
                }
            }
            File.AppendAllLines(Path.Combine(Settings.GetSetting("CommonReportPath"), fileName), allClients);      
        }

        public List<Bill> GenerateAllBills()
        {
            return null;
        }

        void ChangeStatus(string statusMesasge)
        {
            ChangeStatusEvent(statusMesasge);
        }

        void FinishFillDataGrid()
        {
            FillDataSetEvent();
        }
    }
}
