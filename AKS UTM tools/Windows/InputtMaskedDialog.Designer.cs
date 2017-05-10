namespace AKS_UTM_tools.Windows
{
    partial class InputtMaskedDialog
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
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.inputMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.viewPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(238, 49);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "ОК";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(319, 49);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // inputMaskedTextBox
            // 
            this.inputMaskedTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputMaskedTextBox.Name = "inputMaskedTextBox";
            this.inputMaskedTextBox.Size = new System.Drawing.Size(381, 20);
            this.inputMaskedTextBox.TabIndex = 5;
            // 
            // viewPasswordCheckBox
            // 
            this.viewPasswordCheckBox.AutoSize = true;
            this.viewPasswordCheckBox.Location = new System.Drawing.Point(12, 49);
            this.viewPasswordCheckBox.Name = "viewPasswordCheckBox";
            this.viewPasswordCheckBox.Size = new System.Drawing.Size(114, 17);
            this.viewPasswordCheckBox.TabIndex = 6;
            this.viewPasswordCheckBox.Text = "Показать пароль";
            this.viewPasswordCheckBox.UseVisualStyleBackColor = true;
            this.viewPasswordCheckBox.CheckedChanged += new System.EventHandler(this.viewPasswordCheckBox_CheckedChanged);
            // 
            // InputtMaskedDialog
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(405, 84);
            this.Controls.Add(this.viewPasswordCheckBox);
            this.Controls.Add(this.inputMaskedTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputtMaskedDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputMaskedDialog";
            this.Load += new System.EventHandler(this.InputIpDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.MaskedTextBox inputMaskedTextBox;
        public System.Windows.Forms.CheckBox viewPasswordCheckBox;
    }
}