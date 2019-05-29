using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using HP_BL;
using HP_Persistence;
using Newtonsoft.Json;

namespace HP_PLConsole
{
    class User
    {
        private static Product Product = new Product();
        private static List<Items> ListItems = new List<Items>();
        ConsoleTable table = new ConsoleTable();
        public void ScreenLogin()
        {
            Menu MN = new Menu();
            Customer_BL CusBL = new Customer_BL();
            Customers Cus = new Customers();
            string Un = null;
            string Pw = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================= \n");
                Console.WriteLine("ĐĂNG NHẬP\n");
                Console.Write("Tên đăng nhập: ");
                Un = Console.ReadLine().Trim();
                Console.Write("Mật khẩu: ");
                Pw = Password().Trim();
                string select;
                if ((Validate(Un) == false) || (Validate(Pw) == false))
                {
                    Console.Write("Tên đăng nhập hoặc mật khẩu không được chứa kí tự đặc biệt\nBạn có muốn nhập lại không? (Y/N): ");
                    select = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (select != "Y" && select != "N")
                        {
                            Console.Write("Bạn có muốn nhập lại không? (Y/N): ");
                            select = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }

                    switch (select)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MN.menu(null);
                            break;
                        case "n":
                            MN.menu(null);
                            break;
                        default:
                            continue;
                    }
                }
                try
                {
                    Cus = CusBL.Login(Un, Pw);
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("Mất kết nối!");
                    Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                    select = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (select != "Y" && select != "N")
                        {
                            Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                            select = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (select)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MN.menu(null);
                            break;
                        case "n":
                            MN.menu(null);
                            break;
                        default:
                            continue;
                    }
                }
                if (Cus == null)
                {
                    Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng!");
                    Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                    select = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (select != "Y" && select != "N")
                        {
                            Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                            select = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (select)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MN.menu(null);
                            break;
                        case "n":
                            MN.menu(null);
                            break;
                        default:
                            continue;
                    }
                }
                UserMenu(Cus, Un, Pw);
            }
        }
        
        public void UserMenu(Customers Cus, string Un, string Pw)
        {
            Console.Clear();
            Menu MN = new Menu();
            string[] choice = { "Menu sản phẩm", "Thông tin cá nhân", "Xem giỏ hàng", "Đã mua", "Đăng xuất" };
            int number = Product.SubMenu($"Chào mừng {Cus.User_Name} đến với của hàng", choice);
            switch (number)
            {
                case 1:
                    Product.DisplayProduct(Cus);
                    break;
                case 2:
                    CustomerProfile(Un, Pw);
                    break;
                case 3:
                    DisplayCart(Cus);
                    break;
                case 4:
                    Userhasbought(Cus);
                    break;
                case 5:
                    MN.menu(null);
                    break;
            }
        }
        public bool Validate(string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionstr = regex.Matches(str);
            if (matchCollectionstr.Count < str.Length)
            {
                return false;
            }
            return true;
        }

        public string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo CKI = Console.ReadKey(true);
                if (CKI.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (CKI.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write("*");
                sb.Append(CKI.KeyChar);
            }
            return sb.ToString();
        }

        public void CustomerProfile(string username, string password)
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("------------------------ THÔNG TIN CÁ NHÂN --------------------------");
            Customer_BL CusBL = new Customer_BL();
            Customers Cus = new Customers();
            try
            {
                Cus = CusBL.Login(username, password);
            }
            catch (System.Exception)
            {
                Menu MN = new Menu();
                Console.WriteLine("Mất kết nối!");
                Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                string select = Console.ReadLine().ToUpper();
                while (true)
                {
                    if (select != "Y" && select != "N")
                    {
                        Console.Write("Bạn có muốn đăng nhập lại không? (Y/N): ");
                        select = Console.ReadLine().ToUpper();
                        continue;
                    }
                    break;
                }
                switch (select)
                {
                    case "Y":
                        ScreenLogin();
                        break;
                    case "y":
                        ScreenLogin();
                        break;
                    case "N":
                        MN.menu(null);
                        break;
                    case "n":
                        MN.menu(null);
                        break;
                }
            }
            Console.WriteLine("\nTên khách hàng: {0}", Cus.Cus_Name);
            Console.WriteLine("Ngày sinh: {0}", Cus.Cus_DateBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Địa chỉ: {0}", Cus.Cus_Address);
            Console.WriteLine("Email: {0}", Cus.Cus_Email);
            Console.WriteLine("Số điện thoại: {0}", Cus.Cus_Phone_Numbers);
            Console.Write("\nNhấn phím bất kỳ để quay lại!");
            Console.ReadKey();
            UserMenu(Cus, username, password);
        }

        public void AddToCart(Items item, Customers Cus)
        {
            Console.Clear();

            ListItems.Add(item);
            string sJSONReponse = JsonConvert.SerializeObject(ListItems);
            BinaryWriter bw;
            try
            {
                FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write((string)(object)sJSONReponse + Environment.NewLine);
                fs.Close();
                Console.WriteLine("Đã thêm vào giỏ hàng!");
                while (true)
                {
                    string[] choice = { "Xem giỏ hàng", "Menu sản phẩm" };
                    int number = Product.SubMenu(null, choice);
                    switch (number)
                    {
                        case 1:
                            DisplayCart(Cus);
                            break;
                        case 2:
                            Product.DisplayProduct(Cus);
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Không thêm được sản phẩm vào giỏ hàng!");
                Console.ReadKey();
            }
        }

        public void DisplayCart(Customers Cus)
        {
            Console.Clear();

            List<Items> Items = null;
            BinaryReader br;
            try
            {
                if (File.Exists($"CartOf{Cus.User_Name}.dat"))
                {
                    FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                    br = new BinaryReader(fs);
                    string str = br.ReadString();
                    Items = JsonConvert.DeserializeObject<List<Items>>(str);

                    fs.Close();
                    br.Close();
                    Console.WriteLine("==================================================================================");
                    Console.WriteLine($"                    Giỏ hảng của {Cus.User_Name}");
                    Console.WriteLine("==================================================================================\n");
                    table = new ConsoleTable("Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Giá sản phẩm", "Số lượng", "Tổng tiền");
                    int amount = 0;
                    foreach (Items i in Items)
                    {
                        amount += i.Item_Price * i.Quantity;
                        table.AddRow(i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price, i.Quantity, amount);
                    }

                    table.Write(Format.Alternative);
                    while (true)
                    {
                        string[] choice = { "Đặt hàng", "Quay lại" };
                        int number = Product.SubMenu(null, choice);
                        switch (number)
                        {
                            case 1:
                                bool check = true;
                                Order order = new Order();
                                Order_BL OBL = new Order_BL();
                                Console.Write("Địa chỉ giao hàng: ");
                                string address_Shipping = Console.ReadLine().Trim();
                                order.Address_Shipping = address_Shipping;
                                order.Order_Date = DateTime.Now;
                                order.Status = "Không thành công";
                                order.Amount = amount;
                                order.Customer = Cus;
                                Item_BL IBL = new Item_BL();
                                foreach (Items item in Items)
                                {
                                    order.ItemsList = new List<Items>();
                                    order.ItemsList.Add(IBL.GetItemByProduceCode(item.Produce_Code));
                                }
                                check = OBL.CreateOrder(order);
                                if (check == true)
                                {
                                    Console.WriteLine("Đặt hàng thành công!");
                                    while (true)
                                    {
                                        string[] a = { "Thanh toán", "Hủy đơn hàng" };
                                        int b = Product.SubMenu(null, a);
                                        switch (b)
                                        {
                                            case 1:
                                                Product.Pay(amount);
                                                break;
                                            case 2:
                                                check = OBL.DeleteOrder(order.Order_ID);
                                                DisplayCart(Cus);
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n Đặt hàng thất bại!\n");
                                    Console.WriteLine("Nhấn phím bất kỳ để quay lại");
                                    Console.ReadKey();
                                    DisplayCart(Cus);
                                }
                                break;
                            case 2:
                                Product.DisplayProduct(Cus);
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Giỏ hàng trống!");
                    Console.Write("\nNhấn phím bất kỳ để quay lại!");
                    Console.ReadKey();
                    UserMenu(Cus, null, null);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Mất kết nối !");
                Console.ReadKey();
            }
        }
        public void Userhasbought(Customers Cus)
        {
            while (true)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("                             Đã mua");
                Console.WriteLine("===========================================================");
                List<Order> ListOrder;
                try
                {
                    Order_BL OBL = new Order_BL();
                    ListOrder = OBL.GetOrderByCustomerId(Cus.Cus_ID);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    break;
                }
                if (ListOrder.Count < 0)
                {
                    Console.WriteLine("Danh sách trống !\n");
                    Console.ReadKey();
                    break;
                }
                table = new ConsoleTable("Mã đặt hàng", "Ngày đặt hàng", "Địa chỉ giao hàng", "Trạng thái");
                foreach (Order order in ListOrder)
                {
                    if (order.Address_Shipping.Length <= 0)
                    {
                        order.Address_Shipping = Cus.Cus_Address;
                    }
                    table.AddRow(order.Order_ID, order.Order_Date, order.Address_Shipping, order.Status);
                }
                table.Write(Format.Alternative);
                Console.WriteLine("Nhấn phím bất kỳ để quay lại! ");
                Console.ReadKey();
                UserMenu(Cus, null, null);
            }
        }
    }
}