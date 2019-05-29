using System;
using Xunit;
using HP_BL;
using HP_Persistence;
using System.Collections.Generic;

namespace HP_BLTest
{
    public class OrderUnitTest
    {
        Order_BL OBL = new Order_BL();

        // Test Create Order 
        [Fact]
        public void Create_test()
        {
            Order order = new Order();
            order.Customer = new Customers();
            order.Order_ID = 1;
            order.Status = "OK";
            order.Customer.Cus_ID = 1;
            order.ItemsList = new List<Items>();
            Items item = new Items();
            item.Produce_Code = 1;
            item.Quantity = 2;
            order.ItemsList.Add(item);
            Assert.True(OBL.CreateOrder(order));
        }
        // Test Delete Order
        // [Theory]
        // [InlineData(0)]
        // [InlineData(1)]
        // [InlineData(2)]
        // public void Create_test()
        // {

        // }
    }
}