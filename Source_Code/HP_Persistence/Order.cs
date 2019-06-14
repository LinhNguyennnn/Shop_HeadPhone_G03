using System;
using System.Collections.Generic;

namespace HP_Persistence
{
    public class Order
    {
        public int? Order_ID { get; set; }
        public DateTime Order_Date { get; set; }
        public Customers Customer { get; set; }
        public string Status { get; set; }
        public string Address_Shipping { get; set; }

        public List<Items> ItemsList { get; set; }
        public Order() { }

        public Order(int? order_id, string address_Shipping, DateTime order_date, string status, List<Items> itemsList)
        {
            this.Order_ID = order_id;
            this.Order_Date = order_date;
            this.Address_Shipping = address_Shipping;
            this.ItemsList = itemsList;
            this.Status = status;
        }
        public override bool Equals(object obj)
        {
            return obj is Order order && Order_ID == order.Order_ID;
        }

        public override int GetHashCode()
        {
            return (Order_ID + Status + Customer + Address_Shipping + Order_Date + ItemsList).GetHashCode();
        }
    }
}