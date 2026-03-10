select * from Orders
select * from Customers

create view vw_CustomerOrderView as 
select c.CustomerID,c.CompanyName,c.City ,
o.OrderID,o.OrderDate,o.Freight from Customers c 
inner join Orders o on c.CustomerID=o.CustomerID;


select * from vw_CustomerOrderView where City = 'london';


UPDATE vw_CustomerOrderView SET Freight = 50.00 WHERE OrderID = 10248;

--4. Schema‑bound view (WITH SCHEMABINDING)
--Schema binding locks the view to the schema of the tables it 
--references. You cannot drop or alter those tables in a way that would break the view.

--Example:


CREATE VIEW vw_OrderSummary
WITH SCHEMABINDING
AS
SELECT
    o.OrderID,
    o.OrderDate,
    c.CompanyName,
    SUM(od.Quantity * od.UnitPrice) AS TotalAmount
FROM dbo.Orders o
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, o.OrderDate, c.CompanyName;

--Key effects of WITH SCHEMABINDING:

--You cannot drop Orders, Customers, or [Order Details] while this view exists.

--You cannot rename or remove columns that the view references.

--The view definition cannot be altered without first dropping it; you must 
--DROP VIEW and recreate it if you want to change the query.

--Schema‑bound views are often used when you plan to create an index on the view 
--(indexed views), which improves performance for heavy aggregations
