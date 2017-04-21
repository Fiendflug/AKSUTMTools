using DGenerator.Service.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKS_UTM_tools
{
    public partial class SettingsWindow : Form
    {
        SettingsService Settings;

        public SettingsWindow()
        {
            InitializeComponent();
            Settings = new SettingsService();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {

            //CDR Settings section
            
            LocalCdrPathLabel.Text = Settings.GetSetting("LocalCdrPath");
            RemoteCdrPathlabel.Text = Settings.GetSetting("RemoteCdrPath");
            ZipCdrPathLabel.Text = Settings.GetSetting("ZipCdrPath");
            if (Settings.GetSetting("RemoveConvertedCdr") == "1")
                DelecteLocalCdrCheckbox.Checked = true;
            if (Settings.GetSetting("RemoveCallsWithNullDuration") == "1")
                DeleteZeroCallsCdrCheckbox.Checked = true;
            if (Settings.GetSetting("CorretCdrDuration") == "1")
                EditCdrCheckbox.Checked = true;
                
        }

        private void EditCdrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!EditCdrCheckbox.Checked)
                EditCdrSettingsButton.Enabled = false;
            else
                EditCdrSettingsButton.Enabled = true;
        }

        private void EditCdrSettingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
