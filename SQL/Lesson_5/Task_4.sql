USE InternetShopDB
GO

--1) ������� ������� ���������� ����� ������� ��� ��������� ����������� �������. 
--   ������� ��������� ��� ��������� - ���� ������ � ����� �������, �� ������� ��������� ������������. 
CREATE FUNCTION SearchSum (@FirstDate date, @EndDate date)
RETURNS money
AS
BEGIN
	RETURN 
END;


--2)������� ������� ����������  ������ ��������, ������� ��������� ���� ��������� - ������� ����������). 
CREATE FUNCTION SearchPhone (@LastName nvarchar)
RETURNS char
AS
BEGIN
	RETURN (SELECT ei.Phone
			FROM EmployeesInfo as ei
			JOIN Employees as e on ei.ID = e.ID
			WHERE e.LName = @LastName);
END

DROP FUNCTION SearchPhone;

SELECT ei.Phone, e.LName
FROM EmployeesInfo as ei
JOIN Employees as e on ei.ID = e.ID
WHERE e.LName = '�������'

--3)������� ������� ����������  ������� ���������� ���� ���������������� � �������,�� ��������� ������,
-- ������� ��������� ��� ��������� - ������ �������, ����� �������).  customers
CREATE FUNCTION SearchCustomers (@FirstDate date, @EndDate date)
RETURNS int
AS
BEGIN
	RETURN 
END;