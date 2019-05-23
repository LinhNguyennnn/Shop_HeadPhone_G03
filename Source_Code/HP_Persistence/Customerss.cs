using System;

namespace HP_Persistence
{
    public class Customerss
    {

        public string Cus_Name { get; set; }

        public DateTime Cus_DateBirth { get; set; }

        public string Cus_Address { get; set; }

        public string Cus_Email { get; set; }

        public string Cus_Phone_Numbers { get; set; }

        public Customerss() { }

        public Customerss( string name, DateTime datebirth, string address, string email, string phone)
        {

            this.Cus_Name = name;

            this.Cus_DateBirth = datebirth;

            this.Cus_Address = address;

            this.Cus_Email = email;

            this.Cus_Phone_Numbers = phone;

        }
    }
}