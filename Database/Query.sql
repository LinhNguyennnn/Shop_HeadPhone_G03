<<<<<<< HEAD
drop database Headphone_Shop_Gr3;
Create database if not exists Headphone_Shop_Gr3;
=======
-- drop database Headphone_Shop_Gr3;
Create database Headphone_Shop_Gr3;
>>>>>>> 9f56d50a6b8ca7b85ad4b40897b5f48e10c0498b
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
    Item_Description nvarchar(250) not null,
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


insert into Items(Produce_Code, Item_Name, Trademark, Attribute, Item_Price, Item_Description, Quantity)
values ();