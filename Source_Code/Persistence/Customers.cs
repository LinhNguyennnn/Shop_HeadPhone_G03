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
}