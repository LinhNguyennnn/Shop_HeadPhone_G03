using System;
using System.Collections.Generic;

namespace HP_Persistence
{
    public class Order
    {
        public int? Order_ID { get; set; }
        public int ItemId { get; set; }
        public DateTime Order_Date { get; set; }
        public int ItemCount { set; get; }
        public Customers Customer { get; set; }
        public string Status { get; set; }
        public string Address_Shipping { get; set; }
        public decimal Amount { set; get; }
        public string Order_Note { get; set; }

        public List<Items> ItemsList { get; set; }

        public Order() { }
        public Order(int? order_id,string address_Shipping, DateTime order_date, int itemId, string order_note, string status, List<Items> itemsList, int itemCount, decimal amount)
        {
            this.Order_ID = order_id;
            this.Order_Date = order_date;
            this.Address_Shipping = address_Shipping;
            this.Order_Note = order_note;
            this.ItemsList = itemsList;
            this.ItemCount = itemCount;
            this.Amount = amount;
            this.Status = status;
            this.ItemId = itemId;
        }
        public override bool Equals(object obj)
        {
            return obj is Order order && Order_ID == order.Order_ID;
        }

        public override int GetHashCode()
        {
            return (Order_ID + Status + Customer + Order_Note + Order_Date + ItemsList).GetHashCode();
        }
    }
}