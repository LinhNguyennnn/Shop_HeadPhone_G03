using System;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using HP_Persistence;

namespace HP_DAL
{
    public class Item_DAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        public Item_DAL()
        {
            connection = DbHelper.OpenConnection();
        }

        public Items GetItems(string _code)
        {
            if (_code == null)
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
            query = $"select * from Items where Produce_Code = " + _code + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            Items item = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    item = GetItems(reader);
                }
            }
            connection.Close();
            return item;
        }
        public Items GetItems(MySqlDataReader reader)
        {
            string _code = reader.GetString("Produce_Code");
            string _name = reader.GetString("Item_Name");
            string _trade = reader.GetString("Trademark");
            string _attribute = reader.GetString("Attribute");
            string _price = reader.GetString("Item_Price");
            string _description = reader.GetString("Item_Description");
            string _quantity = reader.GetString("Quantity");
            Items items = new Items(_code, _name, _trade, _attribute, _price, _description, _quantity);
            return items;
        }
    }
}