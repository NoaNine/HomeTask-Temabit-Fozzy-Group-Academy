CREATE DATABASE InternetShopDB ON
(
	NAME = 'InternetShopDB',			
	FILENAME = 'E:\InternetShopDB.mdf'
	)
log on						  
	( 
	NAME = 'LogInternetShopDB',				
	FILENAME = 'E:\InternetShopDB.ldf'
	)
COLLATE Cyrillic_General_CI_AS
GO

use InternetShopDB;
use master;

drop database InternetShopDB;

--2. Создать в базе данных таблицы .

--1) Customers (ID,FName,MName,LName,[Address],City,Phone,DateInSystem)
CREATE TABLE Customers
(
	ID int IDENTITY NOT NULL,
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	[Address] nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	Phone char(12) NOT NULL,
	DateInSystem datetime NOT NULL
)
GO

--  2) Employees (ID,FName,MName,LName,Post,Salary,PriorSalary)
CREATE TABLE Employees
(
	ID int IDENTITY NOT NULL,
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	Post nvarchar(max) NOT NULL,
	Salary money NOT NULL,
	PriorSalary money NOT NULL
)
GO

--  3) EmployeesInfo (ID,MaritalStatus,BirthDate,[Address],Phone) 
CREATE TABLE EmployeesInfo
(
	ID int NOT NULL,
	MaritalStatus nvarchar(10) NOT NULL,
	BirthDate datetime NOT NULL,
	[Address] nvarchar(max) NOT NULL,
	Phone char(12) NOT NULL
)
GO

--  4) Products (ID,Name) 
CREATE TABLE Products
(
	ID int NOT NULL,
	[Name] nvarchar(max) NOT NULL
)
GO

--  5) ProductDetails (ID,Color,[Description])
CREATE TABLE ProductDetails
(
	ID int NOT NULL,
	Color nvarchar(25) NOT NULL,
	[Description] nvarchar(max) NOT NULL
)
GO

--  6) Stocks (ProductID, Qty)
CREATE TABLE Stocks
(
	ProductID int NOT NULL,
	Qty smallint NOT NULL
)
GO

--  7) Orders (ID,CustomerID,EmployeeID,OrderDate)
CREATE TABLE Orders
(
	ID int IDENTITY NOT NULL,
	CustomerID int NOT NULL,
	EmployeeID int,
	OrderDate datetime NOT NULL
)
GO

--  8) OrderDetails (OrderID,LineItem,ProductID,Qty,Price,TotalPrice)
CREATE TABLE OrderDetails
(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	ProductID int NOT NULL,
	Qty smallint NOT NULL,
	Price money NOT NULL,
	TotalPrice AS CONVERT(money, Qty*Price)
)
GO

--3. Установить связи между таблицами, необходимо предусмотреть условия ссылочной целостности.
ALTER TABLE Customers
ADD CONSTRAINT PK_Customers
PRIMARY KEY (ID)
GO 

ALTER TABLE Employees
ADD CONSTRAINT PK_Employees_ID
PRIMARY KEY (ID)
GO 

ALTER TABLE EmployeesInfo
ADD CONSTRAINT UQ_EmployeesInfo_ID
UNIQUE (ID),
	CONSTRAINT FQ_EmployeesInfo_ID
FOREIGN KEY (ID) REFERENCES Employees(ID) ON DELETE CASCADE	
GO 
 
ALTER TABLE Products
ADD CONSTRAINT PK_Products_ID
PRIMARY KEY (ID)
GO 

ALTER TABLE ProductDetails
ADD CONSTRAINT UQ_ProductDetails_ID
UNIQUE (ID),
	CONSTRAINT FQ_ProductDetails_ID
FOREIGN KEY (ID) REFERENCES Products(ID) ON DELETE CASCADE
GO 

ALTER TABLE Stocks
ADD CONSTRAINT FQ_Stocks_ProductID
FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE
GO 

ALTER TABLE Orders
ADD CONSTRAINT PK_Orders_ID
PRIMARY KEY (ID),
	CONSTRAINT FQ_Stocks_Orders_CustomerID
FOREIGN KEY (CustomerID) REFERENCES Customers(ID) ON DELETE CASCADE,
	CONSTRAINT FQ_Stocks_Orders_EmployeeID
FOREIGN KEY (EmployeeID) REFERENCES Employees(ID) ON DELETE SET NULL
GO 

