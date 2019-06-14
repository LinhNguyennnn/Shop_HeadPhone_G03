 drop database Headphone_Shop_Gr3;

Create database if not exists Headphone_Shop_Gr3;

use Headphone_Shop_Gr3;

-- select * from Orders;

create table if not exists Customers(
	Cus_ID int auto_increment primary key,
    Cus_Name nvarchar(50) not null,
    Cus_DateBirth date not null,
    Cus_Address nvarchar(100) not null,
    Cus_Email varchar(100) not null unique,
    Cus_Phone_Numbers char(20) not null,
    User_Name varchar(50) not null unique,
    User_Password varchar(15) not null
);

create table if not exists Items(
	Produce_Code int auto_increment primary key,
    Item_Name nvarchar(50) not null,
    Trademark nvarchar(50) not null,
    Attribute nvarchar(50) not null,
    Item_Price int not null,
    Item_Description nvarchar(500) not null
);
create table if not exists Orders(
	Order_ID int auto_increment,
    Cus_ID int not null,
    Order_Status nvarchar(50),
    Order_Date  timestamp,
    Address_Shipping nvarchar(500),
    primary key(Order_ID, Cus_ID),
    foreign key (Cus_ID) references Customers(Cus_ID)
);

create table if not exists OrderDetails(
	Order_ID int,
    Produce_Code int,
    Quantity int,
    primary key(Order_ID, Produce_Code),
    foreign key (Order_ID) references Orders(Order_ID),
    foreign key (Produce_Code) references Items(Produce_Code)
);

insert into Customers(Cus_Name, Cus_DateBirth, Cus_Address, Cus_Email, Cus_Phone_Numbers, User_Name, User_Password)
values('Nguyễn Anh Linh','1999/03/18','Lập Trí - Minh Trí - Sóc Sơn - Hà Nội','linhna.nde18090@vtc.edu.com','013354789712','Linh','nal123'),
	  ('Lý Bảo Thắng','1998/04/19','253 giải phóng','456@gmail.com','028975048976','Thang','lbt456'),
      ('Nguyễn Văn Dân','1998/05/20','385 Tam Trinh','789@gmail.com','089327184637','Dan','nvd789');

