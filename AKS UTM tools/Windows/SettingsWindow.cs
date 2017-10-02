using AKS_UTM_tools.Windows;
using DGenerator.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            //Submit/cancel cotrols

            OkSettingsButton.DialogResult = DialogResult.OK;
            CancelButton.DialogResult = DialogResult.Cancel;

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

            //Server connect section

            ServerHostLabel.Text += Settings.GetSetting("ServerHost");
            ServerUsernameLabel.Text += Settings.GetSetting("ServerUser");
            ServerPasswordLabel.Text += Settings.GetSetting("ServerPassword");
            ServerPortLabel.Text += Settings.GetSetting("ServerPort");

            //Database connect section

            DatabaseHostLabel.Text += Settings.GetSetting("DatabaseHost");
            DatabaseUsernameLabel.Text += Settings.GetSetting("DatabaseUser");
            DatabasePasswordLabel.Text += Settings.GetSetting("DatabasePassword");
            DatabasePortLabel.Text += Settings.GetSetting("DatabasePort");
            DatabaseNameLabel.Text += Settings.GetSetting("DatabaseName");

            //Documents section

            localBillsPathLabel.Text += Settings.GetSetting("LocalBillsPath");
            localDetailsPathLabel.Text += Settings.GetSetting("LocalDetailsPath");
            localBaseReportPathsLabel.Text += Settings.GetSetting("BaseReportPath");
            localOperatorPathsLabel.Text += Settings.GetSetting("LocalOperatorReportPath");
            localtraficReportPathLabel.Text += Settings.GetSetting("LocalTraficReportPath");
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
            MessageBox.Show("Данная функция находится в разработке", "Info", MessageBoxButtons.OK);
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
            ShowInputDialog("RemoteCdrPath", RemoteCdrPathlabel, DialogType.Path);
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
        
        private void ServerHostButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("ServerHost", ServerHostLabel, DialogType.Ip);
        }

        private void ServerUsernameButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("ServerUser", ServerUsernameLabel, DialogType.Name);
        }

        private void ServerPasswordButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("ServerPassword", ServerPasswordLabel, DialogType.Password);
        }

        private void ServerPortButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("ServerPort", ServerPortLabel, DialogType.Port);
        }

        //Database access settings controls

        private void DatabaseHostButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("DatabaseHost", DatabaseHostLabel, DialogType.Ip);
        }

        private void DatabaseUsernameButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("DatabaseUser", DatabaseUsernameLabel, DialogType.Name);
        }

        private void DatabasePasswordButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("DatabasePassword", DatabasePasswordLabel, DialogType.Password);
        }

        private void DatabasePortButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("DatabasePort", DatabasePortLabel, DialogType.Port);
        }

        private void DatabaseNameButton_Click(object sender, EventArgs e)
        {
            ShowInputDialog("DatabaseName", DatabaseNameLabel, DialogType.Name);
        }

        // Documents settings controls

        private void localBillsPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("LocalBillsPath", pathBrowserDialog.SelectedPath + "\\");
                localBillsPathLabel.Text = "Расположение квитанций - " + pathBrowserDialog.SelectedPath + "\\";
            }
        }

        private void loadBillTemplateButton_Click(object sender, EventArgs e)
        {
            openBillTemplateFileDialog.Reset();
            openBillTemplateFileDialog.FileName = "*.html";
            openBillTemplateFileDialog.Filter = "HTML файл шаблона|*.html";
            openBillTemplateFileDialog.Multiselect = false;

            if (openBillTemplateFileDialog.ShowDialog() == DialogResult.OK)
            {
                CopyBillTemplate(openBillTemplateFileDialog.FileName);
            }
        }

        private void detailsPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("LocalDetailsPath", pathBrowserDialog.SelectedPath + "\\");
                localDetailsPathLabel.Text = "Расположение детализаций - " + pathBrowserDialog.SelectedPath + "\\";
            }
        }

        private void baseReportPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("BaseReportPath", pathBrowserDialog.SelectedPath + "\\");
                localBaseReportPathsLabel.Text = "Расположение базовых отчетов - " + pathBrowserDialog.SelectedPath + "\\";
            }
        }

        private void operatorReportPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("LocalOperatorReportPath", pathBrowserDialog.SelectedPath + "\\");
                localOperatorPathsLabel.Text = "Расположение межоператорских отчетов - " + pathBrowserDialog.SelectedPath + "\\";
            }
        }

        private void traficReportPathSelectButton_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateSetting("LocalTraficReportPath", pathBrowserDialog.SelectedPath + "\\");
                localtraficReportPathLabel.Text = "Расположение отчетов по трафику - " + pathBrowserDialog.SelectedPath + "\\";
            }
        }

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

        // Advanced methods

        enum DialogType
        {
            Name,
            Port,
            Ip,
            Password,
            Path
        }

        void ShowInputDialog(string settingName, Label labelElement, DialogType type)
        {
            switch (type)
            {
                case DialogType.Name:
                    InputDialog dialogForm = new InputDialog();
                    dialogForm.Text = "Укажите имя";
                    if (dialogForm.ShowDialog() == DialogResult.OK)
                    {
                        if (dialogForm.inputTextBox.Text != "")
                        {
                            Settings.UpdateSetting(settingName, dialogForm.inputTextBox.Text);
                            labelElement.Text = labelElement.Text.Split('-')[0] + "- " + dialogForm.inputTextBox.Text;
                        }
                    }
                    break;
                case DialogType.Port:
                    InputPortDialog portDialogForm = new InputPortDialog();
                    portDialogForm.Text = "Выберите порт для подключения";
                    portDialogForm.portNumeric.Value = decimal.Parse(Settings.GetSetting(settingName));
                    if (portDialogForm.ShowDialog() == DialogResult.OK)
                    {
                        Settings.UpdateSetting(settingName, portDialogForm.portNumeric.Value.ToString());
                        labelElement.Text = labelElement.Text.Split('-')[0] + "- " + portDialogForm.portNumeric.Value.ToString();
                    }
                    break;
                case DialogType.Ip:
                    InputtMaskedDialog ipDialogForm = new InputtMaskedDialog();
                    ipDialogForm.viewPasswordCheckBox.Visible = false;
                    ipDialogForm.Text = "Укажите IP адрес";
                    ipDialogForm.inputMaskedTextBox.Mask = @"000\.000\.000\.000";
                    if(ipDialogForm.ShowDialog() == DialogResult.OK)
                    {
                        IPAddress ipAddress;
                        if (IPAddress.TryParse(ipDialogForm.inputMaskedTextBox.Text, out ipAddress))
                        {
                            Settings.UpdateSetting(settingName, ipAddress.ToString());
                            labelElement.Text = labelElement.Text.Split('-')[0] + "- " + ipAddress.ToString();
                        }
                    }
                    break;
                case DialogType.Password:
                    InputtMaskedDialog passwordDialogForm = new InputtMaskedDialog();
                    passwordDialogForm.Text = "Введите пароль";
                    passwordDialogForm.inputMaskedTextBox.UseSystemPasswordChar = true;
                    if(passwordDialogForm.ShowDialog() == DialogResult.OK)
                    {
                        Settings.UpdateSetting(settingName, passwordDialogForm.inputMaskedTextBox.Text);
                        labelElement.Text = labelElement.Text.Split('-')[0] + "- " + passwordDialogForm.inputMaskedTextBox.Text;
                    }
                    break;
                case DialogType.Path:
                    InputDialog pathDialogForm = new InputDialog();
                    pathDialogForm.Text = "Укажите расположение";
                    if (pathDialogForm.ShowDialog() == DialogResult.OK)
                    {
                        if (pathDialogForm.inputTextBox.Text != "")
                        {
                            Settings.UpdateSetting(settingName, pathDialogForm.inputTextBox.Text);
                            labelElement.Text = labelElement.Text.Split('-')[0] + "- " + pathDialogForm.inputTextBox.Text;
                        }
                    }
                    break;
            }
        }

        void CopyBillTemplate(string sourcePath)
        {            
            var path = Directory.GetCurrentDirectory() + @"\template";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(sourcePath, Directory.GetCurrentDirectory() + @"\template\template.html", true);
            Settings.UpdateSetting("BillTemplatePath", Directory.GetCurrentDirectory() + @"\template\template.html");
        }
    }
}