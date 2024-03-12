using DocumentFormat.OpenXml.Wordprocessing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using DocumentFormat.OpenXml.Drawing.Charts;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog browserDialog;
        AzureSearch.Quickstart.ManagementAzure managementAzure = new();
        SystemWatcher SystemWatcher;

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
            //browserDialog = new FolderBrowserDialog();
            //folderBrowserDialog1.ShowDialog();

            //var result = folderBrowserDialog1.SelectedPath;

            //try
            //{
            //    AzureSearch.Quickstart.Program program = new();
            //    program.Start();
            //}
            //catch (Exception ex) {
            //    throw ;
            //};
            indexForm indexForm = new();
            this.Hide();
            indexForm.Show();

            //systemWather = new SystemWather(null);




        }

        private void loadResult()
        {

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


        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var test = textBox1.Text;

            StringContent jsonContent = new StringContent(JsonConvert.SerializeObject("Повестка"),
                Encoding.UTF8,
                "text/json");
            var response = await mClient.PostAsync(
                $"http://127.0.0.1:5191/api/weatherforecast",
                jsonContent);

            var tt = response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
            var json = JsonConvert.DeserializeObject(jsonResponse);
            ResultInfo.DataSource = json;

            //HttpRequestMessage request = await mClient.PostAsync(textBox1.Text);
        }

        private void ResultInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
