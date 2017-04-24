using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DGenerator.CDR.Convert
{
    public class ConverterCdr
    {
        string[] AllFiles { get; }
        string DestinationPath { get; }
        bool RemoveNullDirationCalls { get; }
        bool UseCorrectDurationCalls { get; }
        string[] CdrCorrectSettings { get; }

        public ConverterCdr(string[] filePaths, string destionationPath)
        {
            AllFiles = filePaths;
            DestinationPath = destionationPath;
        }

        public ConverterCdr(string[] filePaths, string destionationPath, 
            bool removeNullDirationCalls, bool useCorrectDurationCalls, params string[] cdrCorrectparams)
        {
            AllFiles = filePaths;
            DestinationPath = destionationPath;
            RemoveNullDirationCalls = removeNullDirationCalls;
            UseCorrectDurationCalls = useCorrectDurationCalls;
            CdrCorrectSettings = cdrCorrectparams;
        }

        public void Convert()
        {
            try
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
                        var inputTrunkInLine = splitedLine[0].Remove(0, 1); //Delete MTA 1-bit 
                        var outLine = "";

                        if (RemoveNullDirationCalls & UseCorrectDurationCalls)
                        {

                        }
                        else if (RemoveNullDirationCalls & !UseCorrectDurationCalls)
                        {
                            if (splitedLine[6] != "0")
                            {
                                outLine = splitedLine[1] + ";" + splitedLine[3] + ";" + splitedLine[6] + ";" +
                                lineCount.ToString() + ";" + splitedLine[4] + " " + splitedLine[5] + ";" +
                                inputTrunkInLine + ";" + splitedLine[2] + ";1\r\n";
                            }
                        }
                        else if (!RemoveNullDirationCalls & UseCorrectDurationCalls)
                        {
                            
                        }
                        else if (!RemoveNullDirationCalls & !UseCorrectDurationCalls)
                        {
                            outLine = splitedLine[1] + ";" + splitedLine[3] + ";" + splitedLine[6] + ";" +
                            lineCount.ToString() + ";" + splitedLine[4] + " " + splitedLine[5] + ";" +
                            inputTrunkInLine + ";" + splitedLine[2] + ";1\r\n";
                        }
                        File.AppendAllText(outCdrPath, outLine);
                        lineCount++;
                    }                    
                    fileStream.Close();
                }
            }
            catch (Exception exc)
            {

            }
        }
    }
}
