namespace WinFormsApp1
{
    partial class Registration
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Nickname = new Guna.UI2.WinForms.Guna2TextBox();
            Gmail = new Guna.UI2.WinForms.Guna2TextBox();
            Password = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            RegistrationUser = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // Nickname
            // 
            Nickname.CustomizableEdges = customizableEdges1;
            Nickname.DefaultText = "";
            Nickname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Nickname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Nickname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Nickname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Nickname.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Nickname.Font = new Font("Segoe UI", 9F);
            Nickname.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Nickname.Location = new Point(94, 98);
            Nickname.Name = "Nickname";
            Nickname.PasswordChar = '\0';
            Nickname.PlaceholderText = "Nickname";
            Nickname.SelectedText = "";
            Nickname.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Nickname.Size = new Size(200, 36);
            Nickname.TabIndex = 0;
            Nickname.TextChanged += Nickname_TextChanged;
            // 
            // Gmail
            // 
            Gmail.CustomizableEdges = customizableEdges3;
            Gmail.DefaultText = "";
            Gmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Gmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Gmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Gmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Gmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Gmail.Font = new Font("Segoe UI", 9F);
            Gmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Gmail.Location = new Point(94, 184);
            Gmail.Name = "Gmail";
            Gmail.PasswordChar = '\0';
            Gmail.PlaceholderText = "E-mail";
            Gmail.SelectedText = "";
            Gmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Gmail.Size = new Size(200, 36);
            Gmail.TabIndex = 1;
            // 
            // Password
            // 
            Password.CustomizableEdges = customizableEdges5;
            Password.DefaultText = "";
            Password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Password.Font = new Font("Segoe UI", 9F);
            Password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Password.Location = new Point(94, 265);
            Password.Name = "Password";
            Password.PasswordChar = '\0';
            Password.PlaceholderText = "Password";
            Password.SelectedText = "";
            Password.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Password.Size = new Size(200, 36);
            Password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 80);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 3;
            label1.Text = "Nickname";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 166);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 4;
            label2.Text = "E-mail";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 247);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // RegistrationUser
            // 
            RegistrationUser.BorderRadius = 10;
            RegistrationUser.CustomizableEdges = customizableEdges7;
            RegistrationUser.DisabledState.BorderColor = Color.DarkGray;
            RegistrationUser.DisabledState.CustomBorderColor = Color.DarkGray;
            RegistrationUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            RegistrationUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            RegistrationUser.FillColor = Color.FromArgb(0, 192, 0);
            RegistrationUser.Font = new Font("Segoe UI", 9F);
            RegistrationUser.ForeColor = Color.White;
            RegistrationUser.Location = new Point(103, 326);
            RegistrationUser.Name = "RegistrationUser";
            RegistrationUser.ShadowDecoration.CustomizableEdges = customizableEdges8;
            RegistrationUser.Size = new Size(180, 45);
            RegistrationUser.TabIndex = 6;
            RegistrationUser.Text = "Registration";
            RegistrationUser.Click += Registration_User_Button;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 10;
            guna2Button2.CustomizableEdges = customizableEdges9;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(192, 0, 0);
            guna2Button2.Font = new Font("Segoe UI", 9F);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(103, 402);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button2.Size = new Size(180, 45);
            guna2Button2.TabIndex = 7;
            guna2Button2.Text = "Back";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 484);
            Controls.Add(guna2Button2);
            Controls.Add(RegistrationUser);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Password);
            Controls.Add(Gmail);
            Controls.Add(Nickname);
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox Nickname;
        private Guna.UI2.WinForms.Guna2TextBox Gmail;
        private Guna.UI2.WinForms.Guna2TextBox Password;
        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Button RegistrationUser;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}