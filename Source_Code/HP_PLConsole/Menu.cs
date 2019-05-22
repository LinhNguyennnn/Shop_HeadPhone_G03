using System;

namespace HP_PLConsole
{
    public class Menu
    {
        public void menu(string a)
        {
            Console.Clear();
            if (a != null)
            {
                Console.WriteLine(a);
            }
            int number;
            Console.WriteLine("--- Chào mừng đến với cửa hàng tai nghe --- \n");
            Console.WriteLine("=========================================== \n");
            Console.WriteLine("1. Menu sản phẩm");
            Console.WriteLine("2. Đăng nhập");
            Console.WriteLine("0. Thoát \n");
            Console.Write("#chọn: ");

            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.Write("#Chọn: ");
                }
                else if (number < 0 || number > 2)
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
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Product p = new Product();
                    p.DisplayProduct(null);
                    break;
                case 2:
                    Login L = new Login();
                    L.ScreenLogin();
                    break;
            }
        }
    }
}