-- Answer following questions
--1. I will prefer using join, as SQL Server will optimize joins
--2. CTE stands for Common Table Expression. We may use it to make a table expression that make us easier to join two tables.
--3. Table variable is a kind of variables with the type of Table. It is stored in the tempdb. The scope is local.
--4. You cannot filter using TRUNCATE. TRUNCATE is faster because it does not store log and it is a DDL. It also deletes rows all at the same time.
--5. Identity column is a column that will be automatically generated once a new record is inserted. DELETE a row will create a gap while TRUNCATE delete all rows, and it starts from 1 again when new record is inserted.
--6. DELETE is a DML that it deletes records one by one and makes an entry for each and every deletion in the transaction log, but TRUNCATE is a DDL that it de-allocates pages and makes an entry for de-allocation of pages in the transaction log.

--Queries
USE Northwind
GO

--1. List all cities that have both Employees and Customers.
SELECT DISTINCT City
FROM Employees
WHERE City IN (
	SELECT DISTINCT City
	FROM Customers
)

--2. List all cities that have Customers but no Employee.
--  a. Use sub-query
SELECT DISTINCT City
FROM Customers 
WHERE City NOT IN (
	SELECT DISTINCT City
	FROM Employees
)

--  b. Do not use sub-query
SELECT DISTINCT City
FROM Customers 
EXCEPT
SELECT DISTINCT City
FROM Employees

--3. List all products and their total order quantities throughout all orders.
SELECT p.ProductName, ISNULL(SUM(o.Quantity),0) AS TotalOrder
FROM Products p LEFT JOIN [Order Details] o
ON p.ProductID = o.ProductID
GROUP BY p.ProductID, p.ProductName

--4. List all Customer Cities and total products ordered by that city.
WITH OrderCity
AS
(	SELECT o1.ShipCity, SUM(o2.Quantity) AS Quantity
	FROM Orders o1, [Order Details] o2
	WHERE o1.OrderID = o2.OrderID
	GROUP BY (o1.ShipCity)
)
SELECT c.City, ISNULL(o.Quantity,0) AS Quantity
FROM Customers c LEFT JOIN OrderCity o
ON c.City = o.ShipCity

--5. List all Customer Cities that have at least two customers.
--	a. Use union
SELECT DISTINCT City
FROM Customers
INTERSECT
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(*) >= 2

--	b. Use sub-query and no union
SELECT DISTINCT City
FROM Customers
WHERE City IN (
	SELECT City
	FROM Customers
	GROUP BY City
	HAVING COUNT(*) >= 2)

--6. List all Customer Cities that have ordered at least two different kinds of products.
WITH OrderProduct
AS
(	SELECT o1.CustomerID, o1.OrderID, o2.ProductID
	FROM Orders o1, [Order Details] o2
	WHERE o1.OrderID = o2.OrderID
)
SELECT c.City
FROM Customers c INNER JOIN OrderProduct o
ON c.CustomerId = o.CustomerID
GROUP BY c.City
HAVING COUNT(DISTINCT o.ProductID) >= 2

--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT DISTINCT c.CustomerID, c.CompanyName
FROM Customers c, Orders o
WHERE c.CustomerID = o.CustomerID AND c.City != o.ShipCity

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH PopularProduct (ProductID, avgPrice, Quantity) AS
(SELECT TOP 5 ProductID, AVG(UnitPrice * (1 - Discount)) AS avgPrice, COUNT(*) AS Quantity
FROM [Order Details]
GROUP BY ProductID
ORDER BY COUNT(*) DESC)
SELECT p.ProductID, p.avgPrice, tb.City
FROM (
SELECT o2.ProductID, c.City, COUNT(*) AS cnt, RANK() OVER(PARTITION BY o2.ProductID ORDER BY COUNT(*) DESC) RNK
FROM Orders o, Customers c, [Order Details] o2
WHERE o.CustomerID = c.CustomerID AND o.OrderID = o2.OrderID
GROUP BY o2.ProductID, c.City) tb, PopularProduct p
WHERE tb.ProductID = p.ProductID AND RNK = 1

--9. List all cities that have never ordered something but we have employees there.
--	a. Use sub-query
SELECT City
FROM Employees
WHERE City NOT IN (
	SELECT DISTINCT ShipCity
	FROM Orders
)

--	b. Do not use sub-query
SELECT DISTINCT City
FROM Employees
EXCEPT
SELECT DISTINCT ShipCity
FROM Orders

--10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. 
SELECT ShipCity AS City FROM
(SELECT ShipCity, COUNT(*) AS Occurence, RANK() OVER(ORDER BY COUNT(*)DESC) RNK
FROM Orders
GROUP BY ShipCity) dt
WHERE RNK = 1
INTERSECT
SELECT OrderCity FROM
(SELECT c.City AS OrderCity, COUNT(*) as Occurence, RANK() OVER(ORDER BY COUNT(*) DESC) RNK
FROM Orders o, Customers c
WHERE o.CustomerID = c.CustomerID
GROUP BY c.City) dt2
WHERE RNK =1

--11. How do you remove the duplicates record of a table?
--a.
DELETE FROM [Table]
    WHERE [Primary Key] NOT IN
    (
        SELECT MAX([Primary Key]) AS MaxRecordID
        FROM [Table]
        GROUP BY [All other fields]
    )

--b. 
WITH CTE
AS (SELECT [All other fields], 
           ROW_NUMBER() OVER(PARTITION BY [All other fields]
           ORDER BY [PrimaryKey]) AS DuplicateCount
    FROM [Table])
DELETE FROM CTE
WHERE DuplicateCount > 1;

--Sample table to be used for solutions below
--Employee (empid integer, mgrid integer, deptid integer, salary money) 
--Dept (deptid integer, deptname varchar(20))

--12. Find employees who do not manage anybody.
WITH empHierachyCTE
AS
(
SELECT e.empid, e.mgrid, 1 lvl
FROM Employee e
WHERE e.mgrid IS NULL
UNION ALL 
SELECT e.empid, e.mgrid, cte.lvl + 1
FROM Employee e INNER JOIN empHierachyCTE cte ON e.mgrid = cte.empid
)
SELECT empid FROM empHierachyCTE
WHERE lvl = (SELECT MAX(lvl) FROM empHierachyCTE)

--13. Find departments that have maximum number of employees. (solution should consider scenario having more than 1 departments that have maximum number of employees). 
SELECT deptname
FROM Dept
WHERE deptid IN (
	SELECT deptid FROM
		(SELECT deptid, RANK() OVER(ORDER BY COUNT(*) DESC) RNK
		FROM Employee)
	WHERE RNK = 1)

--14. Find top 3 employees (salary based) in every department. Result should have deptname, empid, salary sorted by deptname and then employee with high to low salary.
--Employee (empid integer, mgrid integer, deptid integer, salary money) 
--Dept (deptid integer, deptname varchar(20))
SELECT d.deptname, tb.empid, tb.salary
FROM (
	SELECT empid, deptid, salary, RANK() OVER(PARTITION BY deptid ORDER BY salary DESC) RNK
	FROM Employee
) tb INNER JOIN dept d
WHERE tb.RNK <=3 AND d.deptid = tb.deptid
ORDER BY d.deptname, salary DESC

