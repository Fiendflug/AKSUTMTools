using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.Models
{
    public class User
    {
        public int AccountID { get; set; }
        public int GroupID { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public string ActualAddress { get; set; }
        public string FlatNumber { get; set; }        
    }
}
