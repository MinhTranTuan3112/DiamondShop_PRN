use FlashyCarbon_DB;
go

--=============[RESET DATA]=============--
delete from [Certification];
delete from [Picture];
delete from [ProductPart];
delete from [Diamond];
delete from [Warranty];
delete from [OrderDetail];
delete from [Product];
delete from [Category];
delete from [Order];
delete from [StakeHolder];
delete from [Customer];
delete from [Account];

--=============[INSERT DATA]=============--
insert into [Account](Email,[Password],[Role],[Status]) values
	('admin@flashycarbon.com', '12345', 'admin','working'),
	('manager@flashycarbon.com', '12345', 'manager','working'),
	('hoangphse172789@fpt.edu.vn', '12345', 'manager', 'working'),
	('johhnydang@flashycarbon.com', '12345', 'sales-staff', 'working'),
	('khoapug@flashycarbon.com', '12345', 'sales-staff', 'working'),
	('rihanna@flashycarbon.com', '12345', 'sales-staff', 'working'),
	('tungsike@wibu.com', '12345', 'delivery-staff', 'working'),
	('phule@giangho.com', '12345', 'delivery-staff', 'working'),

	('an.nguyen@gmail.com', '12345', 'customer', default),
	('ha.tran@gmail.com', '12345', 'customer', default),
	('minh.le@gmail.com', '12345', 'customer', default),
	('thuy.pham@gmail.com', '12345', 'customer', default),
	('tuan.ngo@gmail.com', '12345', 'customer', default),
	('lan.nguyen@gmail.com', '12345', 'customer', default),
	('danh.trinh@gmail.com', '12345', 'customer', default),
	('diem.le@gmail.com', '12345', 'customer', default),
	('bao.hoang@gmail.com', '12345', 'customer', default),
	('van.truong@gmail.com', '12345', 'customer', default),
	('duc.do@gmail.com', '12345', 'customer', default),
	('my.nguyen@gmail.com', '12345', 'customer', default),
	('tuan.le@gmail.com', '12345', 'customer', default),
	('phuong.tran@gmail.com', '12345', 'customer', default),
	('hai.ngo@gmail.com', '12345', 'customer', default),
	('thanh.nguyen@gmail.com', '12345', 'customer', default),
	('bao.tran@gmail.com', '12345', 'customer', default),
	('hong.le@gmail.com', '12345', 'customer', default),
	('minh.do@gmail.com', '12345', 'customer', default),
	('nga.nguyen@gmail.com', '12345', 'customer', default);
go

insert into [StakeHolder](Fullname,PhoneNumber,Salary,AccountId) values
	('Admin', '0000000000', 10000, (select Id from [Account] where Email = 'admin@flashycarbon.com')),
	('Manager', '0000000001', 7500, (select Id from [Account] where Email = 'manager@flashycarbon.com')),
	(N'Hoàng Phạm', '0000000002', 7500, (select Id from [Account] where Email = 'hoangphse172789@fpt.edu.vn')),
	(N'Johnny Đặng', '0000000003', 5000, (select Id from [Account] where Email = 'johhnydang@flashycarbon.com')),
	('Khoa Pug', '0000000004', 5000, (select Id from [Account] where Email = 'khoapug@flashycarbon.com')),
	('Rihana', '0000000005', 5000, (select Id from [Account] where Email = 'rihanna@flashycarbon.com')),
	(N'Tùng Sike', '0000000006', 1000, (select Id from [Account] where Email = 'tungsike@wibu.com')),
	(N'Phú Lê', '0000000007', 1000, (select Id from [Account] where Email = 'phule@giangho.com'));
go

