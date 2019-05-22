using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
namespace HP_PLConsole
{
    public class Product
    {
        Menu MN = new Menu();
        Items item = new Items();
        Order order = new Order();
        ConsoleTable table = new ConsoleTable();
        public void DisplayProduct(Customers Cus)
        {
            Console.Clear();
            int number;
            Console.WriteLine("======================================= \n");
            Console.WriteLine("Menu sản phẩm");
            Console.WriteLine("1. Xem danh sách sản phẩm");
            Console.WriteLine("2. Xem danh sách sản phẩm theo hãng");
            Console.WriteLine("3. Xem danh sách sản phẩm theo loại sản phẩm");
            Console.WriteLine("0. Trở về MENU chính \n");
            Console.Write("#Chọn: ");

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
                case 0:
                    Login login = new Login();
                    login.MenuCustomer(Cus);
                    break;
                case 1:
                    DisplayAllItems(Cus);
                    break;
                case 2:
                    DisplayTradeMark(null);
                    break;
                case 3:
                    DisplayAttribute(Cus);
                    break;
            }
        }
        public int input(string str)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(str);
            while ((matchCollection.Count < str.Length) || (str == ""))
            {
                Console.Write("Dữ liệu nhập vào phải là số tự nhiên!\nMời bạn nhập lại: "); str = Console.ReadLine();
                matchCollection = regex.Matches(str);
            }
            return Convert.ToInt32(str);
        }
        public void DisplayAllItems(Customers Cus)
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("-------------------------DANH SÁCH SẢN PHẨM--------------------------");
            Console.WriteLine("1");
            Item_BL itemBL = new Item_BL();
            List<Items> items = itemBL.GetAllItems();
            Console.WriteLine("2");
            var table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            Console.WriteLine("3");
            foreach (var i in items)
            {
                Console.WriteLine("4");
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price);
            }
            Console.WriteLine("5");
            table.Write(Format.Alternative);
            Console.WriteLine("=====================================================================");
            Console.Write("\nChọn mã sản phẩm: ");
            order.ItemID = input(Console.ReadLine());
            while (itemBL.GetItemByProduceCode(order.ItemID) == null)
            {
                string a;
                while (true)
                {
                    Console.WriteLine("Mã sản phẩm không tồn tại!");
                    Console.WriteLine("Bạn có muốn nhập lại mã sản phẩm không? (Y/N): ");
                    a = Console.ReadLine().ToUpper();
                    if (a != "Y" || a != "y" || a != "N" || a != "n")
                    {
                        Console.WriteLine("Bạn đã nhập sai!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không? (Y/N): ");
                    }
                    else
                    {
                        break;
                    }
                }
                if (a == "Y" || a == "y")
                {
                    Console.Write("\nChọn mã sản phẩm: ");
                    order.ItemID = input(Console.ReadLine());
                }
            }
            item = itemBL.GetItemByProduceCode(order.ItemID);
        }
        public void DisplayTradeMark(Customers Cus)
        {
            Console.Clear();
            int number;
            Console.WriteLine("======================================= \n");
            Console.WriteLine("Danh sách sản phẩm theo hãng");
            Console.WriteLine("1. Urbanista");
            Console.WriteLine("2. MEE");
            Console.WriteLine("3. RHA AUDIO");
            Console.WriteLine("4. jabees");
            Console.WriteLine("5. SONY");
            Console.WriteLine("6. SOMIC");
            Console.WriteLine("7. Sennheiser");
            Console.WriteLine("8. Audio Technica");
            Console.WriteLine("9. Skullcandy");
            Console.WriteLine("10. Ausdom");
            Console.WriteLine("11. 1More");
            Console.WriteLine("0. Trở về menu sản phẩm \n");
            Console.Write("#chọn: ");

            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.Write("#Chọn: ");
                }
                else if (number < 0 || number > 11)
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
                    DisplayProduct(Cus);
                    break;
                case 1:
                    Urbanista();
                    break;
                case 2:
                    MEE();
                    break;
                case 3:
                    RHAAUDIO();
                    break;
                case 4:
                    jabees();
                    break;
                case 5:
                    SONY();
                    break;
                case 6:
                    SOMIC();
                    break;
                case 7:
                    Sennheiser();
                    break;
                case 8:
                    AudioTechnica();
                    break;
                case 9:
                    Skullcandy();
                    break;
                case 10:
                    Ausdom();
                    break;
                case 11:
                    More();
                    break;
            }
        }

        public void DisplayAttribute(Customers Cus)
        {
            Console.Clear();
            int number;
            Console.WriteLine("======================================= \n");
            Console.WriteLine("Danh sách sản phẩm theo phân loại sản phẩm");
            Console.WriteLine("1. Không dây");
            Console.WriteLine("2. Thể thao");
            Console.WriteLine("3. In-Ear");
            Console.WriteLine("4. Gaming");
            Console.WriteLine("5. Earbud");
            Console.WriteLine("0. Trở về menu sản phẩm \n");
            Console.Write("#Chọn: ");

            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.Write("#Chọn: ");
                }
                else if (number < 0 || number > 5)
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
                    DisplayProduct(Cus);
                    break;
                case 1:
                    Khongday();
                    break;
                case 2:
                    Thethao();
                    break;
                case 3:
                    InEar();
                    break;
                case 4:
                    Gaming();
                    break;
                case 5:
                    Earbud();
                    break;
            }
        }

        //=================== Hãng =====================//
        public void Urbanista()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            Console.WriteLine("0. Quay lại danh sách sản phẩm theo hãng \n");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.Write("#Chọn: ");
                }
                else if (number < 0 || number > 0)
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
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void MEE()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.Write("#Chọn: ");
                }
                else if (number < 0 || number > 0)
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
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void RHAAUDIO()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.Write("#Chọn: ");
                }
                else if (number < 0 || number > 0)
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
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void jabees()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void SONY()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void SOMIC()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void Sennheiser()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void AudioTechnica()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void Skullcandy()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void Ausdom()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        public void More()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayTradeMark(null);
                    break;
            }
        }

        //================================================//


        //================= Phân Loại ====================//

        public void Khongday()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayAttribute(null);
                    break;
            }
        }

        public void Thethao()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayAttribute(null);
                    break;
            }
        }

        public void InEar()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayAttribute(null);
                    break;
            }
        }

        public void Gaming()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayAttribute(null);
                    break;
            }
        }

        public void Earbud()
        {
            Console.Clear();
            Console.WriteLine("gọi từ database");
            int number;
            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else if (number < 0 || number > 0)
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    Console.WriteLine("#Chọn: ");
                }
                else
                {
                    break;
                }
            }

            switch (number)
            {
                case 0:
                    DisplayAttribute(null);
                    break;
            }
        }

        //==================================================//
    }
}