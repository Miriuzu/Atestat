using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        public void onReturn()
        {
            txtuser.Text = "";
            txtpass.Text = "";
            Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Insert the username, please.");
            }
            else if (txtpass.Text == "")
            {
                MessageBox.Show("Insert the password, please.");
            }
            else
            {
                try
                {
                    string res = await client.GetStringAsync("http://localhost:3000/login?name=" + txtuser.Text + "&password=" + txtpass.Text);
                    if (Int32.Parse(res) >= 0)
                    {
                        Hide();
                        if (res == "1")
                        {
                            AdminForm admin = new AdminForm(this);
                            admin.Show();
                        }
                        else
                        {
                            UserForm user = new UserForm(this);
                            user.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong password or username.");
                    }
                }
                catch
                {
                    MessageBox.Show("Server is down.");
                }

            }
        }
    }
}
