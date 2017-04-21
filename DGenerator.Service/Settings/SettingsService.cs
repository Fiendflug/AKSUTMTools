using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DGenerator.Service.Settings
{
    public class SettingsService
    {
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

        }

        public void SaveSettings()
        {

        }
    }
}
