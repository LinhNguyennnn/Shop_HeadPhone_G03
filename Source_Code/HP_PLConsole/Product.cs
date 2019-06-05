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
        public void DisplayProduct(Customers Cus)
        {
            User U = new User();
            Console.Clear();
            try
            {
                string[] choice = { "Xem danh sách sản phẩm", "Xem danh sách sản phẩm theo hãng", "Xem danh sách sản phẩm theo loại sản phẩm", "Trở về MENU chính" };
                int number = SubMenu("MENU SẢN PHẨM", choice);
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

        public int DisplayAllItems(Customers Cus)
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("------------------------ DANH SÁCH SẢN PHẨM -------------------------\n");
            Item_BL IBL = new Item_BL();
            List<Items> items = IBL.GetAllItems();
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            foreach (Items i in items)
            {
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price);
            }
            table.Write(Format.Alternative);
            Console.WriteLine("=====================================================================");
            Console.Write("\nChọn mã sản phẩm: ");
            int Id = input(Console.ReadLine());

            while (IBL.GetItemByProduceCode(Id) == null)
            {
                string a;
                Console.WriteLine("Mã sản phẩm không tồn tại!");
                Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
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
                    Id = input(Console.ReadLine());
                }
                else
                {
                    DisplayProduct(Cus);
                }
            }
            return DisplayItemDetail(Id, Cus);
        }

        public int DisplayItemDetail(int id, Customers Cus)
        {
            Item_BL IBL = new Item_BL();
            User U = new User();
            Items item = IBL.GetItemByProduceCode(id);
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("------------------------- CHI TIẾT SẢN PHẨM -------------------------\n");
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            table.AddRow(item.Produce_Code, item.Item_Name, item.Trademark, item.Attribute, item.Item_Price);
            table.Write(Format.Alternative);
            Console.WriteLine("Mô tả sản phẩm : {0}\n", item.Item_Description);
            while (true)
            {
                string[] choice = { "Thêm vào giỏ hàng", "MENU sản phẩm" };
                int number = SubMenu(null, choice);
                switch (number)
                {
                    case 1:
                        int itemQuantity;
                        while (true)
                        {
                            Console.Write("Nhập số lượng sản phẩm: ");
                            try
                            {
                                itemQuantity = int.Parse(Console.ReadLine());
                                if (itemQuantity >= 1 && itemQuantity <= 5)
                                {
                                    break;
                                }
                            }
                            catch (System.Exception)
                            {

                                Console.WriteLine("Số lượng sản phẩm phải là số lớn hơn 0 và nhỏ 5 !");
                                continue;
                            }
                        }
                        if (File.Exists($"CartOf{Cus.User_Name}.dat"))
                        {
                            List<Items> Items = null;
                            FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                            BinaryReader br = new BinaryReader(fs);
                            string str = br.ReadString();
                            Items = JsonConvert.DeserializeObject<List<Items>>(str);
                            fs.Close();
                            br.Close();
                            for (int i = 0; i < Items.Count; i++)
                            {
                                if (id == Items[i].Produce_Code)
                                {
                                    item.Quantity = itemQuantity + Items[i].Quantity;
                                }
                                else
                                {
                                    item.Quantity = itemQuantity;
                                }
                            }
                        }
                        else
                        {
                            item.Quantity = itemQuantity;
                        }
                        U.AddToCart(item, Cus);
                        break;
                    case 2:
                        DisplayProduct(Cus);
                        break;
                }
            }
        }

        public int DisplayTradeMark(Customers Cus)
        {
            Console.Clear();
            string[] choice = { "Urbanista", "MEE", "RHA AUDIO", "jabees", "SONY", "SOMIC", "Sennheiser", "Audio Technica", "Skullcandy", "Ausdom", "1More", "Trở về Menu sản phẩm", };
            int number = SubMenu("Danh sách sản phẩm theo hãng", choice);
            Item_BL IBL = new Item_BL();
            List<Items> items = null;
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
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price);
            }
            table.Write(Format.Alternative);
            Console.WriteLine("=====================================================================");
            Console.Write("\nChọn mã sản phẩm: ");
            int Id = input(Console.ReadLine());
            while (IBL.GetItemByProduceCodeAndTradeMark(Id, trade) == null)
            {
                string a;
                Console.Write("Mã sản phẩm không tồn tại!");
                Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
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
                    Id = input(Console.ReadLine());
                    continue;
                }
                else
                {
                    DisplayProduct(Cus);
                }
            }
            return DisplayItemDetail(Id, Cus);
        }

        public int DisplayAttribute(Customers Cus)
        {
            Console.Clear();
            Item_BL IBL = new Item_BL();
            string[] choice = { "Không dây", "Thể thao", "In-Ear", "Gaming", "Earbud", "Trở về MENU sản phẩm" };
            int number = SubMenu("Danh sách sản phẩm theo phân loại sản phẩm", choice);
            List<Items> items = null;
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
                table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price);
            }
            table.Write(Format.Alternative);
            Console.WriteLine("=====================================================================");
            Console.Write("\nChọn mã sản phẩm: ");
            int Id = input(Console.ReadLine());
            while (IBL.GetItemByProduceCodeAndAttribute(Id, ab) == null)
            {
                string a;
                Console.Write("Mã sản phẩm không tồn tại!");
                Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
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
                    Id = input(Console.ReadLine());
                }
                else
                {
                    DisplayProduct(Cus);
                }
            }
            return DisplayItemDetail(Id, Cus);
        }
        public static short SubMenu(string title, string[] menuItems)
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
                Console.Write("#Chọn: ");
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