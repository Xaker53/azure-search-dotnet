using ICSharpCode.SharpZipLib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureSearch.Quickstart;

namespace WinFormsApp1
{
    public partial class indexForm : Form
    {

        private string PathFile = "";
        private string Algorithm = "Rake";
        private AzureSearch.Quickstart.Program program;
        public Form1 GetForm = null;

        CancellationTokenSource tokenSource;
        CancellationToken token;


        public indexForm()
        {
            InitializeComponent();

            program = new();

            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            folderBrowserDialog1.ShowDialog(this);
            PathFile = folderBrowserDialog1.SelectedPath;
            richTextBox1.Text = PathFile;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (radioButton1.Checked == false)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                this.PathFile = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tokenSource = new();
            Task.Run(() =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                program.UploadDocuments(this.PathFile, Algorithm);

            }, tokenSource.Token);
            //program.UploadDocuments(this.PathFile, Algorithm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete all index?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                program.RecreateIndex();
            }
            //MessageBox.Show("test");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algorithm = rakeToolStripMenuItem.Text;
        }

        private void frequentlyEncounteredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algorithm = "PopularWords";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tokenSource != null)
            {
                program.CancelToken();
                tokenSource.Cancel();
            }

        }

        private void indexForm_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            GetForm.ShowInterface();
        }
    }
}
