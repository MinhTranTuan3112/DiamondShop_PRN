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

-- Ring
insert into [Product]([Name], [Type], Material, Gender, Price, Point, WarrantyPeriod, CategoryId) values
	--Female
	('Female Ring Gold 14K Clavia 3CT', 'Ring', 'White Gold', 0, 5000.00, 5000, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Clavia 2CT', 'Ring', 'White Gold', 0, 4950.00, 4950, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 18K Caste N 1.5CT', 'Ring', 'White Gold', 0, 4900.00, 4900, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Caste N 1.5CT', 'Ring', 'White Gold', 0, 4800.00, 4800, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Flourishing 3CT', 'Ring', 'White Gold', 0, 4800.00, 4800, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Flourishing 2CT', 'Ring', 'White Gold', 0, 4700.00, 4700, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 18K Flourishing 1CT', 'Ring', 'White Gold', 0, 4750.00, 4750, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Bellamy N 1CT', 'Ring', 'White Gold', 0, 4600.00, 4600, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Bellamy N 5C', 'Ring', 'White Gold', 0, 4700.00, 4600, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Arternos 2CT', 'Ring', 'White Gold', 0, 4650.00, 4650, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Arternos 1CT', 'Ring', 'White Gold', 0, 4500.00, 4500, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Grandeur 5C', 'Ring', 'White Gold', 0, 4650.00, 4650, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Grandeur 1CT', 'Ring', 'White Gold', 0, 4000.00, 4000, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Amalia N 5C', 'Ring', 'White Gold', 0, 3800.00, 3800, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Amalia N 1CT', 'Ring', 'White Gold', 0, 3000.00, 3000, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Abby DN 5C', 'Ring', 'White Gold', 0, 2600.00, 2600, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Abby DN 3C', 'Ring', 'White Gold', 0, 2000.00, 2000, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Abby DN 2C', 'Ring', 'White Gold', 0, 1800.00, 1800, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Adivity 5C', 'Ring', 'White Gold', 0, 1500.00, 1500, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Adivity 1CT', 'Ring', 'White Gold', 0, 1000.00, 1000, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

	--Male
	(null, 'Ring', 'White Gold', 1, 1500.00, 450, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1800.00, 500, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1300.00, 400, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1700.00, 480, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1400.00, 420, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1600.00, 460, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1900.00, 520, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1200.00, 380, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1550.00, 440, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	(null, 'Ring', 'White Gold', 1, 1650.00, 470, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry'));
--In Working

insert into [Diamond]([Name], Color, Origin, CaratWeight, Clarity, Cut, Price, WarrantyPeriod) values
	('GIA 0.6 Carat E VS1 Ideal', 'E', 'GIA', '0.6', 'VS1', 'Ideal', 5500.00, 24),
	('GIA 0.7 Carat E VS1 Ideal', 'E', 'GIA', '0.7', 'VS1', 'Ideal', 6000.00, 24),
	('GIA 0.8 Carat E VS1 Ideal', 'E', 'GIA', '0.8', 'VS1', 'Ideal', 6800.00, 24),
	('GIA 0.80 SI2 Ideal', 'E', 'GIA', '0.80', 'SI2', 'Ideal', 7500.00, 24),
	('GIA 0.85 SI2 Ideal', 'F', 'GIA', '0.85', 'SI2', 'Ideal', 8000.00, 24),
	('GIA 0.9 Carat E VS2 Excellent', 'E', 'GIA', '0.9', 'VS2', 'Excellent', 7800.00, 24),
	('GIA 0.90 SI2 Ideal', 'G', 'GIA', '0.90', 'SI2', 'Ideal', 8300.00, 24),
	('GIA 0.90 SI1 Ideal', 'H', 'GIA', '0.90', 'SI1', 'Ideal', 8700.00, 24),
	('GIA 0.95 SI1 Ideal', 'I', 'GIA', '0.95', 'SI1', 'Ideal', 9100.00, 24),
	('GIA 0.9 Carat F VVS2 Very Good', 'F', 'GIA', '0.9', 'VVS2', 'Very Good', 11000.00, 24),
	('GIA 1.0 Carat F VVS1 Ideal', 'F', 'GIA', '1.0', 'VVS1', 'Ideal', 12000.00, 24),
	('GIA 1.00 SI1 Ideal', 'J', 'GIA', '1.00', 'SI1', 'Ideal', 9600.00, 24),
	('GIA 1.1 Carat F VVS2 Very Good', 'F', 'GIA', '1.1', 'VVS2', 'Very Good', 13500.00, 24),
	('GIA 1.2 Carat F VVS2 Very Good', 'F', 'GIA', '1.2', 'VVS2', 'Very Good', 14000.00, 24),
	('GIA 1.2 Carat G VS1 Ideal', 'G', 'GIA', '1.2', 'VS1', 'Ideal', 8500.00, 24),
	('GIA 1.25 VS1 Ideal', 'D', 'GIA', '1.25', 'VS1', 'Ideal', 12500.00, 24),
	('GIA 1.4 Carat G VS1 Premium', 'G', 'GIA', '1.4', 'VS1', 'Premium', 10500.00, 24),
	('GIA 1.4 Carat G VS1 Premium', 'G', 'GIA', '1.4', 'VS1', 'Premium', 10200.00, 24),
	('GIA 1.55 IF Signature', 'E', 'GIA', '1.55', 'IF', 'Signature', 26000.00, 36),
	('GIA 1.65 IF Signature', 'D', 'GIA', '1.65', 'IF', 'Signature', 28000.00, 36),
	('GIA 1.75 IF Signature', 'J', 'GIA', '1.75', 'IF', 'Signature', 30000.00, 36),
	('GIA 1.8 Carat G VVS1 Premium', 'G', 'GIA', '1.8', 'VVS1', 'Premium', 16000.00, 24),
	('GIA 2.00 IF Signature', 'F', 'GIA', '2.00', 'IF', 'Signature', 35000.00, 36),
	('GIA 2.20 IF Signature', 'H', 'GIA', '2.20', 'IF', 'Signature', 40000.00, 36),
	('GIA 2.50 IF Signature', 'G', 'GIA', '2.50', 'IF', 'Signature', 45000.00, 36),
	('GIA 2.10 IF Signature', 'I', 'GIA', '2.10', 'IF', 'Signature', 38000.00, 36),
	('GIA 2.0 Carat F VVS2 Very Good', 'F', 'GIA', '2.0', 'VVS2', 'Very Good', 18000.00, 24),
	('GIA 0.3ct SI1 Fair', 'Faint Yellow', 'GIA', '0.3', 'SI1', 'Fair', 2200.00, 6),
	('GIA 0.5ct SI2 Fair', 'Faint Yellow', 'GIA', '0.5', 'SI2', 'Fair', 2400.00, 6),
	('GIA 0.8ct SI1 Fair', 'Faint Yellow', 'GIA', '0.8', 'SI1', 'Fair', 2600.00, 6),
	('GIA 1.0ct SI2 Fair', 'Faint Yellow', 'GIA', '1.0', 'SI2', 'Fair', 2800.00, 6),
	('GIA 1.2ct SI1 Fair', 'Faint Yellow', 'GIA', '1.2', 'SI1', 'Fair', 3200.00, 6),
	('GIA 2.5ct VS1 Ideal', 'Colorless', 'GIA', '2.5', 'VS1', 'Ideal', 7500.00, 24),
	('LUCKY STAR 1.7 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.7', 'FL', 'Excellent', 25000.00, 36),
	('LUCKY STAR 0.7 Carat D FL Excellent', 'D', 'LUCKY STAR', '0.7', 'FL', 'Excellent', 16000.00, 36),
	('LUCKY STAR 1.4 Carat D IF Excellent', 'D', 'LUCKY STAR', '1.4', 'IF', 'Excellent', 19500.00, 36),
	('LUCKY STAR 1.1 Carat D IF Ideal', 'D', 'LUCKY STAR', '1.1', 'IF', 'Ideal', 14500.00, 36),
	('LUCKY STAR 1.3 Carat D IF Premium', 'D', 'LUCKY STAR', '1.3', 'IF', 'Premium', 18000.00, 36),
	('LUCKY STAR 1.10 VS2 Excellent', 'I', 'LUCKY STAR', '1.10', 'VS2', 'Excellent', 11500.00, 24),
	('LUCKY STAR 1.25 VS1 Excellent', 'F', 'LUCKY STAR', '1.25', 'VS1', 'Excellent', 13000.00, 24),
	('LUCKY STAR 0.75 SI2 Excellent', 'E', 'LUCKY STAR', '0.75', 'SI2', 'Excellent', 6800.00, 18),
	('LUCKY STAR 1.30 VS1 Excellent', 'G', 'LUCKY STAR', '1.30', 'VS1', 'Excellent', 13500.00, 24),
	('LUCKY STAR 1.15 VS2 Excellent', 'J', 'LUCKY STAR', '1.15', 'VS2', 'Excellent', 12000.00, 24),
	('LUCKY STAR 1.20 VS2 Excellent', 'D', 'LUCKY STAR', '1.20', 'VS2', 'Excellent', 12500.00, 24),
	('LUCKY STAR 1.35 VS1 Excellent', 'H', 'LUCKY STAR', '1.35', 'VS1', 'Excellent', 14000.00, 24),
	('LUCKY STAR 0.8 Carat D IF Excellent', 'D', 'LUCKY STAR', '0.8', 'IF', 'Excellent', 12000.00, 36),
	('LUCKY STAR 1.6 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.6', 'FL', 'Excellent', 23000.00, 36),
	('LUCKY STAR 1.5 Carat D IF Excellent', 'D', 'LUCKY STAR', '1.5', 'IF', 'Excellent', 21000.00, 36),
	('LUCKY STAR 1.1 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.1', 'FL', 'Excellent', 17000.00, 36),
	('LUCKY STAR 1.2 Carat D IF Premium', 'D', 'LUCKY STAR', '1.2', 'IF', 'Premium', 17000.00, 36),
	('LUCKY STAR 1.3 Carat D FL Excellent', 'D', 'LUCKY STAR', '1.3', 'FL', 'Excellent', 18500.00, 36),
	('LUCKY STAR 1.8ct SI2 Good', 'Near Colorless', 'LUCKY STAR', '1.8', 'SI2', 'Good', 4200.00, 12),
	('LUCKY STAR 1.5ct SI1 Good', 'Near Colorless', 'LUCKY STAR', '1.5', 'SI1', 'Good', 3800.00, 12),
	('LUCKY STAR 1.3ct SI2 Good', 'Near Colorless', 'LUCKY STAR', '1.3', 'SI2', 'Good', 3600.00, 12),
	('LUCKY STAR 1.0ct SI1 Good', 'Near Colorless', 'LUCKY STAR', '1.0', 'SI1', 'Good', 3400.00, 12),
	('LUCKY STAR 0.7ct SI2 Good', 'Near Colorless', 'LUCKY STAR', '0.7', 'SI2', 'Good', 3200.00, 12),
	('BRILLIANT EARTH 1.50 VVS2 Premium', 'G', 'BRILLIANT EARTH', '1.50', 'VVS2', 'Premium', 18900.00, 30),
	('BRILLIANT EARTH 1.00 VVS1 Premium', 'D', 'BRILLIANT EARTH', '1.00', 'VVS1', 'Premium', 14200.00, 30),
	('BRILLIANT EARTH 1.35 VVS2 Premium', 'H', 'BRILLIANT EARTH', '1.35', 'VVS2', 'Premium', 17500.00, 30),
	('BRILLIANT EARTH 0.90 VVS1 Premium', 'E', 'BRILLIANT EARTH', '0.90', 'VVS1', 'Premium', 13000.00, 30),
	('BRILLIANT EARTH 1.05 VVS1 Premium', 'F', 'BRILLIANT EARTH', '1.05', 'VVS1', 'Premium', 15000.00, 30),
	('BRILLIANT EARTH 1.15 VVS2 Premium', 'I', 'BRILLIANT EARTH', '1.15', 'VVS2', 'Premium', 16000.00, 30),
	('BRILLIANT EARTH 1.25 VVS2 Premium', 'J', 'BRILLIANT EARTH', '1.25', 'VVS2', 'Premium', 17000.00, 30),
	('WORLD GEM 1.5 Carat H SI1 Premium', 'H', 'WORLD GEM', '1.5', 'SI1', 'Premium', 10000.00, 30),
	('WORLD GEM 1.8 Carat J SI2 Very Good', 'J', 'WORLD GEM', '1.8', 'SI2', 'Very Good', 12500.00, 30),
	('WORLD GEM 1.6 Carat H SI1 Ideal', 'H', 'WORLD GEM', '1.6', 'SI1', 'Ideal', 11000.00, 30),
	('WORLD GEM 1.0 Carat J SI2 Excellent', 'J', 'WORLD GEM', '1.0', 'SI2', 'Excellent', 7000.00, 30),
	('WORLD GEM 0.9 Carat H SI1 Ideal', 'H', 'WORLD GEM', '0.9', 'SI1', 'Ideal', 6800.00, 30),
	('WORLD GEM 1.1 Carat J SI2 Premium', 'J', 'WORLD GEM', '1.1', 'SI2', 'Premium', 7500.00, 30),
	('WORLD GEM 1.3 Carat H SI1 Premium', 'H', 'WORLD GEM', '1.3', 'SI1', 'Premium', 9000.00, 30),
	('WORLD GEM 0.7 Carat J SI2 Very Good', 'J', 'WORLD GEM', '0.7', 'SI2', 'Very Good', 5000.00, 30),
	('WORLD GEM 1.6 Carat H SI1 Ideal', 'H', 'WORLD GEM', '1.6', 'SI1', 'Ideal', 11500.00, 30),
	('WORLD GEM 1.0 Carat J SI2 Excellent', 'J', 'WORLD GEM', '1.0', 'SI2', 'Excellent', 7200.00, 30),
	('WORLD GEM 1.5 Carat H SI1 Premium', 'H', 'WORLD GEM', '1.5', 'SI1', 'Premium', 10500.00, 30),
	('IGI 2.7ct VS2 Ideal', 'Colorless', 'IGI', '2.7', 'VS2', 'Ideal', 7800.00, 24),
	('IGI 2.3ct VS1 Ideal', 'Colorless', 'IGI', '2.3', 'VS1', 'Ideal', 7200.00, 24),
	('IGI 1.8ct VS1 Ideal', 'Colorless', 'IGI', '1.8', 'VS1', 'Ideal', 6800.00, 24),
	('IGI 2.0ct VS2 Ideal', 'Colorless', 'IGI', '2.0', 'VS2', 'Ideal', 7000.00, 24),
	('AGS 3.1ct VVS2 Very Good', 'Colorless', 'AGS', '3.1', 'VVS2', 'Very Good', 9200.00, 36),
	('AGS 2.9ct VVS1 Very Good', 'Colorless', 'AGS', '2.9', 'VVS1', 'Very Good', 8900.00, 36),
	('AGS 2.5ct VVS2 Very Good', 'Colorless', 'AGS', '2.5', 'VVS2', 'Very Good', 8000.00, 36),
	('AGS 2.3ct VVS1 Very Good', 'Colorless', 'AGS', '2.3', 'VVS1', 'Very Good', 8500.00, 36),
	('AGS 2.0ct VVS2 Very Good', 'Colorless', 'AGS', '2.0', 'VVS2', 'Very Good', 7800.00, 36);
go

--Diamond Pictures
insert into [Picture] (UrlPath, DiamondId, ProductId)
	select 'imgs/Diamonds/PreviewDiamond.png', [Diamond].Id, null
	from [Diamond];
go

insert into [Picture] (UrlPath, DiamondId, ProductId)
	select 'imgs/Diamonds/OverViewDiamond.png', [Diamond].Id, null
	from [Diamond];
go

insert into [Picture] (UrlPath, DiamondId, ProductId)
	select 'imgs/Diamonds/SideViewDiamond.png', [Diamond].Id, null
	from [Diamond];
go

--Clavia Rings
insert into [Picture](UrlPath, DiamondId, ProductId)
	select 'imgs/DiamondJewelry/Rings/Female/Clavia_Preview.png', null, [Product].Id
	from [Product]
	where [Product].[Type]='Ring' and [Product].[Name] like '%Clavia%';
go

insert into [Picture](UrlPath, DiamondId, ProductId)
	select 'imgs/DiamondJewelry/Rings/Female/Clavia_Stand.png', null, [Product].Id
	from [Product]
	where [Product].[Type]='Ring' and [Product].[Name] like '%Clavia%';
go

insert into [Picture](UrlPath, DiamondId, ProductId)
	select 'imgs/DiamondJewelry/Rings/Female/Clavia_Lay.png', null, [Product].Id
	from [Product]
	where [Product].[Type]='Ring' and [Product].[Name] like '%Clavia%';
go

--Coler Gem
use master;