using DocumentFormat.OpenXml.Wordprocessing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog browserDialog;
        AzureSearch.Quickstart.ManagementAzure managementAzure = new();
        SystemWatcher SystemWatcher;
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

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
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

    }
}
