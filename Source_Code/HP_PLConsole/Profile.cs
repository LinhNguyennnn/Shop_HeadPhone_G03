using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;

namespace HP_PLConsole
{
    public class Profile
    {
        Customers Customer = new Customers();
        public void CustomerProfile()
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("------------------------ THÔNG TIN CÁ NHÂN --------------------------");
            Customer_BL CusBL = new Customer_BL();
            Customers Customers = CusBL.GetProfileCus(Customer.User_Name);
            Console.WriteLine("Tên khách hàng: ", Customers.Cus_Name);
            Console.WriteLine("Ngày sinh:  ", Customer.Cus_DateBirth);
            Console.WriteLine("Địa chỉ: ", Customer.Cus_Address);
            Console.WriteLine("Email: ", Customer.Cus_Email);
            Console.WriteLine("Số điện thoại: ", Customer.Cus_Phone_Numbers);

            Console.ReadKey();
        }
    }
}