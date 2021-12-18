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

--2. ������� � ���� ������ ������� .

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

--3. ���������� ����� ����� ���������, ���������� ������������� ������� ��������� �����������.
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

--4. ������� ���������������� �����������

--  1) ������� ����������� �� ������������ ����� ������ ��������.
ALTER TABLE Customers
ADD CONSTRAINT CK_Customers_Phone
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO 

ALTER TABLE EmployeesInfo
ADD CONSTRAINT CK_EmployeesInfo_Phone
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO

--  2) ������� �����������, �������� �������� � InternetShopDB ����� ������������ ��������� � �������� �� 18 �� 50 ���.
ALTER TABLE EmployeesInfo
ADD CONSTRAINT CK_EmployeesInfo_BirthDate
CHECK (BirthDate < DATEADD(YEAR, -18, GETDATE()) and BirthDate > DATEADD(YEAR, -50, GETDATE()))
GO

--  3) ������� �����������, �������� �������� ������ ���� ������������ � ��� �������� �������� � �� ������� (���� �������� - 90 ���� �����).
ALTER TABLE Orders
ADD CONSTRAINT CK_Orders_OrderDate
CHECK (OrderDate > DATEADD(DAY, -90, GETDATE()) and OrderDate <= GETDATE())
GO

--  4) ������� ����������� �� ���� ������ � ������� "�������� ���������" (����: �����, �� �����, �������, �� �������).
ALTER TABLE EmployeesInfo
ADD CONSTRAINT CK_EmployeesInfo_MaritalStatus
CHECK (MaritalStatus in ('�����', '�� �����', '�������', '�� �������'))
GO

--  5) ������� �����������, �������� �������� ������ ����� ���� ������������������ � ������� � ��� �������� � �� �������.
ALTER TABLE Customers
ADD CONSTRAINT CK_Customers_DateInSystem
CHECK (DateInSystem > DATEADD(DAY, -90, GETDATE()) and DateInSystem <= GETDATE())
GO

--  6) ������� �����������, �������� �������� ������ �� ����� ��������� � ���� ������ ��� ��������. 
ALTER TABLE Employees
ADD CONSTRAINT CK_Employees_PriorSalary
CHECK (PriorSalary != Salary and PriorSalary < Salary)
GO

--  7) ������� �����������, �������� �������� ������� ������ �� ������ �� ����� ���� �������������. 
--ALTER TABLE Products
--ADD CONSTRAINT CK_Products_Name
--CHECK ([Name] < 0)
--GO

INSERT Customers 
(FName, MName, LName, [Address], City, Phone, DateInSystem)
VALUES
('������','����������','����������','������� 21�, 137','���������','(063)4569385',DATEADD(DAY, -85, GETDATE())),
('�����','��������','����','������ 77','����','(093)1416433',DATEADD(DAY, -85, GETDATE())),
('������','������������','��������','������ 6, 22','����','(068)0989367',DATEADD(DAY, -85, GETDATE())),
('��������','����������','��������','������ 25','�����','(098)4569111',DATEADD(DAY, -65, GETDATE())),
('��������','��������','�������','�������� 15','�����','(068)2229325',DATEADD(DAY, -45, GETDATE())),
('����','��������','������','������� 24, 17','����','(063)1119311',DATEADD(DAY, -45, GETDATE())),
('������','��������','�����','������ 21','���������','(068)4569344',DATEADD(DAY, -35, GETDATE())),
('�����','����������','�������','�������� 77, 99','��������','(050)4569255',DATEADD(DAY, -25, GETDATE())),
('�����','����������','������','���������� 20','��������','(050)4539333',DATEADD(DAY, -15, GETDATE())),
('������','���������','��������','������� 1','����','(063)9999380',DATEADD(DAY, -5, GETDATE())),
('�����','��������','�����','������ 23','�����','(067)9995558',DATEADD(DAY, -15, GETDATE()));
GO

INSERT Employees
(FName, MName, LName, Post, Salary, PriorSalary)
VALUES
('��������', '������������', '�������', '������� ��������', 2000, 300),
('������', '���������', '��������', '��������', 700, 150),
('����', '���������', '������', '�������� �� ��������', 500, 50),
('������', '��������', '�������', '�������� �� ��������', 500, 50),
('�����', '����������', '�����', '��������', 700, 150),
('����', '���������', '�����', '�������� �� ��������', 700, 150);
GO

