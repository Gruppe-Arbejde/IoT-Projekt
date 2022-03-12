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

            labelWelcome.BackColor = Color.Transparent;

            #endregion

            #region accountCheck
            // Vi skaber en string, som kan bruges til at forbinde til vores database, som en bruger der checker en given tabel igennem for at se om der eksistere en kunde.
            string accountCheckConnection = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";

            // Vi laver en connection til databasen, med stringen for oven
            connection = new MySqlConnection(accountCheckConnection);

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
                        string custid = "";
                        MySqlDataReader myReader = null;
                        MySqlCommand myCommand = new MySqlCommand("SELECT * FROM customers;", connection);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            username = (string)myReader["fname"];
                            custid = (string)myReader["custid"];
                            if (textBoxUsername.Text.ToLower().Equals(username))
                            {
                                CredentialOK = true;
                                break;
                            }
                        }
                        string customerConnection = $"Server={server};Port=3306;SslMode=none;User Id={textBoxUsername.Text.ToLower()};Password={textBoxPassword.Text};Database={database};";

                        connection.Close();
                        if (connection.State == ConnectionState.Closed && CredentialOK == true)
                        {
                            connection = new MySqlConnection(customerConnection);

                            try
                            {
                                connection.Open();
                                if (connection.State == ConnectionState.Open)
                                {
                                    #region Open bank, with the correct user connected

                                    Bank bank = new Bank(username, password, customerConnection, server, database, custid);
                                    bank.Show();
                                    this.Hide();
                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "SQL Error");
                            }
                        }
                        else
                        {
                            string accountCheckConnection = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";
                            connection = new MySqlConnection(accountCheckConnection);
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


        #endregion

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }
    }
}
