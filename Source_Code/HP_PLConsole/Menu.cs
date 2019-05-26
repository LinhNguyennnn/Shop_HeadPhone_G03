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
            string[] choice = { "Đăng nhập", "Thoát" };
            int number = SubMenu("Chào mừng đến với cửa hàng tai nghe", choice);
            switch (number)
            {
                case 1:
                    User U = new User();
                    U.ScreenLogin();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}