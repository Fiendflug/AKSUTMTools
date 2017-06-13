using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DGenerator.Data.Models;
using System.Data;

namespace DGenerator.Data.DataAccess
{
    public class DatabaseUTM
    {
        SqlQueries Commands { get; set; }
        MySqlConnection Connection { get; set; }

        public delegate void StatusDelegate(string statusMessage);
        public event StatusDelegate ChangeStatusEvent;

        public DatabaseUTM(DatabaseConnectionInfo connectionInfo)
        {
            Commands = new SqlQueries();
            Connection = new MySqlConnection(
                "Server=" + connectionInfo.DatabaseHost + ";" +
                "Database=" + connectionInfo.DatabaseName + ";" +
                "Uid=" + connectionInfo.DatabaseUser + ";" +
                "Pwd=" + connectionInfo.DatabasePassword + ";" +
                "Port=" + connectionInfo.DatabasePort + ";"
                );

            ChangeStatusEvent = delegate { };
        }

        public void Connect()
        {
            try
            {
                Connection.Open();
                ChangeStatusEvent("Соединение с базой данных успешно установлено");
            }
            catch (MySqlException exc)
            {
                switch (exc.Number)
                {
                    case 0:
                        ChangeStatusEvent("Сервер базы данных недоступен. Проверьте настройки приложения и журнал");
                        break;
                    case 1045:
                        ChangeStatusEvent("Некорректные пользователь или пароль базы данных. Проверьте настройки приложения и журнал");
                        break;
                }
            }
        }
        
        public DataSet GetUsersForDataGrid(string groupName = "civil")
        {
            if (Connection.State == ConnectionState.Closed)
                Connect();

            try
            {
                MySqlDataAdapter adapter = null;
                switch (groupName)
                {
                    case "civil":
                        adapter = new MySqlDataAdapter(Commands.GetCivilUsersForDataGrid, Connection);
                        break;
                    case "legal":
                        adapter = new MySqlDataAdapter(Commands.GetLegalUsersForDataGrid, Connection);
                        break;                   
                }
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        public List<Call> GetCalls(long startPeriod, long endPeriod)
        {
            return null;
        }

        public List<ClientInfo> GetAllCilentsInfo (long startPeriod, long endPeriod)
        {
            return null;
        }

        public ClientInfo GetClientInfo(int account, long startPeriod, long endPeriod)
        {
            return null;
        }
    }
}
