using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.Models
{
    public class PhoneConnect
    {
        public int ANumber { get; set; }
        public int BNumber { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string TrunkName { get; set; }
        public decimal Summ { get; set; }
    }
}