ALTER TABLE OrderDetails
ADD CONSTRAINT FQ_OrderDetails_OrderID
FOREIGN KEY (OrderID) REFERENCES Orders(ID) ON DELETE CASCADE,
	CONSTRAINT FQ_OrderDetails_ProductID
FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE,
	CONSTRAINT PK_OrderDetails_OrderID_ProductID
PRIMARY KEY(OrderID, ProductID)
GO 

--4. Создать пользовательские ограничений

--  1) Создать ограничение на корректность ввода номера телефона.
ALTER TABLE Customers
ADD CONSTRAINT CK_Customers_Phone
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO 

ALTER TABLE EmployeesInfo
ADD CONSTRAINT CK_EmployeesInfo_Phone
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO

--  2) Создать ограничение, согласно которому в InternetShopDB могут устраиваться кандидаты в возрасте от 18 до 50 лет.
ALTER TABLE EmployeesInfo
ADD CONSTRAINT CK_EmployeesInfo_BirthDate
CHECK (BirthDate < DATEADD(YEAR, -18, GETDATE()) and BirthDate > DATEADD(YEAR, -50, GETDATE()))
GO

--  3) Создать ограничение, согласно которому заказы могу фиксироватся с дня открытия магазина и до сегодня (день открытия - 90 дней назад).
ALTER TABLE Orders
ADD CONSTRAINT CK_Orders_OrderDate
CHECK (OrderDate > DATEADD(DAY, -90, GETDATE()) and OrderDate <= GETDATE())
GO

--  4) Создать ограничение на ввод данных в столбец "Семейное положение" (ввод: Женат, Не женат, Замужем, Не замежем).
ALTER TABLE EmployeesInfo
ADD CONSTRAINT CK_EmployeesInfo_MaritalStatus
CHECK (MaritalStatus in ('Женат', 'Не женат', 'Замужем', 'Не замужем'))
GO

--  5) Создать ограничение, согласно которому клиент может быть зарегистрированным в системе с дня открытия и до сегодня.
ALTER TABLE Customers
ADD CONSTRAINT CK_Customers_DateInSystem
CHECK (DateInSystem > DATEADD(DAY, -90, GETDATE()) and DateInSystem <= GETDATE())
GO

--  6) Создать ограничение, согласно которому премия не может равняться и быть больше чем зарплата. 
ALTER TABLE Employees
ADD CONSTRAINT CK_Employees_PriorSalary
CHECK (PriorSalary != Salary and PriorSalary < Salary)
GO

--  7) Создать ограничение, согласно которому остаток товара на складе не может быть отрицательным. 
--ALTER TABLE Products
--ADD CONSTRAINT CK_Products_Name
--CHECK ([Name] < 0)
--GO

INSERT Customers 
(FName, MName, LName, [Address], City, Phone, DateInSystem)
VALUES
('Виктор','Викторович','Прокопенко','Руденко 21а, 137','Тернополь','(063)4569385',DATEADD(DAY, -85, GETDATE())),
('Антон','Олегович','Крук','Бажова 77','Киев','(093)1416433',DATEADD(DAY, -85, GETDATE())),
('Оксана','Владимировна','Десятова','Бажана 6, 22','Киев','(068)0989367',DATEADD(DAY, -85, GETDATE())),
('Антонина','Дмитриевна','Шевченко','Мышуги 25','Львов','(098)4569111',DATEADD(DAY, -65, GETDATE())),
('Анатолий','Петрович','Дмитров','Дружнова 15','Львов','(068)2229325',DATEADD(DAY, -45, GETDATE())),
('Иван','Иванович','Кобзар','Ковпака 24, 17','Киев','(063)1119311',DATEADD(DAY, -45, GETDATE())),
('Виктор','Олегович','Грачь','Лесная 21','Тернополь','(068)4569344',DATEADD(DAY, -35, GETDATE())),
('Ольга','Алексеевна','Буткова','Дорожная 77, 99','Николаев','(050)4569255',DATEADD(DAY, -25, GETDATE())),
('Алина','Михайловна','Мелова','Контрактна 20','Николаев','(050)4539333',DATEADD(DAY, -15, GETDATE())),
('Михаил','Андреевич','Савицкий','Медовая 1','Киев','(063)9999380',DATEADD(DAY, -5, GETDATE())),
('Артем','Иванович','Крава','Артема 23','Львов','(067)9995558',DATEADD(DAY, -15, GETDATE()));
GO

