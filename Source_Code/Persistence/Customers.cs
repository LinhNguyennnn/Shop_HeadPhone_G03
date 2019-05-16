using System;

namespace Persistence
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

        // public Customers(int id, string name, string birth, string address, string email, string phone, string username, string password)
        // {
        //     this.Cus_ID = id;

        //     this.Cus_Name = name;

        //     this.Cus_DateBirth = birth;

        //     this.Cus_Address = address;

        //     this.Cus_Email = email;

        //     this.Cus_Phone_Numbers = phone;

        //     this.User_Name = username;

        //     this.User_Password = password;
        // }
        public Customers(string username, string password)
        {
            this.User_Name = username;
            this.User_Password = password;
        }
    }
}