using DGenerator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.DataAccess
{
    public struct CurrentPeriod
    {
        public long StartPeriod;
        public long EndPeriod;
    }

    public class SqlQueries
    {
        public string GetCivilUsersForDataGrid { get; set; }
        public string GetLegalUsersForDataGrid { get; set; }
        public string GetAccountCalls { get; set; }
        public string GetAllCalls { get; set; }
        public string GetAllUSersDetailInfo { get; set; }

        public CurrentPeriod Period { get; set; }
        public string CurrentUserAccount { get; set; }

        public SqlQueries()
        {
            GetCivilUsersForDataGrid = string.Format("SELECT users_accounts.account_id AS 'Аккаунт', users.login AS 'Логин', accounts.balance AS 'Баланс', users.full_name AS 'Полное имя', users.home_telephone AS 'Абонентский номер', users.actual_address AS 'Полный адрес', users.flat_number AS 'Квартира (опция)', users.comments AS 'Комментарий' FROM users, users_accounts, account_tariff_link, accounts WHERE users.id = users_accounts.uid AND users_accounts.account_id = account_tariff_link.account_id AND users_accounts.account_id = accounts.id AND account_tariff_link.tariff_id = 66 AND users.is_deleted = 0 AND account_tariff_link.is_deleted = 0;");
            GetLegalUsersForDataGrid = string.Format("SELECT users_accounts.account_id AS 'Аккаунт', users.login AS 'Логин', users.full_name AS 'Наименование организации', users.actual_address AS 'Адрес', users.comments AS 'Комментарий (договор)' FROM users, users_accounts, account_tariff_link WHERE users.id = users_accounts.uid AND users_accounts.account_id = account_tariff_link.account_id AND account_tariff_link.tariff_id = 65 AND users.is_deleted = 0 AND account_tariff_link.is_deleted = 0;");
            GetAccountCalls = string.Format("select tel_sessions_log.Calling_Station_Id, tel_sessions_log.Called_Station_Id, tel_zones_v2.name, tel_sessions_log.session_start_date, tel_sessions_detail.duration, tel_sessions_detail.base_cost, ROUND(tel_sessions_detail.sum_cost, 2)" +
                                        "from tel_sessions_log, tel_sessions_detail, tel_zones_v2" +
                                        "where tel_sessions_log.id = tel_sessions_detail.dhs_sess_id and" +
                                        "tel_sessions_log.account_id = {0} and" +
                                        "tel_sessions_log.zone_id = tel_zones_v2.id and" +
                                        "tel_sessions_log.session_start_date >= {1} and" +
                                        "tel_sessions_log.session_start_date < {2};",
                                        CurrentUserAccount, Period.StartPeriod, Period.EndPeriod
                );
            GetAllCalls = string.Format("select tel_sessions_log.Calling_Station_Id, tel_sessions_log.Called_Station_Id, tel_zones_v2.name, tel_sessions_log.session_start_date, tel_sessions_detail.duration, tel_sessions_detail.base_cost, ROUND(tel_sessions_detail.sum_cost, 2)" +
                                        "from tel_sessions_log, tel_sessions_detail, tel_zones_v2" +
                                        "where tel_sessions_log.id = tel_sessions_detail.dhs_sess_id and" +
                                        "tel_sessions_log.zone_id = tel_zones_v2.id and" +
                                        "tel_sessions_log.session_start_date >= {0} and" +
                                        "tel_sessions_log.session_start_date < {1};",
                                        Period.StartPeriod, Period.EndPeriod
                );
        }        
    }
}
