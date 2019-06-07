using System;
using System.Collections.Generic;
using HP_DAL;
using HP_Persistence;

namespace HP_BL
{
    public class Order_BL
    {
        Order_DAL ODAL = new Order_DAL();
        public bool CreateOrder(Order order)
        {
            return ODAL.CreateOrder(order);
        }
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            List<Order> listOrders = ODAL.GetOrderByCustomerId(customerId);

            return listOrders;
        }
        public Order GetOrderDetailsByOrderId(int? orderID)
        {
            return ODAL.GetOrderDetailByOrderID(orderID);
        }
        public bool DeleteOrder(int? orderId)
        {
            return ODAL.DeleteOrder(orderId);
        }
        public bool UpdateStatus(int? orderId)
        {
            return ODAL.UpdateStatusOrder(orderId);
        }
    }
}