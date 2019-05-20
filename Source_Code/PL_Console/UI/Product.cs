using System;
namespace UI
{
    class Product : Menu
    {
        public void DisplayProduct()
        {
            Console.Clear();
            int number;
            Console.WriteLine("======================================= \n");
            Console.WriteLine("Menu sản phẩm");
            Console.WriteLine("1. Xem danh sách sản phẩm theo hãng");
            Console.WriteLine("2. Xem danh sách sản phẩm theo phân loại sản phẩm");
            Console.WriteLine("0. Trở về menu chính \n");
            Console.Write("#chọn: ");

            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("bạn đã nhập sai");
                    Console.WriteLine("#chọn: ");
                }
                else if (number < 0 || number > 2)
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
                case 1:
                    DisplayTradeMark();
                    break;
                case 2:
                    DisplayAttribute();
                    break;
            }
        }


        public void DisplayTradeMark()
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
                    Console.WriteLine("bạn đã nhập sai");
                    Console.WriteLine("#chọn: ");
                }
                else if (number < 0 || number > 11)
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
                    DisplayProduct();
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

        public void DisplayAttribute()
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
            Console.Write("#chọn: ");

            while (true)
            {
                bool kt = Int32.TryParse(Console.ReadLine(), out number);
                if (kt == false)
                {
                    Console.WriteLine("bạn đã nhập sai");
                    Console.WriteLine("#chọn: ");
                }
                else if (number < 0 || number > 5)
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
                    DisplayProduct();
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
                    DisplayTradeMark();
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
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayTradeMark();
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
            
            switch(number)
            {
                case 0:
                    DisplayAttribute();
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
            
            switch(number)
            {
                case 0:
                    DisplayAttribute();
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
            
            switch(number)
            {
                case 0:
                    DisplayAttribute();
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
            
            switch(number)
            {
                case 0:
                    DisplayAttribute();
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
            
            switch(number)
            {
                case 0:
                    DisplayAttribute();
                    break;
            }
        }

        //==================================================//        
    }
}