INSERT EmployeesInfo
(ID, MaritalStatus, BirthDate, [Address], Phone)
VALUES
(1, '�� �����', '08/15/1974', '��������� 16/7','(067)4564489'),
(2, '�����', '09/09/1985', '��������� 15','(050)0564585'),
(3, '�� �����', '12/11/1990', '������ 16, 145','(068)4560409'),
(4, '�� �����', '01/11/1988', '�������� 11','(066)4664466'),
(5, '�������', '08/08/1990', '������� 10, 7','(093)4334493'),
(6, '�������', '01/10/1994', '����������� 7','(063)4114141');
GO

INSERT Products
(ID, [Name])
VALUES
(1, '������� Asus D345'),
(2, '������� HP Pavilion 15-p032er'),
(3, '������� Dell Inspiron 5555'),
(4, '������ Acer Aspire ES1'),
(5, '������ Lenovo Flex 10'),
(6, '������ Dell Inspiron 3147'),
(7, '�������� Samsung Galaxy S6 SS 32GB'),
(8, '�������� Apple iPhone 6'),
(9, '����������� Canon PowerShot SX400'),
(10, '��������� LG 55LB631V');
GO

INSERT ProductDetails
(ID, Color, [Description])
VALUES
(1, '������', '����� 14" (1366x768) HD LED, ��������� / Intel Celeron N2840 (2.16 ���) / RAM 2 �� / HDD 500 �� / Intel HD Graphics / ��� �� / LAN / Wi-Fi / Bluetooth / ���-������ / DOS / 2.09 ��'),
(2, '�����', '����� 15.6" (1366x768) HD LED, ��������� / AMD Quad-Core A6-6310 (1.8 - 2.4 ���) / RAM 4 �� / HDD 500 �� / AMD Radeon R4 + AMD Radeon R7 M260, 2 �� / DVD Super Multi / LAN / Wi-Fi / Bluetooth 4.0 / ���-������ / DOS / 2.44 ��'),
(3, '������', '����� 15.6" (1366x768) HD WLED, ��������� / AMD Quad-Core A6-7310 (2.0 ���) / RAM 4 �� / HDD 500 �� / AMD Radeon R5 M335, 2 �� / DVD�RW / LAN / Wi-Fi / Bluetooth / ���-������ / Linux / 2.3 ��'),
(4, '������', '����� 11.6'' (1366x768) HD LED, ������� / Intel Celeron N2840 (2.16 ���) / RAM 2 �� / HDD 500 �� / Intel HD Graphics / ��� �� / LAN / Wi-Fi / Bluetooth / ���-������ / Linpus / 1.29 ��'),
(5, '������', '����� 10.1" (1366x768) HD LED, ���������, ��������� / Intel Celeron N2830 (2.16 ���) / RAM 2 �� / HDD 320 �� / Intel HD Graphics / ��� �� / Wi-Fi / Bluetooth / ���-������ / Windows 8.1 Pro 64bit (Ukrainian language) / Microsoft Office Pro Academic 2013 (Ukrainian language) / 1.2 ��'),
(6, '������', '����� 11.6" IPS (1366x768) HD LED, ���������, ��������� / Intel Pentium N3530 (2.16 - 2.58 ���) / RAM 4 �� / HDD 500 �� / Intel HD Graphics / ��� �� / Wi-Fi / Bluetooth / ���-������ / Windows 8.1 / 1.41 ��'),
(7, '�����', '����� 5.1" Super AMOLED (2560�1440, ���������, ���������, Multi-Touch) / �������� / Exynos 7420 (Quad 2.1 ��� + Quad 1.5 ���) / ������ 16 �� + ����������� 5 �� / Bluetooth 4.1 / Wi-Fi a/b/g/n/ac / 3 �� ����������� ������ / 32 �� ���������� ������ / ������ 3.5 �� / LTE / GPS / ������� / OC Android 5.0 / 143.4 x 70.5 x 6.8 ��, 138 �'),
(8, '������', '�����: 4.7" IPS LCD (1334x750 �����) � LED-���������� / 16 ���. ������ / ���������, ��������� / ������� � ��������� ������ Ion-X Glass � ���������� ������������������� ������: 16 ��'),
(9, '������', '������� 1/2.3", 16 �� / ���: 30� (����������), 4� (��������) / ��������� ���� ������ SD, SDHC, SDXC / LCD-������� 3" / HD-����� / ������� �� �����-�������� ������������ / 104.4 x 69.1 x 80.1 ��, 313 �'),
(10, '������', '��������� ������: 55" ��������� Smart TV: ���� ����������: 1920x1080 Wi-Fi: �� ��������� ��������� ������: DVB-S2, DVB-C, DVB-T2 ������� ��������� ������: 100 �� ������� ����������: 500 �� (MCI)');
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