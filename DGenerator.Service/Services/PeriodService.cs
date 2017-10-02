using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGenerator.Data.DataAccess;

namespace DGenerator.Service.Services
{
    public class PeriodService
    {
        static PeriodService Instance { get; set; }
        public CurrentPeriod PeriodDays { get; set; }
        public DateTime LabeledPeriod { get; set; }
        DateTime UnixStartDate { get; set; }

        public delegate void ChangePeriodStatus();

        public event ChangePeriodStatus ShowPeriodEvent; 

        private PeriodService()
        {
            UnixStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            ShowPeriodEvent = delegate { };
            PeriodDays = GetCurrentPeriod(DateTime.Now.AddMonths(-1));
        }

        public static PeriodService GetInstance()
        {
            if (Instance == null)
                Instance = new PeriodService();
            return Instance;
        }

        CurrentPeriod GetCurrentPeriod(DateTime date)
        {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            var period = new CurrentPeriod();
            
            period.StartPeriod = (long)(firstDay - UnixStartDate).TotalSeconds;
            period.EndPeriod = (long)(lastDay - UnixStartDate).TotalSeconds;

            LabeledPeriod = date;
            ShowPeriodEvent();    

            return period;
        }

        public void SetCurrentPeriod(DateTime selectedDate)
        {
            PeriodDays = GetCurrentPeriod(selectedDate);
        }        
    }
}
