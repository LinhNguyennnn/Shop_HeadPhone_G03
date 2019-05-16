using System;
using System.Text.RegularExpressions;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
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
<<<<<<< HEAD
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
            if (connection == null)
            {
                connection = DbHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select * from Customers where User_Name = '" + username + "' and Password = '" + password + "';";
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

            if(customer != null)
            {

            }
            return customer;
        }
        private Customers GetCustomer(MySqlDataReader reader)
        {
            string username = reader.GetString("User_Name");
            string password = reader.GetString("Password");

            Customers customer = new Customers(username, password);
            return customer;
        }
        
=======
        public Customer Login(string)
>>>>>>> 8364bd210270ce629cd015b4653e5bff3e64f25b
    }
}