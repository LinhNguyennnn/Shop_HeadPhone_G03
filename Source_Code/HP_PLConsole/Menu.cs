using System;
using HP_Persistence;

namespace HP_PLConsole
{
    public class Menu
    {
        public void menu()
        {
            Product Product = new Product();
            Console.Clear();
            string[] choice = { "Xem danh sách sản phẩm","Đăng nhập", "Thoát" };
            int number = Product.SubMenu("Chào mừng đến với cửa hàng tai nghe", choice);
            switch (number)
            {
                case 1:
                    Customers Cus = new Customers();
                    Product.DisplayProduct(Cus);
                    break;
                case 2:
                    User U = new User();
                    U.ScreenLogin();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}