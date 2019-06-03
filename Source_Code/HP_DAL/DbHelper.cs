using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace HP_DAL
{
    public class DbHelper
    {
        private static MySqlConnection connection;
        private static string connection_String;
        public static MySqlConnection OpenConnection()
        {
            try
            {
                if (connection_String == null)
                {
                    using (FileStream fileStream = File.OpenRead("ConnectionString.txt"))
                    {
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            connection_String = reader.ReadLine();
                        }
                    }
                }
                return OpenConnection(connection_String);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static MySqlConnection OpenConnection(string connection_String)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connection_String
                };
                connection.Open();
                return connection;
            }
            catch (System.Exception)
            {
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
        public static MySqlDataReader ExecQuery(string query, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}