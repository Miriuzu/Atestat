using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class AdminForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private Form1 mainForm;
        public AdminForm(Form1 form)
        {
            mainForm = form;
            InitializeComponent();
            getGrid();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.onReturn();
        }

        private async void getGrid()
        {
            string res = await client.GetStringAsync("http://localhost:3000/users");
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(res);
            dataGridView1.DataSource = dt;
        }

    }
}
