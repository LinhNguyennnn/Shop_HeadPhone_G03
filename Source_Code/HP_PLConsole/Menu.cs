using System;    

namespace HP_PLConsole
{
<<<<<<< HEAD
    class Menu
=======
    public class Menu
>>>>>>> 4462d4cf82509d589c0cd4ac7e0c49986bb728e0
    {
        public void menu()
        {
            int number;
            Console.WriteLine("--- Chào mừng đến với cửa hàng tai nghe --- \n");
            Console.WriteLine("======================================= \n");
            Console.WriteLine("1. Menu sản phẩm");
            Console.WriteLine("2. Đăng nhập");
            Console.WriteLine("0. Thoát \n");
            Console.Write("#chọn: ");

            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("bạn đã nhập sai");
                    Console.WriteLine("#chọn: ");
                }
                else if (number < 0 || number > 2)
                {
                    Console.WriteLine("bạn đã nhập sai");
                    Console.WriteLine("#chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    break;
                case 1:
                    Product p = new Product();
                    p.DisplayProduct();
                    break;
                case 2:
                    Login L = new Login();
                    L.ScreenLogin();
                    break;
            }
        }
    }
}