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
	[Password] nvarchar(max) not null,
	AvatarUrl nvarchar(max),
	[CreatedTime] datetime,
	[Role] nvarchar(20) not null,	--1:Admin   2:Manager   3:Sales-Staff   4:Delivery-Staff   5:Customer
	[Status] nvarchar(20) not null
);
go

create table [Customer]
(
	Id uniqueidentifier default newid() primary key,
	Fullname nvarchar(100) not null,
	[Address] nvarchar(max),
	PhoneNumber nvarchar(15) unique,
	Point int,

	AccountId uniqueidentifier not null unique foreign key references [Account](Id)
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

	AccountId uniqueidentifier not null foreign key references [Account](Id)
);
go


create table [Category]
(
	Id uniqueidentifier default newid() primary key,
	[Name] nvarchar(50) not null,
	[LastUpdate] datetime,			--for manage history
	[Status] nvarchar(20)
);
go

create table [Product]
(
	Id uniqueidentifier default newid() primary key,
	Material nvarchar(100),
	Gender bit,
	Price money,			--Diamond Price + Doing_Price
	[Point] int,
	Quantity int,
	WarrantyPeriod int,	--count as month (thoi han bao hanh)
	[LastUpdate] datetime,			--for manage history
	[Status] nvarchar(20),

	CategoryId uniqueidentifier not null foreign key references [Category](Id)
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
	Quantity int,
	WarrantyPeriod int,	--count as month (thoi han bao hanh)
	[LastUpdate] datetime,	--for manage history
	[Status] nvarchar(20),
);
go

create table [ProductPart]
(
	Id uniqueidentifier default newid() primary key,--1 product has many same non-main diamond
	IsMain bit,

	ProductId uniqueidentifier not null foreign key references [Product](Id),
	DiamondId uniqueidentifier not null foreign key references [Diamond](Id)
);
go


create table [Order]
(
	Id uniqueidentifier default newid() primary key,
	Code nvarchar(20),
	OrderDate datetime default GETDATE(),
	Total money,
	ShipDate datetime,
	ShipAddress nvarchar(max),
	Note nvarchar(max),
	[Status] nvarchar(20),

	CustomerId uniqueidentifier not null foreign key references [Customer](Id),
	SalesStaffId uniqueidentifier not null foreign key references [StakeHolder](Id),
	DeliveryStaffId uniqueidentifier not null foreign key references [StakeHolder](Id)
);
go

create table [OrderDetail]
(
	Id uniqueidentifier default newid() primary key,
	Quantity int not null,
	SubTotal money not null,					--Product price * quantity

	OrderId uniqueidentifier not null foreign key references [Order](Id),
	ProductId uniqueidentifier not null foreign key references [Product](Id)
);
go

create table [Warranty]
(
	Id uniqueidentifier default newid() primary key,
	[ItemName] nvarchar(max) not null,
	[Type] nvarchar(50),
	Privacy nvarchar(max),
	Condition nvarchar(max),
	IsProduct bit,					-- 1 = Product Warranty, 0 = Diamond Warranty
	StartDate datetime,
	EndDate datetime,
	[Status] nvarchar(20),
	[Reason] nvarchar(max),

	OrderDetailId uniqueidentifier not null foreign key references [OrderDetail](Id)
);
go

create table [Certification]
(
	Id uniqueidentifier default newid() primary key,
	[Name] nvarchar(max) not null,
	UrlPath nvarchar(max),

	DiamondId uniqueidentifier not null foreign key references [Diamond](Id),
);
go


create table [Picture]
(
	Id uniqueidentifier default newid() primary key,
	UrlPath nvarchar(max),

	DiamondId uniqueidentifier foreign key references [Diamond](Id),
	ProductId uniqueidentifier foreign key references [Product](Id),
	constraint CHK_Picture_ForeignKey check (
        (ProductId IS NOT NULL AND DiamondId IS NULL) 
        OR (ProductId IS NULL AND DiamondId IS NOT NULL)
    )
);