using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;

namespace DGenerator.CDR
{
    public class ArchiveCdr
    {
        string[] FilePaths { get; set; }
        string ArchivePath { get; set; }
        string ArchiveName { get; set; }
        
        public delegate void ZipDelegate();
        public delegate void StatusDelegate(string statusMessage);

        public event ZipDelegate ZipOneCdrEvent;
        public event StatusDelegate ChangeStatusEvent;

        public ArchiveCdr(string[] filePaths, string archivePath, string archiveName)
        {
            FilePaths = filePaths;
            ArchivePath = archivePath;
            ArchiveName = archiveName;

            ZipOneCdrEvent = delegate { };
            ChangeStatusEvent = delegate { };
        }

        public void StartCompress()
        {
            try
            {
                var archivePath = Path.Combine(ArchivePath, ArchiveName);                
                using (var zip = new ZipFile(archivePath))
                {
                    zip.CompressionLevel = CompressionLevel.Default;
                    foreach (var cdr in FilePaths)
                    {
                        zip.AddFile(cdr, ArchiveName);
                        ChangeStatusEvent("CDR-файлы успешно добавлены в архив");
                        ZipOneCdrEvent();
                    }
                    zip.Save();
                    ChangeStatusEvent("Оперция завершена. Все CDR-файлы успешно заархивированы");
                } 
            }
            catch(DirectoryNotFoundException exc)
            {
                //Не найдена папка для сохранения
                ChangeStatusEvent("Невозможно сохранить архив. Некорректная");
            }
            catch(ArgumentException exc)
            {
                //Файл с таким именем существует
                ChangeStatusEvent("Невозможно сохранить архив. Файл с указанным именем уже существует");
            }
            catch(ZipException exc)
            {
                ChangeStatusEvent("Невозможно сохранить архив. Проверьте журнал для получения подробной информации");
            }
            catch(Exception exc)
            {
                ChangeStatusEvent("Неизвестная ошибка. Проверьте журнал для получения подробной информации");
            }            
        }        
    }
}
