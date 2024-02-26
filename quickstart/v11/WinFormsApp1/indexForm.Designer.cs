namespace WinFormsApp1
{
    partial class indexForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            testToolStripMenuItem = new ToolStripMenuItem();
            rakeToolStripMenuItem = new ToolStripMenuItem();
            frequentlyEncounteredToolStripMenuItem = new ToolStripMenuItem();
            folderBrowserDialog1 = new FolderBrowserDialog();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            radioButton1 = new RadioButton();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { testToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(772, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rakeToolStripMenuItem, frequentlyEncounteredToolStripMenuItem });
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(73, 20);
            testToolStripMenuItem.Text = "Algorithm";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // rakeToolStripMenuItem
            // 
            rakeToolStripMenuItem.Name = "rakeToolStripMenuItem";
            rakeToolStripMenuItem.Size = new Size(200, 22);
            rakeToolStripMenuItem.Text = "Rake";
            rakeToolStripMenuItem.Click += rakeToolStripMenuItem_Click;
            // 
            // frequentlyEncounteredToolStripMenuItem
            // 
            frequentlyEncounteredToolStripMenuItem.Name = "frequentlyEncounteredToolStripMenuItem";
            frequentlyEncounteredToolStripMenuItem.Size = new Size(200, 22);
            frequentlyEncounteredToolStripMenuItem.Text = "Frequently encountered";
            frequentlyEncounteredToolStripMenuItem.Click += frequentlyEncounteredToolStripMenuItem_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.White;
            richTextBox1.Enabled = false;
            richTextBox1.ForeColor = SystemColors.MenuText;
            richTextBox1.ImeMode = ImeMode.NoControl;
            richTextBox1.Location = new Point(144, 78);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(479, 23);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(629, 78);
            button1.Name = "button1";
            button1.Size = new Size(46, 23);
            button1.TabIndex = 2;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(629, 158);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(105, 19);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Scan all system";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button2
            // 
            button2.Location = new Point(302, 226);
            button2.Name = "button2";
            button2.Size = new Size(193, 25);
            button2.TabIndex = 4;
            button2.Text = "Start Index";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(629, 226);
            button3.Name = "button3";
            button3.Size = new Size(109, 25);
            button3.TabIndex = 5;
            button3.Text = "Delete all index";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(34, 227);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // indexForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 284);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(radioButton1);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "indexForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem testToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
        private RichTextBox richTextBox1;
        private Button button1;
        private RadioButton radioButton1;
        private Button button2;
        private Button button3;
        private ToolStripMenuItem rakeToolStripMenuItem;
        private ToolStripMenuItem frequentlyEncounteredToolStripMenuItem;
        private Button button4;
    }
}