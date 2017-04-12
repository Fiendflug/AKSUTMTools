using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGenerator.CDR.Convert
{
    public class ConverterCDR
    {
        string[] AllFiles { get; set; }
        string DestinationPath { get; set; }

        ConverterCDR(string[] filePaths, string destionationPath)
        {
            AllFiles = filePaths;
            DestinationPath = destionationPath;
        }

        public void Convert()
        {
            foreach (var cdr in AllFiles)
            {

            }
        }
    }
}
