using System;
using Xunit;
using HP_BL;

namespace HP_BL_Test
{
    public class ItemUnitTest
    {
        Item_BL IBL = new Item_BL();
        [Fact]
        public void GetItemByProduceCodeTest1()
        {
            Assert.NotNull(IBL.GetItemByProduceCode(1));
        }
        [Fact]
        public void GetItemByProduceCodeTest2()
        {
            Assert.Null(IBL.GetItemByProduceCode(0));
        }
        public void GetItemByProduceCodeTest3()
        {
            Assert.Null(IBL.GetItemByProduceCode(null));
        }
    }
}