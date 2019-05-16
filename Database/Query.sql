drop database Headphone_Shop_Gr3;
Create database if not exists Headphone_Shop_Gr3;

use Headphone_Shop_Gr3;

create table if not exists Customers(
	Cus_ID int auto_increment primary key not null,
    Cus_Name nvarchar(50) not null,
    Cus_DateBirth date not null,
    Cus_Address nvarchar(100) not null,
    Cus_Email varchar(100) not null unique,
    Cus_Phone_Numbers char(20) not null,
    User_Name varchar(50) not null unique,
    User_Password varchar(15) not null
);

create table if not exists Items(
	Produce_Code varchar(250) not null primary key,
    Item_Name nvarchar(50) not null,
    Trademark nvarchar(50) not null,
    Attribute nvarchar(50) not null,
    Item_Price decimal(10,2) not null,
    Item_Description nvarchar(500) not null,
    Quantity int not null
);

create table if not exists Orders(
	Order_ID int not null,
    Cus_ID int not null,
    Order_Date  timestamp,
    Note nvarchar(500),
    primary key(Order_ID, Cus_ID),
    foreign key (Cus_ID) references Customers(Cus_ID)
);

create table if not exists OrderDetails(
	Order_ID int,
    Produce_Code varchar(250),
    Order_Count int not null,
    primary key(Order_ID, Produce_Code),
    foreign key (Order_ID) references Orders(Order_ID),
    foreign key (Produce_Code) references Items(Produce_Code)
);

insert into Customers(Cus_ID, Cus_Name, Cus_DateBirth, Cus_Address, Cus_Email, Cus_Phone_Numbers, User_Name, User_Password)
values('1','Nguyễn Anh Linh','1999/3/18','188 giải phóng','123@gmail.com','013354789712','NAL','nal123'),
	  ('2','Lý Bảo Thắng','1998/4/19','253 giải phóng','456@gmail.com','028975048976','LBT','lbt456'),
      ('3','Nguyễn Văn Dân','1998/5/20','385 Tam Trinh','789@gmail.com','089327184637','NVD','nvd789');

