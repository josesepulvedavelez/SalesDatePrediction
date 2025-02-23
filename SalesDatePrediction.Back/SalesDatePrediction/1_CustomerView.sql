
CREATE VIEW CustomerView AS
SELECT
	Customers.custid,
    Customers.companyname, 
    MAX(Sales.Orders.orderdate) AS LastOrderDate,
    DATEADD(DAY, 
        DATEDIFF(DAY, MIN(Sales.Orders.orderdate), MAX(Sales.Orders.orderdate)) / COUNT(Sales.Orders.custid), 
        MAX(Sales.Orders.orderdate)
    ) AS NextPredictedOrder
FROM 
    Sales.Customers 
INNER JOIN 
    Sales.Orders ON Sales.Customers.custid = Sales.Orders.custid
GROUP BY
	Customers.custid,
	Customers.companyname;