use master;
go
if exists (select name from sys.databases where name = 'FlashyCarbon_DB')
begin
	drop database FlashyCarbon_DB;
end;
go
create database FlashyCarbon_DB;
go
use FlashyCarbon_DB;
go

--=====================================================================
create table [Account]
(
	Id uniqueidentifier default newid() primary key,
	Email nvarchar(100) unique,
	[Password] nvarchar(max),
	AvatarUrl nvarchar(max),
	[TimeStamp] datetime,
	[Role] int,--1:Admin   2:Manager   3:Sales-Staff   4:Delivery-Staff   5:Customer
	[Status] nvarchar(20)
);
go

create table [Customer]
(
	Id uniqueidentifier default newid() primary key,
	Fullname nvarchar(100),
	[Address] nvarchar(max),
	PhoneNumber nvarchar(15) unique,
	Point int,

	AccountId uniqueidentifier,

	foreign key (AccountId) references [Account](Id),
);
go

create table [StakeHolder]
(
	Id uniqueidentifier default newid() primary key,
	Fullname nvarchar(100),
	[Address] nvarchar(max),
	PhoneNumber nvarchar(15) unique,
	Salary money,
	DateHired date,

	AccountId uniqueidentifier,

	foreign key (AccountId) references [Account](Id),
);
go


create table [Category]
(
	Id uniqueidentifier default newid() primary key,
	[Name] nvarchar(50),
	[TimeStamp] datetime,
	[Status] nvarchar(20)
);
go

create table [Product]
(
	Id uniqueidentifier default newid() primary key,
	Material nvarchar(100),
	Gender bit,
	Price money,--Diamond Price + Doing_Price
	Point int,
	Quantity int,
	[TimeStamp] datetime,
	[Status] nvarchar(20),

	CategoryId uniqueidentifier,

	foreign key (CategoryId) references [Category](Id)
);
go

create table [Diamond]
(
	Id uniqueidentifier default newid() primary key,
	[Name] nvarchar(max),
	Color nvarchar(20),
	Origin nvarchar(100),
	CaratWeight nvarchar(20),
	Clarity nvarchar(20),
	Cut nvarchar(20),
	Price money,
	Quantity int
);
go

create table [DiamondProduct]
(
	Id uniqueidentifier default newid() primary key,--1 product has many same non-main diamond
	IsMain bit,

	ProductId uniqueidentifier,
	DiamondId uniqueidentifier,

	foreign key (ProductId) references [Product](Id),
	foreign key (DiamondId) references [Diamond](Id)
);
go

create table [Warranty]
(
	Id uniqueidentifier default newid() primary key,
	StartDate datetime,
	EndDate datetime,
	IsValid bit,--true when product not damaged
	IsApply bit--true when payed
);
go

create table [Order]
(
	Id uniqueidentifier default newid() primary key,
	Code nvarchar(20),
	Note nvarchar(max),
	Total money,
	[Date] datetime,
	[Status] nvarchar(20),

	CustomerId uniqueidentifier,
	SalesStaffId uniqueidentifier,
	DeliveryStaffId uniqueidentifier,

	foreign key (CustomerId) references [Customer](Id),
	foreign key (SalesStaffId) references [StakeHolder](Id),
	foreign key (DeliveryStaffId) references [StakeHolder](Id),
);
go

create table [OrderDetail]
(
	Quantity int,
	SubTotal money,--Product price * quantity

	OrderId uniqueidentifier,
	ProductId uniqueidentifier,
	WarrantyId uniqueidentifier,

	primary key (OrderId, ProductId, WarrantyId),
	foreign key (OrderId) references [Order](Id),
	foreign key (ProductId) references [Product](Id),
	foreign key (WarrantyId) references [Warranty](Id)
);
go

create table [Certification]
(
	Id uniqueidentifier default newid() primary key,
	[Name] nvarchar(max),
	UrlPath nvarchar(max),

	DiamondId uniqueidentifier,

	foreign key (DiamondId) references [Diamond](Id),
);
go


create table [Picture]
(
	Id uniqueidentifier default newid() primary key,
	UrlPath nvarchar(max),

	DiamondId uniqueidentifier null,
	ProductId uniqueidentifier null,

	foreign key (DiamondId) references [Diamond](Id),
	foreign key (ProductId) references [Product](Id),
);
go