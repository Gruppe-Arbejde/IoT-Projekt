using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace IoT_Projekt
{
    public partial class Bank : Form
    {
        public MySqlConnection connection;
        public MySqlConnection Connection { get => connection; }

        public Bank(string username, string password, string customerConnection, string server, string database, string custid)
        {
            InitializeComponent();

            #region customerConnection
            customerConnection = $"Server={server};Port=3306;SslMode=none;User Id={username};Password={password};Database={database}";

            connection = new MySqlConnection(customerConnection);

            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    // Debugging
                    //MessageBox.Show("Connection Open");
                }
            }
            catch (Exception ex)
            {
                // Debugging
                MessageBox.Show(ex.Message, "SQL error");
            }
            #endregion

            #region UI
            this.labelAccountName.Text = /*"Welcome, " + */username.Substring(0, 1).ToUpper() + username.Substring(1);
            #endregion


            #region show balance
            string acnumber = "";
            string balance = "";
            MySqlDataReader reader = null;

            // We need to find out the account number that is associated with our login, in order to see the correct account balance
            MySqlCommand cmd = new MySqlCommand($"SELECT acnumber FROM account WHERE custid = '{custid}';", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                acnumber = (string)reader["acnumber"];
                reader.Close();
                break;
            }
            // We've now aquired the account number, now we can find the correct balance
            reader = null;
            cmd = new MySqlCommand($"SELECT opening_balance FROM account WHERE acnumber = '{acnumber}';", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                balance = (string)reader["opening_balance"];
                break;
            }

            labelBalance.Text = $"${balance}";

            #endregion


        }

        private void Bank_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.sqlBankString);
        }
    }
}
