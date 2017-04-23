using DGenerator.Service.Services;
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

            //CDR Settings section (Labels, Checkboxes, Buttons)
            
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

        //CDR Settings controls section

        private void DelecteLocalCdrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = "";
            if (DelecteLocalCdrCheckbox.Checked)
                value = "1";
            else
                value = "0";
            Settings.UpdateSetting("RemoveConvertedCdr", value);
        }

        private void DeleteZeroCallsCdrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = "";
            if (DeleteZeroCallsCdrCheckbox.Checked)
                value = "1";
            else
                value = "0";
            Settings.UpdateSetting("RemoveCallsWithNullDuration", value);
        }

        private void EditCdrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = "";
            if (EditCdrCheckbox.Checked)
            {
                EditCdrSettingsButton.Enabled = true;
                value = "1";
            }
            else
            {
                EditCdrSettingsButton.Enabled = false;
                value = "0";
            }
            Settings.UpdateSetting("CorretCdrDuration", value);
        }

        private void EditCdrSettingsButton_Click(object sender, EventArgs e)
        {

        }

        private void LocalCdrPathSelectButton_Click(object sender, EventArgs e)
        {
            if(pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("LocalCdrPath", pathBrowserDialog.SelectedPath);
                LocalCdrPathLabel.Text = pathBrowserDialog.SelectedPath;
            }
        }

        private void ZipCdrPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("ZipCdrPath", pathBrowserDialog.SelectedPath);
                ZipCdrPathLabel.Text = pathBrowserDialog.SelectedPath;
            }
        }



        // Main controls (OK, Submit, Cancel, Help)

        private void SubmitSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings();
        }

        private void OkSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings();
            Close();
        }

        private void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpSettingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
