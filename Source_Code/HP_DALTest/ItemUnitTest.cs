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
        Item_DAL IDAL = new Item_DAL();
        [Fact]
        public void GetAllItems()
        {
            Assert.NotNull(IDAL.GetAllItems());
        }
        // Test GetItemByProduceCode
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetItemByProduceCode(int id)
        {
            Assert.NotNull(IDAL.GetItemByProduceCode(id));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void GetItemByProduceCode2(int id)
        {
            Assert.Null(IDAL.GetItemByProduceCode(id));
        }
        // Test GetItemByAttribute
        [Theory]
        [InlineData("Thể thao")]
        [InlineData("In-Ear")]
        public void GetItemByAttribute(string attribute)
        {
            Assert.NotNull(IDAL.GetItemByAttribute(attribute));
        }
        [Theory]
        [InlineData("abc123")]
        [InlineData("bdefg")]
        public void GetItemByAttribute2(string attribute)
        {
            Assert.Null(IDAL.GetItemByAttribute(attribute));
        }
        // Test GetItemByTradeMark
        [Theory]
        [InlineData("Urbanista")]
        [InlineData("MEE")]
        public void GetItemByTradeMark(string Trade)
        {
            Assert.NotNull(IDAL.GetItemByTradeMark(Trade));
        }
        [Theory]
        [InlineData("@#!!@#")]
        [InlineData("d")]
        public void GetItemByTradeMark2(string Trade)
        {
            Assert.Null(IDAL.GetItemByTradeMark(Trade));
        }
        // Test GetItemByProduceCodeAndAttribute
        [Theory]
        [InlineData(1, "Không dây")]
        [InlineData(2, "Thể thao")]
        public void GetItemByProduceCodeAndAttribute(int id, string att)
        {
            Assert.NotNull(IDAL.GetItemByProduceCodeAndAttribute(id, att));
        }
        [Theory]
        [InlineData(100, "Headphone")]
        [InlineData(1000, "Gaming")]
        public void GetItemByProduceCodeAndAttribute2(int id, string att)
        {
            Assert.Null(IDAL.GetItemByProduceCodeAndAttribute(id, att));
        }
        // GetItemByProduceCodeAndTradeMark
        [Theory]
        [InlineData(1, "Urbanista")]
        [InlineData(2, "MEE")]
        public void GetItemByProduceCodeAndTradeMark(int id, string trade)
        {
            Assert.NotNull(IDAL.GetItemByProduceCodeAndTradeMark(id, trade));
        }
        [Theory]
        [InlineData(100, "In-Ear")]
        [InlineData(1000, "RHA AUDIO")]
        public void GetItemByProduceCodeAndTradeMark2(int id, string trade)
        {
            Assert.Null(IDAL.GetItemByProduceCodeAndTradeMark(id, trade));
        }
    }
}