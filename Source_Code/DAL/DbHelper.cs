using System;
using System.Collections.Generic;
using System.IO;


namespace DAL
{
    public class DbHelper
    {
        private static string connection_String = "server=localhost;user id=root;password=Hanhphuc1;port=3306;database=headphone_shop_gr3;SslMode=None";
        public static MySqlConnection OpenDefaultConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connection_String
                };
                connection.open();
                return connection;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public static MySqlConnection OpenConnection()
        {
            try
            {
                string connectionString;
                FileStream fileStream = File.OpenRead("ConnectionString.txt");
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    connectionString = reader.ReadLine();
                }
                fileStream.Close();
                return OpenConnection(connectionString);
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public static MySqlConnection OpenConnection(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.open();
                return connection;
            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}
