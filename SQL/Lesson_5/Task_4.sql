USE InternetShopDB
GO

--1) Создать функцию нахождения суммы покупки для упрощения предыдущего запроса. 
--   Функция принимает два параметра - даты начала и конца периода, за который проиходит суммирование. 
CREATE FUNCTION SearchSum (@FirstDate date, @EndDate date)
RETURNS money
AS
BEGIN
	RETURN 
END;


--2)Создать функцию нахождения  номера телефона, Функция принимает один параметра - фамилию сотрудника). 
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
WHERE e.LName = 'Десятов'

--3)Создать функцию нахождения  сколько заказчиков было зарегистрировано в системе,за указанный период,
-- Функция принимает два параметра - начало периода, конец периода).  customers
CREATE FUNCTION SearchCustomers (@FirstDate date, @EndDate date)
RETURNS int
AS
BEGIN
	RETURN 
END;