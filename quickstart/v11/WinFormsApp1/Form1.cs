using DocumentFormat.OpenXml.Wordprocessing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using DocumentFormat.OpenXml.Drawing.Charts;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
using Azure;
using System.Timers;
using System;
using Org.BouncyCastle.Asn1.Cms;
using Timer = System.Threading.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        SystemWatcher SystemWatcher;

        private string jsonResponse { get; set; }


        private HttpClient mClient = new()
        {
            BaseAddress = new Uri("http://127.0.0.1:5191/api/weatherforecast")
        };

        public Form1()
        {
            InitializeComponent();
            SystemWatcher = new(this);


        }

        ~Form1() { }

        private void button1_Click(object sender, EventArgs e)
        {

            indexForm indexForm = new();
            //SystemWatcher = null;
            this.Hide();
            indexForm.Show();
            

        }

        private void loadResult()
        {
            SystemWatcher = new(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {



        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
            if (textBox1.Text.Length > 0)
            {
                FetchToServer(textBox1.Text);

            }
            else
            {
                ResultInfo.Rows.Clear();
                ResultInfo.Height = 0;
            }



            //HttpRequestMessage request = await mClient.PostAsync(textBox1.Text);
        }

        private async void FetchToServer(string TextInput)
        {
            StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(TextInput),
                Encoding.UTF8,
                "text/json");
            var response = await mClient.PostAsync(
                $"http://127.0.0.1:5191/api/weatherforecast",
                jsonContent);
            var tt = response.EnsureSuccessStatusCode();
            this.jsonResponse = await response.Content.ReadAsStringAsync();
            if (jsonResponse.Length > 2)
            {
                ResultInfo.DataSource = JsonConvert.DeserializeObject(jsonResponse);

                ResultInfo.Height = ResultInfo.Rows.Count * 30;



            }
            else if (jsonResponse.Length <=2)
            {
                ResultInfo.Rows.Clear();
                ResultInfo.Height = 0;
            }



        }

        private void ResultInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string PathFile = (ResultInfo.CurrentRow.Cells["Path"].EditedFormattedValue).ToString();
            if (File.Exists(PathFile))
            {
                System.Diagnostics.Process.Start("explorer.exe", PathFile);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
