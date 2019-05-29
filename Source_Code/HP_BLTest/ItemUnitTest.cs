using System;
using Xunit;
using HP_BL;

namespace HP_BLTest
{
    public class ItemUnitTest
    {
        Item_BL IBL = new Item_BL();
        [Fact]
        public void GetAllItems()
        {
            Assert.NotNull(IBL.GetAllItems());
        }
        // Test GetItemByProduceCode
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetItemByProduceCode(int id)
        {
            Assert.NotNull(IBL.GetItemByProduceCode(id));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        public void GetItemByProduceCode2(int id)
        {
            Assert.Null(IBL.GetItemByProduceCode(id));
        }
        // Test GetItemByAttribute
        [Theory]
        [InlineData("Thể thao")]
        [InlineData("In-Ear")]
        public void GetItemByAttribute(string attribute)
        {
            Assert.NotNull(IBL.GetItemByAttribute(attribute));
        }
        [Theory]
        [InlineData("abc123")]
        [InlineData("bdefg")]
        public void GetItemByAttribute2(string attribute)
        {
            Assert.Null(IBL.GetItemByAttribute(attribute));
        }
        // Test GetItemByTradeMark
        [Theory]
        [InlineData("Urbanista")]
        [InlineData("MEE")]
        public void GetItemByTradeMark(string Trade)
        {
            Assert.NotNull(IBL.GetItemByTradeMark(Trade));
        }
        [Theory]
        [InlineData("@#!!@#")]
        [InlineData("d")]
        public void GetItemByTradeMark2(string Trade)
        {
            Assert.Null(IBL.GetItemByTradeMark(Trade));
        }
        // Test GetItemByProduceCodeAndAttribute
        [Theory]
        [InlineData(1, "Không dây")]
        [InlineData(2, "Thể thao")]
        public void GetItemByProduceCodeAndAttribute(int id, string att)
        {
            Assert.NotNull(IBL.GetItemByProduceCodeAndAttribute(id, att));
        }
        [Theory]
        [InlineData(100, "Headphone")]
        [InlineData(1000, "Gaming")]
        public void GetItemByProduceCodeAndAttribute2(int id, string att)
        {
            Assert.Null(IBL.GetItemByProduceCodeAndAttribute(id, att));
        }
        // GetItemByProduceCodeAndTradeMark
        [Theory]
        [InlineData(1, "Urbanista")]
        [InlineData(2, "MEE")]
        public void GetItemByProduceCodeAndTradeMark(int id, string trade)
        {
            Assert.NotNull(IBL.GetItemByProduceCodeAndTradeMark(id, trade));
        }
        [Theory]
        [InlineData(100, "In-Ear")]
        [InlineData(1000, "RHA AUDIO")]
        public void GetItemByProduceCodeAndTradeMark2(int id, string trade)
        {
            Assert.Null(IBL.GetItemByProduceCodeAndTradeMark(id, trade));
        }
    }
}