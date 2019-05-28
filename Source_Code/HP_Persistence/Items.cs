using System;

namespace HP_Persistence
{
    public class Items
    {
        public int Produce_Code { get; set; }

        public string Item_Name { get; set; }

        public string Trademark { get; set; }

        public string Attribute { get; set; }

        public int Item_Price { get; set; }
        public string Item_Description { get; set; }
        public int Quantity { get; set; }

        public Items() { }

        public Items(int _code, string _name, string _trade, string _attribute, int _price, string _Description, int _Quantity)
        {
            this.Produce_Code = _code;

            this.Item_Name = _name;

            this.Trademark = _trade;

            this.Attribute = _attribute;

            this.Item_Price = _price;

            this.Item_Description = _Description;
            
            this.Quantity = _Quantity;
        }
    }
}