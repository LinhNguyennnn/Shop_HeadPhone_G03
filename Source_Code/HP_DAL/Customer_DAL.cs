using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HP_Persistence;
using MySql.Data.MySqlClient;

namespace HP_DAL
{
    public class Customer_DAL
    {
        private MySqlDataReader reader;
        private string query;
        public Customers Login(string username, string password)
        {
            if ((username == null) || (password == null))
            {
                return null;
            }
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(username);
            MatchCollection matchCollectionPassword = regex.Matches(password);
            if (matchCollectionUsername.Count < username.Length || matchCollectionPassword.Count < password.Length)
            {
                return null;
            }
            query = $"select * from Customers where User_Name = '" + username + "' and User_Password = '" + password + "';";
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            Customers customer = null;
            if (reader.Read())
            {
                customer = GetCustomer(reader);
            }
            DbHelper.CloseConnection();
            return customer;
        }
        private Customers GetCustomer(MySqlDataReader reader)
        {
            Customers customer = new Customers();
            customer.User_Name = reader.GetString("User_Name");
            customer.User_Password = reader.GetString("User_Password");
            customer.Cus_Name = reader.GetString("Cus_Name");
            customer.Cus_DateBirth = reader.GetDateTime("Cus_DateBirth");
            customer.Cus_Address = reader.GetString("Cus_Address");
            customer.Cus_Email = reader.GetString("Cus_Email");
            customer.Cus_Phone_Numbers = reader.GetString("Cus_Phone_Numbers");
            customer.Cus_ID = reader.GetInt16("Cus_ID");

            return customer;
        }
    }
}