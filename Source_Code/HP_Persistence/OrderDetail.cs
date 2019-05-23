using System;

namespace HP_Persistence
{
    public class OrderDetail
    {
        public int? Order_ID { get; set; }
        public int Produce_Code { get; set; }
        public int? Order_Count { get; set; }
        public Items Item { get; set; }

        public OrderDetail() { }
        public OrderDetail(int? order_id, int produce_code, int? order_count, Items item)
        {
            this.Order_ID = order_id;
            this.Produce_Code = produce_code;
            this.Order_Count = order_count;
            this.Item = item;
        }
    }
}