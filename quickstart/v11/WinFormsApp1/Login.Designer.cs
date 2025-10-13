namespace WinFormsApp1
{
    partial class Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            LoginUser = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            label2 = new Label();
            Email = new Guna.UI2.WinForms.Guna2TextBox();
            Password = new Guna.UI2.WinForms.Guna2TextBox();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // LoginUser
            // 
            LoginUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoginUser.BorderRadius = 10;
            LoginUser.CustomizableEdges = customizableEdges7;
            LoginUser.DisabledState.BorderColor = Color.DarkGray;
            LoginUser.DisabledState.CustomBorderColor = Color.DarkGray;
            LoginUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            LoginUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            LoginUser.FillColor = Color.FromArgb(0, 192, 0);
            LoginUser.Font = new Font("Segoe UI", 9F);
            LoginUser.ForeColor = Color.White;
            LoginUser.Location = new Point(116, 239);
            LoginUser.Name = "LoginUser";
            LoginUser.ShadowDecoration.CustomizableEdges = customizableEdges8;
            LoginUser.Size = new Size(259, 42);
            LoginUser.TabIndex = 0;
            LoginUser.Text = "Log into";
            LoginUser.Click += LoginUser_Button;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 83);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "E-mail";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 157);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // Email
            // 
            Email.CustomizableEdges = customizableEdges9;
            Email.DefaultText = "";
            Email.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Email.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Email.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Email.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Email.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Email.Font = new Font("Segoe UI", 9F);
            Email.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Email.Location = new Point(82, 101);
            Email.Name = "Email";
            Email.PasswordChar = '\0';
            Email.PlaceholderText = "";
            Email.SelectedText = "";
            Email.ShadowDecoration.CustomizableEdges = customizableEdges10;
            Email.Size = new Size(323, 36);
            Email.TabIndex = 3;
            // 
            // Password
            // 
            Password.CustomizableEdges = customizableEdges11;
            Password.DefaultText = "";
            Password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Password.Font = new Font("Segoe UI", 9F);
            Password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Password.Location = new Point(82, 175);
            Password.Name = "Password";
            Password.PasswordChar = '\0';
            Password.PlaceholderText = "";
            Password.SelectedText = "";
            Password.ShadowDecoration.CustomizableEdges = customizableEdges12;
            Password.Size = new Size(323, 36);
            Password.TabIndex = 4;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(192, 0, 0);
            linkLabel1.Location = new Point(322, 37);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(131, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Don't have an account?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 336);
            Controls.Add(linkLabel1);
            Controls.Add(Password);
            Controls.Add(Email);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LoginUser);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button LoginUser;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox Email;
        private Guna.UI2.WinForms.Guna2TextBox Password;
        private LinkLabel linkLabel1;
    }
}