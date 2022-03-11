
namespace IoT_Projekt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUsernameMissing = new System.Windows.Forms.Label();
            this.labelPasswordMissing = new System.Windows.Forms.Label();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.linkLabelPassword = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelFakeBank = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonLogin.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(389, 343);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogin.MaximumSize = new System.Drawing.Size(298, 37);
            this.buttonLogin.MinimumSize = new System.Drawing.Size(298, 37);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(298, 37);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(392, 141);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsername.MaximumSize = new System.Drawing.Size(299, 45);
            this.textBoxUsername.MinimumSize = new System.Drawing.Size(299, 45);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(299, 42);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.White;
            this.labelUsername.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(391, 118);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(87, 19);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.White;
            this.labelPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(388, 232);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(86, 19);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(392, 255);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.MaximumSize = new System.Drawing.Size(299, 45);
            this.textBoxPassword.MinimumSize = new System.Drawing.Size(299, 45);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(299, 42);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // labelUsernameMissing
            // 
            this.labelUsernameMissing.AutoSize = true;
            this.labelUsernameMissing.BackColor = System.Drawing.Color.White;
            this.labelUsernameMissing.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsernameMissing.ForeColor = System.Drawing.Color.Red;
            this.labelUsernameMissing.Location = new System.Drawing.Point(392, 190);
            this.labelUsernameMissing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsernameMissing.Name = "labelUsernameMissing";
            this.labelUsernameMissing.Size = new System.Drawing.Size(145, 14);
            this.labelUsernameMissing.TabIndex = 5;
            this.labelUsernameMissing.Text = "Please enter valid username!";
            // 
            // labelPasswordMissing
            // 
            this.labelPasswordMissing.AutoSize = true;
            this.labelPasswordMissing.BackColor = System.Drawing.Color.White;
            this.labelPasswordMissing.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordMissing.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordMissing.Location = new System.Drawing.Point(391, 301);
            this.labelPasswordMissing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPasswordMissing.Name = "labelPasswordMissing";
            this.labelPasswordMissing.Size = new System.Drawing.Size(147, 14);
            this.labelPasswordMissing.TabIndex = 6;
            this.labelPasswordMissing.Text = "Please enter valid password!";
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.BackColor = System.Drawing.Color.White;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(641, 238);
            this.checkBoxShowPassword.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(53, 17);
            this.checkBoxShowPassword.TabIndex = 7;
            this.checkBoxShowPassword.Text = "Show";
            this.checkBoxShowPassword.UseVisualStyleBackColor = false;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // linkLabelPassword
            // 
            this.linkLabelPassword.AutoSize = true;
            this.linkLabelPassword.BackColor = System.Drawing.Color.White;
            this.linkLabelPassword.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabelPassword.Location = new System.Drawing.Point(492, 382);
            this.linkLabelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelPassword.Name = "linkLabelPassword";
            this.linkLabelPassword.Size = new System.Drawing.Size(92, 13);
            this.linkLabelPassword.TabIndex = 8;
            this.linkLabelPassword.TabStop = true;
            this.linkLabelPassword.Text = "Forgot Password?";
            this.linkLabelPassword.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(370, 68);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 347);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelWelcome.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(12, 68);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(160, 32);
            this.labelWelcome.TabIndex = 14;
            this.labelWelcome.Text = "Welcome to";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.labelLogin);
            this.panel1.Controls.Add(this.labelFakeBank);
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 475);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(44, 150);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(242, 292);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(14, 101);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(246, 22);
            this.labelLogin.TabIndex = 16;
            this.labelLogin.Text = "Login to acces your account";
            // 
            // labelFakeBank
            // 
            this.labelFakeBank.AutoSize = true;
            this.labelFakeBank.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelFakeBank.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFakeBank.ForeColor = System.Drawing.Color.White;
            this.labelFakeBank.Location = new System.Drawing.Point(164, 69);
            this.labelFakeBank.Name = "labelFakeBank";
            this.labelFakeBank.Size = new System.Drawing.Size(151, 32);
            this.labelFakeBank.TabIndex = 15;
            this.labelFakeBank.Text = "Fake Bank";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(747, 475);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabelPassword);
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.labelPasswordMissing);
            this.Controls.Add(this.labelUsernameMissing);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(763, 514);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(763, 514);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUsernameMissing;
        private System.Windows.Forms.Label labelPasswordMissing;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.LinkLabel linkLabelPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelFakeBank;
    }
}

