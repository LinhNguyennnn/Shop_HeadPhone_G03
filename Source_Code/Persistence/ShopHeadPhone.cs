using System;

namespace persistence
{

    public class Customers
    {
        public int Cus_ID { get; set; }

        public string Cus_Name { get; set; }

        public string Cus_DateBirth { get; set; }

        public string Cus_Address { get; set; }

        public string Cus_Email { get; set; }

        public string Cus_Phone_Numbers { get; set; }

        public string User_Name { get; set; }

        public string User_Password { get; set; }

        public Customers() { }

        public Customers(int id, string name, string birth, string address, string email, string phone, string Uname, string password)
        {
            Cus_ID = id;

            Cus_Name = name;

            Cus_DateBirth = birth;

            Cus_Address = address;

            Cus_Email = email;

            Cus_Phone_Numbers = phone;

            User_Name = Uname;

            User_Password = password;
        }
    }

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