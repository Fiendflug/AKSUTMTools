using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGenerator.CDR.Convert;
using System.Diagnostics;
using DGenerator.Data.ServerUTM;

namespace DGenerator.Service.Services
{
    public class CdrService
    {
        SettingsService AllSettings { get; }
        ConverterCdr Converter { get; }
        string[] FilePaths { get; }
        public delegate void ProgressCdrConvertation();
        public delegate void FinishTask();
        public event ProgressCdrConvertation ConvertOneCdrEvent;
        public event FinishTask CurrentTaskFinished;

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

            
            ConvertOneCdrEvent = delegate { };
            CurrentTaskFinished = delegate { };
        }

        public void Convert()
        {
            Task.Factory.StartNew(() =>
                {
                    Converter.ConvertFileEvent += ChangeProgress;
                    Converter.Convert();
                }).ContinueWith((f) => 
                {
                    FinishConvert();
                });
        }

        public void Transfer()
        {
            
        }

        public void Archive()
        {

        }

        public void View()
        {
            Process.Start("explorer.exe", AllSettings.GetSetting("LocalCdrPath"));
        }

        void ChangeProgress()
        {            
            ConvertOneCdrEvent();
        }

        void FinishConvert()
        {
            CurrentTaskFinished();
            Converter.ConvertFileEvent -= ChangeProgress;
        }
    }
}
