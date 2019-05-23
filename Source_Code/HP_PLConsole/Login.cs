using System;
using System.Text;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
namespace HP_PLConsole
{
    class Login
    {
        Menu MN = new Menu();
        public void ScreenLogin()
        {
            Customer_BL CusBL = new Customer_BL();
            Customers Cus = null;
            string Un = null;
            string Pw = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================= \n");
                Console.WriteLine("ĐĂNG NHẬP\n");
                Console.Write("Tên đăng nhập: ");
                Un = Console.ReadLine();
                Console.Write("Mật khẩu: ");
                Pw = Password();
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
                    Console.Clear();
                    int number;
                    Console.WriteLine("======================================= \n");
                    Console.WriteLine("1. Menu sản phẩm");
                    Console.WriteLine("2. Thông tin cá nhân");
                    Console.WriteLine("0. Đăng xuất");
                    Console.Write("#chọn: ");

                    while (true)
                    {
                        bool kt = Int32.TryParse(Console.ReadLine(), out number);
                        if (kt == false)
                        {
                            Console.WriteLine("Bạn đã nhập sai!");
                            Console.Write("#Chọn: ");
                        }
                        else if (number < 0 || number > 3)
                        {
                            Console.WriteLine("Bạn đã nhập sai!");
                            Console.Write("#Chọn: ");
                        }
                        else
                        {
                            break;
                        }
                    }

                    switch (number)
                    {
                        case 1:
                            Console.Clear();
                            Product product = new Product();
                            try
                            {
                                product.DisplayProduct(Cus);
                            }
                            catch (System.NullReferenceException)
                            {
                                MN.menu("Mất kết nối! \nMời bạn đăng nhập lại!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                MN.menu("Mất kết nối! \nMời bạn đăng nhập lại!");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            try
                            {
                                CustomerProfile(Un, Pw);
                            }
                            catch (System.NullReferenceException)
                            {
                                MN.menu("Mất kết nối! \nMời bạn đăng nhập lại!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                MN.menu("Mất kết nối! \nMời bạn đăng nhập lại!");
                            }
                            break;
                        case 0:
                            Console.Clear();
                            MN.menu(null);
                            break;
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

            Console.WriteLine("Tên khách hàng: {0}", Cus.User_Name);
            Console.WriteLine("Ngày sinh: {0}", Cus.Cus_DateBirth);
            Console.WriteLine("Địa chỉ: {0}", Cus.Cus_Address);
            Console.WriteLine("Email: {0}", Cus.Cus_Email);
            Console.WriteLine("Số điện thoại: {0}", Cus.Cus_Phone_Numbers);

            Console.ReadKey();
        }
    }
}