insert into Items( Item_Name, Trademark, Attribute, Item_Price, Item_Description)
values('Urbanista Tokyo plus TWS','Urbanista','Không dây','2990000','Chíp Bluetooth 5.0 và 4h nghe nhạc liên tục cho 1 lần sạc đầy kết hợp cùng hộp đựng giúp tăng thời lượng sử dụng lên đến hơn 16h'),
      ('MEE audio X10','MEE','Thể thao','2190000','Bluetooth 5.0 cho chất lượng truyền tải tốt nhất.Thời gian nghe nhạc liên tục cho 1 lần sạc đầy là 4,5h và có thể kéo dài đến 23h khi sử dụng chung với hộp đựng.'),
      ('MEE audio M6 PRO 2ND (2018)','MEE','Không dây','1450000','M6 Pro 2ND sở hữu âm bass có độ trầm tốt hơn so với thế hệ đâu tiên,giúp chiếc tai nghe có khả năng chơi tạp tốt hơn trước.'),
      ('RHA MA650','RHA AUDIO','In-Ear','1500000','Driver 380.1 mới được thiết kế giúp mang lại trải nghiệm âm thanh chất lượng cao, với độ chính xác và cân bằng.'),
      ('RHA MA750 Wireless','RHA AUDIO','Không dây','3990000','Công nghệ chống ồn thụ động Noise isolating độc quyền của RHA dựa trên thiết kế Aerophonic và Khả năng chống nước IPX4'),
      ('Jabees Duobees Wireless','jabees','Không dây','800000','Với Bluetooth 5.0, công nghệ Driver kép trong đó 1 driver đảm nhiệm dải mid và treb còn 1 Driver đảm nhiệm dải trầm. Sự kết hợp này giúp chiếc tai nghe có độ chi tiết tốt hơn, tách bạch hơn, kết nối ổn định và độ trễ thấp.'),
      ('Sony WI 1000X Noise Canceling','SONY','Không dây','6990000','Tích hợp công nghệ chống ồn chủ động Noise Canceling, âm thanh được tạo một cách trung thực nhờ công nghệ Hi-res độc quyền của SONY. Tích hợp microphone đàm thoại và kết nối 1 chạp NFC. Có thể kết nối với điện thoại qua jack cắm 3.5 tháo rời,Thời lượng nghe nhạc liên tục lên đến 10h'),
      ('Sony Wi C400 Wireless','SONY','Không dây','1490000','Thiết Kế dành cho điện thoại di động, máy tính bảng, máy nghe nhạc...Hỗ trợ kết nối Bluetooth tích hợp NFC.Thời gian sử dụng liên tục lên đến 20 giờ, thời gian sạc 4.5 giờ'),
      ('Somic G955 Gameing Headset 7.1','SOMIC','Gaming','900000','Được tích hợp soundcard giả lập âm thanh 7.1 giúp tăng cường trải nghiệm trong Game. Microphone kỹ thuật số cực nhạy với khả năng loại bỏ tạp âm'),
	  ('Somic G618i','SOMIC','Gaming','580000','Tai nghe chơi game Somic G618i được thiết kế giúp game thủ chơi đạt thành tích cáo nhất. Phần Ear-hok được thiết kế giúp chiếc tai nghe có thể gắn chặt trên tai người dùng đồng thời không gây cảm giắc khó chịu khi sử dụng trong thời gian dài.'),
      ('Sennheiser Momentum Free','Sennheiser','Không dây','5190000','là chiếc tai nghe Bluetooth nhỏ gọn nhất của Sennheiser từ trước đến nay.Âm thanh hi-fi tinh tế nhờ công nghệ Bluetooth 4.2 và Qualcomm apt-X, tích hợp microphone, thời lượng pin 6h'),
      ('Sennheiser CX 7.00 BT','Sennheiser','In-Ear','4020000','Sử dụng Bluetooth 4.1 và bộ giải mã tín hiệu APTX mới nhất.Hỗ trợ kết nối nhanh 1 chạm NFC. Hỗ trợ kết nối cùng lúc với 2 thiết bị phát. Tích hợp microphone.'),
      ('Sennheiser CX 6.00BT','Sennheiser','Thể thao','2540000','Bluetooth 4.2 và Qualcomm apt-X và Qualcomm apt-X Low Latency giúp cho âm thanh có độ chân thực, sắc nét. Mất 1,5h để sạc đầy pin, cho thời gian nghe khoảng 6h. Chỉ cần sạc 10p là có thể sử dụng thêm 2h.Được tích hợp microphone.'),
      ('Audio Techncia ATH CKR35BT','Audio Technica','Không dây','1750000','Bluetooth: 4.1, Codec hỗ trợ: AAC, SBC. Thời gian sạc: 3h, Thời gian sử dụng pin: 7h liên tiếp'),
      ('Skullcandy 50/50 w/Mic','Skullcandy','Earbud','1150000','Nhận cuộc gọi dễ dàng. Chất lượng âm thanh tuyệt vời. Thiết kế nhỏ gọn và dây dẹt chống rối. Cách âm hoàn hảo. Tương thích với smartphone, ipod, Macs, Laptop, và các thiết bị MP3.'),
      ('Skullcandy Smokin Buds 2 Wireless','Skullcandy','Không dây','1660000','Buds 2 wireless nổi bật với khả năng cách li tiếng ồn tốt và sử thoải mái khi nghe nhạc trong nhiều giờ liên tục giúp cho người chơi Thể thao hay hoạt động vui chơi giải trí. Thời gian pin nghe nhạc liên tục lên đến 6h.'),
      ('Skullcandy Jib Wireless','Skullcandy','In-Ear','920000','Tích hợp Bluetooth và công nghệ lọc âm thụ động. Thời gian sử dụng 6h liên tiếp.'),
      ('Ausdom AH861 Wireless','Ausdom','Không dây','790000','Với chức năng chia sẻ nhạc cho một chiếc tai nghe AH861 khác ở cạnh nó, hai người gần nhau có thể cùng nghe chung 1 bài hát mà chỉ cần sử dụng 1 thiết bị phát duy nhất. Ngoài ra cũng được trang bị Bluetooth 4.1, microphone đàm thoại... Thiết kế trẻ trung, năng động, có thể nghe nhạc nhiều giờ liên tục mà không bị mỏi.'),
      ('1More EB100 Wireless','1More','Thể thao','1500000','Thời lượng pin lên đến 8h, nói chuyện liên tục 10h chỉ mất 2h để sạc đầy pin. Có khả năng chống thấm mồ hôi và nước theo tiêu chuẩn IPX4. Kết nối bluetooth 4.1 và công nghệ giải mã tín hiệu APTX thế hệ mới nhất, với bán kính bắt sóng ổn định là 10m.'),
      ('1More iBFree','1More','Không dây','1150000','Thời lượng pin lên đến 8h, nói chuyện liên tục 10h chỉ mất 2h để sạc đầy pin. Có khả năng chống thấm mồ hôi và nước theo tiêu chuẩn IPX4. Kết nối bluetooth 4.1 và công nghệ giải mã tín hiệu APTX thế hệ mới nhất, với bán kính bắt sóng ổn định là 10m.');

-- select * from Items where Produce_Code = '1' and Trademark = '';
-- select distinct Trademark from Items;
/*CREATE USER if not exists 'HP_User'@'localhost' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON * . * TO 'HP_User'@'localhost'; */


