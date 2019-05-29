using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace HP_DAL
{
    public class DbHelper
    {
        private static MySqlConnection connection;
        public static MySqlConnection OpenConnection()
        {
            try
            {
                string connection_String;
                FileStream fileStream = File.OpenRead("ConnectionString.txt");
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    connection_String = reader.ReadLine();
                }
                fileStream.Close();
                connection = new MySqlConnection
                {
                    ConnectionString = connection_String
                };
                connection.Open();
                return connection;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        public static MySqlDataReader ExecQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}