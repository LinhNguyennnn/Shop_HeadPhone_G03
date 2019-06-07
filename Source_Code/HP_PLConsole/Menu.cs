<<<<<<< HEAD
using System;    
=======
using System;
using HP_Persistence;
>>>>>>> d2b757ba1feff1c3ff8df4f4f7ca9a4499248b13

namespace HP_PLConsole
{
    public class Menu
    {
        public void menu()
        {
            Product Product = new Product();
            Customers Cus = new Customers();
            User U = new User();
            Console.Clear();
            string[] choice = { "Danh sách sản phẩm", "Xem giỏ hàng", "Đăng nhập", "Thoát" };
            int number = Product.SubMenu($"Chào mừng đến với cửa hàng", choice);
            switch (number)
            {
                case 1:
                    Product.DisplayProduct(Cus);
                    break;
                case 2:
                    U.DisplayCart(Cus);
                    break;
                case 3:
                    U.ScreenLogin();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}