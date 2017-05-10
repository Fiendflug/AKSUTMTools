namespace AKS_UTM_tools
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.CommonTab = new System.Windows.Forms.TabPage();
            this.ConnectTab = new System.Windows.Forms.TabPage();
            this.DatabaseSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.DatabaseNameButton = new System.Windows.Forms.Button();
            this.DatabaseNameLabel = new System.Windows.Forms.Label();
            this.DatabasePortButton = new System.Windows.Forms.Button();
            this.DatabasePasswordButton = new System.Windows.Forms.Button();
            this.DatabaseUsernameButton = new System.Windows.Forms.Button();
            this.DatabaseHostButton = new System.Windows.Forms.Button();
            this.DatabasePasswordLabel = new System.Windows.Forms.Label();
            this.DatabaseUsernameLabel = new System.Windows.Forms.Label();
            this.DatabasePortLabel = new System.Windows.Forms.Label();
            this.DatabaseHostLabel = new System.Windows.Forms.Label();
            this.ServerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ServerPortButton = new System.Windows.Forms.Button();
            this.ServerPasswordButton = new System.Windows.Forms.Button();
            this.ServerUsernameButton = new System.Windows.Forms.Button();
            this.ServerHostButton = new System.Windows.Forms.Button();
            this.ServerPasswordLabel = new System.Windows.Forms.Label();
            this.ServerUsernameLabel = new System.Windows.Forms.Label();
            this.ServerPortLabel = new System.Windows.Forms.Label();
            this.ServerHostLabel = new System.Windows.Forms.Label();
            this.CdrTab = new System.Windows.Forms.TabPage();
            this.ZipCdrPathGroup = new System.Windows.Forms.GroupBox();
            this.ZipCdrPathSelectButton = new System.Windows.Forms.Button();
            this.ZipCdrPathLabel = new System.Windows.Forms.Label();
            this.CdrConvertGroup = new System.Windows.Forms.GroupBox();
            this.EditCdrSettingsButton = new System.Windows.Forms.Button();
            this.EditCdrCheckbox = new System.Windows.Forms.CheckBox();
            this.DeleteZeroCallsCdrCheckbox = new System.Windows.Forms.CheckBox();
            this.DelecteLocalCdrCheckbox = new System.Windows.Forms.CheckBox();
            this.LocalCdrPathGroup = new System.Windows.Forms.GroupBox();
            this.RemoteCdrpathButton = new System.Windows.Forms.Button();
            this.RemoteCdrPathlabel = new System.Windows.Forms.Label();
            this.LocalCdrPathSelectButton = new System.Windows.Forms.Button();
            this.LocalCdrPathLabel = new System.Windows.Forms.Label();
            this.ReportsTab = new System.Windows.Forms.TabPage();
            this.SubmitSettingsButton = new System.Windows.Forms.Button();
            this.OkSettingsButton = new System.Windows.Forms.Button();
            this.CancelSettingsButton = new System.Windows.Forms.Button();
            this.HelpSettingsButton = new System.Windows.Forms.Button();
            this.pathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SettingsTabControl.SuspendLayout();
            this.ConnectTab.SuspendLayout();
            this.DatabaseSettingsGroupBox.SuspendLayout();
            this.ServerSettingsGroupBox.SuspendLayout();
            this.CdrTab.SuspendLayout();
            this.ZipCdrPathGroup.SuspendLayout();
            this.CdrConvertGroup.SuspendLayout();
            this.LocalCdrPathGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.CommonTab);
            this.SettingsTabControl.Controls.Add(this.ConnectTab);
            this.SettingsTabControl.Controls.Add(this.CdrTab);
            this.SettingsTabControl.Controls.Add(this.ReportsTab);
            this.SettingsTabControl.Location = new System.Drawing.Point(-1, 0);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(650, 405);
            this.SettingsTabControl.TabIndex = 0;
            // 
            // CommonTab
            // 
            this.CommonTab.Location = new System.Drawing.Point(4, 22);
            this.CommonTab.Name = "CommonTab";
            this.CommonTab.Padding = new System.Windows.Forms.Padding(3);
            this.CommonTab.Size = new System.Drawing.Size(642, 379);
            this.CommonTab.TabIndex = 0;
            this.CommonTab.Text = "Основные";
            this.CommonTab.UseVisualStyleBackColor = true;
            // 
            // ConnectTab
            // 
            this.ConnectTab.Controls.Add(this.DatabaseSettingsGroupBox);
            this.ConnectTab.Controls.Add(this.ServerSettingsGroupBox);
            this.ConnectTab.Location = new System.Drawing.Point(4, 22);
            this.ConnectTab.Name = "ConnectTab";
            this.ConnectTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectTab.Size = new System.Drawing.Size(642, 379);
            this.ConnectTab.TabIndex = 1;
            this.ConnectTab.Text = "Соединение с сервером";
            this.ConnectTab.UseVisualStyleBackColor = true;
            // 
            // DatabaseSettingsGroupBox
            // 
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabaseNameButton);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabaseNameLabel);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabasePortButton);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabasePasswordButton);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabaseUsernameButton);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabaseHostButton);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabasePasswordLabel);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabaseUsernameLabel);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabasePortLabel);
            this.DatabaseSettingsGroupBox.Controls.Add(this.DatabaseHostLabel);
            this.DatabaseSettingsGroupBox.Location = new System.Drawing.Point(11, 170);
            this.DatabaseSettingsGroupBox.Name = "DatabaseSettingsGroupBox";
            this.DatabaseSettingsGroupBox.Size = new System.Drawing.Size(618, 179);
            this.DatabaseSettingsGroupBox.TabIndex = 7;
            this.DatabaseSettingsGroupBox.TabStop = false;
            this.DatabaseSettingsGroupBox.Text = "Параметры подключения к базе данных";
            // 
            // DatabaseNameButton
            // 
            this.DatabaseNameButton.Location = new System.Drawing.Point(533, 135);
            this.DatabaseNameButton.Name = "DatabaseNameButton";
            this.DatabaseNameButton.Size = new System.Drawing.Size(70, 25);
            this.DatabaseNameButton.TabIndex = 8;
            this.DatabaseNameButton.Text = "Изменить";
            this.DatabaseNameButton.UseVisualStyleBackColor = true;
            this.DatabaseNameButton.Click += new System.EventHandler(this.DatabaseNameButton_Click);
            // 
            // DatabaseNameLabel
            // 
            this.DatabaseNameLabel.AutoSize = true;
            this.DatabaseNameLabel.Location = new System.Drawing.Point(6, 141);
            this.DatabaseNameLabel.Name = "DatabaseNameLabel";
            this.DatabaseNameLabel.Size = new System.Drawing.Size(135, 13);
            this.DatabaseNameLabel.TabIndex = 7;
            this.DatabaseNameLabel.Text = "Название базы данных - ";
            // 
            // DatabasePortButton
            // 
            this.DatabasePortButton.Location = new System.Drawing.Point(533, 106);
            this.DatabasePortButton.Name = "DatabasePortButton";
            this.DatabasePortButton.Size = new System.Drawing.Size(70, 25);
            this.DatabasePortButton.TabIndex = 6;
            this.DatabasePortButton.Text = "Изменить";
            this.DatabasePortButton.UseVisualStyleBackColor = true;
            this.DatabasePortButton.Click += new System.EventHandler(this.DatabasePortButton_Click);
            // 
            // DatabasePasswordButton
            // 
            this.DatabasePasswordButton.Location = new System.Drawing.Point(533, 77);
            this.DatabasePasswordButton.Name = "DatabasePasswordButton";
            this.DatabasePasswordButton.Size = new System.Drawing.Size(70, 25);
            this.DatabasePasswordButton.TabIndex = 5;
            this.DatabasePasswordButton.Text = "Изменить";
            this.DatabasePasswordButton.UseVisualStyleBackColor = true;
            this.DatabasePasswordButton.Click += new System.EventHandler(this.DatabasePasswordButton_Click);
            // 
            // DatabaseUsernameButton
            // 
            this.DatabaseUsernameButton.Location = new System.Drawing.Point(533, 50);
            this.DatabaseUsernameButton.Name = "DatabaseUsernameButton";
            this.DatabaseUsernameButton.Size = new System.Drawing.Size(70, 25);
            this.DatabaseUsernameButton.TabIndex = 5;
            this.DatabaseUsernameButton.Text = "Изменить";
            this.DatabaseUsernameButton.UseVisualStyleBackColor = true;
            this.DatabaseUsernameButton.Click += new System.EventHandler(this.DatabaseUsernameButton_Click);
            // 
            // DatabaseHostButton
            // 
            this.DatabaseHostButton.Location = new System.Drawing.Point(533, 23);
            this.DatabaseHostButton.Name = "DatabaseHostButton";
            this.DatabaseHostButton.Size = new System.Drawing.Size(70, 25);
            this.DatabaseHostButton.TabIndex = 5;
            this.DatabaseHostButton.Text = "Изменить";
            this.DatabaseHostButton.UseVisualStyleBackColor = true;
            this.DatabaseHostButton.Click += new System.EventHandler(this.DatabaseHostButton_Click);
            // 
            // DatabasePasswordLabel
            // 
            this.DatabasePasswordLabel.AutoSize = true;
            this.DatabasePasswordLabel.Location = new System.Drawing.Point(6, 83);
            this.DatabasePasswordLabel.Name = "DatabasePasswordLabel";
            this.DatabasePasswordLabel.Size = new System.Drawing.Size(143, 13);
            this.DatabasePasswordLabel.TabIndex = 3;
            this.DatabasePasswordLabel.Text = "Пароль для авторизации - ";
            // 
            // DatabaseUsernameLabel
            // 
            this.DatabaseUsernameLabel.AutoSize = true;
            this.DatabaseUsernameLabel.Location = new System.Drawing.Point(6, 56);
            this.DatabaseUsernameLabel.Name = "DatabaseUsernameLabel";
            this.DatabaseUsernameLabel.Size = new System.Drawing.Size(112, 13);
            this.DatabaseUsernameLabel.TabIndex = 2;
            this.DatabaseUsernameLabel.Text = "Имя пользователя - ";
            // 
            // DatabasePortLabel
            // 
            this.DatabasePortLabel.AutoSize = true;
            this.DatabasePortLabel.Location = new System.Drawing.Point(6, 112);
            this.DatabasePortLabel.Name = "DatabasePortLabel";
            this.DatabasePortLabel.Size = new System.Drawing.Size(126, 13);
            this.DatabasePortLabel.TabIndex = 1;
            this.DatabasePortLabel.Text = "Порт для поключения - ";
            // 
            // DatabaseHostLabel
            // 
            this.DatabaseHostLabel.AutoSize = true;
            this.DatabaseHostLabel.Location = new System.Drawing.Point(6, 29);
            this.DatabaseHostLabel.Name = "DatabaseHostLabel";
            this.DatabaseHostLabel.Size = new System.Drawing.Size(199, 13);
            this.DatabaseHostLabel.TabIndex = 0;
            this.DatabaseHostLabel.Text = "Локальный адрес для доступа к БД - ";
            // 
            // ServerSettingsGroupBox
            // 
            this.ServerSettingsGroupBox.Controls.Add(this.ServerPortButton);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerPasswordButton);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerUsernameButton);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerHostButton);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerPasswordLabel);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerUsernameLabel);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerPortLabel);
            this.ServerSettingsGroupBox.Controls.Add(this.ServerHostLabel);
            this.ServerSettingsGroupBox.Location = new System.Drawing.Point(11, 12);
            this.ServerSettingsGroupBox.Name = "ServerSettingsGroupBox";
            this.ServerSettingsGroupBox.Size = new System.Drawing.Size(618, 147);
            this.ServerSettingsGroupBox.TabIndex = 0;
            this.ServerSettingsGroupBox.TabStop = false;
            this.ServerSettingsGroupBox.Text = "Параметры соединения с сервером";
            // 
            // ServerPortButton
            // 
            this.ServerPortButton.Location = new System.Drawing.Point(533, 106);
            this.ServerPortButton.Name = "ServerPortButton";
            this.ServerPortButton.Size = new System.Drawing.Size(70, 25);
            this.ServerPortButton.TabIndex = 6;
            this.ServerPortButton.Text = "Изменить";
            this.ServerPortButton.UseVisualStyleBackColor = true;
            this.ServerPortButton.Click += new System.EventHandler(this.ServerPortButton_Click);
            // 
            // ServerPasswordButton
            // 
            this.ServerPasswordButton.Location = new System.Drawing.Point(533, 77);
            this.ServerPasswordButton.Name = "ServerPasswordButton";
            this.ServerPasswordButton.Size = new System.Drawing.Size(70, 25);
            this.ServerPasswordButton.TabIndex = 5;
            this.ServerPasswordButton.Text = "Изменить";
            this.ServerPasswordButton.UseVisualStyleBackColor = true;
            this.ServerPasswordButton.Click += new System.EventHandler(this.ServerPasswordButton_Click);
            // 
            // ServerUsernameButton
            // 
            this.ServerUsernameButton.Location = new System.Drawing.Point(533, 50);
            this.ServerUsernameButton.Name = "ServerUsernameButton";
            this.ServerUsernameButton.Size = new System.Drawing.Size(70, 25);
            this.ServerUsernameButton.TabIndex = 5;
            this.ServerUsernameButton.Text = "Изменить";
            this.ServerUsernameButton.UseVisualStyleBackColor = true;
            this.ServerUsernameButton.Click += new System.EventHandler(this.ServerUsernameButton_Click);
            // 
            // ServerHostButton
            // 
            this.ServerHostButton.Location = new System.Drawing.Point(533, 23);
            this.ServerHostButton.Name = "ServerHostButton";
            this.ServerHostButton.Size = new System.Drawing.Size(70, 25);
            this.ServerHostButton.TabIndex = 5;
            this.ServerHostButton.Text = "Изменить";
            this.ServerHostButton.UseVisualStyleBackColor = true;
            this.ServerHostButton.Click += new System.EventHandler(this.ServerHostButton_Click);
            // 
            // ServerPasswordLabel
            // 
            this.ServerPasswordLabel.AutoSize = true;
            this.ServerPasswordLabel.Location = new System.Drawing.Point(6, 83);
            this.ServerPasswordLabel.Name = "ServerPasswordLabel";
            this.ServerPasswordLabel.Size = new System.Drawing.Size(143, 13);
            this.ServerPasswordLabel.TabIndex = 3;
            this.ServerPasswordLabel.Text = "Пароль для авторизации - ";
            // 
            // ServerUsernameLabel
            // 
            this.ServerUsernameLabel.AutoSize = true;
            this.ServerUsernameLabel.Location = new System.Drawing.Point(6, 56);
            this.ServerUsernameLabel.Name = "ServerUsernameLabel";
            this.ServerUsernameLabel.Size = new System.Drawing.Size(112, 13);
            this.ServerUsernameLabel.TabIndex = 2;
            this.ServerUsernameLabel.Text = "Имя пользователя - ";
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Location = new System.Drawing.Point(6, 112);
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(132, 13);
            this.ServerPortLabel.TabIndex = 1;
            this.ServerPortLabel.Text = "Порт для подключения - ";
            // 
            // ServerHostLabel
            // 
            this.ServerHostLabel.AutoSize = true;
            this.ServerHostLabel.Location = new System.Drawing.Point(6, 29);
            this.ServerHostLabel.Name = "ServerHostLabel";
            this.ServerHostLabel.Size = new System.Drawing.Size(92, 13);
            this.ServerHostLabel.TabIndex = 0;
            this.ServerHostLabel.Text = "Адрес сервера - ";
            // 
            // CdrTab
            // 
            this.CdrTab.Controls.Add(this.ZipCdrPathGroup);
            this.CdrTab.Controls.Add(this.CdrConvertGroup);
            this.CdrTab.Controls.Add(this.LocalCdrPathGroup);
            this.CdrTab.Location = new System.Drawing.Point(4, 22);
            this.CdrTab.Name = "CdrTab";
            this.CdrTab.Size = new System.Drawing.Size(642, 379);
            this.CdrTab.TabIndex = 2;
            this.CdrTab.Text = "Файлы статистики";
            this.CdrTab.UseVisualStyleBackColor = true;
            // 
            // ZipCdrPathGroup
            // 
            this.ZipCdrPathGroup.Controls.Add(this.ZipCdrPathSelectButton);
            this.ZipCdrPathGroup.Controls.Add(this.ZipCdrPathLabel);
            this.ZipCdrPathGroup.Location = new System.Drawing.Point(11, 251);
            this.ZipCdrPathGroup.Name = "ZipCdrPathGroup";
            this.ZipCdrPathGroup.Size = new System.Drawing.Size(618, 66);
            this.ZipCdrPathGroup.TabIndex = 2;
            this.ZipCdrPathGroup.TabStop = false;
            this.ZipCdrPathGroup.Text = "Путь для заархивированных CDR";
            // 
            // ZipCdrPathSelectButton
            // 
            this.ZipCdrPathSelectButton.Location = new System.Drawing.Point(581, 26);
            this.ZipCdrPathSelectButton.Name = "ZipCdrPathSelectButton";
            this.ZipCdrPathSelectButton.Size = new System.Drawing.Size(24, 23);
            this.ZipCdrPathSelectButton.TabIndex = 2;
            this.ZipCdrPathSelectButton.Text = "...";
            this.ZipCdrPathSelectButton.UseVisualStyleBackColor = true;
            this.ZipCdrPathSelectButton.Click += new System.EventHandler(this.ZipCdrPathSelectButton_Click);
            // 
            // ZipCdrPathLabel
            // 
            this.ZipCdrPathLabel.AutoSize = true;
            this.ZipCdrPathLabel.Location = new System.Drawing.Point(4, 31);
            this.ZipCdrPathLabel.Name = "ZipCdrPathLabel";
            this.ZipCdrPathLabel.Size = new System.Drawing.Size(149, 13);
            this.ZipCdrPathLabel.TabIndex = 1;
            this.ZipCdrPathLabel.Text = "Локальное расположение - ";
            // 
            // CdrConvertGroup
            // 
            this.CdrConvertGroup.Controls.Add(this.EditCdrSettingsButton);
            this.CdrConvertGroup.Controls.Add(this.EditCdrCheckbox);
            this.CdrConvertGroup.Controls.Add(this.DeleteZeroCallsCdrCheckbox);
            this.CdrConvertGroup.Controls.Add(this.DelecteLocalCdrCheckbox);
            this.CdrConvertGroup.Location = new System.Drawing.Point(11, 120);
            this.CdrConvertGroup.Name = "CdrConvertGroup";
            this.CdrConvertGroup.Size = new System.Drawing.Size(618, 115);
            this.CdrConvertGroup.TabIndex = 1;
            this.CdrConvertGroup.TabStop = false;
            this.CdrConvertGroup.Text = "Параметры конвертирования";
            // 
            // EditCdrSettingsButton
            // 
            this.EditCdrSettingsButton.Enabled = false;
            this.EditCdrSettingsButton.Location = new System.Drawing.Point(400, 72);
            this.EditCdrSettingsButton.Name = "EditCdrSettingsButton";
            this.EditCdrSettingsButton.Size = new System.Drawing.Size(205, 25);
            this.EditCdrSettingsButton.TabIndex = 5;
            this.EditCdrSettingsButton.Text = "Параметры коррекции длительности";
            this.EditCdrSettingsButton.UseVisualStyleBackColor = true;
            this.EditCdrSettingsButton.Click += new System.EventHandler(this.EditCdrSettingsButton_Click);
            // 
            // EditCdrCheckbox
            // 
            this.EditCdrCheckbox.AutoSize = true;
            this.EditCdrCheckbox.Location = new System.Drawing.Point(9, 77);
            this.EditCdrCheckbox.Name = "EditCdrCheckbox";
            this.EditCdrCheckbox.Size = new System.Drawing.Size(229, 17);
            this.EditCdrCheckbox.TabIndex = 2;
            this.EditCdrCheckbox.Text = "Корректировать длительность вызовов";
            this.EditCdrCheckbox.UseVisualStyleBackColor = true;
            this.EditCdrCheckbox.CheckedChanged += new System.EventHandler(this.EditCdrCheckbox_CheckedChanged);
            // 
            // DeleteZeroCallsCdrCheckbox
            // 
            this.DeleteZeroCallsCdrCheckbox.AutoSize = true;
            this.DeleteZeroCallsCdrCheckbox.Location = new System.Drawing.Point(9, 52);
            this.DeleteZeroCallsCdrCheckbox.Name = "DeleteZeroCallsCdrCheckbox";
            this.DeleteZeroCallsCdrCheckbox.Size = new System.Drawing.Size(246, 17);
            this.DeleteZeroCallsCdrCheckbox.TabIndex = 1;
            this.DeleteZeroCallsCdrCheckbox.Text = "Удалять вызовы с нулевой длительностью";
            this.DeleteZeroCallsCdrCheckbox.UseVisualStyleBackColor = true;
            this.DeleteZeroCallsCdrCheckbox.CheckedChanged += new System.EventHandler(this.DeleteZeroCallsCdrCheckbox_CheckedChanged);
            // 
            // DelecteLocalCdrCheckbox
            // 
            this.DelecteLocalCdrCheckbox.AutoSize = true;
            this.DelecteLocalCdrCheckbox.Location = new System.Drawing.Point(9, 27);
            this.DelecteLocalCdrCheckbox.Name = "DelecteLocalCdrCheckbox";
            this.DelecteLocalCdrCheckbox.Size = new System.Drawing.Size(302, 17);
            this.DelecteLocalCdrCheckbox.TabIndex = 0;
            this.DelecteLocalCdrCheckbox.Text = "Удалять локальные файлы после передачи на сервер";
            this.DelecteLocalCdrCheckbox.UseVisualStyleBackColor = true;
            this.DelecteLocalCdrCheckbox.CheckedChanged += new System.EventHandler(this.DelecteLocalCdrCheckbox_CheckedChanged);
            // 
            // LocalCdrPathGroup
            // 
            this.LocalCdrPathGroup.Controls.Add(this.RemoteCdrpathButton);
            this.LocalCdrPathGroup.Controls.Add(this.RemoteCdrPathlabel);
            this.LocalCdrPathGroup.Controls.Add(this.LocalCdrPathSelectButton);
            this.LocalCdrPathGroup.Controls.Add(this.LocalCdrPathLabel);
            this.LocalCdrPathGroup.Location = new System.Drawing.Point(11, 12);
            this.LocalCdrPathGroup.Name = "LocalCdrPathGroup";
            this.LocalCdrPathGroup.Size = new System.Drawing.Size(618, 93);
            this.LocalCdrPathGroup.TabIndex = 0;
            this.LocalCdrPathGroup.TabStop = false;
            this.LocalCdrPathGroup.Text = "Путь для конвертированных CDR";
            // 
            // RemoteCdrpathButton
            // 
            this.RemoteCdrpathButton.Location = new System.Drawing.Point(535, 51);
            this.RemoteCdrpathButton.Name = "RemoteCdrpathButton";
            this.RemoteCdrpathButton.Size = new System.Drawing.Size(70, 25);
            this.RemoteCdrpathButton.TabIndex = 4;
            this.RemoteCdrpathButton.Text = "Изменить";
            this.RemoteCdrpathButton.UseVisualStyleBackColor = true;
            this.RemoteCdrpathButton.Click += new System.EventHandler(this.RemoteCdrpathButton_Click);
            // 
            // RemoteCdrPathlabel
            // 
            this.RemoteCdrPathlabel.AutoSize = true;
            this.RemoteCdrPathlabel.Location = new System.Drawing.Point(4, 57);
            this.RemoteCdrPathlabel.Name = "RemoteCdrPathlabel";
            this.RemoteCdrPathlabel.Size = new System.Drawing.Size(151, 13);
            this.RemoteCdrPathlabel.TabIndex = 3;
            this.RemoteCdrPathlabel.Text = "Расположение на сервере - ";
            // 
            // LocalCdrPathSelectButton
            // 
            this.LocalCdrPathSelectButton.Location = new System.Drawing.Point(581, 26);
            this.LocalCdrPathSelectButton.Name = "LocalCdrPathSelectButton";
            this.LocalCdrPathSelectButton.Size = new System.Drawing.Size(24, 23);
            this.LocalCdrPathSelectButton.TabIndex = 2;
            this.LocalCdrPathSelectButton.Text = "...";
            this.LocalCdrPathSelectButton.UseVisualStyleBackColor = true;
            this.LocalCdrPathSelectButton.Click += new System.EventHandler(this.LocalCdrPathSelectButton_Click);
            // 
            // LocalCdrPathLabel
            // 
            this.LocalCdrPathLabel.AutoSize = true;
            this.LocalCdrPathLabel.Location = new System.Drawing.Point(4, 31);
            this.LocalCdrPathLabel.Name = "LocalCdrPathLabel";
            this.LocalCdrPathLabel.Size = new System.Drawing.Size(149, 13);
            this.LocalCdrPathLabel.TabIndex = 1;
            this.LocalCdrPathLabel.Text = "Локальное расположение - ";
            // 
            // ReportsTab
            // 
            this.ReportsTab.Location = new System.Drawing.Point(4, 22);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Size = new System.Drawing.Size(642, 379);
            this.ReportsTab.TabIndex = 3;
            this.ReportsTab.Text = "Отчеты";
            this.ReportsTab.UseVisualStyleBackColor = true;
            // 
            // SubmitSettingsButton
            // 
            this.SubmitSettingsButton.Location = new System.Drawing.Point(14, 420);
            this.SubmitSettingsButton.Name = "SubmitSettingsButton";
            this.SubmitSettingsButton.Size = new System.Drawing.Size(150, 40);
            this.SubmitSettingsButton.TabIndex = 1;
            this.SubmitSettingsButton.Text = "Применить";
            this.SubmitSettingsButton.UseVisualStyleBackColor = true;
            this.SubmitSettingsButton.Click += new System.EventHandler(this.SubmitSettingsButton_Click);
            // 
            // OkSettingsButton
            // 
            this.OkSettingsButton.Location = new System.Drawing.Point(170, 420);
            this.OkSettingsButton.Name = "OkSettingsButton";
            this.OkSettingsButton.Size = new System.Drawing.Size(150, 40);
            this.OkSettingsButton.TabIndex = 2;
            this.OkSettingsButton.Text = "ОК";
            this.OkSettingsButton.UseVisualStyleBackColor = true;
            this.OkSettingsButton.Click += new System.EventHandler(this.OkSettingsButton_Click);
            // 
            // CancelSettingsButton
            // 
            this.CancelSettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelSettingsButton.Location = new System.Drawing.Point(326, 420);
            this.CancelSettingsButton.Name = "CancelSettingsButton";
            this.CancelSettingsButton.Size = new System.Drawing.Size(150, 40);
            this.CancelSettingsButton.TabIndex = 3;
            this.CancelSettingsButton.Text = "Отмена";
            this.CancelSettingsButton.UseVisualStyleBackColor = true;
            this.CancelSettingsButton.Click += new System.EventHandler(this.CancelSettingsButton_Click);
            // 
            // HelpSettingsButton
            // 
            this.HelpSettingsButton.Location = new System.Drawing.Point(482, 420);
            this.HelpSettingsButton.Name = "HelpSettingsButton";
            this.HelpSettingsButton.Size = new System.Drawing.Size(150, 40);
            this.HelpSettingsButton.TabIndex = 4;
            this.HelpSettingsButton.Text = "Помощь";
            this.HelpSettingsButton.UseVisualStyleBackColor = true;
            this.HelpSettingsButton.Click += new System.EventHandler(this.HelpSettingsButton_Click);
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.OkSettingsButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelSettingsButton;
            this.ClientSize = new System.Drawing.Size(644, 475);
            this.Controls.Add(this.HelpSettingsButton);
            this.Controls.Add(this.CancelSettingsButton);
            this.Controls.Add(this.OkSettingsButton);
            this.Controls.Add(this.SubmitSettingsButton);
            this.Controls.Add(this.SettingsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DGenerator Настройки";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.SettingsTabControl.ResumeLayout(false);
            this.ConnectTab.ResumeLayout(false);
            this.DatabaseSettingsGroupBox.ResumeLayout(false);
            this.DatabaseSettingsGroupBox.PerformLayout();
            this.ServerSettingsGroupBox.ResumeLayout(false);
            this.ServerSettingsGroupBox.PerformLayout();
            this.CdrTab.ResumeLayout(false);
            this.ZipCdrPathGroup.ResumeLayout(false);
            this.ZipCdrPathGroup.PerformLayout();
            this.CdrConvertGroup.ResumeLayout(false);
            this.CdrConvertGroup.PerformLayout();
            this.LocalCdrPathGroup.ResumeLayout(false);
            this.LocalCdrPathGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingsTabControl;
        private System.Windows.Forms.TabPage CommonTab;
        private System.Windows.Forms.TabPage ConnectTab;
        private System.Windows.Forms.TabPage CdrTab;
        private System.Windows.Forms.TabPage ReportsTab;
        private System.Windows.Forms.Button SubmitSettingsButton;
        private System.Windows.Forms.Button OkSettingsButton;
        private System.Windows.Forms.Button CancelSettingsButton;
        private System.Windows.Forms.Button HelpSettingsButton;
        private System.Windows.Forms.GroupBox LocalCdrPathGroup;
        private System.Windows.Forms.Button LocalCdrPathSelectButton;
        private System.Windows.Forms.Label LocalCdrPathLabel;
        private System.Windows.Forms.Button RemoteCdrpathButton;
        private System.Windows.Forms.Label RemoteCdrPathlabel;
        private System.Windows.Forms.GroupBox CdrConvertGroup;
        private System.Windows.Forms.CheckBox DelecteLocalCdrCheckbox;
        private System.Windows.Forms.CheckBox DeleteZeroCallsCdrCheckbox;
        private System.Windows.Forms.Button EditCdrSettingsButton;
        private System.Windows.Forms.CheckBox EditCdrCheckbox;
        private System.Windows.Forms.GroupBox ZipCdrPathGroup;
        private System.Windows.Forms.Button ZipCdrPathSelectButton;
        private System.Windows.Forms.Label ZipCdrPathLabel;
        private System.Windows.Forms.FolderBrowserDialog pathBrowserDialog;
        private System.Windows.Forms.GroupBox ServerSettingsGroupBox;
        private System.Windows.Forms.Label ServerHostLabel;
        private System.Windows.Forms.Label ServerPortLabel;
        private System.Windows.Forms.Label ServerUsernameLabel;
        private System.Windows.Forms.Label ServerPasswordLabel;
        private System.Windows.Forms.Button ServerPortButton;
        private System.Windows.Forms.Button ServerPasswordButton;
        private System.Windows.Forms.Button ServerUsernameButton;
        private System.Windows.Forms.Button ServerHostButton;
        private System.Windows.Forms.GroupBox DatabaseSettingsGroupBox;
        private System.Windows.Forms.Button DatabasePortButton;
        private System.Windows.Forms.Button DatabasePasswordButton;
        private System.Windows.Forms.Button DatabaseUsernameButton;
        private System.Windows.Forms.Button DatabaseHostButton;
        private System.Windows.Forms.Label DatabasePasswordLabel;
        private System.Windows.Forms.Label DatabaseUsernameLabel;
        private System.Windows.Forms.Label DatabasePortLabel;
        private System.Windows.Forms.Label DatabaseHostLabel;
        private System.Windows.Forms.Button DatabaseNameButton;
        private System.Windows.Forms.Label DatabaseNameLabel;
    }
}