insert into [Customer](Fullname, PhoneNumber, AccountId) values
	(N'Nguyễn Văn An', '0000000008', (select Id from [Account] where Email = 'an.nguyen@gmail.com')),
	(N'Trần Thu Hà', '0000000009', (select Id from [Account] where Email = 'ha.tran@gmail.com')),
	(N'Lê Hoàng Minh', '0000000010', (select Id from [Account] where Email = 'minh.le@gmail.com')),
	(N'Phạm Thu Thủy', '0000000011', (select Id from [Account] where Email = 'thuy.pham@gmail.com')),
	(N'Ngô Đức Tuấn', '0000000012', (select Id from [Account] where Email = 'tuan.ngo@gmail.com')),
	(N'Nguyễn Thị Lan', '0000000013', (select Id from [Account] where Email = 'lan.nguyen@gmail.com')),
	(N'Trịnh Công Danh', '0000000014', (select Id from [Account] where Email = 'danh.trinh@gmail.com')),
	(N'Lê Thị Diễm', '0000000015', (select Id from [Account] where Email = 'diem.le@gmail.com')),
	(N'Hoàng Quốc Bảo', '0000000016', (select Id from [Account] where Email = 'bao.hoang@gmail.com')),
	(N'Trương Thị Vân', '0000000017', (select Id from [Account] where Email = 'van.truong@gmail.com')),
	(N'Đỗ Minh Đức', '0000000018', (select Id from [Account] where Email = 'duc.do@gmail.com')),
	(N'Nguyễn Thị Mỹ', '0000000019', (select Id from [Account] where Email = 'my.nguyen@gmail.com')),
	(N'Lê Anh Tuấn', '0000000020', (select Id from [Account] where Email = 'tuan.le@gmail.com')),
	(N'Trần Thị Phương', '0000000021', (select Id from [Account] where Email = 'phuong.tran@gmail.com')),
	(N'Ngô Văn Hải', '0000000022', (select Id from [Account] where Email = 'hai.ngo@gmail.com')),
	(N'Nguyễn Thị Thanh', '0000000023', (select Id from [Account] where Email = 'thanh.nguyen@gmail.com')),
	(N'Trần Quốc Bảo', '0000000024', (select Id from [Account] where Email = 'bao.tran@gmail.com')),
	(N'Lê Thị Hồng', '0000000025', (select Id from [Account] where Email = 'hong.le@gmail.com')),
	(N'Đỗ Văn Minh', '0000000026', (select Id from [Account] where Email = 'minh.do@gmail.com')),
	(N'Nguyễn Thị Nga', '0000000027', (select Id from [Account] where Email = 'nga.nguyen@gmail.com'));
go

insert into [Category]([Name]) values
	('Diamond Jewelry'),
	('Amethyst Jewelry'),
	('Ametrine Jewelry'),
	('Agate Jewelry'),
	('Alexandrite Jewelry'),
	('Andesine Jewelry'),
	('Aquamarine Jewelry'),
	('Cubic Zirconia Jewelry'),
	('Chrysoberyl Jewelry'),
	('Citrine Jewelry'),
	('Emerald Jewelry'),
	('Fluorite Jewelry'),
	('Gemstone Jewelry'),
	('Garnet Jewelry'),
	('Iolite Jewelry'),
	('Opal Jewelry'),
	('Ruby Jewelry'),
	('Sapphire Jewelry'),
	('Spinel Jewelry'),
	('Tanzanite Jewelry'),
	('Topaz Jewelry'),
	('Tourmaline Jewelry'),
	('Apatite Jewelry'),
	('Lapis Lazuli Jewelry');
go

