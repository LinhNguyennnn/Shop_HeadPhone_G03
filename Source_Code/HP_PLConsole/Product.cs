using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
namespace HP_PLConsole
{
    public class Product
    {
        Items item = new Items();
        Order order = new Order();
        ConsoleTable table = new ConsoleTable();

        public void DisplayProduct(Customers Cus)
        {
            Console.Clear();
            int number;
            while (true)
            {
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
            Console.WriteLine("------------------------ DANH SÁCH SẢN PHẨM -------------------------\n");
            Item_BL itemBL = new Item_BL();
            List<Items> items = itemBL.GetAllItems();
            var table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            foreach (var i in items)
            {
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price);
            }
            table.Write(Format.Alternative);
            Console.WriteLine("=====================================================================");
            Console.Write("\nChọn mã sản phẩm: ");
            int Id = input(Console.ReadLine());
            while (itemBL.GetItemByProduceCode(Id) == null)
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
                    Id = input(Console.ReadLine());
                }
            }
            Items PC = itemBL.GetItemByProduceCode(Id);
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("------------------------- CHI TIẾT SẢN PHẨM -------------------------\n");
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            table.AddRow(PC.Produce_Code, PC.Item_Name, PC.Trademark, PC.Attribute, PC.Item_Price);
            table.Write(Format.Alternative);
            Console.WriteLine("Mô tả sản phẩm : {0}\n", PC.Item_Description);
            while (true)
            {
                Console.WriteLine("======================================= \n");
                Console.WriteLine("1. Thêm vào giỏ hàng");
                Console.WriteLine("2. Quay lại");
                Console.Write("#Chọn: ");
                int number;
                while (true)
                {
                    bool kt = Int32.TryParse(Console.ReadLine(), out number);
                    if (kt == false)
                    {
                        Console.WriteLine("Bạn đã nhập sai!");
                        Console.Write("#Chọn: ");
                    }
                    else if (number < 1 || number > 2)
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
                        // add to cart
                        DisplayAllItems(Cus);
                        break;
                    case 2:
                        DisplayAllItems(Cus);
                        break;
                }
            }
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

        private static short Menu(string title, string[] menuItems)
        {
            short choose = 0;
            string line = "========================================";
            Console.WriteLine(line);
            Console.WriteLine(" " + title);
            Console.WriteLine(line);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine(line);
            do
            {
                Console.Write("Your choice: ");
                try
                {
                    choose = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Your Choose is wrong!");
                    continue;
                }
            } while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }
    }
}