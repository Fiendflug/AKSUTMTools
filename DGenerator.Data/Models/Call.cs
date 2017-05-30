using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.Data.Models
{
    public class Call
    {
        public int NumberA { get; set; }
        public int NumberB { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Trunk { get; set; }
        public decimal Summ { get; set; }
    }
}