insert into [Product]([Type], Material, Gender, Price, Point, WarrantyPeriod, CategoryId) values
-- Ring
    ('Ring', 'Gold', 0, 1500.00, 450, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Ring', 'Gold', 1, 1800.00, 540, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Ring', 'Gold', 0, 800.00, 240, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Ring', 'Gold', 1, 950.00, 285, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

-- Earring
    ('Earring', 'Gold', 0, 500.00, 150, 6, (select Id from [Category] where [Name] = 'Diamond Jewelry')), 
    ('Earring', 'Gold', 1, 600.00, 180, 6, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Earring', 'Gold', 0, 400.00, 120, 6, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Earring', 'Gold', 1, 450.00, 135, 6, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

-- Pendant
    ('Pendant', 'Gold', 0, 750.00, 225, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Pendant', 'Gold', 1, 900.00, 270, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Pendant', 'Gold', 0, 600.00, 180, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Pendant', 'Gold', 1, 700.00, 210, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

-- Bangles
    ('Bangles', 'Gold', 0, 1200.00, 360, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Bangles', 'Gold', 1, 1350.00, 405, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Bangles', 'Gold', 0, 900.00, 270, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Bangles', 'Gold', 1, 1000.00, 300, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

-- Bracelet
    ('Bracelet', 'Gold', 0, 750.00, 225, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Bracelet', 'Gold', 1, 850.00, 255, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Bracelet', 'Gold', 0, 600.00, 180, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
    ('Bracelet', 'Gold', 1, 700.00, 210, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry'));
go

insert into [Product] ([Type], Material, Gender, Price, [Point], WarrantyPeriod, CategoryId) values
-- Amethyst Jewelry
    ('Ring', 'Gold', 0, 900.00, 270, 12, (select Id from [Category] where [Name] = 'Amethyst Jewelry')),
    ('Earring', 'Gold', 1, 550.00, 165, 6, (select Id from [Category] where [Name] = 'Amethyst Jewelry')),
    ('Pendant', 'Gold', 0, 800.00, 240, 9, (select Id from [Category] where [Name] = 'Amethyst Jewelry')),
    ('Bangles', 'Gold', 1, 1100.00, 330, 12, (select Id from [Category] where [Name] = 'Amethyst Jewelry')),
    ('Bracelet', 'Gold', 0, 750.00, 225, 9, (select Id from [Category] where [Name] = 'Amethyst Jewelry')),

-- Ametrine Jewelry  
    ('Ring', 'Gold', 1, 950.00, 285, 12, (select Id from [Category] where [Name] = 'Ametrine Jewelry')),
    ('Earring', 'Gold', 0, 580.00, 174, 6, (select Id from [Category] where [Name] = 'Ametrine Jewelry')),
    ('Pendant', 'Gold', 1, 850.00, 255, 9, (select Id from [Category] where [Name] = 'Ametrine Jewelry')),
    ('Bangles', 'Gold', 0, 1150.00, 345, 12, (select Id from [Category] where [Name] = 'Ametrine Jewelry')),
    ('Bracelet', 'Gold', 1, 780.00, 234, 9, (select Id from [Category] where [Name] = 'Ametrine Jewelry')),

-- Agate Jewelry
    ('Ring', 'Gold', 0, 850.00, 255, 12, (select Id from [Category] where [Name] = 'Agate Jewelry')),
    ('Earring', 'Gold', 1, 500.00, 150, 6, (select Id from [Category] where [Name] = 'Agate Jewelry')),
    ('Pendant', 'Gold', 0, 750.00, 225, 9, (select Id from [Category] where [Name] = 'Agate Jewelry')),
    ('Bangles', 'Gold', 1, 1050.00, 315, 12, (select Id from [Category] where [Name] = 'Agate Jewelry')),
    ('Bracelet', 'Gold', 0, 650.00, 195, 9, (select Id from [Category] where [Name] = 'Agate Jewelry')),

-- Alexandrite Jewelry
    ('Ring', 'Gold', 1, 1000.00, 300, 12, (select Id from [Category] where [Name] = 'Alexandrite Jewelry')),
    ('Earring', 'Gold', 0, 620.00, 186, 6, (select Id from [Category] where [Name] = 'Alexandrite Jewelry')),
    ('Pendant', 'Gold', 1, 900.00, 270, 9, (select Id from [Category] where [Name] = 'Alexandrite Jewelry')),
    ('Bangles', 'Gold', 0, 1200.00, 360, 12, (select Id from [Category] where [Name] = 'Alexandrite Jewelry')),
    ('Bracelet', 'Gold', 1, 800.00, 240, 9, (select Id from [Category] where [Name] = 'Alexandrite Jewelry')),

-- Andesine Jewelry
    ('Ring', 'Gold', 0, 880.00, 264, 12, (select Id from [Category] where [Name] = 'Andesine Jewelry')),
    ('Earring', 'Gold', 1, 530.00, 159, 6, (select Id from [Category] where [Name] = 'Andesine Jewelry')),
    ('Pendant', 'Gold', 0, 780.00, 234, 9, (select Id from [Category] where [Name] = 'Andesine Jewelry')),
    ('Bangles', 'Gold', 1, 1100.00, 330, 12, (select Id from [Category] where [Name] = 'Andesine Jewelry')),
    ('Bracelet', 'Gold', 0, 680.00, 204, 9, (select Id from [Category] where [Name] = 'Andesine Jewelry')),

-- Aquamarine Jewelry
	('Ring', 'Gold', 1, 920.00, 276, 12, (select Id from [Category] where [Name] = 'Aquamarine Jewelry')),
	('Earring', 'Gold', 0, 570.00, 171, 6, (select Id from [Category] where [Name] = 'Aquamarine Jewelry')),
	('Pendant', 'Gold', 1, 820.00, 246, 9, (select Id from [Category] where [Name] = 'Aquamarine Jewelry')),
	('Bangles', 'Gold', 0, 1120.00, 336, 12, (select Id from [Category] where [Name] = 'Aquamarine Jewelry')),
	('Bracelet', 'Gold', 1, 720.00, 216, 9, (select Id from [Category] where [Name] = 'Aquamarine Jewelry')),

-- Citrine Jewelry
	('Ring', 'Gold', 0, 890.00, 267, 12, (select Id from [Category] where [Name] = 'Citrine Jewelry')),
	('Earring', 'Gold', 1, 540.00, 162, 6, (select Id from [Category] where [Name] = 'Citrine Jewelry')),
	('Pendant', 'Gold', 0, 790.00, 237, 9, (select Id from [Category] where [Name] = 'Citrine Jewelry')),
	('Bangles', 'Gold', 1, 1090.00, 327, 12, (select Id from [Category] where [Name] = 'Citrine Jewelry')),
	('Bracelet', 'Gold', 0, 690.00, 207, 9, (select Id from [Category] where [Name] = 'Citrine Jewelry')),

-- Emerald Jewelry
	('Ring', 'Gold', 1, 980.00, 294, 12, (select Id from [Category] where [Name] = 'Emerald Jewelry')),
	('Earring', 'Gold', 0, 610.00, 183, 6, (select Id from [Category] where [Name] = 'Emerald Jewelry')),
	('Pendant', 'Gold', 1, 880.00, 264, 9, (select Id from [Category] where [Name] = 'Emerald Jewelry')),
	('Bangles', 'Gold', 0, 1180.00, 354, 12, (select Id from [Category] where [Name] = 'Emerald Jewelry')),
	('Bracelet', 'Gold', 1, 760.00, 228, 9, (select Id from [Category] where [Name] = 'Emerald Jewelry')),

-- Garnet Jewelry
	('Ring', 'Gold', 0, 860.00, 258, 12, (select Id from [Category] where [Name] = 'Garnet Jewelry')),
	('Earring', 'Gold', 1, 510.00, 153, 6, (select Id from [Category] where [Name] = 'Garnet Jewelry')),
	('Pendant', 'Gold', 0, 760.00, 228, 9, (select Id from [Category] where [Name] = 'Garnet Jewelry')),
	('Bangles', 'Gold', 1, 1060.00, 318, 12, (select Id from [Category] where [Name] = 'Garnet Jewelry')),
	('Bracelet', 'Gold', 0, 660.00, 198, 9, (select Id from [Category] where [Name] = 'Garnet Jewelry')),

-- Cubic Zirconia Jewelry
	('Ring', 'Gold', 1, 930.00, 279, 12, (select Id from [Category] where [Name] = 'Cubic Zirconia Jewelry')),
	('Earring', 'Gold', 0, 580.00, 174, 6, (select Id from [Category] where [Name] = 'Cubic Zirconia Jewelry')),
	('Pendant', 'Gold', 1, 830.00, 249, 9, (select Id from [Category] where [Name] = 'Cubic Zirconia Jewelry')),
	('Bangles', 'Gold', 0, 1130.00, 339, 12, (select Id from [Category] where [Name] = 'Cubic Zirconia Jewelry')),
	('Bracelet', 'Gold', 1, 730.00, 219, 9, (select Id from [Category] where [Name] = 'Cubic Zirconia Jewelry')),

-- Sapphire Jewelry
	('Ring', 'Gold', 0, 940.00, 282, 12, (select Id from [Category] where [Name] = 'Sapphire Jewelry')),
	('Earring', 'Gold', 1, 590.00, 177, 6, (select Id from [Category] where [Name] = 'Sapphire Jewelry')),
	('Pendant', 'Gold', 0, 840.00, 252, 9, (select Id from [Category] where [Name] = 'Sapphire Jewelry')),
	('Bangles', 'Gold', 1, 1140.00, 342, 12, (select Id from [Category] where [Name] = 'Sapphire Jewelry')),
	('Bracelet', 'Gold', 0, 740.00, 222, 9, (select Id from [Category] where [Name] = 'Sapphire Jewelry'));
go

insert into [Diamond]([Name], Color, Origin, CaratWeight, Clarity, Cut, Price, WarrantyPeriod) values
('GIA 1.25 VS1 Ideal', 'D', 'GIA', '1.25', 'VS1', 'Ideal', 12500.00, 24),
('LUCKY STAR 0.75 SI2 Excellent', 'E', 'LUCKY STAR', '0.75', 'SI2', 'Excellent', 6800.00, 18),
('GIA 2.00 IF Signature', 'F', 'GIA', '2.00', 'IF', 'Signature', 35000.00, 36), 
('BRILLIANT EARTH 1.50 VVS2 Premium', 'G', 'BRILLIANT EARTH', '1.50', 'VVS2', 'Premium', 18900.00, 30),
('GIA 0.90 SI1 Ideal', 'H', 'GIA', '0.90', 'SI1', 'Ideal', 8700.00, 24),
('LUCKY STAR 1.10 VS2 Excellent', 'I', 'LUCKY STAR', '1.10', 'VS2', 'Excellent', 11500.00, 24),
('GIA 1.75 IF Signature', 'J', 'GIA', '1.75', 'IF', 'Signature', 30000.00, 36),
('BRILLIANT EARTH 1.00 VVS1 Premium', 'D', 'BRILLIANT EARTH', '1.00', 'VVS1', 'Premium', 14200.00, 30),
('GIA 0.80 SI2 Ideal', 'E', 'GIA', '0.80', 'SI2', 'Ideal', 7500.00, 24),
('LUCKY STAR 1.25 VS1 Excellent', 'F', 'LUCKY STAR', '1.25', 'VS1', 'Excellent', 13000.00, 24),
('GIA 2.50 IF Signature', 'G', 'GIA', '2.50', 'IF', 'Signature', 45000.00, 36),
('BRILLIANT EARTH 1.35 VVS2 Premium', 'H', 'BRILLIANT EARTH', '1.35', 'VVS2', 'Premium', 17500.00, 30),
('GIA 0.95 SI1 Ideal', 'I', 'GIA', '0.95', 'SI1', 'Ideal', 9100.00, 24),
('LUCKY STAR 1.15 VS2 Excellent', 'J', 'LUCKY STAR', '1.15', 'VS2', 'Excellent', 12000.00, 24),
('GIA 1.65 IF Signature', 'D', 'GIA', '1.65', 'IF', 'Signature', 28000.00, 36),
('BRILLIANT EARTH 0.90 VVS1 Premium', 'E', 'BRILLIANT EARTH', '0.90', 'VVS1', 'Premium', 13000.00, 30),
('GIA 0.85 SI2 Ideal', 'F', 'GIA', '0.85', 'SI2', 'Ideal', 8000.00, 24),
('LUCKY STAR 1.30 VS1 Excellent', 'G', 'LUCKY STAR', '1.30', 'VS1', 'Excellent', 13500.00, 24),
('GIA 2.20 IF Signature', 'H', 'GIA', '2.20', 'IF', 'Signature', 40000.00, 36),
('BRILLIANT EARTH 1.15 VVS2 Premium', 'I', 'BRILLIANT EARTH', '1.15', 'VVS2', 'Premium', 16000.00, 30),
('GIA 1.00 SI1 Ideal', 'J', 'GIA', '1.00', 'SI1', 'Ideal', 9600.00, 24),
('LUCKY STAR 1.20 VS2 Excellent', 'D', 'LUCKY STAR', '1.20', 'VS2', 'Excellent', 12500.00, 24),
('GIA 1.55 IF Signature', 'E', 'GIA', '1.55', 'IF', 'Signature', 26000.00, 36),
('BRILLIANT EARTH 1.05 VVS1 Premium', 'F', 'BRILLIANT EARTH', '1.05', 'VVS1', 'Premium', 15000.00, 30),
('GIA 0.90 SI2 Ideal', 'G', 'GIA', '0.90', 'SI2', 'Ideal', 8300.00, 24),
('LUCKY STAR 1.35 VS1 Excellent', 'H', 'LUCKY STAR', '1.35', 'VS1', 'Excellent', 14000.00, 24),
('GIA 2.10 IF Signature', 'I', 'GIA', '2.10', 'IF', 'Signature', 38000.00, 36),
('BRILLIANT EARTH 1.25 VVS2 Premium', 'J', 'BRILLIANT EARTH', '1.25', 'VVS2', 'Premium', 17000.00, 30),
('GIA 1.2 Carat G VS1 Ideal', 'G', 'GIA', '1.2', 'VS1', 'Ideal', 8500.00, 24),
('LUCKY STAR 0.8 Carat D IF Excellent', 'D', 'LUCKY STAR', '0.8', 'IF', 'Excellent', 12000.00, 36),
('GIA 2.0 Carat F VVS2 Very Good', 'F', 'GIA', '2.0', 'VVS2', 'Very Good', 18000.00, 24),
('WORLD GEM 1.5 Carat H SI1 Premium', 'H', 'WORLD GEM', '1.5', 'SI1', 'Premium', 10000.00, 30),
('GIA 0.9 Carat E VS2 Excellent', 'E', 'GIA', '0.9', 'VS2', 'Excellent', 7800.00, 24),
('LUCKY STAR 1.1 Carat D IF Ideal', 'D', 'LUCKY STAR', '1.1', 'IF', 'Ideal', 14500.00, 36),
('WORLD GEM 1.8 Carat J SI2 Very Good', 'J', 'WORLD GEM', '1.8', 'SI2', 'Very Good', 12500.00, 30),
('GIA 1.4 Carat G VS1 Premium', 'G', 'GIA', '1.4', 'VS1', 'Premium', 10200.00, 24),
('LUCKY STAR 0.7 Carat D FL Excellent', 'D', 'LUCKY STAR', '0.7', 'FL', 'Excellent', 16000.00, 36),
('WORLD GEM 1.6 Carat H SI1 Ideal', 'H', 'WORLD GEM', '1.6', 'SI1', 'Ideal', 11000.00, 30),
('GIA 1.1 Carat F VVS2 Very Good', 'F', 'GIA', '1.1', 'VVS2', 'Very Good', 13500.00, 24),
('LUCKY STAR 1.3 Carat D IF Premium', 'D', 'LUCKY STAR', '1.3', 'IF', 'Premium', 18000.00, 36),
('WORLD GEM 1.0 Carat J SI2 Excellent', 'J', 'WORLD GEM', '1.0', 'SI2', 'Excellent', 7000.00, 30),
('GIA 0.6 Carat E VS1 Ideal', 'E', 'GIA', '0.6', 'VS1', 'Ideal', 5500.00, 24),
('LUCKY STAR 1.7 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.7', 'FL', 'Excellent', 25000.00, 36),
('GIA 1.8 Carat G VVS1 Premium', 'G', 'GIA', '1.8', 'VVS1', 'Premium', 16000.00, 24),
('WORLD GEM 0.9 Carat H SI1 Ideal', 'H', 'WORLD GEM', '0.9', 'SI1', 'Ideal', 6800.00, 30),
('LUCKY STAR 1.4 Carat D IF Excellent', 'D', 'LUCKY STAR', '1.4', 'IF', 'Excellent', 19500.00, 36),
('GIA 1.2 Carat F VVS2 Very Good', 'F', 'GIA', '1.2', 'VVS2', 'Very Good', 14000.00, 24),
('WORLD GEM 1.1 Carat J SI2 Premium', 'J', 'WORLD GEM', '1.1', 'SI2', 'Premium', 7500.00, 30),
('GIA 0.8 Carat E VS1 Ideal', 'E', 'GIA', '0.8', 'VS1', 'Ideal', 6800.00, 24),
('LUCKY STAR 1.6 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.6', 'FL', 'Excellent', 23000.00, 36),
('WORLD GEM 1.3 Carat H SI1 Premium', 'H', 'WORLD GEM', '1.3', 'SI1', 'Premium', 9000.00, 30),
('GIA 1.0 Carat F VVS1 Ideal', 'F', 'GIA', '1.0', 'VVS1', 'Ideal', 12000.00, 24),
('LUCKY STAR 1.5 Carat D IF Excellent', 'D', 'LUCKY STAR', '1.5', 'IF', 'Excellent', 21000.00, 36),
('WORLD GEM 0.7 Carat J SI2 Very Good', 'J', 'WORLD GEM', '0.7', 'SI2', 'Very Good', 5000.00, 30),
('GIA 1.4 Carat G VS1 Premium', 'G', 'GIA', '1.4', 'VS1', 'Premium', 10500.00, 24),
('LUCKY STAR 1.1 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.1', 'FL', 'Excellent', 17000.00, 36),
('WORLD GEM 1.6 Carat H SI1 Ideal', 'H', 'WORLD GEM', '1.6', 'SI1', 'Ideal', 11500.00, 30),
('GIA 0.9 Carat F VVS2 Very Good', 'F', 'GIA', '0.9', 'VVS2', 'Very Good', 11000.00, 24),
('LUCKY STAR 1.2 Carat D IF Premium', 'D', 'LUCKY STAR', '1.2', 'IF', 'Premium', 17000.00, 36),
('WORLD GEM 1.0 Carat J SI2 Excellent', 'J', 'WORLD GEM', '1.0', 'SI2', 'Excellent', 7200.00, 30),
('GIA 0.7 Carat E VS1 Ideal', 'E', 'GIA', '0.7', 'VS1', 'Ideal', 6000.00, 24),
('LUCKY STAR 1.3 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.3', 'FL', 'Excellent', 18500.00, 36),
('WORLD GEM 1.5 Carat H SI1 Premium', 'H', 'WORLD GEM', '1.5', 'SI1', 'Premium', 10500.00, 30),
('GIA 2.5ct VS1 Ideal', 'Colorless', 'GIA', '2.5', 'VS1', 'Ideal', 7500.00, 24),
('LUCKY STAR 1.8ct SI2 Good', 'Near Colorless', 'LUCKY STAR', '1.8', 'SI2', 'Good', 4200.00, 12),
('AGS 3.1ct VVS2 Very Good', 'Colorless', 'AGS', '3.1', 'VVS2', 'Very Good', 9200.00, 36),
('GIA 1.2ct SI1 Fair', 'Faint Yellow', 'GIA', '1.2', 'SI1', 'Fair', 3200.00, 6),
('IGI 2.7ct VS2 Ideal', 'Colorless', 'IGI', '2.7', 'VS2', 'Ideal', 7800.00, 24),
('LUCKY STAR 1.5ct SI1 Good', 'Near Colorless', 'LUCKY STAR', '1.5', 'SI1', 'Good', 3800.00, 12),
('AGS 2.9ct VVS1 Very Good', 'Colorless', 'AGS', '2.9', 'VVS1', 'Very Good', 8900.00, 36),
('GIA 1.0ct SI2 Fair', 'Faint Yellow', 'GIA', '1.0', 'SI2', 'Fair', 2800.00, 6),
('IGI 2.3ct VS1 Ideal', 'Colorless', 'IGI', '2.3', 'VS1', 'Ideal', 7200.00, 24),
('LUCKY STAR 1.3ct SI2 Good', 'Near Colorless', 'LUCKY STAR', '1.3', 'SI2', 'Good', 3600.00, 12),
('AGS 2.5ct VVS2 Very Good', 'Colorless', 'AGS', '2.5', 'VVS2', 'Very Good', 8000.00, 36),
('GIA 0.8ct SI1 Fair', 'Faint Yellow', 'GIA', '0.8', 'SI1', 'Fair', 2600.00, 6),
('IGI 2.0ct VS2 Ideal', 'Colorless', 'IGI', '2.0', 'VS2', 'Ideal', 7000.00, 24),
('LUCKY STAR 1.0ct SI1 Good', 'Near Colorless', 'LUCKY STAR', '1.0', 'SI1', 'Good', 3400.00, 12),
('AGS 2.3ct VVS1 Very Good', 'Colorless', 'AGS', '2.3', 'VVS1', 'Very Good', 8500.00, 36),
('GIA 0.5ct SI2 Fair', 'Faint Yellow', 'GIA', '0.5', 'SI2', 'Fair', 2400.00, 6),
('IGI 1.8ct VS1 Ideal', 'Colorless', 'IGI', '1.8', 'VS1', 'Ideal', 6800.00, 24),
('LUCKY STAR 0.7ct SI2 Good', 'Near Colorless', 'LUCKY STAR', '0.7', 'SI2', 'Good', 3200.00, 12),
('AGS 2.0ct VVS2 Very Good', 'Colorless', 'AGS', '2.0', 'VVS2', 'Very Good', 7800.00, 36),
('GIA 0.3ct SI1 Fair', 'Faint Yellow', 'GIA', '0.3', 'SI1', 'Fair', 2200.00, 6);
go

use master;