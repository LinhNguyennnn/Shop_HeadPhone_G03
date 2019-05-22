using System;
using System.Text.RegularExpressions;
using HP_Persistence;
using MySql.Data.MySqlClient;

namespace HP_DAL
{
    public class Customer_DAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;
        public Customer_DAL()
        {
            connection = DbHelper.OpenConnection();
        }

        public Customers Login(string username, string password)
        {
            if ((username == null) || (password == null))
            {
                return null;
            }
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection MatchCollectionUsername = regex.Matches(username);
            MatchCollection MatchCollectionPassword = regex.Matches(password);
            if (MatchCollectionUsername.Count < username.Length || MatchCollectionPassword.Count < password.Length)
            {
                return null;
            }
            try
            {
                if (connection == null)
                {
                    connection = DbHelper.OpenConnection();
                }
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            query = @"select * from Customers where User_Name = '" + username + "' and User_Password = '" + password + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Customers customer = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    customer = GetCustomer(reader);
                }
            }
            connection.Close();
            return customer;
        }
        private Customers GetCustomer(MySqlDataReader reader)
        {
            string username = reader.GetString("User_Name");
            string password = reader.GetString("User_Password");
            string name = reader.GetString("Cus_Name");
            DateTime datebirth = reader.GetDateTime("Cus_DateBirth");
            string address = reader.GetString("Cus_Address");
            string email = reader.GetString("Cus_Email");
            string phone = reader.GetString("Cus_Phone_Numbers");
            int id = reader.GetInt16("Cus_ID");
            Order order = new Order(null, null, null, null, null);

            Customers customer = new Customers(id, name, datebirth, address, email, phone, username, password, order);
            return customer;
        }
    }
}