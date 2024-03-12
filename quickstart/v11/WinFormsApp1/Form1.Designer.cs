namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            fileSystemWatcher1 = new FileSystemWatcher();
            button2 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            textBox1 = new TextBox();
            ResultInfo = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            FileText = new DataGridViewTextBoxColumn();
            Path = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ResultInfo).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(32, 401);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Index Files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;
            // 
            // button2
            // 
            button2.Location = new Point(613, 401);
            button2.Name = "button2";
            button2.Size = new Size(154, 26);
            button2.TabIndex = 2;
            button2.Text = "start system wather (beta)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(88, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(614, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // ResultInfo
            // 
            ResultInfo.AllowUserToAddRows = false;
            ResultInfo.AllowUserToDeleteRows = false;
            ResultInfo.AllowUserToResizeColumns = false;
            ResultInfo.AllowUserToResizeRows = false;
            ResultInfo.BackgroundColor = Color.FromArgb(224, 224, 224);
            ResultInfo.CellBorderStyle = DataGridViewCellBorderStyle.None;
            ResultInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultInfo.ColumnHeadersVisible = false;
            ResultInfo.Columns.AddRange(new DataGridViewColumn[] { FileName, FileText, Path });
            ResultInfo.Location = new Point(88, 100);
            ResultInfo.Name = "ResultInfo";
            ResultInfo.RowHeadersVisible = false;
            ResultInfo.RowTemplate.Height = 30;
            ResultInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ResultInfo.Size = new Size(614, 213);
            ResultInfo.TabIndex = 4;
            ResultInfo.CellContentClick += ResultInfo_CellContentClick;
            // 
            // FileName
            // 
            FileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileName.DataPropertyName = "fileName";
            FileName.HeaderText = "FileName";
            FileName.Name = "FileName";
            // 
            // FileText
            // 
            FileText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileText.DataPropertyName = "fileText";
            FileText.HeaderText = "FileText";
            FileText.Name = "FileText";
            // 
            // Path
            // 
            Path.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Path.DataPropertyName = "filePath";
            Path.HeaderText = "Path";
            Path.Name = "Path";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 442);
            Controls.Add(ResultInfo);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Index File";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ResultInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private FileSystemWatcher fileSystemWatcher1;
        private Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
        private DataGridView ResultInfo;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn FileText;
        private DataGridViewTextBoxColumn Path;
    }
}