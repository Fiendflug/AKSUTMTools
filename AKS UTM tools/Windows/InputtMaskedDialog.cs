using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKS_UTM_tools.Windows
{
    public partial class InputtMaskedDialog : Form
    {
        public InputtMaskedDialog()
        {
            InitializeComponent();
        }

        private void InputIpDialog_Load(object sender, EventArgs e)
        {
            submitButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        private void viewPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (viewPasswordCheckBox.Checked)
                inputMaskedTextBox.UseSystemPasswordChar = false;
            else
                inputMaskedTextBox.UseSystemPasswordChar = true;
        }
    }
}