INSERT Employees
(FName, MName, LName, Post, Salary, PriorSalary)
VALUES
('Анатолий', 'Владимирович', 'Десятов', 'Главный директор', 2000, 300),
('Андрей', 'Антонович', 'Зарицкий', 'Менеджер', 700, 150),
('Олег', 'Артемович', 'Сурков', 'Менеджер по продажам', 500, 50),
('Максим', 'Иванович', 'Рудаков', 'Менеджер по продажам', 500, 50),
('Ирина', 'Михайловна', 'Макар', 'Менеджер', 700, 150),
('Юлия', 'Борисовна', 'Таран', 'Менеджер по продажам', 700, 150);
GO

INSERT EmployeesInfo
(ID, MaritalStatus, BirthDate, [Address], Phone)
VALUES
(1, 'Не женат', '08/15/1974', 'Викторкая 16/7','(067)4564489'),
(2, 'Женат', '09/09/1985', 'Малинская 15','(050)0564585'),
(3, 'Не женат', '12/11/1990', 'Победы 16, 145','(068)4560409'),
(4, 'Не женат', '01/11/1988', 'Антонова 11','(066)4664466'),
(5, 'Замужем', '08/08/1990', 'Руденко 10, 7','(093)4334493'),
(6, 'Замужем', '01/10/1994', 'Просвещения 7','(063)4114141');
GO

INSERT Products
(ID, [Name])
VALUES
(1, 'Ноутбук Asus D345'),
(2, 'Ноутбук HP Pavilion 15-p032er'),
(3, 'Ноутбук Dell Inspiron 5555'),
(4, 'Нетбук Acer Aspire ES1'),
(5, 'Нетбук Lenovo Flex 10'),
(6, 'Нетбук Dell Inspiron 3147'),
(7, 'Смартфон Samsung Galaxy S6 SS 32GB'),
(8, 'Смартфон Apple iPhone 6'),
(9, 'Фотоаппарат Canon PowerShot SX400'),
(10, 'Телевизор LG 55LB631V');
GO

INSERT ProductDetails
(ID, Color, [Description])
VALUES
(1, 'Черный', 'Экран 14" (1366x768) HD LED, глянцевый / Intel Celeron N2840 (2.16 ГГц) / RAM 2 ГБ / HDD 500 ГБ / Intel HD Graphics / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.09 кг'),
(2, 'Серый', 'Экран 15.6" (1366x768) HD LED, глянцевый / AMD Quad-Core A6-6310 (1.8 - 2.4 ГГц) / RAM 4 ГБ / HDD 500 ГБ / AMD Radeon R4 + AMD Radeon R7 M260, 2 ГБ / DVD Super Multi / LAN / Wi-Fi / Bluetooth 4.0 / веб-камера / DOS / 2.44 кг'),
(3, 'Черный', 'Экран 15.6" (1366x768) HD WLED, глянцевый / AMD Quad-Core A6-7310 (2.0 ГГц) / RAM 4 ГБ / HDD 500 ГБ / AMD Radeon R5 M335, 2 ГБ / DVD±RW / LAN / Wi-Fi / Bluetooth / веб-камера / Linux / 2.3 кг'),
(4, 'Черный', 'Экран 11.6'' (1366x768) HD LED, матовый / Intel Celeron N2840 (2.16 ГГц) / RAM 2 ГБ / HDD 500 ГБ / Intel HD Graphics / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Linpus / 1.29 кг'),
(5, 'Черный', 'Экран 10.1" (1366x768) HD LED, сенсорный, глянцевый / Intel Celeron N2830 (2.16 ГГц) / RAM 2 ГБ / HDD 320 ГБ / Intel HD Graphics / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 8.1 Pro 64bit (Ukrainian language) / Microsoft Office Pro Academic 2013 (Ukrainian language) / 1.2 кг'),
(6, 'Черный', 'Экран 11.6" IPS (1366x768) HD LED, сенсорный, глянцевый / Intel Pentium N3530 (2.16 - 2.58 ГГц) / RAM 4 ГБ / HDD 500 ГБ / Intel HD Graphics / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 8.1 / 1.41 кг'),
(7, 'Белый', 'Экран 5.1" Super AMOLED (2560х1440, сенсорный, емкостный, Multi-Touch) / моноблок / Exynos 7420 (Quad 2.1 ГГц + Quad 1.5 ГГц) / камера 16 Мп + фронтальная 5 Мп / Bluetooth 4.1 / Wi-Fi a/b/g/n/ac / 3 ГБ оперативной памяти / 32 ГБ встроенной памяти / разъем 3.5 мм / LTE / GPS / ГЛОНАСС / OC Android 5.0 / 143.4 x 70.5 x 6.8 мм, 138 г'),
(8, 'Черный', 'Экран: 4.7" IPS LCD (1334x750 точек) с LED-подсветкой / 16 млн. цветов / сенсорный, емкостной / стойкое к царапинам стекло Ion-X Glass с олеофобным покрытиемВстроенная память: 16 ГБ'),
(9, 'Черный', 'Матрица 1/2.3", 16 Мп / Зум: 30х (оптический), 4х (цифровой) / поддержка карт памяти SD, SDHC, SDXC / LCD-дисплей 3" / HD-видео / питание от литий-ионнного аккумулятора / 104.4 x 69.1 x 80.1 мм, 313 г'),
(10, 'Черный', 'Диагональ экрана: 55" Поддержка Smart TV: Есть Разрешение: 1920x1080 Wi-Fi: Да Диапазоны цифрового тюнера: DVB-S2, DVB-C, DVB-T2 Частота развертки панели: 100 Гц Частота обновления: 500 Гц (MCI)');
GO

