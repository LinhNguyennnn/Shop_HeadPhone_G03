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
                UserMenu(Cus);
            }
        }
        public void UserMenu(Customers Cus)
        {
            Console.Clear();
            Product Product = new Product();
            Menu MN = new Menu();
            string[] choice = { "Menu sản phẩm", "Thông tin cá nhân", "Xem giỏ hàng", "Đã mua", "Đăng xuất" };
            int number = Product.SubMenu($"Chào mừng {Cus.User_Name} đến với của hàng", choice);
            switch (number)
            {
                case 1:
                    Product.DisplayProduct(Cus);
                    break;
                case 2:
                    CustomerProfile(Cus.User_Name, Cus.User_Password);
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
            Console.WriteLine("===================================================");
            Console.WriteLine("---------------- THÔNG TIN CÁ NHÂN ----------------");
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
            UserMenu(Cus);
        }

        public void AddToCart(Items item, Customers Cus)
        {
            Console.Clear();
            List<Items> ListItems = new List<Items>();
            if (File.Exists($"CartOf{Cus.User_Name}.dat"))
            {
                FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);
                string str = br.ReadString();
                ListItems = JsonConvert.DeserializeObject<List<Items>>(str);

                fs.Close();
                br.Close();
                ListItems.Add(item);
            }
            else
            {
                ListItems.Add(item);
            }
            for (int i = 0; i < ListItems.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (ListItems[i].Produce_Code == ListItems[j].Produce_Code)
                    {
                        ListItems.RemoveAt(j);
                    }
                }
            }
            string sJSONReponse = JsonConvert.SerializeObject(ListItems);
            try
            {
                FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write((string)(object)sJSONReponse);
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
                            Product Product = new Product();
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
            int amount = 0;
            try
            {
                if (File.Exists($"CartOf{Cus.User_Name}.dat"))
                {
                    FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                    BinaryReader br = new BinaryReader(fs);
                    string str = br.ReadString();
                    Items = JsonConvert.DeserializeObject<List<Items>>(str);

                    fs.Close();
                    br.Close();
                    Console.WriteLine("===================================================================================================================");
                    Console.WriteLine($"                                               Giỏ hàng của {Cus.User_Name}");
                    Console.WriteLine("===================================================================================================================\n");
                    Console.WriteLine("+-------------+-----------------------------------+----------------+------------+---------+----------+------------+");
                    Console.WriteLine("| {0,-12}|           {1,-24}|      {2,-10}| {3,-11}| {4,-9}| {5,-11}| {6,-13}|", "Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Đơn giá", "Số lượng", "Thành tiền");
                    Console.WriteLine("+-------------+-----------------------------------+----------------+------------+---------+----------+------------+");
                    foreach (Items i in Items)
                    {
                        amount += i.Item_Price * i.Quantity;
                        Console.WriteLine("|      {0,-7}| {1,-34}| {2,-15}| {3,-11}| {4,-8}|    {5,-6}|  {6,-10}|", i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, i.Item_Price, i.Quantity, i.Item_Price * i.Quantity);
                        Console.WriteLine("+-------------+-----------------------------------+----------------+------------+---------+----------+------------+");
                    }
                    Console.WriteLine("|    Tổng tiền                                                                                       |  {0,-9} |", amount);
                    Console.WriteLine("+-----------------------------------------------------------------------------------------------------------------+");
                    while (true)
                    {
                        string[] choice = { "Đặt hàng", "Xóa mặt hàng", "Quay lại" };
                        int number = Product.SubMenu(null, choice);
                        switch (number)
                        {
                            case 1:
                                CreateOrder(Cus, Items, amount);
                                break;
                            case 2:
                                DeleteItemInCart(Cus);
                                break;
                            case 3:
                                UserMenu(Cus);
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Giỏ hàng trống!");
                    Console.Write("\nNhấn phím bất kỳ để quay lại!");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public void Userhasbought(Customers Cus)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("============================================================================");
                Console.WriteLine("                                Đã mua");
                Console.WriteLine("============================================================================\n");
                List<Order> ListOrder;
                try
                {
                    Order_BL OBL = new Order_BL();
                    ListOrder = OBL.GetOrderByCustomerId(Cus.Cus_ID);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                if (ListOrder.Count < 0)
                {
                    Console.WriteLine("Danh sách trống !\n");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
                Console.WriteLine("+-------------+---------------------+---------------------------------------+------------------+");
                Console.WriteLine("| {0,-15}|    {1,-20}|          {2,-21}           |    {3,-16}|", "Mã đặt hàng", "Ngày đặt hàng", "Địa chỉ giao hàng", "Trạng thái");
                Console.WriteLine("+-------------+---------------------+---------------------------------------+------------------+");
                foreach (Order order in ListOrder)
                {
                    Console.WriteLine("|      {0,-7}| {1,-20}| {2,-44}| {3,-18}|", order.Order_ID, order.Order_Date.ToString("dd/MM/yyyy h:mm tt"), order.Address_Shipping, order.Status);
                    Console.WriteLine("+-------------+---------------------+---------------------------------------+------------------+");
                }
                Console.WriteLine("Nhấn phím bất kỳ để quay lại! ");
                Console.ReadKey();
                UserMenu(Cus);
            }
        }

        public void CreateOrder(Customers Cus, List<Items> ListItems, int amount)
        {
            bool check = true;
            Order order = new Order();
            Order_BL OBL = new Order_BL();
            Console.Write("Địa chỉ giao hàng: ");
            string address_Shipping = Console.ReadLine().Trim();
            if (address_Shipping.Length == 0)
            {
                order.Address_Shipping = Cus.Cus_Address;
            }
            else
            {
                order.Address_Shipping = address_Shipping;
            }
            order.Order_Date = DateTime.Now;
            order.Status = "Không thành công";
            order.Customer = Cus;
            Item_BL IBL = new Item_BL();
            order.ItemsList = new List<Items>();
            order.ItemsList = ListItems;
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
                            int money;
                            while (true)


                            {
                                try
                                {
                                    while (true)
                                    {
                                        Console.Write("Nhập số tiền : ");
                                        money = int.Parse(Console.ReadLine());
                                        if (money >= 500 && money <= 50000000 && money % 500 == 0)
                                        {
                                            if (money < amount)
                                            {
                                                Console.WriteLine("Số tiền bạn nhập vào nhỏ hơn tổng tiền phải thanh toán !");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Số tiền bạn nhập vào không hợp lệ !");
                                            Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
                                            string Question;
                                            while (true)
                                            {
                                                Question = Console.ReadLine();
                                                if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
                                                }
                                            }
                                            switch (Question)
                                            {
                                                case "Y":
                                                    continue;
                                                case "y":
                                                    continue;
                                                case "N":
                                                    DisplayCart(Cus);
                                                    break;
                                                case "n":
                                                    DisplayCart(Cus);
                                                    break;
                                            }
                                        }
                                    }
                                }
                                catch (System.Exception)
                                {
                                    {
                                        Console.WriteLine("Số tiền nhập vào không hợp lệ ! ");
                                        Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
                                        string Question;
                                        while (true)
                                        {
                                            Question = Console.ReadLine();
                                            if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
                                            }
                                        }
                                        switch (Question)
                                        {
                                            case "Y":
                                                continue;
                                            case "y":
                                                continue;
                                            case "N":
                                                DisplayCart(Cus);
                                                break;
                                            case "n":
                                                DisplayCart(Cus);
                                                break;
                                        }
                                    }
                                }
                                break;
                            }
                            bool UpdateStatus = OBL.UpdateStatus(order.Order_ID);
                            Console.WriteLine("Thanh toán thành công !");
                            try
                            {
                                if (File.Exists(Path.Combine($"CartOf{Cus.User_Name}.dat")))
                                {
                                    File.Delete(Path.Combine($"CartOf{Cus.User_Name}.dat"));
                                }
                                else
                                {
                                    Console.WriteLine("Giỏ hàng không tồn tại");
                                }
                            }
                            catch (IOException ioExp)
                            {
                                Console.WriteLine(ioExp.Message);
                            }
                            Console.ReadKey();
                            Paybill(Cus, order.Order_ID);
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
                Console.WriteLine("Nhấn phím bất kỳ để quay lại Menu chính!");
                Console.ReadKey();
                UserMenu(Cus);
            }
        }
        public void DeleteItemInCart(Customers Cus)
        {
            Product Product = new Product();
            string a;
            List<Items> ListItems = null;
            FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            string st = br.ReadString();
            ListItems = JsonConvert.DeserializeObject<List<Items>>(st);

            fs.Close();
            br.Close();

            Console.Write("Nhập mã sản phẩm cần xóa khỏi giỏ hàng : ");
            int id = Product.input(Console.ReadLine());
            int index = ListItems.FindIndex(x => x.Produce_Code == id);
            if (index == -1)
            {
                Console.WriteLine("Mã sản phẩm không tồn tại!");
                Console.Write("Bạn có muốn nhập lại mã sản phẩm không ? (Y/N): ");
                a = Console.ReadLine().ToUpper();
                while (true)
                {
                    if (a != "Y" && a != "N")
                    {
                        Console.Write("Bạn chỉ được nhập (Y/N): ");
                        a = Console.ReadLine().ToUpper();
                    }
                    break;
                }
                if (a == "Y" || a == "y")
                {
                    Console.Write("Nhập mã sản phẩm cần xóa khỏi giỏ hàng : ");
                    id = Product.input(Console.ReadLine());
                }
                else
                {
                    DisplayCart(Cus);
                }
            }
            else
            {
                ListItems.RemoveAt(index);
            }
            if (ListItems.Count == 0)
            {
                try
                {
                    if (File.Exists(Path.Combine($"CartOf{Cus.User_Name}.dat")))
                    {
                        File.Delete(Path.Combine($"CartOf{Cus.User_Name}.dat"));
                        Console.WriteLine("Đã xóa sản phẩm!");
                        Console.ReadKey();
                        UserMenu(Cus);
                    }
                    else
                    {
                        Console.WriteLine("Giỏ hàng không tồn tại");
                    }
                }
                catch (IOException ioExp)
                {
                    Console.WriteLine(ioExp.Message);
                }
            }
            else
            {
                string sJSONReponse = JsonConvert.SerializeObject(ListItems);
                try
                {
                    fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write((string)(object)sJSONReponse);
                    fs.Close();
                    Console.WriteLine("Đã xóa sản phẩm!");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Không xóa được sản phẩm!");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
            }
        }
        public void Paybill(Customers Cus, int? orderId)
        {
            Console.Clear();
            Order_BL OBL = new Order_BL();
            Order order = new Order();
            int amount = 0;
            try
            {
                order = OBL.GetOrderDetailsByOrderId(orderId);
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadKey();
                UserMenu(Cus);
            }
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.WriteLine("|                            HÓA ĐƠN BÁN HÀNG                         |");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("|                      Ngày {0,-2} tháng {1,-2} năm {2, -5}                     |", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.WriteLine("|Tên khách hàng : {0,-30}                      |", order.Customer.Cus_Name);
            Console.WriteLine("|Địa chỉ : {0,-60}     |", order.Customer.Cus_Address);
            Console.WriteLine("+-----------------------------------+---------+----------+------------+");
            Console.WriteLine("|           {0,-24}| {1,-9}| {2,-11}| {3,-13}|", "Tên sản phẩm", "Đơn giá", "Số lượng", "Thành tiền");
            Console.WriteLine("+-----------------------------------+---------+----------+------------+");
            foreach (var i in order.ItemsList)
            {
                amount += i.Item_Price * i.Quantity;
                Console.WriteLine("| {0,-34}| {1,-8}|    {2,-6}|  {3,-10}|", i.Item_Name, i.Item_Price, i.Quantity, i.Item_Price * i.Quantity);
                Console.WriteLine("+-----------------------------------+---------+----------+------------+");
            }
            Console.WriteLine("|    Tổng tiền                                           |  {0,-9} |", amount);
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.WriteLine("|        Nguời mua hàng                            Người bán hàng     |");
            Console.WriteLine("|            {0,-7}                                 ( Đã ký )        |    ", Cus.User_Name);
            Console.WriteLine("|       {0,-20}                                          |    ", order.Customer.Cus_Name);
            Console.WriteLine("+---------------------------------------------------------------------+");
            Console.WriteLine("Nhấn phím bất kỳ để quay về MENU chính");
            Console.ReadKey();
            UserMenu(Cus);
        }
    }
}