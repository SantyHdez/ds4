


-- Ejemplo 1
-- Seleccionar y mostrar todos los datos de la tabla Products
SELECT * FROM Products
go

-- Ejemplo 2
-- En este ejemplo solo se mostraran los campos seleccionados de
-- la tabla Products
Select ProductID, ProductName, UnitPrice FROM Products
go

-- Ejemplo 3
-- Seleccionar los datos de la tabla Products donde el dato 
-- almacenado en el campo unitprice sea mayor a 15
Select ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 15
go

-- Ejemplo 4
-- seleccionar los datos de la tabla Products donde el dato almacenado en el campo
-- sea mayor o igual a 15 y menos o igual a 50
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice >= 15 AND UnitPrice <= 50
go

-- Ejemplo 5
-- otra forma de crear la consulta anterior es utilizando la instruccion between
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice between 15 and 50
go

--Ejemplo 6
-- Haciendo uso del operador not obtenemos los registros de la tabla Products
-- donde el dato almacenado en el campo unitprice sea menor que 15
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE not UnitPrice > 15
go

--Ejemplo 7
-- Seleccionar los registros de la tabla products donde el dato almacenado en el campo
-- ProductID sea mayor a 50 y el dato almacenado en el campo UnitPrice sea menor a 10
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE ProductID > 15 OR UnitPrice < 10
go

-- Ejemplo 8
-- Seleccionar los campos employeeID y LastName de la tabla empoyees
-- donde el dato almacenado en el campo LastName comience con la letra D
SELECT  EmployeeID, LastName FROM Employees
WHERE LastName like 'D%'
go

-- Ejemplo 9
-- Seleccionar los campos EmployeeID y LastName de la tabka Employees donde el dato almacenado
-- en el campo LastName termine con la letra N
Select EmployeeID, LastName from Employees
where LastName like '%N'
go

--Ejemplo 10
--  Seleccionar los campos EmployeeID, LastName y Title de la tabla Employees donde el dato
-- almacenado en el campo Title se encuentre la palabra SALES, no importando en que posicion
Select EmployeeID, LastName, Title from Employees
where Title like '%SALES%'
go

--Ejemplo 11
-- Seleccionar los campos EmployeeID y LastName de empleados EXCEPTO aquellos donde el dato almacenado
-- en LasrName comience con la letra D
Select EmployeeID, LastName from Employees
where LastName not like 'D%'
go

--Ejemplo 12
-- Ordenar de forma ascendente los registros almacenados en los campos ProductID
-- ProductName y UnitPrice de la tabla Products, se ordenaran por medio del campo ProductID
Select ProductID, ProductName, UnitPrice
FROM Products
Order By ProductID ASC
go

-- Ejemplo 13
-- Ordenar de forma descendente los registros almacenados en los campos ProductID, ProductName
-- y UnitPrice de la tabla Products, se ordenaran por medio del campo ProductID
Select ProductID, ProductName, UnitPrice
FROM Products
Order by ProductID DESC

--Ejemplo 14
-- Seleccionar todos los registros no repetidos almacenados en el campo ORderID
-- de la tabla Order Details
Select Distinct OrderID From [Order Details]
go

-- Ejemplo 15
-- Mostrar los primeros cinco registros de la tabla order Details
Select Top 5 OrderID, ProductID, Quantity
FROM [Order Details]
go

-- Ejemplo 16
-- se mostraran el 10% de todos los pedidos almacenados en la tabla Order Details
SELECT TOP 10 PERCENT OrderID, ProductID, Quantity
FROM [Order Details]
go

-- Ejemplo 17
-- Seleccionar los datos almacenados en el campo CategoryName de la tabla Categories
-- y renonmbrar a la columna con el nombre Nombre de Categoria
SELECT CategoryName AS [Nombre de Categoria]
FROM Categories

--Ejemplo 18
-- Se quiere conocer cual seria la fecha de envio (shippedDate) con un retraso de 5 dias
-- Mostrar los campos OrderID, OrderDate y ShippedDate de la tabla Orders
SELECT OrderID, OrderDate, ShippedDate, ShippedDate + 5 AS RetrasoEnvio
FROM Orders
go

-- Ejemplo 19
-- Se desea conocer todos los productos que se encuentran en una orden
SELECT OrderID, P.ProductID, ProductName
FROM Products P
INNER JOIN [Order Details] OD
ON P.ProductID=OD.ProductID
go

-- Ejemplo 20
--  En la siguiente consulta se muestra los productos que tengan o no asignado un proveedor y los proveedores
-- independientemente si estos han ofrecido o no un producto
SELECT ProductName, CompanyName, ContactName
FROM Products P
Full JOIN Suppliers S
ON P.SupplierID=S.SupplierID
go

