
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.Models
{
    public class UserDetail
    {
        public string CurrentPeriod { get; set; }
        public string ContractNumber { get; set; }
        public string FullName { get; set; }
        public int LinesCount { get; set; }
        public int MGSumm { get; set; }
        public PhoneConnect[] AllPhoneConnections { get; set; }

    }
}
