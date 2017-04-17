using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
                StreamReader fileStream = new StreamReader(cdr);
                var outCdrPath = DestinationPath + Path.GetFileNameWithoutExtension(cdr) + ".cdr";
                var lineCount = 0;
                string lines;
                while ((lines = fileStream.ReadLine()) != null)
                {
                    var splitedLine = lines.Split(new char[] { ' ' });
                    var inputTrunkInLine = splitedLine[0].Remove(0, 1);

                    var outLine = splitedLine[1] + ";" + splitedLine[3] + ";" + splitedLine[6] + ";" + 
                        lineCount.ToString() + ";" + splitedLine[4] + " " + splitedLine[5] + ";" + 
                        inputTrunkInLine + ";" + splitedLine[2] + ";1\r\n";

                    File.AppendAllText(outCdrPath, outLine);
                    lineCount++;
                }
                fileStream.Close();
            }
        }
    }
}
