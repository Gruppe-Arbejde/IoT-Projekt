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

        public decimal balance;
        public string acnumber = "";
        public string username;

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
            this.labelAccountName.Text = username.Substring(0, 1).ToUpper() + username.Substring(1);
            #endregion


            #region show balance
           
            // We need to find out the account number that is associated with our login, in order to see the correct account balance
            MySqlDataReader reader = null;
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
                balance = (decimal)reader["opening_balance"];
                reader.Close();
                break;
            }

            // Finally we can show the correct balance in the UI
            labelBalance.Text = $"{balance} kr.";

            #endregion


            #region show recent transactions

            reader = null;
            cmd = new MySqlCommand($"SELECT * FROM trandetails WHERE acnumber = '{acnumber}';", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dateOfTransaction = (DateTime)reader["dot"];
                string dot = dateOfTransaction.ToString("yyyy-MM-dd HH:mm:ss");
                decimal amount = (decimal)reader["transaction_amount"];
                listBoxTransactions.Items.Add(dot + "\t" + amountFormatting(amount, (string)reader["transaction_type"]));
            }
            reader.Close();

            #endregion

        }

        private string amountFormatting(decimal amount, string type)
        {
            string amountFormatted = string.Format("{0:0.00}", amount);
            if (type == "Deposit")
            {
              amountFormatted = $"+{amountFormatted} kr.";
            }
            else if (type == "Withdraw")
            {
                amountFormatted = $"-{amountFormatted} kr.";
            }

            return amountFormatted;
        }

        private void Bank_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.sqlBankString);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            int amount = 100;
            string target = "Maximus";
            if (balance >= 100)
            {
                balance -= 100;
                MySqlCommand cmd = new MySqlCommand();
                StringBuilder    ($"INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{acnumber}', CURRENT_TIMESTAMP, 'Cheque', 'Withdraw', '{amount}', '{username}', '{target}')");
                cmd.
            
            }
        }
    }
}
