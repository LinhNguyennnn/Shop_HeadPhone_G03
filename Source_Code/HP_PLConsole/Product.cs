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
        Items item = new Items();
        Order order = new Order();
        ConsoleTable table = new ConsoleTable();
        public void DisplayProduct(Customers Cus)
        {
            Console.Clear();
            string[] choice = { "Xem danh sách sản phẩm", "Xem danh sách sản phẩm theo hãng", "Xem danh sách sản phẩm theo loại sản phẩm", "Trở về MENU chính" };
            int number = SubMenu("MENU SẢN PHẨM", choice);
            switch (number)
            {
                case 4:
                    Menu MN = new Menu();
                    MN.menu(null);
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
        public int DisplayAllItems(Customers Cus)
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
        public int DisplayItemDetail(int id, Customers Cus)
        {
            Item_BL itemBL = new Item_BL();
            Items item = itemBL.GetItemByProduceCode(id);
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("------------------------- CHI TIẾT SẢN PHẨM -------------------------\n");
            table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm");
            table.AddRow(item.Produce_Code, item.Item_Name, item.Trademark, item.Attribute, item.Item_Price);
            table.Write(Format.Alternative);
            Console.WriteLine("Mô tả sản phẩm : {0}\n", item.Item_Description);
            while (true)
            {
                Console.WriteLine("======================================= \n");
                Console.WriteLine("1. Thêm vào giỏ hàng");
                Console.WriteLine("0. Quay lại");
                Console.Write("#Chọn: ");
                int number;
                while (true)
                {
                    bool kt = Int32.TryParse(Console.ReadLine(), out number);
                    if (kt == false || number < 0 || number > 1)
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
                        AddToCart(item, Cus);
                        break;
                    case 0:
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
            Item_BL itemBL = new Item_BL();
            List<Items> items = null;
            switch (number)
            {
                case 12:
                    DisplayProduct(Cus);
                    break;
                case 1:
                    items = itemBL.GetItemByTradeMark("Urbanista");
                    break;
                case 2:
                    items = itemBL.GetItemByTradeMark("MEE");
                    break;
                case 3:
                    items = itemBL.GetItemByTradeMark("RHAAUDIO");
                    break;
                case 4:
                    items = itemBL.GetItemByTradeMark("jabees");
                    break;
                case 5:
                    items = itemBL.GetItemByTradeMark("SONY");
                    break;
                case 6:
                    items = itemBL.GetItemByTradeMark("SOMIC");
                    break;
                case 7:
                    items = itemBL.GetItemByTradeMark("Sennheiser");
                    break;
                case 8:
                    items = itemBL.GetItemByTradeMark("AudioTechnica");
                    break;
                case 9:
                    items = itemBL.GetItemByTradeMark("Skullcandy");
                    break;
                case 10:
                    items = itemBL.GetItemByTradeMark("Ausdom");
                    break;
                case 11:
                    items = itemBL.GetItemByTradeMark("More");
                    break;
            }
            Console.Clear();
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

        public int DisplayAttribute(Customers Cus)
        {
            Console.Clear();
            Item_BL itemBL = new Item_BL();
            string[] choice = { "Không dây", "Thể thao", "In-Ear", "Gaming", "Earbud", "Trở về MENU sản phẩm" };
            int number = SubMenu("Danh sách sản phẩm theo phân loại sản phẩm", choice);
            List<Items> items = null;
            switch (number)
            {
                case 6:
                    DisplayProduct(Cus);
                    break;
                case 1:
                    items = itemBL.GetItemByAttribute("Không dây");
                    break;
                case 2:
                    items = itemBL.GetItemByAttribute("Thể thao");
                    break;
                case 3:
                    items = itemBL.GetItemByAttribute("In-Ear");
                    break;
                case 4:
                    items = itemBL.GetItemByAttribute("Gaming");
                    break;
                case 5:
                    items = itemBL.GetItemByAttribute("Earbud");
                    break;
            }
            Console.Clear();
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

        public void AddToCart(Items item, Customers Cus)
        {
            List<Items> ListItems = new List<Items>();
            ListItems.Add(item);
            string sJSONReponse = JsonConvert.SerializeObject(ListItems);
            BinaryWriter bw;
            string fileName = "CartOf.dat";
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write((string)(object)sJSONReponse);
                fs.Close();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Không thêm được sản phẩm vào giỏ hàng!");
            }
            Console.WriteLine("Đã thêm vào giỏ hàng!");
            while (true)
            {
                string[] choice = { "Xem giỏ hàng", "Menu sản phẩm" };
                int number = SubMenu(null, choice);
                switch (number)
                {
                    case 2:
                        DisplayProduct(Cus);
                        break;
                    case 1:
                        DisplayCart();
                        break;
                }
            }
        }
        public void DisplayCart()
        {
            List<Items> ListItems = new List<Items>();
            object StringResponse = new object();
            StringResponse.ToString();
            FileStream fs = new FileStream("CartOf.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                BinaryReader br = new BinaryReader(fs);
                // br.ReadDataFromFile("CartOf.dat");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Không đọc được dữ liệu trong giỏ hàng!");
            }
        }
        interface IConverter
        {
            bool Convert(string str, out object val);
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
                    Console.Write("#Chọn: ");
                    continue;
                }
            } while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }
    }
}