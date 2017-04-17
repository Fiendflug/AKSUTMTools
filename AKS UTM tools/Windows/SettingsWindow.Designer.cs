﻿namespace AKS_UTM_tools
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
            this.CdrTab = new System.Windows.Forms.TabPage();
            this.ReportsTab = new System.Windows.Forms.TabPage();
            this.SubmitSettingsButton = new System.Windows.Forms.Button();
            this.OkSettingsButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.HelpSettingsButton = new System.Windows.Forms.Button();
            this.SettingsTabControl.SuspendLayout();
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
            this.ConnectTab.Location = new System.Drawing.Point(4, 22);
            this.ConnectTab.Name = "ConnectTab";
            this.ConnectTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectTab.Size = new System.Drawing.Size(642, 355);
            this.ConnectTab.TabIndex = 1;
            this.ConnectTab.Text = "Соединение с сервером";
            this.ConnectTab.UseVisualStyleBackColor = true;
            // 
            // CdrTab
            // 
            this.CdrTab.Location = new System.Drawing.Point(4, 22);
            this.CdrTab.Name = "CdrTab";
            this.CdrTab.Size = new System.Drawing.Size(642, 355);
            this.CdrTab.TabIndex = 2;
            this.CdrTab.Text = "Файлы статистики";
            this.CdrTab.UseVisualStyleBackColor = true;
            // 
            // ReportsTab
            // 
            this.ReportsTab.Location = new System.Drawing.Point(4, 22);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Size = new System.Drawing.Size(642, 355);
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
            // 
            // OkSettingsButton
            // 
            this.OkSettingsButton.Location = new System.Drawing.Point(170, 420);
            this.OkSettingsButton.Name = "OkSettingsButton";
            this.OkSettingsButton.Size = new System.Drawing.Size(150, 40);
            this.OkSettingsButton.TabIndex = 2;
            this.OkSettingsButton.Text = "ОК";
            this.OkSettingsButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(326, 420);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // HelpSettingsButton
            // 
            this.HelpSettingsButton.Location = new System.Drawing.Point(482, 420);
            this.HelpSettingsButton.Name = "HelpSettingsButton";
            this.HelpSettingsButton.Size = new System.Drawing.Size(150, 40);
            this.HelpSettingsButton.TabIndex = 4;
            this.HelpSettingsButton.Text = "Помощь";
            this.HelpSettingsButton.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 475);
            this.Controls.Add(this.HelpSettingsButton);
            this.Controls.Add(this.button3);
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
            this.SettingsTabControl.ResumeLayout(false);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button HelpSettingsButton;
    }
}