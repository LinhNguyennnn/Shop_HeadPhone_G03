using System;

namespace persistence
{
        public class Items
    {
        public string Produce_Code { get; set; }

        public string Item_Name { get; set; }

        public string Trademark { get; set; }

        public string Attribute { get; set; }

        public string Item_Price { get; set; }

        public string Item_Description { get; set; }

        public string Quantity { get; set; }

        public Items() { }

        public Items(string _code, string _name, string _trade, string _attribute, string _price, string _description, string _quantity)
        {
            Produce_Code = _code;

            Item_Name = _name;

            Trademark = _trade;

            Attribute = _attribute;

            Item_Price = _price;

            Item_Description = _description;

            Quantity = _quantity;
        }
    }
}