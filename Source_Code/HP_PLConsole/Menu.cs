using System;

namespace HP_PLConsole
{
    public class Menu : Product
    {
        public void menu(string a)
        {
            Console.Clear();
            if (a != null)
            {
                Console.WriteLine(a);
            }
            string[] choice = { "Menu sản phẩm", "Đăng nhập", "Thoát" };
            int number = SubMenu("Chào mừng đến với cửa hàng tai nghe", choice);
            switch (number)
            {
                case 3:
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