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
        public string sqlBankString { get; set; }

        public Bank(string username, string password)
        {
            InitializeComponent();
            #region Credentials for AccountCheck

            string server = "157.90.11.126";
            string database = "fakebank";

            string id = $"{username}";
            string key = $"{password}";
            #endregion

            #region accountCheck
            sqlBankString = $"Server={server};Port=3306;SslMode=none;User Id={id};Password={key};Database={database}";

            connection = new MySqlConnection(sqlBankString);

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                MySqlDataReader myRowReader = null;
                MySqlCommand myRowCommand = new MySqlCommand("SELECT * FROM users", connection);
                myRowReader = myRowCommand.ExecuteReader();
                while (myRowReader.Read())
                {
                    string usernameL = (string)myRowReader["usernameL"];
                    //listBox1.Items.Add(myRowReader["usernameL"] + "\t" + myRowReader["username"] + "\t" + myRowReader["password"]);
                }
                myRowReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
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