INSERT Stocks
(ProductID, Qty)
VALUES
(1, 20),
(2, 10),
(3, 7),
(4, 8),
(5, 9),
(6, 5),
(7, 12),
(8, 54),
(9, 8),
(10, 7);
GO

INSERT Orders
(CustomerID, EmployeeID, OrderDate)
VALUES
(1,3, DATEADD(DAY, -85, GETDATE())),
(2,6, DATEADD(DAY, -85, GETDATE())),
(3,4, DATEADD(DAY, -85, GETDATE())),
(3,NULL, DATEADD(DAY, -75, GETDATE())),
(2,3, DATEADD(DAY, -65, GETDATE())),
(4,6, DATEADD(DAY, -65, GETDATE())),
(1,3, DATEADD(DAY, -55, GETDATE())),
(5,3, DATEADD(DAY, -45, GETDATE())),
(6,3, DATEADD(DAY, -45, GETDATE())),
(1,4, DATEADD(DAY, -45, GETDATE())),
(2,NULL, DATEADD(DAY, -45, GETDATE())),
(7,3, DATEADD(DAY, -35, GETDATE())),
(6,4,	 DATEADD(DAY, -35, GETDATE())),
(3,NULL, DATEADD(DAY, -35, GETDATE())),
(5,6, DATEADD(DAY, -35, GETDATE())),
(8,3, DATEADD(DAY, -25, GETDATE())),
(5,4, DATEADD(DAY, -25, GETDATE())),
(7,4, DATEADD(DAY, -25, GETDATE())),
(7,3, DATEADD(DAY, -15, GETDATE())),
(9,3, DATEADD(DAY, -15, GETDATE())),
(8,4, DATEADD(DAY, -15, GETDATE())),
(10,NULL, DATEADD(DAY, -15, GETDATE())),
(11,3, DATEADD(DAY, -5, GETDATE())),
(10,4, DATEADD(DAY, -5, GETDATE()));
GO

INSERT OrderDetails
(OrderID, LineItem, ProductID, Qty, Price)
VALUES
(1,1,1,1,295),
(2,1,2,1,445),
(2,2,6,1,450),
(3,1,4,1,422),
(3,2,9,4,218),
(4,1,7,1,450),
(5,1,9,1,220),
(6,1,8,1,550),
(7,1,8,2,550),
(7,2,9,1,222),
(7,3,5,1,289),
(8,1,3,1,518),
(8,2,9,1,222),
(9,1,6,1,451),
(10,1,10,1,600),
(11,1,7,3,452),
(12,1,7,2,452),
(13,1,9,1,222),
(13,2,8,1,550),
(13,3,7,1,455),
(14,1,9,2,222),
(15,1,3,1,520),
(16,1,4,2,420),
(17,1,10,2,600),
(18,1,10,1,600),
(19,1,7,3,453),
(19,2,8,2,550),
(20,1,5,2,300),
(21,1,4,1,422),
(21,2,5,1,305),
(22,1,1,1,305),
(22,2,2,1,450),
(23,1,1,3,300),
(23,2,2,1,450),
(23,3,3,1,525),
(23,4,4,2,420),
(24,1,6,4,450);
GO

SELECT * FROM Customers
SELECT * FROM Employees
SELECT * FROM Stocks
SELECT * FROM EmployeesInfo
SELECT * FROM Orders
SELECT * FROM Products
SELECT * FROM ProductDetails
SELECT * FROM OrderDetails