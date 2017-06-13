
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.Models
{
    public class ClientInfo
    {
        public int Account { get; set; }
        public string Login { get; set; }
        public string ContractNumber { get; set; }
        public string Group { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public List<Call> AllPhoneConnections { get; set; }
        public decimal MGSumm { get; set; }
        public decimal PeriodicSumm { get; set; }
        public decimal TotalSumm { get { return MGSumm + PeriodicSumm; } }
    }
}
