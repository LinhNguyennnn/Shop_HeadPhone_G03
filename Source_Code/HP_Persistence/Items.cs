using System;

namespace HP_Persistence
{
    public class Items
    {
        public int Produce_Code { get; set; }

        public string Item_Name { get; set; }

        public string Trademark { get; set; }

        public string Attribute { get; set; }

        public string Item_Price { get; set; }

        public string Item_Description { get; set; }

        public string Quantity { get; set; }

        public Items() { }

        public Items(int _code, string _name, string _trade, string _attribute, string _price, string _description, string _quantity)
        {
            this.Produce_Code = _code;

            this.Item_Name = _name;

            this.Trademark = _trade;

            this.Attribute = _attribute;

            this.Item_Price = _price;

            this.Item_Description = _description;

            this.Quantity = _quantity;
        }
    }
}