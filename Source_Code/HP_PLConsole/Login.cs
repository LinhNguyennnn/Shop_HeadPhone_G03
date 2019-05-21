using System;
using System.Text;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
namespace HP_PLConsole
{
    class Login : Menu
    {
        public void ScreenLogin()
        {
            Customer_BL CusBL = new Customer_BL();
            Customers Cus = null;
            Product Product = new Product();
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

                try
                {
                    Cus = CusBL.Login(Un, Pw);
                }
                catch (System.Exception)
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
                            menu();
                            break;
                        case "n":
                            menu();
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
                            menu();
                            break;
                        case "n":
                            menu();
                            break;
                        default:
                            continue;
                    }
                }
                break;
            }
            if(Cus != null)
            {
                Product.DisplayProduct();
            }
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
    }
}