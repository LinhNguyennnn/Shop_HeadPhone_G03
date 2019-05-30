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
<<<<<<< HEAD
        // [Fact]
        // public void GetItemByProduceCodeTest1()
        // {
        //     Assert.NotNull(OBL.CreateOrder());
        // }
        // Test Delete Order
        // [Theory]
        // [InlineData(0)]
        // [InlineData(1)]
        // [InlineData(2)]
        // public void DeleteOrder(Oid)
        // {
        //     Assert.Null(OBL.DeleteOrder(Oid));
        // }
=======
        [Fact]
        public void CreateOrder()
        {
            Order order = new Order();
            order.Customer = new Customers();
            order.Order_Date = DateTime.Now;
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

        // Test GetOrderByCustomerId
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetOrderByCustomerId(int id)
        {
            Assert.NotNull(OBL.GetOrderByCustomerId(id));
        }

        // Test DeleteOrder
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void DeleteOrder(int? id)
        {
            Assert.True(OBL.DeleteOrder(id));
        }

        // Test UpdateStatus
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void UpdateStatus(int? id)
        {
            Assert.False(OBL.UpdateStatus(id));
        }
>>>>>>> 01e642e8a83ffff67b13a69ca49ed7df4520a880
    }
}