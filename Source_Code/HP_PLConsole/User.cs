using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
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
            Menu m = new Menu();
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
                    Console.Write("Tên đăng nhập hoặc mật khẩu không được chứa ký tự đặc biệt!\nBạn có muốn nhập lại không? (Y/N): ");
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
                            m.menu();
                            break;
                        case "n":
                            m.menu();
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
                            m.menu();
                            break;
                        case "n":
                            m.menu();
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
                            m.menu();
                            break;
                        case "n":
                            m.menu();
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
            Menu m = new Menu();
            Product Product = new Product();
            if (Cus.User_Name == null && Cus.User_Password == null)
            {
                m.menu();
            }
            string[] choice = { "Danh sách sản phẩm", "Thông tin cá nhân", "Xem giỏ hàng", "Lịch sử giao dịch", "Đăng xuất" };
            int number = Product.SubMenu($"Chào mừng {Cus.User_Name} đến với cửa hàng", choice);
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
                    UserPurchased(Cus);
                    break;
                case 5:
                    m.menu();
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
            catch (System.Exception ex)
            {
                Menu m = new Menu();
                Console.WriteLine(ex.Message);
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
                        m.menu();
                        break;
                    case "n":
                        m.menu();
                        break;
                }
            }
            Console.WriteLine("\nTên khách hàng: {0}", Cus.Cus_Name);
            Console.WriteLine("Ngày sinh: {0}", Cus.Cus_DateBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Địa chỉ: {0}", Cus.Cus_Address);
            Console.WriteLine("Email: {0}", Cus.Cus_Email);
            Console.WriteLine("Số điện thoại: {0}", Cus.Cus_Phone_Numbers);
            Console.Write("\nNhấn phím bất kỳ để quay lại!");
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
            try
            {
                FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                string sJSONReponse = JsonConvert.SerializeObject(ListItems);
                bw.Write((string)(object)sJSONReponse);
                fs.Close();
                Console.WriteLine("Đã thêm vào giỏ hàng!");
                while (true)
                {
                    string[] choice = { "Xem giỏ hàng", "Danh sách sản phẩm" };
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
                Console.WriteLine("Không thêm được sản phẩm vào giỏ hàng!");
                Console.ReadKey();
            }
        }

        public void DisplayCart(Customers Cus)
        {
            Console.Clear();
            List<Items> Items = new List<Items>();
            if (Cus.User_Name != null && Cus.User_Password != null)
            {
                try
                {
                    if (File.Exists($"CartOf.dat"))
                    {
                        FileStream fs = new FileStream($"CartOf.dat", FileMode.Open, FileAccess.ReadWrite);
                        BinaryReader br = new BinaryReader(fs);
                        string str = br.ReadString();
                        Items = JsonConvert.DeserializeObject<List<Items>>(str);
                        fs.Close();
                        fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        BinaryWriter bw = new BinaryWriter(fs);
                        string sJSONReponse = JsonConvert.SerializeObject(Items);
                        bw.Write((string)(object)sJSONReponse);
                        fs.Close();
                        try
                        {
                            if (File.Exists(Path.Combine($"CartOf.dat")))
                            {
                                File.Delete(Path.Combine($"CartOf.dat"));
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
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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
                    int total = 0;
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine($"                                                      Giỏ hàng");
                    Console.WriteLine("================================================================================================================================\n");
                    Console.WriteLine("+-------------+-----------------------------------+----------------+------------+-----------------+----------+------------------+");
                    Console.WriteLine("| {0,-12}|           {1,-24}|      {2,-10}| {3,-11}|    {4,-6}      | {5,-9}| {6,-17}|", "Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Đơn giá", "Số lượng", "Thành tiền");
                    Console.WriteLine("+-------------+-----------------------------------+----------------+------------+-----------------+----------+------------------+");
                    foreach (Items i in Items)
                    {
                        total += i.Item_Price * i.Quantity;
                        Console.WriteLine("|      {0,-7}| {1,-34}| {2,-15}| {3,-11}| {4,-16}|    {5,-6}|  {6,-16}|", i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, FormatMoney(i.Item_Price), i.Quantity, FormatMoney(i.Item_Price * i.Quantity));
                        Console.WriteLine("+-------------+-----------------------------------+----------------+------------+-----------------+----------+------------------+");
                    }
                    Console.WriteLine("|    Tổng tiền                                                                                               |  {0,-15} |", FormatMoney(total));
                    Console.WriteLine("+-------------------------------------------------------------------------------------------------------------------------------+");
                    while (true)
                    {
                        string[] choice = { "Đặt hàng", "Xóa mặt hàng", "Quay lại" };
                        int number = Product.SubMenu(null, choice);
                        switch (number)
                        {
                            case 1:
                                CreateOrder(Cus, Items, total);
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
                    Console.WriteLine("Giỏ hàng trống!");
                    Console.Write("\nNhấn phím bất kỳ để quay lại!");
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
        public void UserPurchased(Customers Cus)
        {
            Console.Clear();
            while (true)
            {
                List<Order> ListOrder;
                try
                {
                    Order_BL OBL = new Order_BL();
                    ListOrder = OBL.GetOrderByCustomerId(Cus.Cus_ID);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                if (ListOrder.Count <= 0)
                {
                    Console.WriteLine("Danh sách trống !\n");
                    Console.Write("Nhấn phím bất kỳ để quay lại trang chính!");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
                Console.WriteLine("==========================================================================================================");
                Console.WriteLine("                                             Danh sách sản phẩm đã mua");
                Console.WriteLine("==========================================================================================================\n");
                Console.WriteLine("+----------------+--------------------+------------------------------------------+------------------------+");
                Console.WriteLine("| {0,-15}|    {1,-16}|          {2,-21}           |   {3,-21}|", "Mã đơn hàng", "Ngày đặt hàng", "Địa chỉ giao hàng", "Trạng thái thanh toán");
                Console.WriteLine("+----------------+--------------------+------------------------------------------+------------------------+");
                foreach (Order order in ListOrder)
                {
                    Console.WriteLine("|      {0,-7}   |     {1,-15}| {2,-41}|  {3,-22}|", order.Order_ID, order.Order_Date.ToString("dd/MM/yyyy"), order.Address_Shipping, order.Status);
                    Console.WriteLine("+----------------+--------------------+------------------------------------------+------------------------+");
                }
                int Count = ListOrder.Count;
                while (true)
                {
                    string[] choice = { "Xem chi tiết đơn hàng", "Quay lại" };
                    int number = Product.SubMenu(null, choice);
                    switch (number)
                    {
                        case 1:
                            int orderid;
                            while (true)
                            {
                                Console.Write("Nhập mã đơn hàng: ");
                                bool isINT = Int32.TryParse(Console.ReadLine(), out orderid);
                                if (!isINT)
                                {
                                    Console.WriteLine("Giá trị nhập vào phải là số!");
                                    continue;
                                }
                                else if (orderid > 0 && orderid <= Count)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Mã đơn hàng không hợp lệ");
                                    continue;
                                }
                            }
                            Order_BL OBL = new Order_BL();
                            Order order = new Order();
                            try
                            {
                                order = OBL.GetOrderDetailsByOrderId(orderid);
                            }
                            catch (System.Exception ex)
                            {
                                Console.WriteLine(ex);
                                Console.ReadKey();
                                UserMenu(Cus);
                            }
                            if (order.Status == "Không thành công")
                            {
                                Console.WriteLine("Do đơn hàng này chưa đặt hàng thành công nên không có hóa đơn !");
                                Console.WriteLine("Nhấn phím bất kỳ để trở lại!");
                                Console.ReadKey();
                                continue;
                            }
                            else
                            {
                                Paybill(Cus, orderid);
                            }
                            break;
                        case 2:
                            UserMenu(Cus);
                            break;
                    }
                }
            }
        }

        public void CreateOrder(Customers Cus, List<Items> ListItems, int total)
        {
            Console.Clear();
            if (Cus.User_Name == null && Cus.User_Password == null)
            {
                Console.Write("Bạn cần đăng nhập để thanh toán!\nBạn có muốn đăng nhập không ? (Y/N): ");
                string select = Console.ReadLine().ToUpper();
                while (true)
                {
                    if (select != "Y" && select != "N")
                    {
                        Console.Write("Bạn có muốn đăng nhập không? (Y/N): ");
                        select = Console.ReadLine().ToUpper();
                        continue;
                    }
                    break;
                }
                if (select == "Y" || select == "y")
                {
                    LoginToPay(Cus, ListItems, total);
                }
                else
                {
                    DisplayCart(Cus);
                }
            }
            else
            {
                if (File.Exists($"CartOf{Cus.User_Name}.dat"))
                {
                    List<Items> Items = new List<Items>();
                    FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                    BinaryReader br = new BinaryReader(fs);
                    string str = br.ReadString();
                    Items = JsonConvert.DeserializeObject<List<Items>>(str);
                    fs.Close();
                    br.Close();
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine($"                                                      Giỏ hàng");
                    Console.WriteLine("================================================================================================================================\n");
                    Console.WriteLine("+-------------+-----------------------------------+----------------+------------+-----------------+----------+------------------+");
                    Console.WriteLine("| {0,-12}|           {1,-24}|      {2,-10}| {3,-11}|    {4,-6}      | {5,-9}| {6,-17}|", "Mã sản phẩm", "Tên sản phẩm", "Hãng", "Thuộc tính", "Đơn giá", "Số lượng", "Thành tiền");
                    Console.WriteLine("+-------------+-----------------------------------+----------------+------------+-----------------+----------+------------------+");
                    foreach (Items i in Items)
                    {
                        Console.WriteLine("|      {0,-7}| {1,-34}| {2,-15}| {3,-11}| {4,-16}|    {5,-6}|  {6,-16}|", i.Produce_Code, i.Item_Name, i.Trademark, i.Attribute, FormatMoney(i.Item_Price), i.Quantity, FormatMoney(i.Item_Price * i.Quantity));
                        Console.WriteLine("+-------------+-----------------------------------+----------------+------------+-----------------+----------+------------------+");
                    }
                    Console.WriteLine("|    Tổng tiền                                                                                               |  {0,-15} |", FormatMoney(total));
                    Console.WriteLine("+-------------------------------------------------------------------------------------------------------------------------------+");
                }
                else
                {
                    Console.WriteLine("Giỏ hàng trống!");
                    Console.Write("\nNhấn phím bất kỳ để quay lại!");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
                bool check = true;
                Order order = new Order();
                Order_BL OBL = new Order_BL();
                Console.Write("Nhập địa chỉ giao hàng: ");
                string address_Shipping = Console.ReadLine().Trim();
                if (address_Shipping.Length == 0)
                {
                    order.Address_Shipping = Cus.Cus_Address;
                }
                else
                {
                    order.Address_Shipping = address_Shipping;
                }
                Console.WriteLine("Địa chỉ giao hàng: {0}", order.Address_Shipping);
                order.Order_Date = DateTime.Now;
                order.Status = "Không thành công";
                order.Customer = Cus;
                Item_BL IBL = new Item_BL();
                order.ItemsList = new List<Items>();
                order.ItemsList = ListItems;
                check = OBL.CreateOrder(order);
                if (check == true)
                {
                    Console.WriteLine("Đặt hàng thành công!");
                    while (true)
                    {
                        string[] a = { "Thanh toán", "Hủy đơn hàng" };
                        int select = Product.SubMenu(null, a);
                        switch (select)
                        {
                            case 1:
                                Pay(Cus, order, total);
                                break;
                            case 2:
                                try
                                {
                                    check = OBL.DeleteOrder(order.Order_ID);
                                }
                                catch (System.Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                DisplayCart(Cus);
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n Đặt hàng thất bại!\n");
                    Console.WriteLine("Nhấn phím bất kỳ để quay lại trang chính!");
                    Console.ReadKey();
                    UserMenu(Cus);
                }
            }
        }
        public void Pay(Customers Cus, Order order, int total)
        {
            int money;
            Order_BL OBL = new Order_BL();
            while (true)
            {
                Console.Write("Nhập số tiền : ");
                bool isINT = Int32.TryParse(Console.ReadLine(), out money);
                if (!isINT)
                {

                    Console.WriteLine("Số tiền nhập vào không hợp lệ !");
                    Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
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
                            Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
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
                else if (money < 500 || money > 50000000)
                {
                    Console.WriteLine("Số tiền bạn nhập vào không hợp lệ !");
                    continue;
                }
                else
                {
                    if (money >= total)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Số tiền bạn nhập vào nhỏ hơn tổng số tiền phải thanh toán !");
                        continue;
                    }
                }
            }
            bool UpdateStatus = OBL.UpdateStatus(order.Order_ID);
            if (UpdateStatus == true)
            {
                Console.WriteLine("Thanh toán thành công !");
                Console.WriteLine("Tiền thừa : {0}", FormatMoney(money - total));
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
                Console.Write("Nhấn phím bất kỳ để in hóa đơn!");
                Console.ReadKey();
                Paybill(Cus, order.Order_ID);
            }
            else
            {
                Console.WriteLine("Thanh toán thất bại !");
                Console.Write("Nhấn phím bất kỳ để quay lại giỏ hàng!");
                Console.ReadKey();
                DisplayCart(Cus);
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

            Console.Write("Nhập mã sản phẩm cần xóa khỏi giỏ hàng : ");
            int id = Product.input(Console.ReadLine());
            int index = ListItems.FindIndex(x => x.Produce_Code == id);
            if (index == -1)
            {
                Console.WriteLine("Mã sản phẩm không tồn tại trong giỏ hàng!");
                Console.Write("Bạn có muốn nhập lại không ? (Y/N): ");
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
                    Console.Write("Nhập mã sản phẩm cần xóa khỏi giỏ hàng : ");
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
                        Console.WriteLine("Đã xóa sản phẩm!");
                        Console.ReadKey();
                        UserMenu(Cus);
                    }
                    else
                    {
                        Console.WriteLine("Giỏ hàng không tồn tại");
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
                    fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write((string)(object)sJSONReponse);
                    fs.Close();
                    Console.WriteLine("Đã xóa sản phẩm!");
                    Console.ReadKey();
                    DisplayCart(Cus);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Không xóa được sản phẩm!");
                    Console.ReadKey();
                    DisplayCart(Cus);
                }
            }
        }
        public void Paybill(Customers Cus, int? orderId)
        {
            Console.Clear();
            Order_BL OBL = new Order_BL();
            Order order = new Order();
            int total = 0;
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
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("|                                HÓA ĐƠN THANH TOÁN                             |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                      Ngày {0,-2} tháng {1,-2} năm {2, -5}                               |", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("|Tên khách hàng : {0,-35}                           |", order.Customer.Cus_Name);
            Console.WriteLine("|Địa chỉ : {0,-55}              |", order.Customer.Cus_Address);
            Console.WriteLine("+----------------------------------+----------------+----------+----------------+");
            Console.WriteLine("|{0,-34}|{1,-16}|{2,-10}|{3,-16}|", "Tên sản phẩm", "Đơn giá", "Số lượng", "Thành tiền");
            Console.WriteLine("+----------------------------------+----------------+----------+----------------+");
            foreach (var i in order.ItemsList)
            {
                total += i.Item_Price * i.Quantity;
                string format = string.Format($"|{i.Item_Name,-34}|{FormatMoney(i.Item_Price),-16}|{i.Quantity,-10}|{FormatMoney(i.Item_Price * i.Quantity),-16}|");
                Console.WriteLine(format);
                Console.WriteLine("+----------------------------------+----------------+----------+----------------+");
            }
            Console.WriteLine("|    Tổng tiền ( Đã bao gồm thuế VAT )                         |{0,-16}|", FormatMoney(total));
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("|        Người mua hàng                                                         |");
            Console.WriteLine("|            {0,-7}                                                            |    ", Cus.User_Name);
            Console.WriteLine("|       {0,-20}                                                    |", order.Customer.Cus_Name);
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("Nhấn phím bất kỳ để quay lại trang chính!");
            Console.ReadKey();
            UserMenu(Cus);
        }
        public string FormatMoney(int Price)
        {
            string a = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", Price);
            return a;
        }
        public void LoginToPay(Customers Cus, List<Items> ListItems, int total)
        {
            Menu m = new Menu();
            Customer_BL CusBL = new Customer_BL();
            Cus = new Customers();
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
                    Console.Write("Tên đăng nhập hoặc mật khẩu không được chứa ký tự đặc biệt!\nBạn có muốn nhập lại không? (Y/N): ");
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
                            m.menu();
                            break;
                        case "n":
                            m.menu();
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
                            m.menu();
                            break;
                        case "n":
                            m.menu();
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
                            m.menu();
                            break;
                        case "n":
                            m.menu();
                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    if (File.Exists($"CartOf{Cus.User_Name}.dat"))
                    {
                        FileStream fsreader = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.Open, FileAccess.ReadWrite);
                        BinaryReader br = new BinaryReader(fsreader);
                        string str = br.ReadString();
                        List<Items> ListItems2 = JsonConvert.DeserializeObject<List<Items>>(str);
                        fsreader.Close();
                        br.Close();
                        ListItems.AddRange(ListItems2);
                        for (int i = 0; i < ListItems.Count; i++)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if (ListItems[i].Produce_Code == ListItems[j].Produce_Code)
                                {
                                    ListItems[i].Quantity += ListItems[j].Quantity;
                                    ListItems.RemoveAt(j);
                                }
                            }
                        }
                        FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        BinaryWriter bw = new BinaryWriter(fs);
                        string sJSONReponse = JsonConvert.SerializeObject(ListItems);
                        bw.Write((string)(object)sJSONReponse);
                        fs.Close();
                    }
                    else
                    {
                        FileStream fs = new FileStream($"CartOf{Cus.User_Name}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        BinaryWriter bw = new BinaryWriter(fs);
                        string sJSONReponse = JsonConvert.SerializeObject(ListItems);
                        bw.Write((string)(object)sJSONReponse);
                        fs.Close();
                    }
                }
                try
                {
                    if (File.Exists(Path.Combine($"CartOf.dat")))
                    {
                        File.Delete(Path.Combine($"CartOf.dat"));
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
                CreateOrder(Cus, ListItems, total);
            }
        }
    }
}