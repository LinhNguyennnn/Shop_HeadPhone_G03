using System;
using System.Text.RegularExpressions;
using CTS_Persistence;
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
        public Customer Login(string )
    }
}