using System;
using System.Collections.Generic;

namespace HP_Persistence
{
    public class Order
    {
        public int? Order_ID { get; set; }
        public DateTime? Order_Date { get; set; }
        public Customers OrderCustomer { set; get; }
        public string Order_Note { get; set; }

        public List<Items> ListItems { get; set; }

        public Order()
        {
        }
        public Order(int? order_id, DateTime? order_date, string order_note, List<Items> listItems)
        {
            this.Order_ID = order_id;
            this.Order_Date = order_date;
            this.Order_Note = order_note;
            this.ListItems = listItems;
        }
    }
}