using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public class RootObject
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string email { get; set; }
            public int admin { get; set; }
        }

        RootObject obj;


        private void button1_Click(object sender, EventArgs e)
        {
            string password = txtuser.Text;

            string html = string.Empty;
            string url = @"http://localhost:8080/searchu?username=" + txtuser.Text;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Console.WriteLine(html);


            var resultscan = JsonConvert.DeserializeObject<List<RootObject>>(html);
            obj = resultscan[0];


            
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
