using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
using Newtonsoft.Json;

namespace HP_PLConsole
{
    class Login : Product
    {
        public void ScreenLogin()
        {
            Menu MN = new Menu();
            Customer_BL CusBL = new Customer_BL();
            Customers Cus = new Customers();
            string Un = null;
            string Pw = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================= \n");
                Console.WriteLine("ĐĂNG NHẬP\n");
                Console.Write("Tên đăng nhập: ");
                Un = Console.ReadLine().Trim();
                Console.Write("Mật khẩu: ");
                Pw = Password().Trim();
                string select;

                if ((Validate(Un) == false) || (Validate(Pw) == false))
                {
                    Console.Write("Tên đăng nhập hoặc mật khẩu không được chứa kí tự đặc biệt\nBạn có muốn nhập lại không? (Y/N): ");
                    select = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (select != "Y" && select != "N")
                        {
                            Console.Write("Bạn có muốn nhập lại không? (Y/N): ");
                            select = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }

                    switch (select)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MN.menu(null);
                            break;
                        case "n":
                            MN.menu(null);
                            break;
                        default:
                            continue;
                    }
                }
                try
                {
                    Cus = CusBL.Login(Un, Pw);
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("Mất kết nối!");
                    Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                    select = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (select != "Y" && select != "N")
                        {
                            Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                            select = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (select)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MN.menu(null);
                            break;
                        case "n":
                            MN.menu(null);
                            break;
                        default:
                            continue;
                    }
                }
                if (Cus == null)
                {
                    Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng!");
                    Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                    select = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (select != "Y" && select != "N")
                        {
                            Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                            select = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (select)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MN.menu(null);
                            break;
                        case "n":
                            MN.menu(null);
                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        string[] choice = { "Menu sản phẩm", "Thông tin cá nhân", "Xem giỏ hàng", "Đăng xuất" };
                        int number = SubMenu(null, choice);
                        switch (number)
                        {
                            case 1:
                                DisplayProduct(Cus);
                                break;
                            case 2:
                                CustomerProfile(Un, Pw);
                                break;
                            case 3:
                                DisplayCart();
                                break;
                            case 4:
                                Console.Clear();
                                MN.menu(null);
                                break;
                        }
                    }
                }
            }
        }
        public bool Validate(string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionstr = regex.Matches(str);
            if (matchCollectionstr.Count < str.Length)
            {
                return false;
            }
            return true;
        }
        public string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo CKI = Console.ReadKey(true);
                if (CKI.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (CKI.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write("*");
                sb.Append(CKI.KeyChar);
            }
            return sb.ToString();
        }
        public void CustomerProfile(string username, string password)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("------------------------ THÔNG TIN CÁ NHÂN --------------------------");
                Customer_BL CusBL = new Customer_BL();
                Customers Cus = new Customers();
                try
                {
                    Cus = CusBL.Login(username, password);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Mất kết nối!");
                }
                Console.WriteLine("\nTên khách hàng: {0}", Cus.Cus_Name);
                Console.WriteLine("Ngày sinh: {0}", Cus.Cus_DateBirth.ToString("dd/MM/yyyy"));
                Console.WriteLine("Địa chỉ: {0}", Cus.Cus_Address);
                Console.WriteLine("Email: {0}", Cus.Cus_Email);
                Console.WriteLine("Số điện thoại: {0}", Cus.Cus_Phone_Numbers);

                Console.Write("\nNhấn phím bất kỳ để quay lại!");
                Console.ReadKey();
                break;
            }
        }
        public void AddToCart(Items item, Customers Cus)
        {
            List<Items> ListItems = new List<Items>();
            ListItems.Add(item);
            string sJSONReponse = JsonConvert.SerializeObject(ListItems);
            BinaryWriter bw;
            string fileName = $"CartOf{Cus.User_Name}.dat";
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write((string)(object)sJSONReponse);
                fs.Close();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Không thêm được sản phẩm vào giỏ hàng!");
            }
            Console.WriteLine("Đã thêm vào giỏ hàng!");
            while (true)
            {
                string[] choice = { "Xem giỏ hàng", "Menu sản phẩm" };
                int number = SubMenu(null, choice);
                switch (number)
                {
                    case 2:
                        DisplayProduct(Cus);
                        break;
                    case 1:
                        DisplayCart();
                        break;
                }
            }
        }
    }
}