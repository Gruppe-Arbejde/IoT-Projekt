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
        // Here we have the login information for our Account Checker user in the database
        string server = "server";
        string id = "id";
        string password = "password";
        string database = "database";

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
            // We create a string that can be used to connect to our database, as a user who checks a given table through to see if a customer exists.
            string accountCheckConnection = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";

            // We make a connection to the database, by using the string above
            connection = new MySqlConnection(accountCheckConnection);

            try
            {
                // Here we try to open the connection to the database. If we succeed we get a messagebox prompt that says there is a connection (only purpose is debugging)
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    // Debugging
                    // MessageBox.Show("Connection Open");
                }
            }
            // If our connection fails, an "SQL error will be thrown, as well as the error code"
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
                        //#region Locating user credentials
                        string username = "";
                        string custid = "";

                        // We want to figure out, if the information that our user types exist in our database. In order to do so, we'll search for anything under the customer table.
                        MySqlDataReader myReader = null;
                        MySqlCommand myCommand = new MySqlCommand("SELECT * FROM customers;", connection);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            username = (string)myReader["fname"];
                            custid = (string)myReader["custid"];

                            // if the username written by the user on the login page, matches the name in our row "fname" under the table "customers", then we'll change the CredentialOK to true.
                            if (textBoxUsername.Text.ToLower().Equals(username))
                            {
                                CredentialOK = true;
                                break;
                            }
                            //#endregion
                        }

                        //#region Opening Bank
                        string customerConnection = $"Server={server};Port=3306;SslMode=none;User Id={textBoxUsername.Text.ToLower()};Password={textBoxPassword.Text};Database={database};";
                        connection.Close();

                        // If the credentials are true, and our connection with the bank as AccountChecker is closed, then we want to open a new connection as the user
                        if (connection.State == ConnectionState.Closed && CredentialOK == true)
                        {
                            connection = new MySqlConnection(customerConnection);
                            try
                            {
                                // If the connection succeeds, then we'll want to open a new window, i.e. our bank 
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
                            // But if the connection fails, then we'll thros an error
                            catch (Exception ex)
                            {
                                //#region No User Handling
                                // If the user credentials typed in doesnt match anything in the database, we want to fallback to our AccountCheck user, while also telling our user that the information doesn't exist
                                string accountCheckConnection = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";
                                connection = new MySqlConnection(accountCheckConnection);
                                connection.Open();
                                // Debugging
                                MessageBox.Show(ex.Message, "Bruger findes ikke");
                                this.Cursor = Cursors.Default;

                                textBoxErrorHandeling(textBoxPassword);
                                labelPasswordMissing.Visible = true;

                                textBoxErrorHandeling(textBoxUsername);
                                labelUsernameMissing.Visible = true;
                            }
                        }
                        //#endregion

                        else
                        {
                            //#region No User Handling
                            // If the user credentials typed in doesnt match anything in the database, we want to fallback to our AccountCheck user, while also telling our user that the information doesn't exist
                            string accountCheckConnection = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={password};Database={database}";
                            connection = new MySqlConnection(accountCheckConnection);
                            connection.Open();
                            // Debugging
                            MessageBox.Show("Bruger findes ikke", "Login Fejl");
                            this.Cursor = Cursors.Default;

                            textBoxErrorHandeling(textBoxPassword);
                            labelPasswordMissing.Visible = true;

                            textBoxErrorHandeling(textBoxUsername);
                            labelUsernameMissing.Visible = true;
                            //#endregion
                        }
                    }
                    catch (Exception q)
                    {
                        MessageBox.Show(q.Message);
                    }
                }
                else
                {
                    // UI / UX if theres an empty password box, then it'll turn its border red
                    textBoxErrorHandeling(textBoxPassword);
                    labelPasswordMissing.Visible = true;
                }
            }
            else
            {
                // UI / UX if theres an empty username box, then it'll turn its border red
                textBoxErrorHandeling(textBoxUsername);
                labelUsernameMissing.Visible = true;
            }
            #endregion
        }
        #region UI/UX
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            // UI / UX, the username box changes border color depending on, if there is anything in the box or not, when login is pressed
            this.CreateGraphics().Clear(Login.ActiveForm.BackColor);
            labelUsernameMissing.Visible = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            // UI / UX, the password box changes border color depending on, if there is anything in the box or not, when login is pressed
            this.CreateGraphics().Clear(Login.ActiveForm.BackColor);
            labelPasswordMissing.Visible = false;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // checkbox that we can enable or disable in order to see our password
            textBoxPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '•';
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            // When enter key is pressed, the login button is pressed
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        #endregion
    }
}
