using System;
using Xunit;
using HP_DAL;
using HP_Persistence;

namespace HP_DALTest
{
    public class OrderUnitTest
    {
        Order_DAL ODAL = new Order_DAL();
        // [Fact]
        // public void createOrder(Order order)
        // {
        //     Assert.True(ODAL.CreateOrder(order));
        // }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetOrderByCustomerId(int customerId)
        {
            Assert.NotNull(ODAL.GetOrderByCustomerId(customerId));
        }
    }
}