insert into Items(Produce_Code, Item_Name, Trademark, Attribute, Item_Price, Item_Description, Quantity)
values('1','Urbanista Tokyo plus TWS','Urbanista','không dây','2990000','Chíp Bluetooth 5.0 và 4h nghe nhạc liên tục cho 1 lần sạc đầy kết hợp cùng hộp đựng giúp tăng thời lượng sử dụng lên đến hơn 16h','100'),
	  ('2','Urbanista New York ANC Wireless','Urbanista','không dây','3990000','Công nghệ chống ồn chủ động với khả năng loại bỏ những âm thanh dưới 27 dB,hầu hết những tiếng ồn từ động cơ khi tham gia giao thông hay tiếng ồn ào nơi công sở sẽ được triệt tiêu.','100'),
      ('3','Urbanista Detroit Wireless','Urbanista','không dây','1890000','Với chíp bluetooth 4.2 với độ trễ thấp và khả năng kết nối ổn định trong phạm vi 10m','100'),
      ('4','Urbanista Chicago Wireless','Urbanista','thể thao','2190000','Được thiết kế hướng đến những vận động viên chuyên nghiệp,với 7h nghe nhạc liên tục cùng âm thanh sống động và khả năng bám tai tốt giúp bạn tự do và thoải mái khi vận động mạnh.','100'),
      ('5','Urbanista Milan ANC Wireless','Urbanista','không dây','3190000','Được thiết kế với chất lượng âm thanh vượt trội kết hợp với công nghệ chống ồn chủ động ANC giúp cách ly hoàn toàn với tiếng ồn môi trường bên ngoài.','100'),
      ('6','MEE audio X10','MEE','thể thao','2190000','Bluetooth 5.0 cho chất lượng truyền tải tốt nhất.Thời gian nghe nhạc liên tục cho 1 lần sạc đầy là 4,5h và có thể kéo dài đến 23h khi sử dụng chung với hộp đựng.','100'),
      ('7','MEE audio M6 PRO 2ND Wireless','MEE','không dây','2400000','Là một sản phẩm được thiết kế dành cho giới chuyên nghiệp: ca sĩ, nhạc sĩ, nhạc công với kiểu âm thanh monitor đặc trưng.','100'),
      ('8','MEE audio M6 PRO 2ND (2018)','MEE','không dây','1450000','M6 Pro 2ND sở hữu âm bass có độ trầm tốt hơn so với thế hệ đâu tiên,giúp chiếc tai nghe có khả năng chơi tạp tốt hơn trước.','100'),
      ('9','MEE audio X1 Sport','MEE','thể thao','680000','Được thiết kế giúp bạn cảm thấy thoải mái và tràn đầy âm nhạc khi chơi thể thao.','100'),
      ('10','MEE audio EarBoost EB1','MEE','không dây','2600000','Với ứng dụng EarBoost giúp tăng cường trải nghiệm người dùng một cách trọn vẹn nhất,với khả năng điều chỉnh chất âm theo điều kiện thính lực của từng người.','100'),
      ('11','RHA T20i','RHA AUDIO','In-Ear','4800000','Độ trung thực cao, chống ồn hiệu quả, công nghệ màng loa DualCoil','100'),
      ('12','RHA MA650','RHA AUDIO','In-Ear','1500000','Driver 380.1 mới được thiết kế giúp mang lại trải nghiệm âm thanh chất lượng cao, với độ chính xác và cân bằng.','100'),
      ('13','RHA MA390','RHA AUDIO','In-Ear','800000','Được thiết kế giúp bạn tận hưởng âm nhạc một cách thoải mái kể cả ở những môi trường ồn ào nhất,công nghệ Driver 130.8 cho âm bass siêu trầm nhưng vẫn giữ được độ trong sáng và chi tiết ở dải trung và cao','100'),
      ('14','RHA MA650 Wireless','RHA AUDIO','không dây','2500000','Sử dụng công nghệ Bluetooth 4.1 với bộ giải mã tín hiệu chất lượng cao  aptX và AAC,Thời gian nghe nhạc liên tục lên đến 12h','100'),
      ('15','RHA MA750 Wireless','RHA AUDIO','không dây','3990000','Công nghệ chống ồn thụ động Noise isolating độc quyền của RHA dựa trên thiết kế Aerophonic và Khả năng chống nước IPX4','100'),
      ('16','Jabees Beebud True Wireless','jabees','không dây','1280000','Với Bluetooth 5.0, cùng chip xử lý điều khiển tiên tiến giúp bạn thao tác được nhiều chức năng trên tai nghe hơn.','100'),
      ('17','Jabees Firefly True Wireless','jabees','không dây','1980000','Với Bluetooth 5.0, công nghệ tự cân bằng âm thanh 2 bên tai nghe, công nghệ sạc nhanh chỉ 10p cho 2 tiếng nghe nhạc liên tục và chỉ mất 30p cho 1 lần sạc đầy.','100'),
      ('18','Jabees Beez True Wireless','jabees','không dây','1580000','Với Bluetooth 5.0,Beez được tích hợp công nghệ sạc nhanh với 10p sạc cho 2h nghe nhạc liên tục và 30p sạc cho 4h nghe nhạc.','100'),
      ('19','Jabees BTwins True Wireless','jabees','không dây','1890000','Với Bluetooth V4.1 và EDR cho chất lượng âm thanh trung thực cùng độ chi tiết cao, với âm trầm sâu và trung âm rõ ràng, treble đầy đủ, là một sản phẩm tuyệt vời cho đi bộ, chạy bộ, đi xe đạp, phòng tập thể dục và một số hoạt động khác','100'),
      ('20','Jabees Duobees Wireless','jabees','không dây','800000','Với Bluetooth 5.0, công nghệ Driver kép trong đó 1 driver đảm nhiệm dải mid và treb còn 1 Driver đảm nhiệm dải trầm. Sự kết hợp này giúp chiếc tai nghe có độ chi tiết tốt hơn, tách bạch hơn, kết nối ổn định và độ trễ thấp.','100'),
      ('21','Sony WI 1000X Noise Canceling','SONY','không dây','6990000','Tích hợp công nghệ chống ồn chủ động Noise Canceling, âm thanh được tạo một cách trung thực nhờ công nghệ Hi-res độc quyền của SONY. Tích hợp microphone đàm thoại và kết nối 1 chạp NFC. Có thể kết nối với điện thoại qua jack cắm 3.5 tháo rời,Thời lượng nghe nhạc liên tục lên đến 10h','100'),
      ('22','Sony Wi C400 Wireless','SONY','không dây','1490000','Thiết Kế dành cho điện thoại di động, máy tính bảng, máy nghe nhạc...Hỗ trợ kết nối Bluetooth tích hợp NFC.Thời gian sử dụng liên tục lên đến 20 giờ, thời gian sạc 4.5 giờ','100'),
      ('23','Sony WI-SP500 Wireless','SONY','không dây','1890000','Được thiết kế dành cho người chơi thể thao. Kết nối bluetooth 4.2 mới nhất.Thời gian nghe nhạc liên tục 8h và thời gian pin chờ lên đến 200h. Tích hợp Microphone đàm thoại tiện lợi. Chống mồ hôi theo tiêu chuẩn IPX4','100'),
      ('24','Sony WI-C300 Wireless','SONY','không dây','1190000 ','Thiết kế dành cho điện thoại di động, máy tính bảng, máy nghe nhạc...Hỗ trợ kết nối Bluetooth tích hợp NFC. Thời gian sử dụng liên tục lên đến 8 giờ, thời gian sạc 2 giờ','100'),
      ('25','SONY WI-SP600N Wireless','SONY','không dây','3190000','Với Bluetooth 4.2, kết nối nhanh 1 chạm NFC, chống ồn chủ động, màng loa Extra-bass.Khả năng chống nước theo tiêu chuẩn IPX4 và thời lượng pin nghe nhạc liên tục lên đến 6h.Ngoài ra, còn được tích hợp cụm phím điều khiển tiện lợi, với microphone đàm thoại chất lượng HD','100'),
      ('26','Somic G955 Gameing Headset 7.1','SOMIC','Gaming','900000','Được tích hợp soundcard giả lập âm thanh 7.1 giúp tăng cường trải nghiệm trong Game. Microphone kỹ thuật số cực nhạy với khả năng loại bỏ tạp âm','100'),
	  ('27','Somic G618i','SOMIC','Gaming','580000','Tai nghe chơi game Somic G618i được thiết kế giúp game thủ chơi đạt thành tích cáo nhất. Phần Ear-hok được thiết kế giúp chiếc tai nghe có thể gắn chặt trên tai người dùng đồng thời không gây cảm giắc khó chịu khi sử dụng trong thời gian dài.','100'),
      ('28','Somic G618 PRO Wireless','SOMIC','Gaming','980000','Công nghệ Bluetooth 4.1 và bộ giải mã APTX cho âm thanh được truyền tải 1 cách trung thực với độ trễ thấp. Được tích hợp 2 microphone giúp đạt chất lượng đàm thoại tốt nhất với khả năng lọc tiến ồn cao hơn. Thời gian nghe nhạc và đàm thoại liên tục lên đến 8h','100'),
      ('29','Somic G954 V7.1 có rung','SOMIC','Gaming','950000','Công nghệ giả lập âm thanh vòm 7.1 giúp tăng cường tính thực tế và rõ nét trong game giúp game thủ xác định chính xác các vị trí. Công nghệ rung thông minh SVE thế hệ mới mang lại trải nghiệm hoàn toàn mới mẻ và thú vị','100'),
      ('30','Somic G951 pink','SOMIC','TGaming','1350000','Giả lập âm thanh 7.1 cao cấp của Somic, tích hợp hệ thống đèn led tai mèo với hiệu ứng led nhịp hơi thở đẹp mắt,chế độ rung sử dụng AI tăng cường trải nghiệm trong game. Thích hợp cho các bạn nữ chơi game, chụp ảnh, nghe nhạc, livestream, xem phim. Đệm tai cỡ lớn giúp người dùng thoải mái trong nhiều giờ sử dụng.','100'),
      ('31','Sennheiser Momentum Free','Sennheiser','không dây','5190000','là chiếc tai nghe Bluetooth nhỏ gọn nhất của Sennheiser từ trước đến nay.Âm thanh hi-fi tinh tế nhờ công nghệ Bluetooth 4.2 và Qualcomm apt-X, tích hợp microphone, thời lượng pin 6h','100'),
      ('32','Sennheiser CX 7.00 BT','Sennheiser','In-Ear','4020000','Sử dụng Bluetooth 4.1 và bộ giải mã tín hiệu APTX mới nhất.Hỗ trợ kết nối nhanh 1 chạm NFC. Hỗ trợ kết nối cùng lúc với 2 thiết bị phát. Tích hợp microphone.','100'),
      ('33','Sennheiser CX 6.00BT','Sennheiser','thể thao','2540000','Bluetooth 4.2 và Qualcomm apt-X và Qualcomm apt-X Low Latency giúp cho âm thanh có độ chân thực, sắc nét. Mất 1,5h để sạc đầy pin, cho thời gian nghe khoảng 6h. Chỉ cần sạc 10p là có thể sử dụng thêm 2h.Được tích hợp microphone.','100'),
      ('34','Sennheiser CX SPORT','Sennheiser','thể thao','3490000','Có khả năng chống nước, mồ hôi, kết nối có độ ổn định cao và độ thoải mái khi sử dụng. Bluetooth 4.2 cho phép kết nối với 2 thiết bị cùng lúc. Thời lượng pin 6h và sạc nhanh 10p nghe được 1h. Qualcomm apt-X cho âm thanh Hi-Fi chân thực và Qualcomm apt-X Low Latency độ trễ thấp để giữ âm thanh đồng bộ.','100'),
      ('35','Sennheiser Momentum TWS','Sennheiser','không dây','8990000','Tích hợp Bluetooth 5.0, trang bị Driver độc quyền, công nghệ Qualcomm aptX Low Latency giúp âm thanh đạt chi tiết cao và độ trễ thấp. Transparent Hearing với 2 microphone thu lại tiếng ồn của môi trường giúp cảm nhận rõ hơn tiếng động xung quanh. Thời lượng pin 4h và có thể lên 12h nếu dùng chung với dock sạc.','100'),
      ('36','Audio Techncia ATH CKR35BT','Audio Technica','không dây','1750000','Bluetooth: 4.1, Codec hỗ trợ: AAC, SBC. Thời gian sạc: 3h, Thời gian sử dụng pin: 7h liên tiếp','100'),
      ('37','Audio Technica ATH CKR55BT','Audio Technica','không dây','2890000','Bluetooth: 4.1, Codec hỗ trợ: AAC, SBC. Thời gian sạc: 3h, Thời gian sử dụng pin: 7h liên tiếp','100'),
      ('38','Audio Technica ATH CKR75BT','Audio Technica','không dây','3690000','Bluetooth: 4.1, Codec hỗ trợ: AAC, SBC. Thời gian sạc: 3h, Thời gian sử dụng pin: 7h liên tiếp','100'),
      ('39','Audio Technica ATH ck330is','Audio Technica','không dây','790000','Được làm cho Smartphone, với mic đàm thoại cực nhậy được tích hợp ngay trên dây dẫn.','100'),
      ('40','Audio Technica ATH-CKR30iS','Audio Technica','không dây','900000','Có microphone khi nghe nhạc và nhận cuộc gọi trên Smartphone. Âm thanh mạnh mẽ rõ nét và tự nhiên nhờ Driver 9,8mm. Dải tần số: 5 – 24,000 Hz.Công xuất cực đại: 200 mW.','100'),
      ('41','Skullcandy 50/50 w/Mic','Skullcandy','Earbud','1150000','Nhận cuộc gọi dễ dàng. Chất lượng âm thanh tuyệt vời. Thiết kế nhỏ gọn và dây dẹt chống rối. Cách âm hoàn hảo. Tương thích với smartphone, ipod, Macs, Laptop, và các thiết bị MP3.','100'),
      ('42','Skullcandy Smokin Buds 2 Wireless','Skullcandy','không dây','1660000','Buds 2 wireless nổi bật với khả năng cách li tiếng ồn tốt và sử thoải mái khi nghe nhạc trong nhiều giờ liên tục giúp cho người chơi thể thao hay hoạt động vui chơi giải trí. Thời gian pin nghe nhạc liên tục lên đến 6h.','100'),
      ('43','Skullcandy Inkd Wireless','Skullcandy','không dây','1150000','Thời gian pin nghe nhạc liên tục lên đến 8h, kèm theo microphone đàm thoại và cụm tăng giảm âm lượng giúp tai nghe trở nên năng động và tiện lợi hơn.','100'),
      ('44','Skullcandy Grind Wireless','Skullcandy','không dây','1850000','Được thiết kế cho nhu cầu nghe nhạc chất lượng cao ở bất cứ nơi đâu. Bluetooth 4.1 và microphone đàm thoại tiện lợi hơn với Smartphone. Thời gian nghe nhạc liên tục lên đến 12h. Tích hợp thêm dây dẫn tháo rời có thể nghe nhạc khi hết pin.','100'),
      ('45','Skullcandy Jib Wireless','Skullcandy','In-Ear','920000','Tích hợp Bluetooth và công nghệ lọc âm thụ động. Thời gian sử dụng 6h liên tiếp.','100'),
      ('46','Ausdom SP007 Wireless','Ausdom','không dây','499000','Bluetooth 4.1. Tích hợp microphone đàm thoại. Nghe nhạc liên tục 7h, đàm thoại liên tục 8h cho 1 lần sạc đầy pin Bán kinh bắt sóng ổn định trong phạm vi 8m.','100'),
      ('47','AUSDOM M08 Wireless','Ausdom','không dây','990000','Sử dụng driver dynamic, tích hợp công nghệ bluetooth 4.0 bắt sóng ổn định trong phạm vi bán kính 10m, thời lượng pin lên đến 20h. Tích hợp microphone đàm thoại và có thể nghe nhạc thông qua kết nối dây dẫn truyền thống khi tai nghe hết pin.','100'),
      ('48','Ausdom AH861 Wireless','Ausdom','không dây','790000','Với chức năng chia sẻ nhạc cho một chiếc tai nghe AH861 khác ở cạnh nó, hai người gần nhau có thể cùng nghe chung 1 bài hát mà chỉ cần sử dụng 1 thiết bị phát duy nhất. Ngoài ra cũng được trang bị Bluetooth 4.1, microphone đàm thoại... Thiết kế trẻ trung, năng động, có thể nghe nhạc nhiều giờ liên tục mà không bị mỏi.','100'),
      ('49','1More EB100 Wireless','1More','thể thao','1500000','','100'),
      ('50','1More iBFree','1More','không dây','1150000','Thời lượng pin lên đến 8h, nói chuyện liên tục 10h chỉ mất 2h để sạc đầy pin. Có khả năng chống thấm mồ hôi và nước theo tiêu chuẩn IPX4. Kết nối bluetooth 4.1 và công nghệ giải mã tín hiệu APTX thế hệ mới nhất, với bán kính bắt sóng ổn định là 10m.','100');