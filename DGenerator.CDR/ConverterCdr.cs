using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DGenerator.CDR
{
    public class ConverterCdr
    {
        public delegate void ConvertOneFile();
        public delegate void StatusDelegate(string statusMessage);

        public event ConvertOneFile ConvertFileEvent;
        public event StatusDelegate ChangeStatusEvent;

        string[] AllFiles { get; }
        string DestinationPath { get; }
        bool RemoveNullDirationCalls { get; }
        bool UseCorrectDurationCalls { get; }
        string[] CdrCorrectSettings { get; }

        public ConverterCdr(string[] filePaths, string destionationPath)
        {
            AllFiles = filePaths;
            DestinationPath = destionationPath;
            ConvertFileEvent = delegate { };
            ChangeStatusEvent = delegate { };
        }

        public ConverterCdr(string[] filePaths, string destionationPath, 
            bool removeNullDirationCalls, bool useCorrectDurationCalls, params string[] cdrCorrectparams)
        {
            AllFiles = filePaths;
            DestinationPath = destionationPath;
            RemoveNullDirationCalls = removeNullDirationCalls;
            UseCorrectDurationCalls = useCorrectDurationCalls;
            CdrCorrectSettings = cdrCorrectparams;
            ConvertFileEvent = delegate { };
            ChangeStatusEvent = delegate { };
        }

        public void Convert()
        {
            try
            {
                ChangeStatusEvent("Приступаю к конвертированию CDR-файлов");
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
                            ChangeStatusEvent("Данная функция находится в разработке. Проверьте настройки приложения");
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
                            ChangeStatusEvent("Данная функция находится в разработке. Проверьте настройки приложения");
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
                    ConvertFileEvent();
                    ChangeStatusEvent("Файл " + Path.GetFileName(outCdrPath) + " конвертируется в формат UTM5");
                }
                ChangeStatusEvent("Все CDR-файлы были успешно сконверитроавны");
            }
            catch(DirectoryNotFoundException exc)
            {
                ChangeStatusEvent("Некорректный путь для сохраниния CDR-ов. CDR-файлы не были сконвертированы");
            }
            catch (Exception exc)
            {
                ChangeStatusEvent("Неизвестная ошибка. Проверьте журнал для получения подробной информации");
            }
        }
    }
}
