using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace IoT_Projekt
{
    public partial class Login : Form
    {
        public MySqlConnection connection;
        public MySqlConnection Connection { get => connection; }

        bool CredentialOK = false;
        #region Credentials for AccountCheck
        string server = "157.90.11.126";
        string id = "AccountCheck";
        string password = "Losting50##";
        string database = "fakebank";
        #endregion

        public Login()
        {
            InitializeComponent();
            #region Visual
            labelUsernameMissing.Visible = false;
            labelPasswordMissing.Visible = false;

            this.textBoxUsername.AutoSize = false;
            this.textBoxPassword.AutoSize = false;
            #endregion

            #region accountCheck
            // Vi skaber en string, som kan bruges til at forbinde til vores database, som en bruger der checker en given tabel igennem for at se om der eksistere en kunde.
            string sqlLogOnString = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";

            // Vi laver en connection til databasen, med stringen for oven
            connection = new MySqlConnection(sqlLogOnString);

            try
            {
                // Her prøver vi at åbne forbindelsen til databasen. Hvis det lykkedes får vi en messagebox prompt der siger der er forbindelse (Ren debugging)
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    // Debugging
                    //MessageBox.Show("Connection Open");
                }
            }
            // Hvis vores forbindelse fejler, bliver der smidt en "SQL error, samt fejl koden"
            catch (Exception ex)
            {
                // Debugging
                MessageBox.Show(ex.Message, "SQL error");
            }
            #endregion
        }

        public void textBoxErrorHandeling(TextBox textBox)
        {
            //Draw red Rectangle around the TextBox
            textBox.BorderStyle = BorderStyle.Fixed3D;
            Graphics g;
            g = this.CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);
            g.DrawRectangle(pen, new Rectangle(textBox.Location, textBox.Size));

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.TextLength != 0)
            {
                if (textBoxPassword.TextLength != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    #region Backend Login
                    try
                    {
                        string username = "";
                        MySqlDataReader myReader = null;
                        MySqlCommand myCommand = new MySqlCommand("SELECT * FROM users;", connection);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            username = (string)myReader["usernameL"];
                            if (textBoxUsername.Text.ToLower().Equals(username))
                            {
                                CredentialOK = true;
                                break;
                            }
                            else
                                break;
                        }
                        string sqlBankString = $"Server={server};Port=3306;SslMode=none;User Id={textBoxUsername.Text.ToLower()};Password={textBoxPassword.Text};Database={database};";

                        connection.Close();
                        if (connection.State == ConnectionState.Closed && CredentialOK == true)
                        {
                            connection = new MySqlConnection(sqlBankString);

                            try
                            {
                                connection.Open();
                                if (connection.State == ConnectionState.Open)
                                {

                                    #region Move Login to new form

                                    Bank bank = new Bank();
                                    bank.sqlBankString = sqlBankString;
                                    bank.Show();
                                    this.Hide();

                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "SQL error - User connection Error");
                            }
                        }
                        else
                        {
                            string sqlLogOnString = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";
                            connection = new MySqlConnection(sqlLogOnString);
                            connection.Open();
                            // Debugging
                            MessageBox.Show("Bruger findes ikke", "Credential Error");
                            this.Cursor = Cursors.Default;

                            textBoxErrorHandeling(textBoxPassword);
                            labelPasswordMissing.Visible = true;

                            textBoxErrorHandeling(textBoxUsername);
                            labelUsernameMissing.Visible = true;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    textBoxErrorHandeling(textBoxPassword);
                    labelPasswordMissing.Visible = true;
                }
            }
            else
            {
                textBoxErrorHandeling(textBoxUsername);
                labelUsernameMissing.Visible = true;
            }
            #endregion
        }

        #region UI
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(Login.ActiveForm.BackColor);
            labelUsernameMissing.Visible = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(Login.ActiveForm.BackColor);
            labelPasswordMissing.Visible = false;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '•';
        }

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUp SignUp = new SignUp();
            SignUp.ShowDialog();
        }
        #endregion
    }
}
