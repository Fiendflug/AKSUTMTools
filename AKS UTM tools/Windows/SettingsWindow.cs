using AKS_UTM_tools.Windows;
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

        void SettingsWindow_Load(object sender, EventArgs e)
        {

            //CDR Settings section (Labels, Checkboxes, Buttons)
            
            LocalCdrPathLabel.Text += Settings.GetSetting("LocalCdrPath");
            RemoteCdrPathlabel.Text += Settings.GetSetting("RemoteCdrPath");
            ZipCdrPathLabel.Text = Settings.GetSetting("ZipCdrPath");
            if (Settings.GetSetting("RemoveConvertedCdr") == "1")
                DelecteLocalCdrCheckbox.Checked = true;
            if (Settings.GetSetting("RemoveCallsWithNullDuration") == "1")
                DeleteZeroCallsCdrCheckbox.Checked = true;
            if (Settings.GetSetting("CorrectCdrDuration") == "1")
                EditCdrCheckbox.Checked = true;
        }

        //CDR Settings controls section

        void DelecteLocalCdrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = "";
            if (DelecteLocalCdrCheckbox.Checked)
                value = "1";
            else
                value = "0";
            Settings.UpdateSetting("RemoveConvertedCdr", value);
        }

        void DeleteZeroCallsCdrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = "";
            if (DeleteZeroCallsCdrCheckbox.Checked)
                value = "1";
            else
                value = "0";
            Settings.UpdateSetting("RemoveCallsWithNullDuration", value);
        }

        void EditCdrCheckbox_CheckedChanged(object sender, EventArgs e)
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
            Settings.UpdateSetting("CorrectCdrDuration", value);
        }

        void EditCdrSettingsButton_Click(object sender, EventArgs e)
        {

        }

        void LocalCdrPathSelectButton_Click(object sender, EventArgs e)
        {
            if(pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("LocalCdrPath", pathBrowserDialog.SelectedPath + "\\");
                LocalCdrPathLabel.Text = "Локальное расположение " + pathBrowserDialog.SelectedPath + "\\";
            }
        }

        void RemoteCdrpathButton_Click(object sender, EventArgs e)
        {
            InputDialog dialogForm = new InputDialog();
            if(dialogForm.ShowDialog() == DialogResult.OK)
            {
                if(dialogForm.inputTextBox.Text != "")
                {
                    Settings.UpdateSetting("RemoteCdrPath", dialogForm.inputTextBox.Text);
                    RemoteCdrPathlabel.Text = "Расположение на сервере - " + dialogForm.inputTextBox.Text;
                }
            } 
        }

        void ZipCdrPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("ZipCdrPath", pathBrowserDialog.SelectedPath);
                ZipCdrPathLabel.Text = pathBrowserDialog.SelectedPath;
            }
        }

        // Server connection Settings controls

        

        // Main controls (OK, Submit, Cancel, Help)

        void SubmitSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings();
        }

        void OkSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings();
            Close();
        }

        void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void HelpSettingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}