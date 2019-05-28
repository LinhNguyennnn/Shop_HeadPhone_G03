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
            try
            {
                DbHelper.OpenConnection();
            }
            catch (System.Exception)
            {
                return null;
            }
            query = $"select * from Items where Produce_Code = " + _code + ";";
            reader = DbHelper.ExecQuery(query);
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
            try
            {
                DbHelper.OpenConnection();
            }
            catch
            {
                return null;
            }
            query = $"select * from Items where Produce_Code = " + _code + " and Trademark = '" + Attribute + "';";
            reader = DbHelper.ExecQuery(query);
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
            try
            {
                DbHelper.OpenConnection();
            }
            catch
            {
                return null;
            }
            query = $"select * from Items where Produce_Code = " + _code + " and Trademark = '" + TradeMark + "';";
            reader = DbHelper.ExecQuery(query);
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
            try
            {
                DbHelper.OpenConnection();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            query = $"select * from Items;";
            List<Items> items = null;
            reader = DbHelper.ExecQuery(query);
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
            try
            {
                DbHelper.OpenConnection();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            query = $"select * from Items where Trademark = '" + tradeMark + "';";
            reader = DbHelper.ExecQuery(query);
            List<Items> items = null;
            items = new List<Items>();
            while (reader.Read())
            {
                items.Add(GetItems(reader));
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
            try
            {
                DbHelper.OpenConnection();
            }
            catch (System.Exception)
            {
                return null;
            }
            query = $"select * from Items where Attribute = '" + attribute + "';";
            reader = DbHelper.ExecQuery(query);
            List<Items> items = null;
            items = new List<Items>();
            while (reader.Read())
            {
                items.Add(GetItems(reader));
            }
            DbHelper.CloseConnection();
            return items;
        }
        public Items GetItems(MySqlDataReader reader)
        {
            Items items = new Items();
            items.Produce_Code = reader.GetInt16("Produce_Code");
            items.Item_Name = reader.GetString("Item_Name");
            items.Trademark = reader.GetString("Trademark");
            items.Attribute = reader.GetString("Attribute");
            items.Item_Price = reader.GetDecimal("Item_Price");
            items.Item_Description = reader.GetString("Item_Description");

            return items;
        }
    }
}