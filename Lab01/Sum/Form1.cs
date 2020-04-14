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

namespace Sum
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://localhost:44390/sum");
            request.Method = "POST"; // для отправки используется метод Post
            request.ContentType = "application/x-www-form-urlencoded";
            string sum = $"X={X.Text}&Y={Y.Text}";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(sum);
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Result.Text = reader.ReadToEnd();
                }
            }
            
            response.Close();
        }

        private void X_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
