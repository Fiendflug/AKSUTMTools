using DGenerator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.DataAccess
{
    public class SqlQueries
    {
        public string GetAllUsersForDataGrid { get; set; }
        public string GetCivilUsersForDataGrid { get; set; }
        public string GetLegalUsersForDataGrid { get; set; }
        public string GetAllCalls { get; set; }
        public string GetAllUSersDetailInfo { get; set; }

        public SqlQueries()
        {
            //GetAllUsersForDataGrid = string.Format("SELECT users_accounts.account_id, users.login, users.full_name, users.actual_address, users.flat_number FROM users, users_accounts, account_tariff_link WHERE users.id = users_accounts.uid AND users_accounts.account_id = account_tariff_link.account_id AND users.is_deleted = 0 AND account_tariff_link.is_deleted = 0;");
            GetCivilUsersForDataGrid = string.Format("SELECT users_accounts.account_id, users.login, accounts.balance, users.full_name, users.home_telephone, users.actual_address, users.flat_number, users.comments FROM users, users_accounts, account_tariff_link, accounts WHERE users.id = users_accounts.uid AND users_accounts.account_id = account_tariff_link.account_id AND users_accounts.account_id = accounts.id AND account_tariff_link.tariff_id = 66 AND users.is_deleted = 0 AND account_tariff_link.is_deleted = 0;");
            GetLegalUsersForDataGrid = string.Format("SELECT users_accounts.account_id, users.login, users.full_name, users.actual_address, users.comments FROM users, users_accounts, account_tariff_link WHERE users.id = users_accounts.uid AND users_accounts.account_id = account_tariff_link.account_id AND account_tariff_link.tariff_id = 65 AND users.is_deleted = 0 AND account_tariff_link.is_deleted = 0;");

        }        
    }
}
