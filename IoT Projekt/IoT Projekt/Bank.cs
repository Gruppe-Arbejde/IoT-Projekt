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

        #region Types of variables
        public decimal balance;
        public string acnumber = "";
        public string username;
        public string customerConnection;
        #endregion

        public Bank(string username, string password, string customerConnection, string server, string database, string custid)
        {
            InitializeComponent();

            #region customerConnection
            this.username = username;
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

            listboxTransactionsRefresh();

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
                                #region Locating target identifiers
                                //Declaring variables for the target/reciever
                                string target = comboBox1.SelectedItem.ToString();
                                string targetCustomerID = "";
                                string targetAccountNumber = "";
                                decimal targetBalance = 0;

                                //We want the targets Customer ID, and to find that we send a request to the Database. Here we ask the Database to search for a Customer ID, where the username is the same as the username the user entered.
                                MySqlDataReader readerTargetCustumerID = null;
                                MySqlCommand getTargetCustomerID = new MySqlCommand($"SELECT custid FROM customers WHERE fname = '{target}'", connection);
                                readerTargetCustumerID = getTargetCustomerID.ExecuteReader();
                                while (readerTargetCustumerID.Read())
                                {
                                    targetCustomerID = (string)readerTargetCustumerID["custid"];
                                    break;
                                }
                                readerTargetCustumerID.Close();

                                //We want the targets Balance, and to find that we send a request to the Database. We ask the Database to search for the Balance which corresponds to the targets Curstomer ID wich we found above. We also find to Account Number since we need it for later.
                                MySqlDataReader readerTargetBalance = null;
                                MySqlCommand getTargetBalance = new MySqlCommand($"SELECT opening_balance, acnumber FROM account WHERE custid = '{targetCustomerID}'", connection);
                                readerTargetBalance = getTargetBalance.ExecuteReader();
                                while (readerTargetBalance.Read())
                                {
                                    targetBalance = (decimal)readerTargetBalance["opening_balance"];
                                    targetAccountNumber = (string)readerTargetBalance["acnumber"];
                                    break;
                                }
                                readerTargetBalance.Close();
                                #endregion

                                #region Executing transer and transaction commands
                                //Calculating new balance for sender and target
                                decimal newSenderBalance = balance - amount;
                                decimal newTargetBalance = targetBalance + amount;

                                NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;

                                var newSenderBalanceFormated = newSenderBalance.ToString("N", nfi).Replace(".", "").Replace(",", ".");
                                var newTargetBalanceFormated = newTargetBalance.ToString("N", nfi).Replace(".", "").Replace(",", ".");
                                
                                var amountFormated = amount.ToString("N", nfi).Replace(".", "").Replace(",", ".");

                                //DEBUGGING
                                //var testString = $"UPDATE account SET opening_balance = {newSenderBalanceFormated} WHERE acnumber = '{acnumber}'; UPDATE account SET opening_balance = {newTargetBalanceFormated} WHERE acnumber = '{targetAccountNumber}';".Replace(".", "").Replace(",", ".");

                                //Execute Sql command - Set account balance in Database for sender and target
                                MySqlCommand setNewBalance = new MySqlCommand($"UPDATE account SET opening_balance = {newSenderBalanceFormated} WHERE acnumber = '{acnumber}'; UPDATE account SET opening_balance = {newTargetBalanceFormated} WHERE acnumber = '{targetAccountNumber}';", connection);
                                setNewBalance.ExecuteNonQuery();
                                balance = newSenderBalance;

                                //DEBUGGING
                                //var testStringTwo = $"INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{acnumber}', CURRENT_TIMESTAMP, 'Cheque', 'Withdraw', {amount}, '{username}', '{target}'); INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{targetAccountNumber}', CURRENT_TIMESTAMP, 'Cheque', 'Deposit', {amount}, '{target}', '{username}');";
                                
                                //Execute Sql command - Create new Transaction in Database for sender and Target
                                MySqlCommand setNewTransaction = new MySqlCommand($"INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{acnumber}', CURRENT_TIMESTAMP, 'Cheque', 'Withdraw', {amountFormated}, '{username}', '{target}'); INSERT INTO trandetails(acnumber, dot, medium_of_transaction, transaction_type, transaction_amount, money_from, money_end) VALUES('{targetAccountNumber}', CURRENT_TIMESTAMP, 'Cheque', 'Deposit', {amountFormated}, '{username}', '{target}');", connection);
                                setNewTransaction.ExecuteNonQuery();

                                #endregion

                                #region Update UI
                                labelBalance.Text = balance.ToString();
                                listboxTransactionsRefresh();

                                comboBox1.SelectedIndex = 0;
                                #endregion
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

        private void listboxTransactionsRefresh()
        {
            #region show recent transactions
            listBoxTransactions.Items.Clear();
            MySqlDataReader reader = null;
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

        private void buttonTakeLoan_Click(object sender, EventArgs e)
        {
            balance += 1000;   
            MySqlCommand setUserBalance = new MySqlCommand($"UPDATE account SET opening_balance = {balance} WHERE acnumber = '{acnumber}'; ");
            setUserBalance.ExecuteNonQuery();

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

    }
}
