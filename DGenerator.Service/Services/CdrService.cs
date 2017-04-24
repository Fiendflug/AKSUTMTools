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
        string[] FilePaths { get; }
        public delegate void ProgressCdrConvertation();
        public event ProgressCdrConvertation ConvertOneCdrEvent;

        public CdrService(string[] filePaths)
        {
            AllSettings = new SettingsService();
            FilePaths = filePaths;

            if (AllSettings.GetSetting("RemoveCallsWithNullDuration") == "1" & AllSettings.GetSetting("CorrectCdrDuration") == "1")
                Converter = new ConverterCdr(FilePaths, AllSettings.GetSetting("LocalCdrPath"), true, true);
            else if (AllSettings.GetSetting("RemoveCallsWithNullDuration") == "1" & AllSettings.GetSetting("CorrectCdrDuration") == "0")
                Converter = new ConverterCdr(FilePaths, AllSettings.GetSetting("LocalCdrPath"), true, false);
            else if (AllSettings.GetSetting("RemoveCallsWithNullDuration") == "0" & AllSettings.GetSetting("CorrectCdrDuration") == "1")
                Converter = new ConverterCdr(FilePaths, AllSettings.GetSetting("LocalCdrPath"), false, true);
            else if (AllSettings.GetSetting("RemoveCallsWithNullDuration") == "0" & AllSettings.GetSetting("CorrectCdrDuration") == "0")
                Converter = new ConverterCdr(FilePaths, AllSettings.GetSetting("LocalCdrPath"));

            Converter.ConvertFileEvent += ChangeProgress;
            ConvertOneCdrEvent = delegate { };
        }

        public void Convert()
        {
            Task convertWork = new Task(() => Converter.Convert());
            convertWork.Start();
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

        void ChangeProgress()
        {            
            ConvertOneCdrEvent();
        }
    }
}
