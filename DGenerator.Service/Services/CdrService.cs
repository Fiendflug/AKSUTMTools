using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGenerator.CDR;
using System.Diagnostics;
using DGenerator.Data.ServerUTM;

namespace DGenerator.Service.Services
{
    public class CdrService
    {
        SettingsService AllSettings { get; }
        ConverterCdr Converter { get; }
        ArchiveCdr Zip { get; }
        ServerConnectService ServerConnect { get; set; }
        public string[] FilePaths { get; set; }
        public delegate void ProgressCdrConvertation();
        public delegate void ProgressCdrTransfer();
        public delegate void ProgressCdrZip();
        public delegate void FinishTask();
        public delegate void ChangeStatusDelegate(string statusMessage);

        public event ProgressCdrConvertation ConvertOneCdrEvent;
        public event ProgressCdrTransfer TransferOneCdrEvent;
        public event ProgressCdrZip ZipOneCdrEvent;
        public event FinishTask CurrentTaskFinished;
        public event ChangeStatusDelegate ChangeStatusEvent;

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

            Zip = new ArchiveCdr(FilePaths, AllSettings.GetSetting("ZipCdrPath"), "PeriodTestArchive.zip");

            ConvertOneCdrEvent = delegate { };
            TransferOneCdrEvent = delegate { };
            ZipOneCdrEvent = delegate { };
            CurrentTaskFinished = delegate { };
            ChangeStatusEvent = delegate { };
        }

        public void Convert()
        {
            Task.Factory.StartNew(() =>
                {
                    Converter.ConvertFileEvent += ConvertOneCdr;
                    Converter.ChangeStatusEvent += ChangeStatus;
                    Converter.Convert();
                }).ContinueWith((f) => 
                {
                    FinishConvert();
                });
        }

        public void Transfer()
        {
            ServerConnect = ServerConnectService.GetInstance(FilePaths);
            Task.Factory.StartNew(() =>
            {                
                ServerConnect.CdrTransferEvent += TransferOneCdr;
                ServerConnect.ChangeStatusEvent += ChangeStatus;
                ServerConnect.Transfer();
            }).ContinueWith((f) =>
            {
                FinishTransfer();
            });
        }

        public void Archive()
        {
            Task.Factory.StartNew(() =>
            {
                Zip.ZipOneCdrEvent += ZipOneCdr;
                Zip.ChangeStatusEvent += ChangeStatus;
                Zip.StartCompress();
            }).ContinueWith((f) =>
            {
                FinishConvert();
            });
        }

        public void View()
        {
            Process.Start("explorer.exe", AllSettings.GetSetting("LocalCdrPath"));
        }

        void ConvertOneCdr()
        {            
            ConvertOneCdrEvent();
        }

        void TransferOneCdr()
        {
            TransferOneCdrEvent();
        }

        void ZipOneCdr()
        {
            ZipOneCdrEvent();
        }

        void FinishTransfer()
        {
            CurrentTaskFinished();
            ServerConnect.CdrTransferEvent -= TransferOneCdr;
            ServerConnect.ChangeStatusEvent -= ChangeStatus;
        }

        void FinishConvert()
        {
            CurrentTaskFinished();
            Converter.ConvertFileEvent -= ConvertOneCdr;
            Converter.ChangeStatusEvent -= ChangeStatus;
        }

        void FinishArchive()
        {
            CurrentTaskFinished();
            Zip.ZipOneCdrEvent -= ZipOneCdr;
            Zip.ChangeStatusEvent -= ChangeStatus;
        }

        void ChangeStatus(string statusMesasge)
        {
            ChangeStatusEvent(statusMesasge);
        }
    }
}
