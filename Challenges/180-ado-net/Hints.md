# SQL Abfragen und Commands

### Liste aller Kunden mit Bestellungen laden

```sql
SELECT 
    c.CustomerID,
    FirstName,
    LastName,
    COUNT(sh.SalesOrderID) AS OrderCount
FROM [SalesLT].[Customer] AS c 
INNER JOIN [SalesLT].[SalesOrderHeader] AS sh 
ON c.CustomerID = sh.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
ORDER BY OrderCount DESC
```

### Bestellungen und Lieferanschrift eines Kunden laden

```sql
SELECT  
    sh.SalesOrderID,
    sh.OrderDate,
    sh.SalesOrderNumber,
    sh.TotalDue,
    a.AddressLine1,
    a.City,
    a.PostalCode
FROM [SalesLT].[SalesOrderHeader] AS sh
INNER JOIN [SalesLT].Address AS a
ON sh.ShipToAddressID = a.AddressID
WHERE sh.CustomerID = @CustomerID
```

### Details einer Bestellung laden

```sql
SELECT
    sd.OrderQty,
    sd.UnitPrice,
    p.Name
FROM [SalesLT].[SalesOrderDetail] as sd
JOIN [SalesLT].[Product] as p
ON sd.ProductID = p.ProductID
WHERE sd.SalesOrderID = @SalesOrderID
```

### Anlegen eines neuen Produkts

```sql
INSERT INTO [SalesLT].[Product] (Name, ProductNumber, StandardCost, ListPrice, ProductCategoryID, SellStartDate) 
VALUES (@Name, @Number, @Price, @Price, @Category, GETDATE())
```

### Laden aller neu angelegten Produkte

```sql
SELECT ProductID, Name FROM [SalesLT].[Product] WHERE YEAR(ModifiedDate) = YEAR(GETDATE())
```

### Löschen eines Produkts

```sql
DELETE FROM [SalesLT].[Product] WHERE ProductID=@ProductID
```
