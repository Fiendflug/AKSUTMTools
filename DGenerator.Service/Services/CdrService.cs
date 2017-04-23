using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGenerator.CDR.Convert;

namespace DGenerator.Service.Services
{
    public class CdrService
    {
        SettingsService AllSettings { get; }
        ConverterCdr Converter { get; }
        string[] FilePaths { get; set; }

        public CdrService(string[] filePaths)
        {
            AllSettings = new SettingsService();
            FilePaths = filePaths;
            Converter = new ConverterCdr(FilePaths, AllSettings.GetSetting("LocalCdrPath"));            
        }

        public void Convert()
        {
            if (AllSettings.GetSetting("CorretCdrDuration") == "1")
            {
                
            }
            else
            {

            }
        }

        public void Transfer()
        {

        }

        public void Archive()
        {

        }

        public void View()
        {

        }
    }
}
