using System;
using Xunit;
using HP_DAL;
using HP_Persistence;
using System.Collections.Generic;

namespace HP_DALTest
{
    public class OrderUnitTest
    {
        Order_DAL ODAL = new Order_DAL();

        // Test CreateOrder
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
            Assert.True(ODAL.CreateOrder(order));
        }

        // Test GetOrderByCustomerId
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetOrderByCustomerId(int id)
        {
            Assert.NotNull(ODAL.GetOrderByCustomerId(id));
        }

        // Test DeleteOrder
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void DeleteOrder(int? id)
        {
            Assert.True(ODAL.DeleteOrder(id));
        }

        // Test UpdateStatusOrder
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void UpdateStatusOrder(int? id)
        {
            Assert.False(ODAL.UpdateStatusOrder(id));
        }
    }
}