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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            folderBrowserDialog1 = new FolderBrowserDialog();
            fileSystemWatcher1 = new FileSystemWatcher();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            ResultInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            FileText = new DataGridViewTextBoxColumn();
            Path = new DataGridViewTextBoxColumn();
            fileID = new DataGridViewTextBoxColumn();
            textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResultInfo).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;
            // 
            // GroupBox1
            // 
            GroupBox1.BorderRadius = 10;
            GroupBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            GroupBox1.Controls.Add(ResultInfo);
            GroupBox1.CustomizableEdges = customizableEdges7;
            GroupBox1.Font = new Font("Segoe UI", 9F);
            GroupBox1.ForeColor = SystemColors.WindowText;
            GroupBox1.Location = new Point(88, 87);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            GroupBox1.Size = new Size(614, 268);
            GroupBox1.TabIndex = 6;
            GroupBox1.Text = "Result Search";
            // 
            // ResultInfo
            // 
            ResultInfo.AllowUserToAddRows = false;
            ResultInfo.AllowUserToDeleteRows = false;
            ResultInfo.AllowUserToResizeColumns = false;
            ResultInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            ResultInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ResultInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ResultInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ResultInfo.ColumnHeadersHeight = 4;
            ResultInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ResultInfo.ColumnHeadersVisible = false;
            ResultInfo.Columns.AddRange(new DataGridViewColumn[] { FileName, FileText, Path, fileID });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ResultInfo.DefaultCellStyle = dataGridViewCellStyle3;
            ResultInfo.Dock = DockStyle.Fill;
            ResultInfo.EnableHeadersVisualStyles = true;
            ResultInfo.GridColor = Color.FromArgb(231, 229, 255);
            ResultInfo.Location = new Point(0, 40);
            ResultInfo.Margin = new Padding(15);
            ResultInfo.Name = "ResultInfo";
            ResultInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            ResultInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            ResultInfo.RowHeadersVisible = false;
            ResultInfo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ResultInfo.ScrollBars = ScrollBars.Vertical;
            ResultInfo.Size = new Size(614, 228);
            ResultInfo.TabIndex = 4;
            ResultInfo.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ResultInfo.ThemeStyle.AlternatingRowsStyle.Font = null;
            ResultInfo.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ResultInfo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ResultInfo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ResultInfo.ThemeStyle.BackColor = Color.White;
            ResultInfo.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            ResultInfo.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ResultInfo.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ResultInfo.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            ResultInfo.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ResultInfo.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ResultInfo.ThemeStyle.HeaderStyle.Height = 4;
            ResultInfo.ThemeStyle.ReadOnly = true;
            ResultInfo.ThemeStyle.RowsStyle.BackColor = Color.White;
            ResultInfo.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ResultInfo.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            ResultInfo.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ResultInfo.ThemeStyle.RowsStyle.Height = 25;
            ResultInfo.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ResultInfo.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            ResultInfo.CellContentClick += ResultInfo_CellContentClick_1;
            // 
            // FileName
            // 
            FileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileName.DataPropertyName = "fileName";
            FileName.HeaderText = "FileName";
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            // 
            // FileText
            // 
            FileText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileText.DataPropertyName = "fileText";
            FileText.HeaderText = "FileText";
            FileText.Name = "FileText";
            FileText.ReadOnly = true;
            // 
            // Path
            // 
            Path.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Path.DataPropertyName = "filePath";
            Path.HeaderText = "Path";
            Path.Name = "Path";
            Path.ReadOnly = true;
            // 
            // fileID
            // 
            fileID.DataPropertyName = "fileID";
            fileID.HeaderText = "fileID";
            fileID.Name = "fileID";
            fileID.ReadOnly = true;
            fileID.Visible = false;
            // 
            // textBox1
            // 
            textBox1.BorderRadius = 10;
            textBox1.CustomizableEdges = customizableEdges5;
            textBox1.DefaultText = "";
            textBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.ForeColor = Color.Black;
            textBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textBox1.Location = new Point(88, 48);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '\0';
            textBox1.PlaceholderText = "";
            textBox1.SelectedText = "";
            textBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            textBox1.Size = new Size(614, 23);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 10;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Crimson;
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(12, 395);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(103, 29);
            guna2Button1.TabIndex = 8;
            guna2Button1.Text = "Index Files";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.Animated = true;
            guna2Button2.BackColor = Color.Transparent;
            guna2Button2.BorderColor = Color.Transparent;
            guna2Button2.BorderRadius = 10;
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Crimson;
            guna2Button2.Font = new Font("Segoe UI", 9F);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(657, 395);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.PressedColor = Color.Gainsboro;
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(112, 29);
            guna2Button2.TabIndex = 9;
            guna2Button2.Text = "Exit";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(786, 444);
            Controls.Add(guna2Button2);
            Controls.Add(guna2Button1);
            Controls.Add(textBox1);
            Controls.Add(GroupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IndexTF";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ResultInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private FolderBrowserDialog folderBrowserDialog1;
        private FileSystemWatcher fileSystemWatcher1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2GroupBox GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView ResultInfo;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn FileText;
        private DataGridViewTextBoxColumn Path;
        private DataGridViewTextBoxColumn fileID;
        private Guna.UI2.WinForms.Guna2TextBox textBox1;
        private Guna.UI2.WinForms.Guna2Button button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}