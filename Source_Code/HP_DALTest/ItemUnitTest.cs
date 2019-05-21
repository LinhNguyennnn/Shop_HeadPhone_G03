using System;
using Xunit;
using HP_DAL;
using HP_Persistence;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HP_DALTest
{
    public class ItemUnitTest
    {
        private Item_DAL itemDAL = new Item_DAL();
        private MySqlConnection connection = DbHelper.OpenConnection();
        private MySqlDataReader reader;
        private string query;

        [Fact]
        public void GetItemByProduceCodeTest1()
        {
            Items item = itemDAL.GetItemByProduceCode(1);

            Assert.NotNull(item);
            Assert.Equal(1, item.Produce_Code);
        }

        [Fact]
        public void GetItemByProduceCodeTest2()
        {
            Assert.Null(itemDAL.GetItemByProduceCode(0));
        }

        [Fact]
        public Items GetItemExecQuery(string query)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand(query, connection);
            Items item = null;
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    item = itemDAL.GetItems(reader);
                }
            }
            connection.Close();
            return item;
        }
    }
}