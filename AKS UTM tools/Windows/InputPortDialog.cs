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
    public partial class InputPortDialog : Form
    {
        public InputPortDialog()
        {
            InitializeComponent();
        }

        private void InputPortDialog_Load(object sender, EventArgs e)
        {
            submitButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }
    }
}
