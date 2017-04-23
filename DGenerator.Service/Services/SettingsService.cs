using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DGenerator.Service.Services
{
    public class SettingsService
    {
        Configuration ConfigurationFile { get; set; }

        public SettingsService()
        {
            ConfigurationFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetSetting(string name)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[name] ?? "Сбой чтения конфигурации";
            }
            catch (ConfigurationErrorsException exc)
            {
                Console.WriteLine(exc.Message);
                return "Сбой чтения конфигурации";              
            }
        }

        public void UpdateSetting(string name, string value)
        {
            try
            {
                var settings = ConfigurationFile.AppSettings.Settings;                
                if (settings[name] != null)
                    settings[name].Value = value;
            }
            catch(ConfigurationErrorsException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void SaveSettings()
        {
            try
            {
                ConfigurationFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(ConfigurationFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
