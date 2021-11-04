--Answer following questions
--1. View is a virtual table that contains data from one or multiple tables. It helps us to retrieve joined tables easily.
--2. Yes
--3. Stored procedure is to prepare sql query that we can save and reuse. It is easier to use and and will have a better performance.
--4. View is a virtual table by joining tables, but stored procedure is like receiving parameters to do functions.
--5. Functions must have inputs and outputs, but stored procedure isn't necessary to have one. Functions are called in select statement. 
	/*Stored procedure is for DML, but functions are for calculations. Stored procedure can call functions, but functions cannot.*/
--6. Yes
--7. No as stored procedures can return multiple result sets each with its own schema.
--8. Trigger is a special type of stored procedure. It automatically runs when an event occurs. There are DML, DDL, and LOGON triggers.
--9. Triggers cannot be explicitly executed.	

--Write queries
USE Northwind
GO

--1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
CREATE VIEW view_product_order_chan
AS (
	SELECT ProductID, ProductName, UnitsOnOrder
	FROM Products
)

--2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
CREATE PROC sp_product_order_quantity_chan
@id int,
@quantity int out
AS
BEGIN
	SELECT @quantity = UnitsOnOrder
	FROM Products
	WHERE ProductID = @id
END

--3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.
CREATE PROC sp_product_order_city_chan
@name nvarchar(40),
@city nvarchar(15) out,
@quantity int out
AS
BEGIN
	SELECT TOP 5 @city = o2.ShipCity, @quantity = SUM(o1.Quantity)
	FROM Products p, [Order Details] o1, Orders o2
	WHERE p.ProductID = o1.ProductID AND o1.OrderID = o2.OrderID AND p.ProductName = @name
	GROUP BY o2.ShipCity
	ORDER BY SUM(o1.Quantity) DESC
END

--4.
/*   Create 2 new tables “people_your_last_name” “city_your_last_name”. 
	 City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
	 People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
	 Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. 
	 Create a view “Packers_your_name” lists all people from Green Bay. 
	 If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.	*/
CREATE TABLE city_chan (
	Id INT PRIMARY KEY,
	City VARCHAR(50) NOT NULL
)
CREATE TABLE people_chan (
	Id INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	City INT FOREIGN KEY REFERENCES city_chan (Id)
)
INSERT INTO city_chan VALUES (1, 'Seattle')
INSERT INTO city_chan VALUES (2, 'Green Bay')
INSERT INTO people_chan VALUES (1, 'Aaron Rodgers', 2)
INSERT INTO people_chan VALUES (2, 'Russell Wilson', 1)
INSERT INTO people_chan VALUES (3, 'Jody Nelson', 2)

INSERT INTO city_chan VALUES (3, 'Madison')
UPDATE people_chan SET City = (SELECT Id FROM city_chan WHERE City = 'Madison')
WHERE City = (SELECT Id FROM city_chan WHERE City = 'Seattle')
DELETE city_chan
WHERE City = 'Seattle'

CREATE VIEW packers_chan
AS (
	SELECT Id, Name
	FROM people_chan
	WHERE City = (SELECT Id FROM city_chan WHERE City = 'Green Bay')
)

DROP TABLE people_chan
DROP TABLE city_chan
DROP VIEW packers_chan

--5.
/*  Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” 
	and fill it with all employees that have a birthday on Feb. 
	(Make a screen shot) drop the table. Employee table should not be affected.
*/
CREATE PROC sp_birthday_employees_chan
AS
BEGIN
	SELECT EmployeeID, LastName, FirstName, BirthDate INTO birthday_employees_chan
	FROM Employees WHERE MONTH(BirthDate) = 2
END

EXEC sp_birthday_employees_chan

DROP TABLE birthday_employees_chan
DROP PROC sp_birthday_employees_chan

--6. How do you make sure two tables have the same data?
/* We can do SELECT * FROM TABLE A EXCEPT SELECT * FROM TABLE B.
Then if it can successfully run and returns nothing, it means they have the same data. */

--7.
/* SELECT 
	CASE WHEN MiddleName IS NULL THEN FirstName + ' ' + LastName
	ELSE FirstName + ' ' + LastName + ' ' + MiddleName + '.'
	END AS [Full Name] FROM table */

--8.
/* 
SELECT TOP 1 Student
FROM (
	SELECT Student, RANK() (ORDER BY Marks DESC) RNK FROM table
	WHERE Sex = 'F' ) tb 
*/

--9.
/*
SELECT *
FROM table
ORDER BY Sex, Marks DESC
*/




