using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
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
        public string customerConnection;

        public Bank(string username, string password, string customerConnection, string server, string database, string custid)
        {
            InitializeComponent();
            this.username = username;

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

            labelTargetMissing.Visible = false;
            labelAmountMissing.Visible = false;

            MySqlDataAdapter getAllUsers = new MySqlDataAdapter($"SELECT fname FROM customers WHERE custid != '{custid}'", connection);
            DataTable dt = new DataTable();
            getAllUsers.Fill(dt);
            foreach (DataRow user in dt.Rows)
            {
                comboBox1.Items.Add(user["fname"].ToString());
            }

            #endregion


            #region show balance

            // We need to find out the account number that is associated with our login, in order to see the correct account balance
            MySqlDataReader reader = null;
            MySqlCommand getUserAccountNumber = new MySqlCommand($"SELECT acnumber FROM account WHERE custid = '{custid}';", connection);
            reader = getUserAccountNumber.ExecuteReader();
            while (reader.Read())
            {
                acnumber = (string)reader["acnumber"];
                break;
            }
            reader.Close();

            // We've now aquired the account number, now we can find the correct balance
            MySqlCommand getUserBalance = new MySqlCommand($"SELECT opening_balance FROM account WHERE acnumber = '{acnumber}';", connection);
            reader = getUserBalance.ExecuteReader();
            while (reader.Read())
            {
                balance = (decimal)reader["opening_balance"];
                break;
            }
            reader.Close();

            // Finally we can show the correct balance in the UI
            labelBalance.Text = $"{balance} kr.";

            #endregion


            #region show recent transactions

            MySqlCommand getAllUserTransactions = new MySqlCommand($"SELECT * FROM trandetails WHERE acnumber = '{acnumber}';", connection);
            reader = getAllUserTransactions.ExecuteReader();
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (textBoxSendAmount.Text.Length != 0)
                {
                    try
                    {
                        decimal amount = Convert.ToDecimal(textBoxSendAmount.Text);

                        if (amount > 0)
                        {
                            if (balance >= amount)
                            {
                                string target = comboBox1.SelectedItem.ToString();
                                string targetCustomerNumber = "";
                                string targetAccountNumber = "";
                                decimal targetBalance = 0;

                                MySqlDataReader readerTargetCustumerNumber = null;
                                MySqlCommand getTargetCustomerNumber = new MySqlCommand($"SELECT custid FROM customers WHERE fname = '{target}'", connection);
                                readerTargetCustumerNumber = getTargetCustomerNumber.ExecuteReader();
                                while (readerTargetCustumerNumber.Read())
                                {
                                    targetCustomerNumber = (string)readerTargetCustumerNumber["custid"];
                                    break;
                                }
                                readerTargetCustumerNumber.Close();

                                MySqlDataReader readerTargetBalance = null;
                                MySqlCommand getTargetBalance = new MySqlCommand($"SELECT opening_balance, acnumber FROM account WHERE custid = '{targetCustomerNumber}'", connection);
                                readerTargetBalance = getTargetBalance.ExecuteReader();
                                while (readerTargetBalance.Read())
                                {
                                    targetBalance = (decimal)readerTargetBalance["opening_balance"];
                                    targetAccountNumber = (string)readerTargetBalance["acnumber"];
                                    break;
                                }
                                readerTargetBalance.Close();

                                //Calculating new balance
                                decimal newSenderBalance = balance - amount;
                                decimal newTargetBalance = targetBalance + amount;

                                NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;

                                var newSenderBalanceFormated = newSenderBalance.ToString("N", nfi);
                                var newTargetBalanceFormated = newTargetBalance.ToString("N", nfi);
                                var amountFormated = amount.ToString("N", nfi);


                                //var testString = $"UPDATE account SET opening_balance = {newSenderBalanceFormated} WHERE acnumber = '{acnumber}'; UPDATE account SET opening_balance = {newTargetBalanceFormated} WHERE acnumber = '{targetAccountNumber}';".Replace(".", "").Replace(",", ".");

                                //Execute Sql command - Set account balance in Database
                                MySqlCommand setNewBalance = new MySqlCommand($"UPDATE account SET opening_balance = {newSenderBalanceFormated} WHERE acnumber = '{acnumber}'; UPDATE account SET opening_balance = {newTargetBalanceFormated} WHERE acnumber = '{targetAccountNumber}';".Replace(".", "").Replace(",", "."), connection);
                                setNewBalance.ExecuteNonQuery();
                                balance = newSenderBalance;

                                //var testStringTwo = $"INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{acnumber}', CURRENT_TIMESTAMP, 'Cheque', 'Withdraw', {amount}, '{username}', '{target}'); INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{targetAccountNumber}', CURRENT_TIMESTAMP, 'Cheque', 'Deposit', {amount}, '{target}', '{username}');";
                                MySqlCommand setNewTransaction = new MySqlCommand($"INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{acnumber}', CURRENT_TIMESTAMP, 'Cheque', 'Withdraw', {amount}, '{username}', '{target}'); INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{targetAccountNumber}', CURRENT_TIMESTAMP, 'Cheque', 'Deposit', {amount}, '{username}', '{target}');", connection);
                                setNewTransaction.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("You don't have enough money to complete the transfer!");
                            }
                        }
                        else
                        {
                            labelAmountMissing.Visible = true;
                        }
                    }   
                    catch (Exception)
                    {
                        labelAmountMissing.Visible = true;
                    }
                
                }
                else
                {
                    labelAmountMissing.Visible = true;
                }
            }
            else
            {
                labelTargetMissing.Visible = true;  
            }
        }

        #region UI
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTargetMissing.Visible = false;
        }

        private void textBoxSendAmount_TextChanged(object sender, EventArgs e)
        {
            labelAmountMissing.Visible = false;
        }
        #endregion
    }
}
