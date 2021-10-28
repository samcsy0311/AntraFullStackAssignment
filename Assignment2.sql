--Answer the following questions
--1. A result set is the output of a query.
--2. UNION will not include duplicate records, but UNION ALL will. The first column will be sorted automatically when using UNION, and UNION cannot be used in recursive cte.
--3. INTERSECT, EXCEPT
--4. UNION expands vertically, but JOIN expands horizontally.
--5. INNER JOIN looks for values that both tables have on the reference key, but OUTER JOIN will include values that only one table have.
--6. LEFT JOIN only includes all records from the left table, but OUTER JOIN includes everything from both tables.
--7. CROSS JOIN returns the cartesian product of two tables.
--8. You cannot use aggregate functions in a WHERE clause, but is fine in a HAVING clause. HAVING clause is only used after a GROUP BY statement. WHERE is applicable in SELECT, UPDATE, DELETE.
--9. Yes

--Queries
USE AdventureWorks2019
GO

--1. How many products can you find in the Production.Product table?
SELECT COUNT(*)
FROM Production.Product

--2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

--3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID

--4. How many products that do not have a product subcategory. 
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) AS SumOfProduct
FROM Production.ProductInventory

--6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID, Quantity as TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 AND Quantity < 100

--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT Shelf, ProductID, Quantity as TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 AND Quantity < 100

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT ProductID, AVG(Quantity) AS Average
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID

--9. Write query to see the average quantity of products by shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf

--10. Write query to see the average quantity of products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf

--11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(*) AS TheCount, AVG(listPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

--12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following. 
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c, Person.StateProvince s
WHERE c.CountryRegionCode = s.CountryRegionCode

--13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c, Person.StateProvince s
WHERE c.CountryRegionCode = s.CountryRegionCode AND (c.Name = 'Germany' OR c.Name = 'Canada')

USE Northwind
GO

--14. List all Products that has been sold at least once in last 25 years.
SELECT P.ProductName, COUNT(*) AS Quantities
FROM Orders o, dbo.[Order Details] o2, Products p
WHERE o.OrderID = o2.OrderID AND o2.ProductID = p.ProductID AND YEAR(OrderDate) >= 1996
GROUP BY o2.ProductID, P.ProductName

--15. List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 ShipPostalCode, COUNT(ShipPostalCode) AS Quantity
FROM Orders
WHERE ShipPostalCode IS NOT NULL
GROUP BY ShipPostalCode
ORDER BY Quantity DESC

--16. List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 ShipPostalCode, COUNT(ShipPostalCode) AS Quantity
FROM Orders
WHERE ShipPostalCode IS NOT NULL AND YEAR(OrderDate) >= 1996
GROUP BY ShipPostalCode
ORDER BY Quantity DESC

--17. List all city names and number of customers in that city.  
SELECT City, COUNT(*) AS NumberOfCustomers
FROM Customers
GROUP BY City

--18. List city names which have more than 2 customers, and number of customers in that city 
SELECT City, COUNT(*) AS NumberOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(*) > 2

--19. List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.ContactName
FROM Customers c, Orders o
WHERE c.CustomerID = o.CustomerID AND o.OrderDate > '1-1-1998'

--20. List the names of all customers with most recent order dates 
SELECT c.ContactName, o.OrderDate
FROM Customers c, Orders o
WHERE c.CustomerID = o.CustomerID AND o.OrderDate = 
	(SELECT MAX(OrderDate)
	FROM Orders)

--21. Display the names of all customers along with the count of products they bought 
SELECT c.ContactName, ISNULL(COUNT(o2.Quantity),0) AS NumOfProducts
FROM Customers c LEFT JOIN Orders o1 ON c.CustomerID = o1.CustomerID, [Order Details] o2
WHERE o1.OrderID = o2.OrderID
GROUP BY c.CustomerID, c.ContactName

--22. Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CustomerID, ISNULL(COUNT(o2.Quantity),0) AS NumOfProducts
FROM Customers c LEFT JOIN Orders o1 ON c.CustomerID = o1.CustomerID, [Order Details] o2
WHERE o1.OrderID = o2.OrderID
GROUP BY c.CustomerID
HAVING COUNT(o2.Quantity) > 100

--23. List all of the possible ways that suppliers can ship their products. Display the results as below
SELECT s1.CompanyName AS [Supplier Company Name], s2.CompanyName AS [Shipping Company Name]
FROM Suppliers s1, Shippers s2

--24. Display the products order each day. Show Order date and Product Name.
SELECT O.OrderDate, tb.ProductName
FROM Orders O,
	(SELECT o.OrderID, p.ProductName 
	FROM Products p, [Order Details] o
	WHERE o.ProductID = p.ProductID) tb
WHERE O.OrderID = tb.OrderID
ORDER BY OrderDate

--25. Displays pairs of employees who have the same job title.
SELECT e2.FirstName + ' ' + e2.LastName AS Name1,
e1.FirstName + ' ' + e1.LastName AS Name2,
e1.Title
FROM Employees e1, Employees e2
WHERE e1.Title = e2.Title AND e1.EmployeeID != e2.EmployeeID AND e1.FirstName > e2.FirstName

--26. Display all the Managers who have more than 2 employees reporting to them.
SELECT e1.EmployeeID AS ID, 
(SELECT FirstName + ' ' + LastName FROM Employees e3 WHERE e3.EmployeeID = e1.EmployeeID) AS Name,
COUNT(*) AS NumOfEmployeesReporting
FROM Employees e1, Employees e2
WHERE e1.EmployeeID = e2.ReportsTo
GROUP BY e1.EmployeeID
HAVING COUNT(*) > 2

--27. Display the customers and suppliers by city.
SELECT City, CompanyName AS Name, ContactName AS [Contact Name], Relationship AS Type
FROM [Customer and Suppliers by City]
