use FlashyCarbon_DB;
go

--=============[RESET DATA]=============--
delete from [Picture];
delete from [Warranty]
delete from [OrderDetail];
delete from [CustomerPromotion];
delete from [Promotion];
delete from [Order];
delete from [ProductPart];
delete from [Diamond];
delete from [Certificate];
delete from [Product];
delete from [Category];
delete from [StakeHolder];
delete from [Customer];
delete from [Account];

--=============[INSERT DATA]=============--
insert into [Account](Email,[Password],[Role],[Status]) values
	('Admin@flashycarbon.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Admin','working'),
	('manager@flashycarbon.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Manager','working'),
	('hoangphse172789@fpt.edu.vn', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Manager', 'working'),
	('johhnydang@flashycarbon.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'SalesStaff', 'working'),
	('khoapug@flashycarbon.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'SalesStaff', 'working'),
	('rihanna@flashycarbon.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'SalesStaff', 'working'),
	('tungsike@wibu.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'DeliveryStaff', 'working'),
	('phule@giangho.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'DeliveryStaff', 'working'),

	('an.nguyen@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('ha.tran@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('minh.le@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('thuy.pham@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('tuan.ngo@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('lan.nguyen@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('danh.trinh@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('diem.le@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('bao.hoang@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('van.truong@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('duc.do@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('my.nguyen@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('tuan.le@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('phuong.tran@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('hai.ngo@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('thanh.nguyen@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('bao.tran@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('hong.le@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('minh.do@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default),
	('nga.nguyen@gmail.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'Customer', default);
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
	('Female Ring Gold 14K Clavia 3CT', 'Ring', 'White Gold', 0, 12274000, 122740, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Clavia 2CT', 'Ring', 'White Gold', 0, 53462000, 534620, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 18K Caste N 1.5CT', 'Ring', 'White Gold', 0, 17154000, 171540, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Caste N 1.5CT', 'Ring', 'White Gold', 0, 50487000, 504870, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Flourishing 3CT', 'Ring', 'White Gold', 0, 62032000, 620320, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Flourishing 2CT', 'Ring', 'White Gold', 0, 58392000, 583920, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 18K Flourishing 1CT', 'Ring', 'White Gold', 0, 54248000, 542480, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Bellamy N 1CT', 'Ring', 'White Gold', 0, 40159000, 401590, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Bellamy N 5C', 'Ring', 'White Gold', 0, 89766000, 897660, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Arternos 2CT', 'Ring', 'White Gold', 0, 58887000, 588870, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Arternos 1CT', 'Ring', 'White Gold', 0, 79505000, 795050, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Grandeur 5C', 'Ring', 'White Gold', 0, 48201000, 482010, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Grandeur 1CT', 'Ring', 'White Gold', 0, 62855000, 628550, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Amalia N 5C', 'Ring', 'White Gold', 0, 30894000, 308940, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Amalia N 1CT', 'Ring', 'White Gold', 0, 61959000, 619590, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Abby DN 5C', 'Ring', 'White Gold', 0, 33287000, 332870, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Abby DN 3C', 'Ring', 'White Gold', 0, 89965000, 899650, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Abby DN 2C', 'Ring', 'White Gold', 0, 81725000, 817250, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Adivity 5C', 'Ring', 'White Gold', 0, 14912000, 149120, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Female Ring Gold 14K Adivity 1CT', 'Ring', 'White Gold', 0, 24340000, 243400, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	
	--Male
	('Male Ring Gold 14K A8 5C Y', 'Ring', 'White Gold', 1, 91264000, 912640, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K A8 3CT Y', 'Ring', 'White Gold', 1, 8779000, 87790, 14, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K A8 N 2CT Y', 'Ring', 'White Gold', 1, 41341000, 413410, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K A8 1.5CT Y', 'Ring', 'White Gold', 1, 88080000, 880800, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Aventador D 5C W', 'Ring', 'White Gold', 1, 21842000, 218420, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Aventador D 1CT W', 'Ring', 'White Gold', 1, 40353000, 403530, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Platinum 14K Authentic 5C WY', 'Ring', 'Platinum', 1, 88695000, 886950, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Authentic 3C WY', 'Ring', 'White Gold', 1, 99386000, 993860, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Authentic 1CT WY', 'Ring', 'White Gold', 1, 31307000, 313070, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Caddie 5C W', 'Ring', 'White Gold', 1, 86035000, 860350, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Caddie 3CT W', 'Ring', 'White Gold', 1, 90604000, 906040, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Caddie 2CT W', 'Ring', 'White Gold', 1, 63032000, 630320, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Caddie 1CT W', 'Ring', 'White Gold', 1, 37834000, 378340, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Candid N 5C W', 'Ring', 'White Gold', 1, 38284000, 382840, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Candid N 3C W', 'Ring', 'White Gold', 1, 10837000, 108370, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Candid N 2CT W', 'Ring', 'White Gold', 1, 98724000, 987240, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 14K Candid N 1CT W', 'Ring', 'White Gold', 1, 67776000, 677760, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 10K Pinnacle N 3C W', 'Ring', 'White Gold', 1, 17867000, 178670, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 10K Pinnacle N 2C W', 'Ring', 'White Gold', 1, 85222000, 852220, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Male Ring Gold 10K Pinnacle 2C W', 'Ring', 'White Gold', 1, 29999000, 299990, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry'));
go

insert into [Product]([Name], [Type], Material, Price, Point, WarrantyPeriod, CategoryId) values
-- Earring
	('Earring Platinum 950 Basque S 5C', 'Earring', 'Platinum', 47661000, 476610, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Earring Platinum 950 Canzon 2C', 'Earring', 'Platinum', 34299000, 342990, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Earring Platinum 950 Jasmine S 3C', 'Earring', 'Platinum', 75216000, 752160, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Earring Platinum 950 Jasmine S 2C', 'Earring', 'Platinum', 59185000, 591850, 9, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Earring Platinum 950 Ratline 3C', 'Earring', 'Platinum', 72503000, 725030, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Earring Gold 14K Flowery 5C', 'Earring', 'White Gold', 94817000, 948170, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Earring Gold 14K Flowery 3C', 'Earring', 'White Gold', 90477000, 904770, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry'));
go

insert into [Product]([Name], [Type], Material, Price, Point, WarrantyPeriod, CategoryId) values
-- Pendant
	('Pendant Gold 14K Flowery 5C', 'Pendant', 'White Gold', 9432000, 94320, 15, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Pendant Gold 14K Gerberas 1CT', 'Pendant', 'White Gold', 72115000, 721150, 13, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Pendant Gold 14K Benicia N 5C', 'Pendant', 'White Gold', 94856000, 948560, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

-- Bangles
	('Bangles Gold 14K Bambina', 'Bangles', 'White Gold', 33410000, 334100, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Bangles Gold 14K Gratify 2C', 'Bangles', 'White Gold', 16285000, 162850, 11, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Bangles Gold 14K Hilarial 3C', 'Bangles', 'White Gold', 84249000, 842490, 10, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Bangles Gold 14K Naiya 3C', 'Bangles', 'White Gold',96176000, 961760, 8, (select Id from [Category] where [Name] = 'Diamond Jewelry')),

-- Bracelets
	('Bracelet Gold 14K Dacing S 1CT', 'Bracelet', 'White Gold', 77084000, 770840, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Bracelet Gold 14K Lucky U S 2C', 'Bracelet', 'White Gold', 6351000, 63510, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Bracelet Gold 14K Benicia N 5C', 'Bracelet', 'White Gold', 89954000, 899540, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry')),
	('Bracelet Gold 14K Gerberas 1CT', 'Bracelet', 'White Gold', 42937000, 429370, 12, (select Id from [Category] where [Name] = 'Diamond Jewelry'));
go

--==============================[ CERTIFICATE ]==============================
insert into [Certificate](ReportNumber, Origin, Shape, Color, Clarity, Cut, CaratWeight, DateOfIssue) values
('6375879020', 'GIA', 'Oval', 'E', 'VS2', 'Fair', '0.19 carat', '2021-01-17'),
('1565842837', 'GIA', 'Octagonal', 'W', 'I3', 'Fair', '4.54 carat', '2021-04-22'),
('2852728783', 'GIA', 'Rectangle', 'K', 'I1', 'VeryGood', '4.68 carat', '2023-08-01'),
('2766489949', 'GIA', 'Pear', 'F', 'FL', 'Excellent', '1.32 carat', '2021-01-01'),
('2475221970', 'GIA', 'Square', 'N', 'FL', 'Excellent', '4.34 carat', '2021-08-12'),
('3643565244', 'GIA', 'Oval', 'T', 'I1', 'Poor', '2.02 carat', '2023-04-11'),
('2174071087', 'GIA', 'Oval', 'Z', 'VVS2', 'Poor', '0.71 carat', '2020-07-23'),
('4871473747', 'GIA', 'Pear', 'W', 'I3', 'Poor', '2.41 carat', '2022-09-19'),
('7472316798', 'GIA', 'Oval', 'M', 'I1', 'VeryGood', '1.87 carat', '2022-12-04'),
('6297345746', 'GIA', 'Rectangle', 'P', 'SI1', 'Poor', '0.47 carat', '2020-02-13'),
('3791648207', 'GIA', 'Rectangle', 'E', 'I2', 'Poor', '3.90 carat', '2022-05-23'),
('6689342078', 'GIA', 'Pear', 'V', 'FL', 'Excellent', '0.16 carat', '2021-06-24'),
('1253568535', 'GIA', 'Octagonal', 'T', 'SI2', 'VeryGood', '4.85 carat', '2020-09-12'),
('5513525010', 'GIA', 'Square', 'L', 'VS1', 'Good', '5 carat', '2023-07-23'),
('4536392036', 'GIA', 'Square', 'D', 'I2', 'Good', '2.60 carat', '2020-08-03'),
('4049413395', 'GIA', 'Triangle', 'N', 'FL', 'Fair', '1.06 carat', '2022-04-09'),
('6042032755', 'GIA', 'Oval', 'M', 'SI1', 'Fair', '0.32 carat', '2024-04-27'),
('6401890136', 'GIA', 'Triangle', 'J', 'I2', 'Good', '0.65 carat', '2022-04-05'),
('5465783487', 'GIA', 'Triangle', 'D', 'I3', 'Fair', '1.89 carat', '2023-06-02'),
('9153506207', 'GIA', 'Marquise', 'F', 'SI1', 'Fair', '1.04 carat', '2023-05-10'),
('3475459382', 'IGI', 'Rectangle', 'Q', 'VVS1', 'Fair', '0.73 carat', '2023-07-11'),
('8055764929', 'IGI', 'Round', 'K', 'SI2', 'Fair', '1.98 carat', '2022-03-20'),
('2584036661', 'IGI', 'Marquise', 'J', 'IF', 'Fair', '4.15 carat', '2021-06-14'),
('1285464843', 'IGI', 'Triangle', 'G', 'VVS1', 'Good', '1.03 carat', '2024-09-08'),
('7720571140', 'IGI', 'Round', 'N', 'SI1', 'Excellent', '4.44 carat', '2022-01-21'),
('4502854078', 'IGI', 'Heart', 'X', 'VS2', 'Poor', '2.45 carat', '2021-07-27'),
('0883278945', 'IGI', 'Rectangle', 'L', 'SI2', 'Fair', '1.55 carat', '2024-08-21'),
('3067204304', 'IGI', 'Octagonal', 'E', 'SI1', 'Excellent', '2.68 carat', '2020-09-11'),
('6859729105', 'IGI', 'Oval', 'K', 'I1', 'Poor', '3.57 carat', '2023-08-21'),
('1687456451', 'IGI', 'Oval', 'Z', 'VS2', 'Fair', '3.35 carat', '2023-07-19'),
('7482696030', 'IGI', 'Round', 'U', 'SI1', 'Excellent', '2.85 carat', '2020-10-03'),
('2609677411', 'IGI', 'Octagonal', 'M', 'FL', 'Fair', '2.40 carat', '2022-12-07'),
('5578995429', 'IGI', 'Triangle', 'Q', 'VVS1', 'Good', '2.46 carat', '2020-01-13'),
('2178316095', 'IGI', 'Round', 'M', 'SI2', 'Fair', '1.71 carat', '2024-02-15'),
('7778527227', 'IGI', 'Rectangle', 'H', 'VVS2', 'VeryGood', '3.73 carat', '2024-03-09'),
('5446711974', 'IGI', 'Triangle', 'Y', 'VS1', 'Good', '0.14 carat', '2021-06-03'),
('2593260860', 'IGI', 'Marquise', 'Z', 'I1', 'Excellent', '4.42 carat', '2020-07-10'),
('3509152119', 'IGI', 'Round', 'T', 'IF', 'VeryGood', '0.23 carat', '2024-05-18'),
('4019991897', 'IGI', 'Rectangle', 'E', 'VVS1', 'Good', '4.38 carat', '2021-04-11'),
('2045050722', 'IGI', 'Octagonal', 'X', 'VS1', 'Excellent', '2.43 carat', '2023-12-04'),
('1942627499', 'AGS', 'Oval', 'M', 'I1', 'Poor', '1.04 carat', '2024-02-02'),
('9896849880', 'AGS', 'Octagonal', 'L', 'SI2', 'Good', '0.19 carat', '2022-09-27'),
('9392175363', 'AGS', 'Rectangle', 'D', 'I1', 'Fair', '3.46 carat', '2022-07-28'),
('2992594357', 'AGS', 'Triangle', 'J', 'VS1', 'Good', '0.19 carat', '2024-12-12'),
('5140269229', 'AGS', 'Marquise', 'L', 'VS2', 'Poor', '0.14 carat', '2024-10-18'),
('7353627484', 'AGS', 'Round', 'F', 'I2', 'Excellent', '3.87 carat', '2024-09-11'),
('8946063802', 'AGS', 'Square', 'L', 'VS2', 'Good', '3.32 carat', '2021-07-28'),
('0210332640', 'AGS', 'Triangle', 'Y', 'SI1', 'Fair', '4.63 carat', '2020-01-22'),
('3167974706', 'AGS', 'Pear', 'M', 'SI1', 'VeryGood', '1.16 carat', '2024-11-23'),
('7973808062', 'AGS', 'Heart', 'M', 'I3', 'VeryGood', '4.66 carat', '2020-09-15'),
('7147259080', 'AGS', 'Oval', 'T', 'I3', 'VeryGood', '0.31 carat', '2021-11-26'),
('0136858329', 'AGS', 'Octagonal', 'X', 'VS1', 'Good', '2.70 carat', '2023-07-14'),
('7157931309', 'AGS', 'Square', 'N', 'I2', 'VeryGood', '1.10 carat', '2022-03-16'),
('3407258018', 'AGS', 'Pear', 'E', 'VVS2', 'Good', '1.53 carat', '2021-06-17'),
('0365492764', 'AGS', 'Marquise', 'K', 'I3', 'Poor', '3.96 carat', '2021-10-20'),
('0966089485', 'AGS', 'Rectangle', 'S', 'VVS2', 'Poor', '1.99 carat', '2023-10-11'),
('6281957504', 'AGS', 'Octagonal', 'U', 'SI2', 'Good', '2.98 carat', '2020-07-12'),
('2981881085', 'AGS', 'Square', 'E', 'SI1', 'Poor', '4.89 carat', '2021-10-11'),
('1738271880', 'AGS', 'Marquise', 'G', 'IF', 'Good', '2.16 carat', '2023-11-04'),
('0199239630', 'AGS', 'Marquise', 'N', 'VS2', 'Fair', '3.75 carat', '2024-05-05'),
('4446650806', 'HRD', 'Rectangle', 'O', 'VVS1', 'VeryGood', '3.80 carat', '2021-01-06'),
('8549105387', 'HRD', 'Rectangle', 'J', 'FL', 'Poor', '1.58 carat', '2023-10-23'),
('4936365716', 'HRD', 'Round', 'E', 'SI1', 'Excellent', '1 carat', '2024-02-18'),
('9566910957', 'HRD', 'Heart', 'G', 'SI2', 'Poor', '4.88 carat', '2024-07-21'),
('7726998828', 'HRD', 'Marquise', 'Z', 'I3', 'Good', '3.88 carat', '2023-03-15'),
('5114621758', 'HRD', 'Rectangle', 'R', 'I1', 'Good', '0.39 carat', '2024-10-22'),
('7105020231', 'HRD', 'Triangle', 'S', 'I1', 'Poor', '3.34 carat', '2021-06-03'),
('7378757059', 'HRD', 'Oval', 'F', 'VVS2', 'VeryGood', '3.65 carat', '2022-02-03'),
('0859329600', 'HRD', 'Marquise', 'J', 'I3', 'Poor', '2.43 carat', '2020-10-02'),
('7348344572', 'HRD', 'Square', 'O', 'VVS2', 'Poor', '1.01 carat', '2020-09-01'),
('6413081579', 'HRD', 'Pear', 'J', 'I2', 'Good', '0.25 carat', '2024-08-08'),
('9295399888', 'HRD', 'Round', 'W', 'I1', 'Excellent', '3.33 carat', '2022-12-13'),
('5014975517', 'HRD', 'Oval', 'R', 'VS1', 'Poor', '4.94 carat', '2023-09-20'),
('6148980699', 'HRD', 'Oval', 'D', 'VVS2', 'Good', '2.75 carat', '2021-04-27'),
('6961781659', 'HRD', 'Octagonal', 'E', 'VS1', 'Poor', '3.15 carat', '2021-10-25'),
('1183250666', 'HRD', 'Pear', 'N', 'SI1', 'Good', '4.44 carat', '2020-10-27'),
('9084400278', 'HRD', 'Rectangle', 'Y', 'VS2', 'Good', '4.40 carat', '2021-12-02'),
('5832937973', 'HRD', 'Pear', 'G', 'VS1', 'Excellent', '3.99 carat', '2021-10-12'),
('3034274266', 'HRD', 'Heart', 'Y', 'VS1', 'VeryGood', '3.70 carat', '2021-02-17'),
('5343219843', 'HRD', 'Heart', 'P', 'SI2', 'Fair', '2.80 carat', '2022-03-01'),
('6130090811', 'EGL', 'Triangle', 'Q', 'SI2', 'VeryGood', '3.15 carat', '2020-02-20'),
('4883635920', 'EGL', 'Pear', 'N', 'IF', 'Poor', '3.65 carat', '2024-10-28'),
('5890652207', 'EGL', 'Rectangle', 'E', 'FL', 'Poor', '4.48 carat', '2021-01-12'),
('5427718453', 'EGL', 'Square', 'G', 'IF', 'Excellent', '4.82 carat', '2023-03-06'),
('2733905790', 'EGL', 'Square', 'U', 'I1', 'Fair', '2.61 carat', '2020-09-02'),
('2659987212', 'EGL', 'Round', 'V', 'SI1', 'VeryGood', '3.56 carat', '2021-03-12'),
('6472457567', 'EGL', 'Marquise', 'W', 'IF', 'Good', '4.51 carat', '2022-12-15'),
('6779876080', 'EGL', 'Marquise', 'Q', 'I2', 'Poor', '0.87 carat', '2022-11-24'),
('3461084449', 'EGL', 'Triangle', 'F', 'VVS2', 'Good', '2 carat', '2021-01-10'),
('6025102157', 'EGL', 'Triangle', 'Q', 'I1', 'Fair', '1.13 carat', '2024-05-06'),
('6789014926', 'EGL', 'Rectangle', 'Z', 'I1', 'Excellent', '4.67 carat', '2023-07-02'),
('1655268164', 'EGL', 'Heart', 'G', 'I3', 'Fair', '4.32 carat', '2024-10-22'),
('8943627332', 'EGL', 'Rectangle', 'Q', 'SI1', 'VeryGood', '3.66 carat', '2023-10-09'),
('3022727578', 'EGL', 'Rectangle', 'P', 'SI1', 'VeryGood', '1.85 carat', '2022-10-09'),
('0423495935', 'EGL', 'Octagonal', 'T', 'VVS2', 'Fair', '0.88 carat', '2024-11-01'),
('7346653459', 'EGL', 'Pear', 'S', 'I2', 'Fair', '2.75 carat', '2023-02-27'),
('2742191204', 'EGL', 'Rectangle', 'S', 'VVS1', 'Excellent', '3.81 carat', '2024-11-25'),
('2473803768', 'EGL', 'Pear', 'W', 'I1', 'Poor', '3.52 carat', '2021-08-14'),
('9105474365', 'EGL', 'Oval', 'V', 'FL', 'Poor', '1.43 carat', '2023-07-27'),
('6971850191', 'EGL', 'Marquise', 'D', 'IF', 'Good', '1.36 carat', '2020-01-14'),
('9954870780', 'CGL', 'Round', 'W', 'VVS1', 'Fair', '3.62 carat', '2022-07-01'),
('5247804165', 'CGL', 'Rectangle', 'F', 'IF', 'VeryGood', '4.85 carat', '2020-10-05'),
('3370837321', 'CGL', 'Pear', 'L', 'I1', 'Excellent', '2.12 carat', '2020-05-11'),
('8665980595', 'CGL', 'Oval', 'M', 'I1', 'VeryGood', '2.10 carat', '2023-06-08'),
('3632063835', 'CGL', 'Oval', 'M', 'FL', 'VeryGood', '3.41 carat', '2023-01-16'),
('3695780069', 'CGL', 'Square', 'Y', 'SI2', 'Poor', '3.37 carat', '2021-02-18'),
('9717170073', 'CGL', 'Round', 'W', 'VVS2', 'VeryGood', '1.62 carat', '2022-01-26'),
('5525707333', 'CGL', 'Triangle', 'M', 'VVS1', 'VeryGood', '0.38 carat', '2024-05-28'),
('2115585249', 'CGL', 'Round', 'F', 'FL', 'Fair', '0.30 carat', '2024-08-27'),
('5966497953', 'CGL', 'Oval', 'E', 'SI2', 'Fair', '3.11 carat', '2021-01-04'),
('0375204683', 'CGL', 'Oval', 'O', 'IF', 'VeryGood', '0.85 carat', '2023-12-07'),
('2955503837', 'CGL', 'Rectangle', 'V', 'I2', 'VeryGood', '3.22 carat', '2023-11-01'),
('8051723081', 'CGL', 'Rectangle', 'X', 'FL', 'Good', '3.86 carat', '2021-08-09'),
('8990591950', 'CGL', 'Rectangle', 'J', 'VS1', 'Good', '1.30 carat', '2021-12-28'),
('1925231087', 'CGL', 'Rectangle', 'R', 'FL', 'Good', '1.68 carat', '2022-07-08'),
('9492005008', 'CGL', 'Marquise', 'Q', 'VVS1', 'VeryGood', '1.44 carat', '2020-06-03'),
('8478053890', 'CGL', 'Round', 'Z', 'I3', 'Good', '2.33 carat', '2022-12-09'),
('6088504798', 'CGL', 'Marquise', 'V', 'I1', 'Fair', '3.08 carat', '2020-12-02'),
('4257348545', 'CGL', 'Heart', 'D', 'IF', 'Excellent', '0.97 carat', '2022-08-21'),
('3233569629', 'CGL', 'Rectangle', 'J', 'I3', 'VeryGood', '3.46 carat', '2023-09-07');
go

--==============================[ DIAMOND ]==============================
insert into [Diamond](Origin, Shape, Color, Clarity, Cut, CaratWeight, Point, Price, Quantity, WarrantyPeriod, CertificateId) values
('GIA', 'Oval', 'E', 'VS2', 'Fair', '0.19 carat', '279809', '27980911', '4', '11',(select Id from [Certificate] where ReportNumber='6375879020' and Origin='GIA' and Shape='Oval' and Color='E' and Clarity='VS2' and Cut='Fair' and CaratWeight='0.19 carat')),
('GIA', 'Octagonal', 'W', 'I3', 'Fair', '4.54 carat', '761896', '76189694', '5', '16',(select Id from [Certificate] where ReportNumber='1565842837' and Origin='GIA' and Shape='Octagonal' and Color='W' and Clarity='I3' and Cut='Fair' and CaratWeight='4.54 carat')),
('GIA', 'Rectangle', 'K', 'I1', 'VeryGood', '4.68 carat', '392229', '39222939', '2', '20',(select Id from [Certificate] where ReportNumber='2852728783' and Origin='GIA' and Shape='Rectangle' and Color='K' and Clarity='I1' and Cut='VeryGood' and CaratWeight='4.68 carat')),
('GIA', 'Pear', 'F', 'FL', 'Excellent', '1.32 carat', '396784', '39678414', '5', '24',(select Id from [Certificate] where ReportNumber='2766489949' and Origin='GIA' and Shape='Pear' and Color='F' and Clarity='FL' and Cut='Excellent' and CaratWeight='1.32 carat')),
('GIA', 'Square', 'N', 'FL', 'Excellent', '4.34 carat', '93270', '9327023', '4', '16',(select Id from [Certificate] where ReportNumber='2475221970' and Origin='GIA' and Shape='Square' and Color='N' and Clarity='FL' and Cut='Excellent' and CaratWeight='4.34 carat')),
('GIA', 'Oval', 'T', 'I1', 'Poor', '2.02 carat', '310177', '31017722', '4', '12',(select Id from [Certificate] where ReportNumber='3643565244' and Origin='GIA' and Shape='Oval' and Color='T' and Clarity='I1' and Cut='Poor' and CaratWeight='2.02 carat')),
('GIA', 'Oval', 'Z', 'VVS2', 'Poor', '0.71 carat', '995584', '99558465', '2', '21',(select Id from [Certificate] where ReportNumber='2174071087' and Origin='GIA' and Shape='Oval' and Color='Z' and Clarity='VVS2' and Cut='Poor' and CaratWeight='0.71 carat')),
('GIA', 'Pear', 'W', 'I3', 'Poor', '2.41 carat', '976781', '97678150', '3', '18',(select Id from [Certificate] where ReportNumber='4871473747' and Origin='GIA' and Shape='Pear' and Color='W' and Clarity='I3' and Cut='Poor' and CaratWeight='2.41 carat')),
('GIA', 'Oval', 'M', 'I1', 'VeryGood', '1.87 carat', '260873', '26087356', '1', '6',(select Id from [Certificate] where ReportNumber='7472316798' and Origin='GIA' and Shape='Oval' and Color='M' and Clarity='I1' and Cut='VeryGood' and CaratWeight='1.87 carat')),
('GIA', 'Rectangle', 'P', 'SI1', 'Poor', '0.47 carat', '948291', '94829198', '2', '8',(select Id from [Certificate] where ReportNumber='6297345746' and Origin='GIA' and Shape='Rectangle' and Color='P' and Clarity='SI1' and Cut='Poor' and CaratWeight='0.47 carat')),
('GIA', 'Rectangle', 'E', 'I2', 'Poor', '3.90 carat', '860681', '86068146', '4', '21',(select Id from [Certificate] where ReportNumber='3791648207' and Origin='GIA' and Shape='Rectangle' and Color='E' and Clarity='I2' and Cut='Poor' and CaratWeight='3.90 carat')),
('GIA', 'Pear', 'V', 'FL', 'Excellent', '0.16 carat', '965211', '96521112', '4', '16',(select Id from [Certificate] where ReportNumber='6689342078' and Origin='GIA' and Shape='Pear' and Color='V' and Clarity='FL' and Cut='Excellent' and CaratWeight='0.16 carat')),
('GIA', 'Octagonal', 'T', 'SI2', 'VeryGood', '4.85 carat', '860099', '86009983', '5', '7',(select Id from [Certificate] where ReportNumber='1253568535' and Origin='GIA' and Shape='Octagonal' and Color='T' and Clarity='SI2' and Cut='VeryGood' and CaratWeight='4.85 carat')),
('GIA', 'Square', 'L', 'VS1', 'Good', '5 carat', '77933', '7793346', '2', '15',(select Id from [Certificate] where ReportNumber='5513525010' and Origin='GIA' and Shape='Square' and Color='L' and Clarity='VS1' and Cut='Good' and CaratWeight='5 carat')),
('GIA', 'Square', 'D', 'I2', 'Good', '2.60 carat', '941044', '94104464', '5', '15',(select Id from [Certificate] where ReportNumber='4536392036' and Origin='GIA' and Shape='Square' and Color='D' and Clarity='I2' and Cut='Good' and CaratWeight='2.60 carat')),
('GIA', 'Triangle', 'N', 'FL', 'Fair', '1.06 carat', '548640', '54864016', '5', '23',(select Id from [Certificate] where ReportNumber='4049413395' and Origin='GIA' and Shape='Triangle' and Color='N' and Clarity='FL' and Cut='Fair' and CaratWeight='1.06 carat')),
('GIA', 'Oval', 'M', 'SI1', 'Fair', '0.32 carat', '745817', '74581789', '4', '12',(select Id from [Certificate] where ReportNumber='6042032755' and Origin='GIA' and Shape='Oval' and Color='M' and Clarity='SI1' and Cut='Fair' and CaratWeight='0.32 carat')),
('GIA', 'Triangle', 'J', 'I2', 'Good', '0.65 carat', '737197', '73719770', '1', '15',(select Id from [Certificate] where ReportNumber='6401890136' and Origin='GIA' and Shape='Triangle' and Color='J' and Clarity='I2' and Cut='Good' and CaratWeight='0.65 carat')),
('GIA', 'Triangle', 'D', 'I3', 'Fair', '1.89 carat', '654280', '65428035', '4', '18',(select Id from [Certificate] where ReportNumber='5465783487' and Origin='GIA' and Shape='Triangle' and Color='D' and Clarity='I3' and Cut='Fair' and CaratWeight='1.89 carat')),
('GIA', 'Marquise', 'F', 'SI1', 'Fair', '1.04 carat', '79099', '7909974', '5', '20',(select Id from [Certificate] where ReportNumber='9153506207' and Origin='GIA' and Shape='Marquise' and Color='F' and Clarity='SI1' and Cut='Fair' and CaratWeight='1.04 carat')),
('IGI', 'Rectangle', 'Q', 'VVS1', 'Fair', '0.73 carat', '998911', '99891196', '3', '19',(select Id from [Certificate] where ReportNumber='3475459382' and Origin='IGI' and Shape='Rectangle' and Color='Q' and Clarity='VVS1' and Cut='Fair' and CaratWeight='0.73 carat')),
('IGI', 'Round', 'K', 'SI2', 'Fair', '1.98 carat', '613233', '61323361', '3', '8',(select Id from [Certificate] where ReportNumber='8055764929' and Origin='IGI' and Shape='Round' and Color='K' and Clarity='SI2' and Cut='Fair' and CaratWeight='1.98 carat')),
('IGI', 'Marquise', 'J', 'IF', 'Fair', '4.15 carat', '509719', '50971941', '5', '6',(select Id from [Certificate] where ReportNumber='2584036661' and Origin='IGI' and Shape='Marquise' and Color='J' and Clarity='IF' and Cut='Fair' and CaratWeight='4.15 carat')),
('IGI', 'Triangle', 'G', 'VVS1', 'Good', '1.03 carat', '396767', '39676758', '3', '22',(select Id from [Certificate] where ReportNumber='1285464843' and Origin='IGI' and Shape='Triangle' and Color='G' and Clarity='VVS1' and Cut='Good' and CaratWeight='1.03 carat')),
('IGI', 'Round', 'N', 'SI1', 'Excellent', '4.44 carat', '570384', '57038479', '2', '7',(select Id from [Certificate] where ReportNumber='7720571140' and Origin='IGI' and Shape='Round' and Color='N' and Clarity='SI1' and Cut='Excellent' and CaratWeight='4.44 carat')),
('IGI', 'Heart', 'X', 'VS2', 'Poor', '2.45 carat', '696300', '69630043', '1', '14',(select Id from [Certificate] where ReportNumber='4502854078' and Origin='IGI' and Shape='Heart' and Color='X' and Clarity='VS2' and Cut='Poor' and CaratWeight='2.45 carat')),
('IGI', 'Rectangle', 'L', 'SI2', 'Fair', '1.55 carat', '365188', '36518829', '4', '10',(select Id from [Certificate] where ReportNumber='0883278945' and Origin='IGI' and Shape='Rectangle' and Color='L' and Clarity='SI2' and Cut='Fair' and CaratWeight='1.55 carat')),
('IGI', 'Octagonal', 'E', 'SI1', 'Excellent', '2.68 carat', '932561', '93256122', '3', '20',(select Id from [Certificate] where ReportNumber='3067204304' and Origin='IGI' and Shape='Octagonal' and Color='E' and Clarity='SI1' and Cut='Excellent' and CaratWeight='2.68 carat')),
('IGI', 'Oval', 'K', 'I1', 'Poor', '3.57 carat', '295665', '29566559', '1', '9',(select Id from [Certificate] where ReportNumber='6859729105' and Origin='IGI' and Shape='Oval' and Color='K' and Clarity='I1' and Cut='Poor' and CaratWeight='3.57 carat')),
('IGI', 'Oval', 'Z', 'VS2', 'Fair', '3.35 carat', '528691', '52869176', '2', '16',(select Id from [Certificate] where ReportNumber='1687456451' and Origin='IGI' and Shape='Oval' and Color='Z' and Clarity='VS2' and Cut='Fair' and CaratWeight='3.35 carat')),
('IGI', 'Round', 'U', 'SI1', 'Excellent', '2.85 carat', '393996', '39399611', '2', '12',(select Id from [Certificate] where ReportNumber='7482696030' and Origin='IGI' and Shape='Round' and Color='U' and Clarity='SI1' and Cut='Excellent' and CaratWeight='2.85 carat')),
('IGI', 'Octagonal', 'M', 'FL', 'Fair', '2.40 carat', '770654', '77065426', '4', '19',(select Id from [Certificate] where ReportNumber='2609677411' and Origin='IGI' and Shape='Octagonal' and Color='M' and Clarity='FL' and Cut='Fair' and CaratWeight='2.40 carat')),
('IGI', 'Triangle', 'Q', 'VVS1', 'Good', '2.46 carat', '967044', '96704411', '2', '22',(select Id from [Certificate] where ReportNumber='5578995429' and Origin='IGI' and Shape='Triangle' and Color='Q' and Clarity='VVS1' and Cut='Good' and CaratWeight='2.46 carat')),
('IGI', 'Round', 'M', 'SI2', 'Fair', '1.71 carat', '444715', '44471553', '3', '20',(select Id from [Certificate] where ReportNumber='2178316095' and Origin='IGI' and Shape='Round' and Color='M' and Clarity='SI2' and Cut='Fair' and CaratWeight='1.71 carat')),
('IGI', 'Rectangle', 'H', 'VVS2', 'VeryGood', '3.73 carat', '695665', '69566541', '2', '15',(select Id from [Certificate] where ReportNumber='7778527227' and Origin='IGI' and Shape='Rectangle' and Color='H' and Clarity='VVS2' and Cut='VeryGood' and CaratWeight='3.73 carat')),
('IGI', 'Triangle', 'Y', 'VS1', 'Good', '0.14 carat', '778081', '77808121', '5', '9',(select Id from [Certificate] where ReportNumber='5446711974' and Origin='IGI' and Shape='Triangle' and Color='Y' and Clarity='VS1' and Cut='Good' and CaratWeight='0.14 carat')),
('IGI', 'Marquise', 'Z', 'I1', 'Excellent', '4.42 carat', '164123', '16412316', '1', '7',(select Id from [Certificate] where ReportNumber='2593260860' and Origin='IGI' and Shape='Marquise' and Color='Z' and Clarity='I1' and Cut='Excellent' and CaratWeight='4.42 carat')),
('IGI', 'Round', 'T', 'IF', 'VeryGood', '0.23 carat', '295816', '29581660', '2', '18',(select Id from [Certificate] where ReportNumber='3509152119' and Origin='IGI' and Shape='Round' and Color='T' and Clarity='IF' and Cut='VeryGood' and CaratWeight='0.23 carat')),
('IGI', 'Rectangle', 'E', 'VVS1', 'Good', '4.38 carat', '72354', '7235430', '2', '15',(select Id from [Certificate] where ReportNumber='4019991897' and Origin='IGI' and Shape='Rectangle' and Color='E' and Clarity='VVS1' and Cut='Good' and CaratWeight='4.38 carat')),
('IGI', 'Octagonal', 'X', 'VS1', 'Excellent', '2.43 carat', '199281', '19928133', '4', '19',(select Id from [Certificate] where ReportNumber='2045050722' and Origin='IGI' and Shape='Octagonal' and Color='X' and Clarity='VS1' and Cut='Excellent' and CaratWeight='2.43 carat')),
('AGS', 'Oval', 'M', 'I1', 'Poor', '1.04 carat', '750282', '75028285', '3', '9',(select Id from [Certificate] where ReportNumber='1942627499' and Origin='AGS' and Shape='Oval' and Color='M' and Clarity='I1' and Cut='Poor' and CaratWeight='1.04 carat')),
('AGS', 'Octagonal', 'L', 'SI2', 'Good', '0.19 carat', '327254', '32725427', '1', '12',(select Id from [Certificate] where ReportNumber='9896849880' and Origin='AGS' and Shape='Octagonal' and Color='L' and Clarity='SI2' and Cut='Good' and CaratWeight='0.19 carat')),
('AGS', 'Rectangle', 'D', 'I1', 'Fair', '3.46 carat', '494401', '49440166', '3', '9',(select Id from [Certificate] where ReportNumber='9392175363' and Origin='AGS' and Shape='Rectangle' and Color='D' and Clarity='I1' and Cut='Fair' and CaratWeight='3.46 carat')),
('AGS', 'Triangle', 'J', 'VS1', 'Good', '0.19 carat', '852783', '85278398', '2', '18',(select Id from [Certificate] where ReportNumber='2992594357' and Origin='AGS' and Shape='Triangle' and Color='J' and Clarity='VS1' and Cut='Good' and CaratWeight='0.19 carat')),
('AGS', 'Marquise', 'L', 'VS2', 'Poor', '0.14 carat', '167603', '16760362', '3', '18',(select Id from [Certificate] where ReportNumber='5140269229' and Origin='AGS' and Shape='Marquise' and Color='L' and Clarity='VS2' and Cut='Poor' and CaratWeight='0.14 carat')),
('AGS', 'Round', 'F', 'I2', 'Excellent', '3.87 carat', '107517', '10751701', '5', '12',(select Id from [Certificate] where ReportNumber='7353627484' and Origin='AGS' and Shape='Round' and Color='F' and Clarity='I2' and Cut='Excellent' and CaratWeight='3.87 carat')),
('AGS', 'Square', 'L', 'VS2', 'Good', '3.32 carat', '460993', '46099311', '5', '14',(select Id from [Certificate] where ReportNumber='8946063802' and Origin='AGS' and Shape='Square' and Color='L' and Clarity='VS2' and Cut='Good' and CaratWeight='3.32 carat')),
('AGS', 'Triangle', 'Y', 'SI1', 'Fair', '4.63 carat', '531826', '53182600', '3', '7',(select Id from [Certificate] where ReportNumber='0210332640' and Origin='AGS' and Shape='Triangle' and Color='Y' and Clarity='SI1' and Cut='Fair' and CaratWeight='4.63 carat')),
('AGS', 'Pear', 'M', 'SI1', 'VeryGood', '1.16 carat', '652981', '65298135', '1', '18',(select Id from [Certificate] where ReportNumber='3167974706' and Origin='AGS' and Shape='Pear' and Color='M' and Clarity='SI1' and Cut='VeryGood' and CaratWeight='1.16 carat')),
('AGS', 'Heart', 'M', 'I3', 'VeryGood', '4.66 carat', '745713', '74571335', '1', '7',(select Id from [Certificate] where ReportNumber='7973808062' and Origin='AGS' and Shape='Heart' and Color='M' and Clarity='I3' and Cut='VeryGood' and CaratWeight='4.66 carat')),
('AGS', 'Oval', 'T', 'I3', 'VeryGood', '0.31 carat', '347313', '34731335', '1', '10',(select Id from [Certificate] where ReportNumber='7147259080' and Origin='AGS' and Shape='Oval' and Color='T' and Clarity='I3' and Cut='VeryGood' and CaratWeight='0.31 carat')),
('AGS', 'Octagonal', 'X', 'VS1', 'Good', '2.70 carat', '274236', '27423664', '2', '9',(select Id from [Certificate] where ReportNumber='0136858329' and Origin='AGS' and Shape='Octagonal' and Color='X' and Clarity='VS1' and Cut='Good' and CaratWeight='2.70 carat')),
('AGS', 'Square', 'N', 'I2', 'VeryGood', '1.10 carat', '902864', '90286493', '5', '17',(select Id from [Certificate] where ReportNumber='7157931309' and Origin='AGS' and Shape='Square' and Color='N' and Clarity='I2' and Cut='VeryGood' and CaratWeight='1.10 carat')),
('AGS', 'Pear', 'E', 'VVS2', 'Good', '1.53 carat', '337577', '33757796', '4', '10',(select Id from [Certificate] where ReportNumber='3407258018' and Origin='AGS' and Shape='Pear' and Color='E' and Clarity='VVS2' and Cut='Good' and CaratWeight='1.53 carat')),
('AGS', 'Marquise', 'K', 'I3', 'Poor', '3.96 carat', '236132', '23613209', '1', '10',(select Id from [Certificate] where ReportNumber='0365492764' and Origin='AGS' and Shape='Marquise' and Color='K' and Clarity='I3' and Cut='Poor' and CaratWeight='3.96 carat')),
('AGS', 'Rectangle', 'S', 'VVS2', 'Poor', '1.99 carat', '723806', '72380666', '2', '21',(select Id from [Certificate] where ReportNumber='0966089485' and Origin='AGS' and Shape='Rectangle' and Color='S' and Clarity='VVS2' and Cut='Poor' and CaratWeight='1.99 carat')),
('AGS', 'Octagonal', 'U', 'SI2', 'Good', '2.98 carat', '973351', '97335150', '2', '11',(select Id from [Certificate] where ReportNumber='6281957504' and Origin='AGS' and Shape='Octagonal' and Color='U' and Clarity='SI2' and Cut='Good' and CaratWeight='2.98 carat')),
('AGS', 'Square', 'E', 'SI1', 'Poor', '4.89 carat', '841046', '84104637', '3', '22',(select Id from [Certificate] where ReportNumber='2981881085' and Origin='AGS' and Shape='Square' and Color='E' and Clarity='SI1' and Cut='Poor' and CaratWeight='4.89 carat')),
('AGS', 'Marquise', 'G', 'IF', 'Good', '2.16 carat', '581815', '58181543', '5', '20',(select Id from [Certificate] where ReportNumber='1738271880' and Origin='AGS' and Shape='Marquise' and Color='G' and Clarity='IF' and Cut='Good' and CaratWeight='2.16 carat')),
('AGS', 'Marquise', 'N', 'VS2', 'Fair', '3.75 carat', '143700', '14370056', '3', '15',(select Id from [Certificate] where ReportNumber='0199239630' and Origin='AGS' and Shape='Marquise' and Color='N' and Clarity='VS2' and Cut='Fair' and CaratWeight='3.75 carat')),
('HRD', 'Rectangle', 'O', 'VVS1', 'VeryGood', '3.80 carat', '388637', '38863721', '5', '7',(select Id from [Certificate] where ReportNumber='4446650806' and Origin='HRD' and Shape='Rectangle' and Color='O' and Clarity='VVS1' and Cut='VeryGood' and CaratWeight='3.80 carat')),
('HRD', 'Rectangle', 'J', 'FL', 'Poor', '1.58 carat', '394178', '39417827', '3', '21',(select Id from [Certificate] where ReportNumber='8549105387' and Origin='HRD' and Shape='Rectangle' and Color='J' and Clarity='FL' and Cut='Poor' and CaratWeight='1.58 carat')),
('HRD', 'Round', 'E', 'SI1', 'Excellent', '1 carat', '210847', '21084748', '4', '12',(select Id from [Certificate] where ReportNumber='4936365716' and Origin='HRD' and Shape='Round' and Color='E' and Clarity='SI1' and Cut='Excellent' and CaratWeight='1 carat')),
('HRD', 'Heart', 'G', 'SI2', 'Poor', '4.88 carat', '463659', '46365924', '2', '18',(select Id from [Certificate] where ReportNumber='9566910957' and Origin='HRD' and Shape='Heart' and Color='G' and Clarity='SI2' and Cut='Poor' and CaratWeight='4.88 carat')),
('HRD', 'Marquise', 'Z', 'I3', 'Good', '3.88 carat', '828832', '82883220', '4', '11',(select Id from [Certificate] where ReportNumber='7726998828' and Origin='HRD' and Shape='Marquise' and Color='Z' and Clarity='I3' and Cut='Good' and CaratWeight='3.88 carat')),
('HRD', 'Rectangle', 'R', 'I1', 'Good', '0.39 carat', '531141', '53114142', '2', '23',(select Id from [Certificate] where ReportNumber='5114621758' and Origin='HRD' and Shape='Rectangle' and Color='R' and Clarity='I1' and Cut='Good' and CaratWeight='0.39 carat')),
('HRD', 'Triangle', 'S', 'I1', 'Poor', '3.34 carat', '482854', '48285498', '2', '23',(select Id from [Certificate] where ReportNumber='7105020231' and Origin='HRD' and Shape='Triangle' and Color='S' and Clarity='I1' and Cut='Poor' and CaratWeight='3.34 carat')),
('HRD', 'Oval', 'F', 'VVS2', 'VeryGood', '3.65 carat', '739201', '73920172', '1', '24',(select Id from [Certificate] where ReportNumber='7378757059' and Origin='HRD' and Shape='Oval' and Color='F' and Clarity='VVS2' and Cut='VeryGood' and CaratWeight='3.65 carat')),
('HRD', 'Marquise', 'J', 'I3', 'Poor', '2.43 carat', '833253', '83325319', '1', '21',(select Id from [Certificate] where ReportNumber='0859329600' and Origin='HRD' and Shape='Marquise' and Color='J' and Clarity='I3' and Cut='Poor' and CaratWeight='2.43 carat')),
('HRD', 'Square', 'O', 'VVS2', 'Poor', '1.01 carat', '967829', '96782933', '4', '8',(select Id from [Certificate] where ReportNumber='7348344572' and Origin='HRD' and Shape='Square' and Color='O' and Clarity='VVS2' and Cut='Poor' and CaratWeight='1.01 carat')),
('HRD', 'Pear', 'J', 'I2', 'Good', '0.25 carat', '218747', '21874766', '2', '23',(select Id from [Certificate] where ReportNumber='6413081579' and Origin='HRD' and Shape='Pear' and Color='J' and Clarity='I2' and Cut='Good' and CaratWeight='0.25 carat')),
('HRD', 'Round', 'W', 'I1', 'Excellent', '3.33 carat', '205670', '20567028', '1', '8',(select Id from [Certificate] where ReportNumber='9295399888' and Origin='HRD' and Shape='Round' and Color='W' and Clarity='I1' and Cut='Excellent' and CaratWeight='3.33 carat')),
('HRD', 'Oval', 'R', 'VS1', 'Poor', '4.94 carat', '872403', '87240304', '4', '16',(select Id from [Certificate] where ReportNumber='5014975517' and Origin='HRD' and Shape='Oval' and Color='R' and Clarity='VS1' and Cut='Poor' and CaratWeight='4.94 carat')),
('HRD', 'Oval', 'D', 'VVS2', 'Good', '2.75 carat', '907066', '90706622', '3', '14',(select Id from [Certificate] where ReportNumber='6148980699' and Origin='HRD' and Shape='Oval' and Color='D' and Clarity='VVS2' and Cut='Good' and CaratWeight='2.75 carat')),
('HRD', 'Octagonal', 'E', 'VS1', 'Poor', '3.15 carat', '535311', '53531173', '1', '23',(select Id from [Certificate] where ReportNumber='6961781659' and Origin='HRD' and Shape='Octagonal' and Color='E' and Clarity='VS1' and Cut='Poor' and CaratWeight='3.15 carat')),
('HRD', 'Pear', 'N', 'SI1', 'Good', '4.44 carat', '243302', '24330215', '1', '17',(select Id from [Certificate] where ReportNumber='1183250666' and Origin='HRD' and Shape='Pear' and Color='N' and Clarity='SI1' and Cut='Good' and CaratWeight='4.44 carat')),
('HRD', 'Rectangle', 'Y', 'VS2', 'Good', '4.40 carat', '968870', '96887070', '3', '23',(select Id from [Certificate] where ReportNumber='9084400278' and Origin='HRD' and Shape='Rectangle' and Color='Y' and Clarity='VS2' and Cut='Good' and CaratWeight='4.40 carat')),
('HRD', 'Pear', 'G', 'VS1', 'Excellent', '3.99 carat', '901456', '90145687', '3', '21',(select Id from [Certificate] where ReportNumber='5832937973' and Origin='HRD' and Shape='Pear' and Color='G' and Clarity='VS1' and Cut='Excellent' and CaratWeight='3.99 carat')),
('HRD', 'Heart', 'Y', 'VS1', 'VeryGood', '3.70 carat', '910331', '91033162', '1', '19',(select Id from [Certificate] where ReportNumber='3034274266' and Origin='HRD' and Shape='Heart' and Color='Y' and Clarity='VS1' and Cut='VeryGood' and CaratWeight='3.70 carat')),
('HRD', 'Heart', 'P', 'SI2', 'Fair', '2.80 carat', '910760', '91076070', '5', '18',(select Id from [Certificate] where ReportNumber='5343219843' and Origin='HRD' and Shape='Heart' and Color='P' and Clarity='SI2' and Cut='Fair' and CaratWeight='2.80 carat')),
('EGL', 'Triangle', 'Q', 'SI2', 'VeryGood', '3.15 carat', '858916', '85891640', '3', '19',(select Id from [Certificate] where ReportNumber='6130090811' and Origin='EGL' and Shape='Triangle' and Color='Q' and Clarity='SI2' and Cut='VeryGood' and CaratWeight='3.15 carat')),
('EGL', 'Pear', 'N', 'IF', 'Poor', '3.65 carat', '318520', '31852055', '4', '13',(select Id from [Certificate] where ReportNumber='4883635920' and Origin='EGL' and Shape='Pear' and Color='N' and Clarity='IF' and Cut='Poor' and CaratWeight='3.65 carat')),
('EGL', 'Rectangle', 'E', 'FL', 'Poor', '4.48 carat', '444622', '44462236', '1', '22',(select Id from [Certificate] where ReportNumber='5890652207' and Origin='EGL' and Shape='Rectangle' and Color='E' and Clarity='FL' and Cut='Poor' and CaratWeight='4.48 carat')),
('EGL', 'Square', 'G', 'IF', 'Excellent', '4.82 carat', '400786', '40078630', '2', '24',(select Id from [Certificate] where ReportNumber='5427718453' and Origin='EGL' and Shape='Square' and Color='G' and Clarity='IF' and Cut='Excellent' and CaratWeight='4.82 carat')),
('EGL', 'Square', 'U', 'I1', 'Fair', '2.61 carat', '307127', '30712734', '1', '12',(select Id from [Certificate] where ReportNumber='2733905790' and Origin='EGL' and Shape='Square' and Color='U' and Clarity='I1' and Cut='Fair' and CaratWeight='2.61 carat')),
('EGL', 'Round', 'V', 'SI1', 'VeryGood', '3.56 carat', '810051', '81005113', '5', '14',(select Id from [Certificate] where ReportNumber='2659987212' and Origin='EGL' and Shape='Round' and Color='V' and Clarity='SI1' and Cut='VeryGood' and CaratWeight='3.56 carat')),
('EGL', 'Marquise', 'W', 'IF', 'Good', '4.51 carat', '814634', '81463445', '1', '18',(select Id from [Certificate] where ReportNumber='6472457567' and Origin='EGL' and Shape='Marquise' and Color='W' and Clarity='IF' and Cut='Good' and CaratWeight='4.51 carat')),
('EGL', 'Marquise', 'Q', 'I2', 'Poor', '0.87 carat', '628972', '62897234', '3', '9',(select Id from [Certificate] where ReportNumber='6779876080' and Origin='EGL' and Shape='Marquise' and Color='Q' and Clarity='I2' and Cut='Poor' and CaratWeight='0.87 carat')),
('EGL', 'Triangle', 'F', 'VVS2', 'Good', '2 carat', '453825', '45382568', '4', '8',(select Id from [Certificate] where ReportNumber='3461084449' and Origin='EGL' and Shape='Triangle' and Color='F' and Clarity='VVS2' and Cut='Good' and CaratWeight='2 carat')),
('EGL', 'Triangle', 'Q', 'I1', 'Fair', '1.13 carat', '596457', '59645762', '2', '13',(select Id from [Certificate] where ReportNumber='6025102157' and Origin='EGL' and Shape='Triangle' and Color='Q' and Clarity='I1' and Cut='Fair' and CaratWeight='1.13 carat')),
('EGL', 'Rectangle', 'Z', 'I1', 'Excellent', '4.67 carat', '298747', '29874748', '5', '13',(select Id from [Certificate] where ReportNumber='6789014926' and Origin='EGL' and Shape='Rectangle' and Color='Z' and Clarity='I1' and Cut='Excellent' and CaratWeight='4.67 carat')),
('EGL', 'Heart', 'G', 'I3', 'Fair', '4.32 carat', '781083', '78108358', '1', '7',(select Id from [Certificate] where ReportNumber='1655268164' and Origin='EGL' and Shape='Heart' and Color='G' and Clarity='I3' and Cut='Fair' and CaratWeight='4.32 carat')),
('EGL', 'Rectangle', 'Q', 'SI1', 'VeryGood', '3.66 carat', '82208', '8220836', '2', '16',(select Id from [Certificate] where ReportNumber='8943627332' and Origin='EGL' and Shape='Rectangle' and Color='Q' and Clarity='SI1' and Cut='VeryGood' and CaratWeight='3.66 carat')),
('EGL', 'Rectangle', 'P', 'SI1', 'VeryGood', '1.85 carat', '980445', '98044580', '2', '23',(select Id from [Certificate] where ReportNumber='3022727578' and Origin='EGL' and Shape='Rectangle' and Color='P' and Clarity='SI1' and Cut='VeryGood' and CaratWeight='1.85 carat')),
('EGL', 'Octagonal', 'T', 'VVS2', 'Fair', '0.88 carat', '100130', '10013078', '4', '8',(select Id from [Certificate] where ReportNumber='0423495935' and Origin='EGL' and Shape='Octagonal' and Color='T' and Clarity='VVS2' and Cut='Fair' and CaratWeight='0.88 carat')),
('EGL', 'Pear', 'S', 'I2', 'Fair', '2.75 carat', '556916', '55691631', '1', '8',(select Id from [Certificate] where ReportNumber='7346653459' and Origin='EGL' and Shape='Pear' and Color='S' and Clarity='I2' and Cut='Fair' and CaratWeight='2.75 carat')),
('EGL', 'Rectangle', 'S', 'VVS1', 'Excellent', '3.81 carat', '359850', '35985054', '2', '24',(select Id from [Certificate] where ReportNumber='2742191204' and Origin='EGL' and Shape='Rectangle' and Color='S' and Clarity='VVS1' and Cut='Excellent' and CaratWeight='3.81 carat')),
('EGL', 'Pear', 'W', 'I1', 'Poor', '3.52 carat', '185369', '18536971', '3', '20',(select Id from [Certificate] where ReportNumber='2473803768' and Origin='EGL' and Shape='Pear' and Color='W' and Clarity='I1' and Cut='Poor' and CaratWeight='3.52 carat')),
('EGL', 'Oval', 'V', 'FL', 'Poor', '1.43 carat', '860050', '86005018', '1', '13',(select Id from [Certificate] where ReportNumber='9105474365' and Origin='EGL' and Shape='Oval' and Color='V' and Clarity='FL' and Cut='Poor' and CaratWeight='1.43 carat')),
('EGL', 'Marquise', 'D', 'IF', 'Good', '1.36 carat', '582918', '58291836', '1', '11',(select Id from [Certificate] where ReportNumber='6971850191' and Origin='EGL' and Shape='Marquise' and Color='D' and Clarity='IF' and Cut='Good' and CaratWeight='1.36 carat')),
('CGL', 'Round', 'W', 'VVS1', 'Fair', '3.62 carat', '150729', '15072979', '2', '13',(select Id from [Certificate] where ReportNumber='9954870780' and Origin='CGL' and Shape='Round' and Color='W' and Clarity='VVS1' and Cut='Fair' and CaratWeight='3.62 carat')),
('CGL', 'Rectangle', 'F', 'IF', 'VeryGood', '4.85 carat', '432499', '43249916', '2', '24',(select Id from [Certificate] where ReportNumber='5247804165' and Origin='CGL' and Shape='Rectangle' and Color='F' and Clarity='IF' and Cut='VeryGood' and CaratWeight='4.85 carat')),
('CGL', 'Pear', 'L', 'I1', 'Excellent', '2.12 carat', '305823', '30582312', '5', '22',(select Id from [Certificate] where ReportNumber='3370837321' and Origin='CGL' and Shape='Pear' and Color='L' and Clarity='I1' and Cut='Excellent' and CaratWeight='2.12 carat')),
('CGL', 'Oval', 'M', 'I1', 'VeryGood', '2.10 carat', '257473', '25747357', '5', '23',(select Id from [Certificate] where ReportNumber='8665980595' and Origin='CGL' and Shape='Oval' and Color='M' and Clarity='I1' and Cut='VeryGood' and CaratWeight='2.10 carat')),
('CGL', 'Oval', 'M', 'FL', 'VeryGood', '3.41 carat', '67531', '6753195', '4', '7',(select Id from [Certificate] where ReportNumber='3632063835' and Origin='CGL' and Shape='Oval' and Color='M' and Clarity='FL' and Cut='VeryGood' and CaratWeight='3.41 carat')),
('CGL', 'Square', 'Y', 'SI2', 'Poor', '3.37 carat', '504455', '50445540', '5', '8',(select Id from [Certificate] where ReportNumber='3695780069' and Origin='CGL' and Shape='Square' and Color='Y' and Clarity='SI2' and Cut='Poor' and CaratWeight='3.37 carat')),
('CGL', 'Round', 'W', 'VVS2', 'VeryGood', '1.62 carat', '864352', '86435257', '4', '22',(select Id from [Certificate] where ReportNumber='9717170073' and Origin='CGL' and Shape='Round' and Color='W' and Clarity='VVS2' and Cut='VeryGood' and CaratWeight='1.62 carat')),
('CGL', 'Triangle', 'M', 'VVS1', 'VeryGood', '0.38 carat', '132017', '13201740', '5', '12',(select Id from [Certificate] where ReportNumber='5525707333' and Origin='CGL' and Shape='Triangle' and Color='M' and Clarity='VVS1' and Cut='VeryGood' and CaratWeight='0.38 carat')),
('CGL', 'Round', 'F', 'FL', 'Fair', '0.30 carat', '477439', '47743912', '4', '17',(select Id from [Certificate] where ReportNumber='2115585249' and Origin='CGL' and Shape='Round' and Color='F' and Clarity='FL' and Cut='Fair' and CaratWeight='0.30 carat')),
('CGL', 'Oval', 'E', 'SI2', 'Fair', '3.11 carat', '226158', '22615820', '5', '9',(select Id from [Certificate] where ReportNumber='5966497953' and Origin='CGL' and Shape='Oval' and Color='E' and Clarity='SI2' and Cut='Fair' and CaratWeight='3.11 carat')),
('CGL', 'Oval', 'O', 'IF', 'VeryGood', '0.85 carat', '616288', '61628813', '2', '13',(select Id from [Certificate] where ReportNumber='0375204683' and Origin='CGL' and Shape='Oval' and Color='O' and Clarity='IF' and Cut='VeryGood' and CaratWeight='0.85 carat')),
('CGL', 'Rectangle', 'V', 'I2', 'VeryGood', '3.22 carat', '87683', '8768311', '3', '8',(select Id from [Certificate] where ReportNumber='2955503837' and Origin='CGL' and Shape='Rectangle' and Color='V' and Clarity='I2' and Cut='VeryGood' and CaratWeight='3.22 carat')),
('CGL', 'Rectangle', 'X', 'FL', 'Good', '3.86 carat', '890292', '89029280', '3', '21',(select Id from [Certificate] where ReportNumber='8051723081' and Origin='CGL' and Shape='Rectangle' and Color='X' and Clarity='FL' and Cut='Good' and CaratWeight='3.86 carat')),
('CGL', 'Rectangle', 'J', 'VS1', 'Good', '1.30 carat', '650312', '65031297', '5', '8',(select Id from [Certificate] where ReportNumber='8990591950' and Origin='CGL' and Shape='Rectangle' and Color='J' and Clarity='VS1' and Cut='Good' and CaratWeight='1.30 carat')),
('CGL', 'Rectangle', 'R', 'FL', 'Good', '1.68 carat', '246195', '24619592', '3', '6',(select Id from [Certificate] where ReportNumber='1925231087' and Origin='CGL' and Shape='Rectangle' and Color='R' and Clarity='FL' and Cut='Good' and CaratWeight='1.68 carat')),
('CGL', 'Marquise', 'Q', 'VVS1', 'VeryGood', '1.44 carat', '442304', '44230467', '5', '15',(select Id from [Certificate] where ReportNumber='9492005008' and Origin='CGL' and Shape='Marquise' and Color='Q' and Clarity='VVS1' and Cut='VeryGood' and CaratWeight='1.44 carat')),
('CGL', 'Round', 'Z', 'I3', 'Good', '2.33 carat', '89588', '8958837', '5', '10',(select Id from [Certificate] where ReportNumber='8478053890' and Origin='CGL' and Shape='Round' and Color='Z' and Clarity='I3' and Cut='Good' and CaratWeight='2.33 carat')),
('CGL', 'Marquise', 'V', 'I1', 'Fair', '3.08 carat', '964387', '96438707', '3', '21',(select Id from [Certificate] where ReportNumber='6088504798' and Origin='CGL' and Shape='Marquise' and Color='V' and Clarity='I1' and Cut='Fair' and CaratWeight='3.08 carat')),
('CGL', 'Heart', 'D', 'IF', 'Excellent', '0.97 carat', '919201', '91920150', '1', '22',(select Id from [Certificate] where ReportNumber='4257348545' and Origin='CGL' and Shape='Heart' and Color='D' and Clarity='IF' and Cut='Excellent' and CaratWeight='0.97 carat')),
('CGL', 'Rectangle', 'J', 'I3', 'VeryGood', '3.46 carat', '713769', '71376909', '1', '10',(select Id from [Certificate] where ReportNumber='3233569629' and Origin='CGL' and Shape='Rectangle' and Color='J' and Clarity='I3' and Cut='VeryGood' and CaratWeight='3.46 carat'));
go

--insert into [ProductPart](IsMain, Point, ProductId, DiamondId) values
--('1', (select top 1 Id from [Diamond] order by newid()), (select top 1 Id from [Diamond] order by newid()),(select top 1 Id from [Diamond] order by newid()),
--('0', (select top 1 Id from [Diamond] order by newid()), (select top 1 Id from [Diamond] order by newid()),(select top 1 Id from [Diamond] order by newid()),
--('0', (select top 1 Id from [Diamond] order by newid()), (select top 1 Id from [Diamond] order by newid()),(select top 1 Id from [Diamond] order by newid()),
--('0', (select top 1 Id from [Diamond] order by newid()), (select top 1 Id from [Diamond] order by newid()),(select top 1 Id from [Diamond] order by newid()),
--('0', (select top 1 Id from [Diamond] order by newid()), (select top 1 Id from [Diamond] order by newid()),(select top 1 Id from [Diamond] order by newid()),


--=================[PICTURES]=================
--Diamond
--insert into [Picture] (UrlPath, DiamondId, ProductId)
--	select 'imgs/Diamonds/PreviewDiamond.png', [Diamond].Id, null
--	from [Diamond];
--go
--insert into [Picture] (UrlPath, DiamondId, ProductId)
--	select 'imgs/Diamonds/OverViewDiamond.png', [Diamond].Id, null
--	from [Diamond];
--go
--insert into [Picture] (UrlPath, DiamondId, ProductId)
--	select 'imgs/Diamonds/SideViewDiamond.png', [Diamond].Id, null
--	from [Diamond];
--go


----Clavia Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Clavia_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Clavia%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Clavia_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Clavia%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Clavia_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Clavia%';
--go


----Caste Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Caste_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Caste%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Caste_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Caste%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Caste_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Caste%';
--go


----Flourishing Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Flourishing_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Flourishing%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Flourishing_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Flourishing%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Flourishing_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Flourishing%';
--go


----Bellamy Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Bellamy_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Bellamy%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Bellamy_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Bellamy%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Bellamy_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Bellamy%';
--go


----Amalia Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Amalia_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Amalia%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Amalia_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Amalia%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Amalia_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Amalia%';
--go


----Arternos Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Arternos_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Arternos%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Arternos_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Arternos%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Arternos_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Arternos%';
--go


----Abby Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Arternos_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Abby%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Arternos_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Abby%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Arternos_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Abby%';
--go


----Grandeur Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Grandeur_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Grandeur%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Grandeur_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Grandeur%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Grandeur_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Grandeur%';
--go


----Adivity Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Adivity_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Adivity%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Adivity_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Adivity%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Female/Adivity_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Adivity%';
--go

----A8 Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/A8_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%A8%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/A8_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%A8%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/A8_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%A8%';
--go


----Aventador Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Aventador_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Aventador%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Aventador_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Aventador%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Aventador_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Aventador%';
--go

----Authentic Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Authentic_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Authentic%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Authentic_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Authentic%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Authentic_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Authentic%';
--go

----Caddie Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Caddie_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Caddie%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Caddie_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Caddie%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Caddie_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Caddie%';
--go


----Candid Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Candid_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Candid%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Candid_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Candid%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Candid_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Candid%';
--go


----Pinnacle Rings
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Pinnacle_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Pinnacle%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Pinnacle_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Pinnacle%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Rings/Male/Pinnacle_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Ring' and [Product].[Name] like '%Pinnacle%';
--go

----Basque Earring
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Earrings/Basque_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Earring' and [Product].[Name] like '%Basque%';
--go

----Canzon Earring
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Earrings/Canzon_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Earring' and [Product].[Name] like '%Canzon%';
--go

----Jasmine Earring
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Earrings/Jasmine_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Earring' and [Product].[Name] like '%Jasmine%';
--go

----Flowery Earring
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Earrings/Flowery_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Earring' and [Product].[Name] like '%Flowery%';
--go

----Ratline Earring
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Earrings/Ratline_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Earring' and [Product].[Name] like '%Ratline%';
--go

----Flowery Pendant
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Pendants/Flowery.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Pendant' and [Product].[Name] like '%Flowery%';
--go

----Gerberas Pendant
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Pendants/Gerberas.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Pendant' and [Product].[Name] like '%Gerberas%';
--go

----Benicia Pendant
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Pendants/Benicia.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Pendant' and [Product].[Name] like '%Benicia%';
--go

----Dacing Bracelet
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bracelets/Dacing_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bracelet' and [Product].[Name] like '%Dacing%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bracelets/Dacing_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bracelet' and [Product].[Name] like '%Dacing%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bracelet/Dacing_Lay.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bracelet' and [Product].[Name] like '%Dacing%';
--go

----Lucky Bracelet
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bracelets/Lucky_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bracelet' and [Product].[Name] like '%Lucky%';
--go
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bracelets/Lucky_Stand.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bracelet' and [Product].[Name] like '%Lucky%';
--go

----Bambina Bangles
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bangles/Bambina.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bangles' and [Product].[Name] like '%Bambina%';
--go

----Gratify Bangles
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bangles/Gratify.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bangles' and [Product].[Name] like '%Gratify%';
--go

----Naiya Bangles
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bangles/Naiya.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bangles' and [Product].[Name] like '%Naiya%';
--go

----Hilarial Bangles
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bangles/Hilarial_Open.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bangles' and [Product].[Name] like '%Hilarial%';
--go

----Hilarial Bangles
--insert into [Picture](UrlPath, DiamondId, ProductId)
--	select 'imgs/DiamondJewelry/Bangles/Hilarial_Preview.png', null, [Product].Id
--	from [Product]
--	where [Product].[Type]='Bangles' and [Product].[Name] like '%Hilarial%';
--go

use master;