using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.Models
{
    public class Bill
    {
        public int AccountID { get; set; }
        public DateTime CurrentPeriod { get; set; }
        public string FullName { get; set; }
        public string ActualAddress { get; set; }
        public decimal TarifSumm { get; set; }
        public decimal MGSumm { get; set; }
        public decimal BillSumm { get; set; }
    }
}
