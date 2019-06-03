using System;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using HP_Persistence;
using System.Collections.Generic;

namespace HP_DAL
{
    public class Item_DAL
    {
        private MySqlDataReader reader;
        private string query;

        public Items GetItemByProduceCode(int? _code)
        {
            if (_code == null)
            {
                return null;
            }
            query = $"select * from Items where Produce_Code = " + _code + ";";
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            Items item = null;
            if (reader.Read())
            {
                item = GetItems(reader);
            }
            DbHelper.CloseConnection();
            return item;
        }
        public Items GetItemByProduceCodeAndAttribute(int? _code, string Attribute)
        {
            if (_code == null)
            {
                return null;
            }
            query = $"select * from Items where Produce_Code = " + _code + " and Attribute = '" + Attribute + "';";
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            Items item = null;
            if (reader.Read())
            {
                item = GetItems(reader);
            }
            DbHelper.CloseConnection();
            return item;
        }
        public Items GetItemByProduceCodeAndTradeMark(int? _code, string TradeMark)
        {
            if (_code == null)
            {
                return null;
            }
            query = $"select * from Items where Produce_Code = " + _code + " and Trademark = '" + TradeMark + "';";
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            Items item = null;
            if (reader.Read())
            {
                item = GetItems(reader);
            }
            DbHelper.CloseConnection();
            return item;
        }
        public List<Items> GetAllItems()
        {
            query = $"select * from Items;";
            List<Items> items = null;
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            items = new List<Items>();
            while (reader.Read())
            {
                items.Add(GetItems(reader));
            }
            DbHelper.CloseConnection();
            return items;
        }
        public List<Items> GetItemByTradeMark(string tradeMark)
        {
            if (tradeMark == null)
            {
                return null;
            }
            query = @"select * from Items where Trademark = '" + tradeMark + "';";
            List<Items> items = null;
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            items = new List<Items>();
           
            while (reader.Read())
            {
                items.Add(GetItems(reader));
            }
             if (items.Count <= 0)
            {
                return null;
            }
            DbHelper.CloseConnection();
            return items;
        }

        public List<Items> GetItemByAttribute(string attribute)
        {
            if (attribute == null)
            {
                return null;
            }
            query = $"select * from Items where Attribute = '" + attribute + "';";
            List<Items> items = null;
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            items = new List<Items>();
           
            while (reader.Read())
            {
                items.Add(GetItems(reader));
            }
             if (items.Count <= 0)
            {
                return null;
            }
            DbHelper.CloseConnection();
            return items;
        }
        public Items GetItems(MySqlDataReader reader)
        {
            Items items = new Items();
            items.Produce_Code = reader.GetInt32("Produce_Code");
            items.Item_Name = reader.GetString("Item_Name");
            items.Trademark = reader.GetString("Trademark");
            items.Attribute = reader.GetString("Attribute");
            items.Item_Price = reader.GetInt32("Item_Price");
            items.Item_Description = reader.GetString("Item_Description");

            return items;
        }
    }
}