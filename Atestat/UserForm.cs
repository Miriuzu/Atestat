using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class UserForm : Form
    {
        private Form1 mainForm;
        public UserForm(Form1 form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.onReturn();
        }
    }
}
