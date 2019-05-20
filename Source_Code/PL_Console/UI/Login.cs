using System;

namespace UI
{
    class Login : Menu
    {
        public void ScreenLogin()
        {
            Console.Clear();
            Console.WriteLine("======================================= \n");
            Console.WriteLine("Vui Lòng Điền Thông Tin");
            Console.WriteLine("Email: ");
            Console.ReadLine();
            Console.WriteLine("Password: ");
            Console.ReadLine();
            Console.WriteLine("0. Thoát");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("bạn đã nhập sai");
                    Console.WriteLine("#chọn: ");
                }
                else if (number < 0 || number > 0)
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
                    menu();
                    break;
            }
        }
    }
}