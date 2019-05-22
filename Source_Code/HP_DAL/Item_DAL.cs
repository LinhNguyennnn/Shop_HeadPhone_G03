using System;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using HP_Persistence;
using System.Collections.Generic;

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

        public Items GetItemByProduceCode(int? _code)
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
        public List<Items> GetAllItems()
        {
            if (connection == null)
            {
                connection = DbHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $"select Produce_Code, Item_Name, Trademark, Attribute, Item_Price from Items;";
            MySqlCommand command = new MySqlCommand(query, connection);
            List<Items> items = null;
            using (reader = command.ExecuteReader())
            {
                items = new List<Items>();
                while (reader.Read())
                {
                    items.Add(GetItems(reader));
                }
            }
            connection.Close();
            return items;
        }
        public List<Items> GetItemByTradeMark(string tradeMark)
        {
            if (tradeMark == null)
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
            query = $"select Produce_Code, Item_Name, Trademark, Attribute, Item_Price from Items where TradeMark = " + tradeMark + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            List<Items> items = null;
            using (reader = command.ExecuteReader())
            {
                items = new List<Items>();
                while (reader.Read())
                {
                    items.Add(GetItems(reader));
                }
            }
            connection.Close();
            return items;
        }

        public List<Items> GetItemByAttribute(string attribute)
        {
            if (attribute == null)
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
            query = $"select Produce_Code, Item_Name, Trademark, Attribute, Item_Price from Items where Attribute = " + attribute + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            List<Items> items = null;
            using (reader = command.ExecuteReader())
            {
                items = new List<Items>();
                while (reader.Read())
                {
                    items.Add(GetItems(reader));
                }
            }
            connection.Close();
            return items;
        }
        public ItemsDetail GetItemsDetails(MySqlDataReader reader)
        {
            int _code = reader.GetInt16("Produce_Code");
            string _name = reader.GetString("Item_Name");
            string _trade = reader.GetString("Trademark");
            string _attribute = reader.GetString("Attribute");
            string _price = reader.GetString("Item_Price");
            string _description = reader.GetString("Item_Description");
            string _quantity = reader.GetString("Quantity");
            ItemsDetail itemsDetail = new ItemsDetail(_code, _name, _trade, _attribute, _price, _description, _quantity);
            return itemsDetail;
        }
        public Items GetItems(MySqlDataReader reader)
        {
            int _code = reader.GetInt16("Produce_Code");
            string _name = reader.GetString("Item_Name");
            string _trade = reader.GetString("Trademark");
            string _attribute = reader.GetString("Attribute");
            string _price = reader.GetString("Item_Price");
            Items items = new Items(_code, _name, _trade, _attribute, _price);
            return items;
        }
    }
}