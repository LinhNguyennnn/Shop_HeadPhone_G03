using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
using Newtonsoft.Json;

namespace HP_PLConsole
{
    public class Product
    {
        ConsoleTable table = new ConsoleTable();
        User U = new User();
        public void DisplayProduct(Customers Cus)
        {
            User U = new User();
            Console.Clear();
            try
            {
                string[] choice = { "Xem danh sách tất cả sản phẩm", "Xem danh sách sản phẩm theo hãng", "Xem danh sách sản phẩm theo thuộc tính", "Trở về trang chính" };
                int number = SubMenu("DANH SÁCH SẢN PHẨM", choice);
                switch (number)
                {
                    case 1:
                        DisplayAllItems(Cus);
                        break;
                    case 2:
                        DisplayTradeMark(Cus);
                        break;
                    case 3:
                        DisplayAttribute(Cus);
                        break;
                    case 4:
                        U.UserMenu(Cus);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public int input(string str)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(str);
            while ((matchCollection.Count < str.Length) || (str == ""))
            {
                Console.Write("Dữ liệu nhập vào phải là số tự nhiên!\nMời bạn nhập lại: ");
                str = Console.ReadLine();
                matchCollection = regex.Matches(str);
            }
            return Convert.ToInt32(str);
        }

        public void DisplayAllItems(Customers Cus)
        {
            Console.Clear();
            Console.WriteLine("================================================================================================");
            Console.WriteLine("------------------------------------- DANH SÁCH SẢN PHẨM ---------------------------------------");
            Console.WriteLine("================================================================================================\n");
            Item_BL IBL = new Item_BL();
            List<Items> items = IBL.GetAllItems();
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            foreach (Items i in items)
            {
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, U.FormatMoney(i.Item_Price));
            }
            table.Write(Format.Alternative);
            string[] choice1 = { "Xem chi tiết sản phẩm", "Thêm vào giỏ hàng", "Quay về trang chính" };
            int number1 = Product.SubMenu(null, choice1);
            switch (number1)
            {
                case 1:
                    Console.Write("Chọn mã sản phẩm: ");
                    int showdetal = input(Console.ReadLine());
                    while (IBL.GetItemByProduceCode(showdetal) == null)
                    {
                        string a;
                        Console.WriteLine("Mã sản phẩm không tồn tại!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                        while (true)
                        {
                            if (a != "Y" && a != "N")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                a = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }
                        if (a == "Y" || a == "y")
                        {
                            Console.Write("\nChọn mã sản phẩm: ");
                            showdetal = input(Console.ReadLine());
                        }
                        else
                        {
                            DisplayProduct(Cus);
                        }
                    }
                    DisplayItemDetails(showdetal, Cus);
                    break;
                case 2:
                    Console.Write("Chọn mã sản phẩm: ");
                    int pc = input(Console.ReadLine());
                    while (IBL.GetItemByProduceCode(pc) == null)
                    {
                        string a;
                        Console.WriteLine("Mã sản phẩm không tồn tại!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                        while (true)
                        {
                            if (a != "Y" && a != "N")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                a = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }
                        if (a == "Y" || a == "y")
                        {
                            Console.Write("\nChọn mã sản phẩm: ");
                            pc = input(Console.ReadLine());
                        }
                        else
                        {
                            DisplayProduct(Cus);
                        }
                    }
                    Items item = IBL.GetItemByProduceCode(pc);
                    InputQuantity(Cus, item, pc);
                    break;
                case 3:
                    U.UserMenu(Cus);
                    break;
            }
        }

        public void DisplayItemDetails(int id, Customers Cus)
        {
            Item_BL IBL = new Item_BL();
            Items item = IBL.GetItemByProduceCode(id);
            Console.Clear();
            Console.WriteLine("==================================================================================");
            Console.WriteLine("-------------------------------- CHI TIẾT SẢN PHẨM -------------------------------\n");
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            table.AddRow(item.Produce_Code, item.Item_Name, item.Trademark, item.Attribute, U.FormatMoney(item.Item_Price));
            table.Write(Format.Alternative);
            Console.WriteLine("Mô tả sản phẩm : {0}\n", item.Item_Description);
            while (true)
            {
                string[] choice = { "Thêm vào giỏ hàng", "Trở về danh sách sản phẩm", "Trở về trang chính" };
                int number = SubMenu(null, choice);
                switch (number)
                {
                    case 1:
                        InputQuantity(Cus, item, id);
                        break;
                    case 2:
                        DisplayProduct(Cus);
                        break;
                    case 3:
                        if (Cus.User_Name != null && Cus.User_Password != null)
                        {
                            U.UserMenu(Cus);
                        }
                        else
                        {
                            Console.Clear();
                            Menu m = new Menu();
                            Product Product = new Product();
                            string[] choice1 = { "Danh sách sản phẩm", "Xem giỏ hàng", "Đăng nhập", "Thoát" };
                            int number1 = Product.SubMenu($"Chào mừng đến với cửa hàng", choice1);
                            switch (number1)
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
                        break;
                }
            }
        }

        public void DisplayTradeMark(Customers Cus)
        {
            Console.Clear();
            string[] choice = { "Urbanista", "MEE", "RHA AUDIO", "jabees", "SONY", "SOMIC", "Sennheiser", "Audio Technica", "Skullcandy", "Ausdom", "1More", "Trở về danh sách sản phẩm", };
            int number = SubMenu("Danh sách sản phẩm theo hãng", choice);
            Item_BL IBL = new Item_BL();
            List<Items> items = new List<Items>();
            string trade = null;
            switch (number)
            {
                case 1:
                    items = IBL.GetItemByTradeMark("Urbanista");
                    trade = "Urbanista";
                    break;
                case 2:
                    items = IBL.GetItemByTradeMark("MEE");
                    trade = "MEE";
                    break;
                case 3:
                    items = IBL.GetItemByTradeMark("RHA AUDIO");
                    trade = "RHA AUDIO";
                    break;
                case 4:
                    items = IBL.GetItemByTradeMark("jabees");
                    trade = "jabees";
                    break;
                case 5:
                    items = IBL.GetItemByTradeMark("SONY");
                    trade = "SONY";
                    break;
                case 6:
                    items = IBL.GetItemByTradeMark("SOMIC");
                    trade = "SOMIC";
                    break;
                case 7:
                    items = IBL.GetItemByTradeMark("Sennheiser");
                    trade = "Sennheiser";
                    break;
                case 8:
                    items = IBL.GetItemByTradeMark("Audio Technica");
                    trade = "Audio Technica";
                    break;
                case 9:
                    items = IBL.GetItemByTradeMark("Skullcandy");
                    trade = "Skullcandy";
                    break;
                case 10:
                    items = IBL.GetItemByTradeMark("Ausdom");
                    trade = "Ausdom";
                    break;
                case 11:
                    items = IBL.GetItemByTradeMark("1More");
                    trade = "1More";
                    break;
                case 12:
                    DisplayProduct(Cus);
                    break;
            }
            Console.Clear();
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            foreach (Items i in items)
            {
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, U.FormatMoney(i.Item_Price));
            }
            table.Write(Format.Alternative);
            string[] choice1 = { "Xem chi tiết sản phẩm", "Thêm vào giỏ hàng", "Quay về trang chính" };
            int number1 = Product.SubMenu(null, choice1);
            switch (number1)
            {
                case 1:
                    Console.Write("Chọn mã sản phẩm: ");
                    int showdetal = input(Console.ReadLine());
                    while (IBL.GetItemByProduceCodeAndTradeMark(showdetal, trade) == null)
                    {
                        string a;
                        Console.WriteLine("Mã sản phẩm không tồn tại!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                        while (true)
                        {
                            if (a != "Y" && a != "N")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                a = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }
                        if (a == "Y" || a == "y")
                        {
                            Console.Write("\nChọn mã sản phẩm: ");
                            showdetal = input(Console.ReadLine());
                        }
                        else
                        {
                            DisplayProduct(Cus);
                        }
                    }
                    DisplayItemDetails(showdetal, Cus);
                    break;
                case 2:
                    Console.Write("Chọn mã sản phẩm: ");
                    int pc = input(Console.ReadLine());
                    while (IBL.GetItemByProduceCodeAndTradeMark(pc, trade) == null)
                    {
                        string a;
                        Console.WriteLine("Mã sản phẩm không tồn tại!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                        while (true)
                        {
                            if (a != "Y" && a != "N")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                a = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }
                        if (a == "Y" || a == "y")
                        {
                            Console.Write("\nChọn mã sản phẩm: ");
                            pc = input(Console.ReadLine());
                        }
                        else
                        {
                            DisplayProduct(Cus);
                        }
                    }
                    Items item = IBL.GetItemByProduceCodeAndTradeMark(pc, trade);
                    InputQuantity(Cus, item, pc);
                    break;
                case 3:
                    U.UserMenu(Cus);
                    break;
            }
        }

        public void DisplayAttribute(Customers Cus)
        {
            Console.Clear();
            Item_BL IBL = new Item_BL();
            User U = new User();
            string[] choice = { "Không dây", "Thể thao", "In-Ear", "Gaming", "Earbud", "Trở về danh sách sản phẩm" };
            int number = SubMenu("Danh sách sản phẩm theo thuộc tính", choice);
            List<Items> items = new List<Items>();
            string ab = null;
            switch (number)
            {
                case 1:
                    items = IBL.GetItemByAttribute("Không dây");
                    ab = "Không dây";
                    break;
                case 2:
                    items = IBL.GetItemByAttribute("Thể thao");
                    ab = "Thể thao";
                    break;
                case 3:
                    items = IBL.GetItemByAttribute("In-Ear");
                    ab = "In-Ear";
                    break;
                case 4:
                    items = IBL.GetItemByAttribute("Gaming");
                    ab = "Gaming";
                    break;
                case 5:
                    items = IBL.GetItemByAttribute("Earbud");
                    ab = "Earbud";
                    break;
                case 6:
                    DisplayProduct(Cus);
                    break;
            }
            Console.Clear();
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            foreach (Items i in items)
            {
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, U.FormatMoney(i.Item_Price));
            }
            table.Write(Format.Alternative);
            string[] choice1 = { "Xem chi tiết sản phẩm", "Thêm vào giỏ hàng", "Quay về trang chính" };
            int number1 = Product.SubMenu(null, choice1);
            switch (number1)
            {
                case 1:
                    Console.Write("Chọn mã sản phẩm: ");
                    int showdetal = input(Console.ReadLine());
                    while (IBL.GetItemByProduceCodeAndAttribute(showdetal, ab) == null)
                    {
                        string a;
                        Console.WriteLine("Mã sản phẩm không tồn tại!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                        while (true)
                        {
                            if (a != "Y" && a != "N")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                a = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }
                        if (a == "Y" || a == "y")
                        {
                            Console.Write("\nChọn mã sản phẩm: ");
                            showdetal = input(Console.ReadLine());
                        }
                        else
                        {
                            DisplayProduct(Cus);
                        }
                    }
                    DisplayItemDetails(showdetal, Cus);
                    break;
                case 2:
                    Console.Write("Chọn mã sản phẩm: ");
                    int pc = input(Console.ReadLine());
                    while (IBL.GetItemByProduceCodeAndAttribute(pc, ab) == null)
                    {
                        string a;
                        Console.WriteLine("Mã sản phẩm không tồn tại!");
                        Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                        while (true)
                        {
                            if (a != "Y" && a != "N")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                a = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }
                        if (a == "Y" || a == "y")
                        {
                            Console.Write("\nChọn mã sản phẩm: ");
                            pc = input(Console.ReadLine());
                        }
                        else
                        {
                            DisplayProduct(Cus);
                        }
                    }
                    Items item = IBL.GetItemByProduceCodeAndAttribute(pc, ab);
                    InputQuantity(Cus, item, pc);
                    break;
                case 3:
                    U.UserMenu(Cus);
                    break;
            }
        }
        public void InputQuantity(Customers Cus, Items item, int pc)
        {
            int itemQuantity;
            while (true)
            {
                Console.Write("Nhập số lượng sản phẩm: ");
                bool isINT = Int32.TryParse(Console.ReadLine(), out itemQuantity);
                if (!isINT)
                {
                    Console.WriteLine("Số lượng sản phẩm phải là số lớn hơn 0 và nhỏ hơn 10 !");
                    continue;
                }
                else if (itemQuantity < 1 || itemQuantity > 10)
                {
                    Console.WriteLine("Số lượng sản phẩm phải là số lớn hơn 0 và nhỏ hơn 10 !");
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (File.Exists($"CartOf{Cus.User_Name}.dat"))
            {
                List<Items> Items = new List<Items>();
                FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);
                string str = br.ReadString();
                Items = JsonConvert.DeserializeObject<List<Items>>(str);
                fs.Close();
                br.Close();
                int index = Items.FindIndex(x => x.Produce_Code == pc);
                if (index == -1)
                {
                    item.Quantity = itemQuantity;
                }
                else
                {
                    item.Quantity = itemQuantity + Items[index].Quantity;
                }
            }
            else
            {
                item.Quantity = itemQuantity;
            }
            U.AddToCart(item, Cus);
        }
        public static short SubMenu(string title, string[] menuItems)
        {
            short choose = 0;
            string line = "==========================================";
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
                Console.Write("#Chọn: ");
                try
                {
                    choose = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Bạn đã nhập sai!");
                    continue;
                }
            } while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }
    }
}