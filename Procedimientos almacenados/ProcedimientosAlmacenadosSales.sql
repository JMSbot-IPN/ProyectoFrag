--CONSULTAS DEL PROYECTO DE FRAGMENTACION

--a. Determinar el total de las ventas de los productos de la categor�a que se provea 
--	 como argumento de entrada en la consulta, para cada uno de los territorios 
--	 registrados en la base de datos o para cada una de las regiones (atributo group
--	 de SalesTerritory) seg�n se especifique como argumento de entrada.

-- variable @cat es el argumento de entrada que
-- corresponde a la categor�a del producto
-- Se realiza un inner join para acceder a los
-- territorios y calcular mediante una suma
-- el total de las ventas que se encuentra en
-- salesorderdetail.

ALTER PROCEDURE sp_consulta_A
(@cat nvarchar(100)) AS
BEGIN
IF(@cat >=1 AND @cat <= 4 )
	BEGIN
		select soh.TerritoryID, sum(sod.linetotal)
		from salesAW.sales.SalesOrderDetail sod
		inner join SalesAW.sales.SalesOrderHeader soh
		on sod.SalesOrderID = soh.SalesOrderID
		where sod.ProductID in (
			select ProductID
			from [INSTANCIA2].productionAW.Production.Product
			where ProductSubcategoryID in (
				 select ProductSubcategoryID
				 from [INSTANCIA2].productionAW.Production.ProductSubcategory
				 where ProductCategoryID = @cat
			   )
			)
		group by soh.TerritoryID 
	END
END

EXECUTE sp_consulta_A @cat = 1

----------------------------------------------------------------------------------------------------------
--b. Determinar el producto m�s solicitado para la regi�n (atributo group de 
--salesterritory) que se especifique como argumento de entrada y en que 
--territorio de la regi�n tiene mayor demanda
CREATE or alter PROCEDURE sp_consulta_B
@region nvarchar(50) AS
BEGIN 
SELECT
	TOP 1 SUM(Tabla.lineTotal) as total_ventas, Prod.Name as Nombre, Prod.ProductID
FROM [INSTANCIA2].productionAW.Production.Product Prod
inner join(SELECT ProductID, lineTotal FROM  sales.SalesOrderDetail sod
	WHERE SalesOrderID in( SELECT SalesOrderID FROM  sales.SalesOrderHeader soh
		WHERE TerritoryID in( SELECT TerritoryID FROM  sales.SalesTerritory st
			WHERE [Group] = @region))) as Tabla
	on
	Prod.ProductID = Tabla.ProductID GROUP BY Prod.Name, Prod.ProductID ORDER by
	total_ventas DESC
END
execute ProdMasSolicitado @region=N'North America'


---------------------------------------------------------------------------------------------------------
--c. Actualizar el stock disponible en un 5% de los productos de la categor�a que se 
--provea como argumento de entrada, en una localidad que tambi�n se provea 
--como argumento de entrada en la instrucci�n de actualizaci�n.

GO
CREATE PROCEDURE sp_consulta_C
(@cat nvarchar(100),
@loc nvarchar(100)) AS
BEGIN
	IF EXISTS (
		SELECT * FROM [INSTANCIA2].productionAW.Production.ProductInventory
		WHERE locationId = @loc
		AND productId IN ( 
				SELECT productId
				FROM [INSTANCIA2].productionAW.Production.Product
				WHERE ProductSubcategoryId IN (	
						SELECT ProductSubcategoryId
						FROM [INSTANCIA2].productionAW.Production.ProductSubcategory
						WHERE ProductCategoryId = @cat))
	)
	BEGIN
		UPDATE [INSTANCIA2].productionAW.Production.ProductInventory
		SET quantity =  quantity * 1.05
		WHERE locationId = @loc
		AND productId IN ( 
				SELECT productId
				FROM [INSTANCIA2].productionAW.Production.Product
				WHERE ProductSubcategoryId IN (	
						SELECT ProductSubcategoryId
						FROM [INSTANCIA2].productionAW.Production.ProductSubcategory
						WHERE ProductCategoryId = @cat))

		SELECT * FROM [INSTANCIA2].productionAW.Production.ProductInventory WHERE locationId = @loc
		AND productId IN ( 
				SELECT productId
				FROM [INSTANCIA2].productionAW.Production.Product
				WHERE ProductSubcategoryId IN (	
						SELECT ProductSubcategoryId
						FROM [INSTANCIA2].productionAW.Production.ProductSubcategory
						WHERE ProductCategoryId = @cat))
		print('Se actualizo correctamente el inventario')
	END
	ELSE
	BEGIN
		print 'No hay productos de esta locacion y categoria en el inventario'
	END
END

EXECUTE sp_consulta_C @cat = 3, @loc = 7

---------------------------------------------------------------------------------------------
--d. Determinar si hay clientes de un territorio que se especifique como argumento 
--de entrada, que realizan ordenes en territorios diferentes al que se encuentran.

GO
CREATE PROCEDURE sp_consulta_D
(@terri nvarchar(100)) AS
BEGIN
	if (@terri >= 1 AND @terri <=10)
		BEGIN
			SELECT c.CustomerId
			FROM salesAW.Sales.Customer c INNER JOIN salesAW.Sales.SalesOrderHeader soh 
			ON c.TerritoryId != soh.TerritoryId
			AND C.customerId = soh.CustomerId
			WHERE soh.TerritoryId = @terri
		END
		ELSE
		BEGIN
			print('No existe ese territorio')
		END
END

EXECUTE sp_consulta_D @terri = 7

------------------------------------------------------------------------------------------------
--e. Actualizar la cantidad de productos de una orden que se provea como 
--argumento en la instrucci�n de actualizaci�n
GO
ALTER PROCEDURE sp_consulta_E
(@qty nvarchar(100),
 @OrderId nvarchar(100),
 @producto nvarchar(100)) AS
BEGIN
	IF EXISTS(SELECT * FROM salesAW.Sales.SalesOrderDetail WHERE SalesOrderID = @OrderId AND ProductID = @producto)
	BEGIN
		UPDATE salesAW.Sales.SalesOrderDetail
		SET OrderQty = @qty
		WHERE SalesOrderID = @OrderId AND ProductID = @producto

		SELECT * FROM salesAW.Sales.SalesOrderDetail WHERE SalesOrderID = @OrderId AND ProductID = @producto
	END
	ELSE 
	BEGIN
		SELECT * FROM salesAW.Sales.SalesOrderDetail WHERE SalesOrderID = @OrderId AND ProductID = @producto
		print('No existe esa orden con ese producto')
	END
END

EXECUTE sp_consulta_E @qty = 3, @OrderId = 43659, @producto = 780

SELECT * FROM Sales.SalesOrderDetail

-----------------------------------------------------------------------------------------------------
--f. Actualizar el m�todo de env�o de una orden que se reciba como argumento en 
--la instrucci�n de actualizaci�n.

GO
ALTER PROCEDURE sp_consulta_F
(@envio nvarchar(100),
 @Order nvarchar(100)) AS
BEGIN
	IF (@envio >= 1 AND @envio <= 5)
	BEGIN
		IF EXISTS ( SELECT * FROM salesAW.Sales.SalesOrderHeader WHERE SalesOrderID = @Order)
		BEGIN
			UPDATE salesAW.Sales.SalesOrderHeader
			SET ShipMethodID = @envio
			WHERE SalesOrderID = @Order AND (@envio >= 1 AND @envio <=5) 

			SELECT * FROM salesAW.Sales.SalesOrderHeader WHERE SalesOrderID = @Order
		END
		ELSE
		BEGIN
		print('Orden no existente')
		END
	END
	ELSE
	BEGIN
		print('Forma de envio no disponible')
	END
END

EXECUTE sp_consulta_F @envio = 2, @Order = 43659

-----------------------------------------------------------------------------------
--g. Actualizar el correo electr�nico de una cliente que se reciba como argumento 
--en la instrucci�n de actualizaci�n

GO
CREATE PROCEDURE sp_consulta_G
(@fName nvarchar(100),
 @lName nvarchar(100),
 @correo nvarchar(100)) AS
BEGIN
	IF EXISTS (
		SELECT * FROM [INSTANCIA3].otherAW.Person.EmailAddress 
		WHERE BusinessEntityID in(
				SELECT BusinessEntityID 
				FROM Person.Person as p
				WHERE p.FirstName=@fName AND p.LastName=@lName AND p.PersonType='SC'))
	BEGIN
		UPDATE [INSTANCIA3].otherAW.Person.EmailAddress SET EmailAddress = @correo
			WHERE BusinessEntityID in(
					SELECT BusinessEntityID FROM [INSTANCIA3].Person.Person1 as p
					WHERE p.FirstName=@fName AND p.LastName=@lName AND p.PersonType='SC')

		SELECT * FROM [INSTANCIA3].otherAW.Person.EmailAddress 
		WHERE BusinessEntityID in(
				SELECT BusinessEntityID 
				FROM [INSTANCIA3].Person.Person1 as p
				WHERE p.FirstName=@fName AND p.LastName=@lName AND p.PersonType='SC')
	END
	ELSE
	BEGIN
		print('Persona no encontrada o no pertenece a un cliente')
	END
END

EXECUTE sp_consulta_G @fName = 'S', @lName = 'P', @correo = 'prueba@ipn.mx' 

-----------------------------------------------------------------------------------
--h. Determinar el empleado que atendi� m�s ordenes por territorio/regi�n.

GO
ALTER PROCEDURE sp_consulta_H AS
BEGIN
	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 1 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory1  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory1.SalesPersonID = P.BusinessEntityID

	UNION 

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 2 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory2  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory2.SalesPersonID = P.BusinessEntityID

	UNION

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 3 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory3  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory3.SalesPersonID = P.BusinessEntityID

	UNION 

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 4 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory4  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory4.SalesPersonID = P.BusinessEntityID

	UNION

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 5 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory5  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory5.SalesPersonID = P.BusinessEntityID

	UNION 

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 6 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory6  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory6.SalesPersonID = P.BusinessEntityID

	UNION

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 7 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory7  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory7.SalesPersonID = P.BusinessEntityID

	UNION 

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 8 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory8  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory8.SalesPersonID = P.BusinessEntityID

	UNION

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 9 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory9  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory9.SalesPersonID = P.BusinessEntityID

	UNION 

	SELECT TerritoryID,SalesPersonID, P.FirstName, P.LastName, Total_Pedidos FROM
	(SELECT TOP 1 * FROM (
	SELECT TerritoryID, SalesPersonID, count(*) as Total_Pedidos
	FROM salesAW.Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL AND TerritoryID = 10 GROUP BY SalesPersonId, TerritoryID ) 
	AS pedidos ORDER BY TerritoryID, Total_Pedidos DESC) AS territory10  INNER JOIN [INSTANCIA3].otherAW.Person.Person1 as P ON territory10.SalesPersonID = P.BusinessEntityID

END

EXECUTE sp_consulta_H

-----------------------------------------------------------------------------------------------------------------------------
--i. Determinar para un rango de fechas establecidas como argumento de entrada,
--cual es el total de las ventas en cada una de las regiones.

GO
CREATE PROCEDURE sp_consulta_I
(@fechaEntrada DATE,
 @fechaSalida DATE) AS
BEGIN
	IF EXISTS(
		SELECT * FROM salesAW.Sales.SalesOrderHeader
		WHERE OrderDate BETWEEN @fechaEntrada AND @fechaSalida)
	BEGIN	
		SELECT TerritoryID, SUM(TotalDue) AS Total_Ventas 
		FROM salesAW.Sales.SalesOrderHeader 
		WHERE OrderDate BETWEEN @fechaEntrada AND @fechaSalida GROUP BY TerritoryID ORDER BY TerritoryID
	END
	ELSE
	BEGIN
		print('Error en la fecha o en el rango')
	END
END

EXECUTE sp_consulta_I @fechaEntrada = '2011-05-31', @fechaSalida = '2011-06-30'

-----------------------------------------------------------------------------------------------
--j. Determinar los 5 productos menos vendidos en un rango de fecha establecido 
--como argumento de entrada.


USE [otherAW]
GO

SELECT [BusinessEntityID]
      ,[PersonType]
      ,[NameStyle]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[EmailPromotion]
  INTO otherAW.person.person1
  FROM [Person].[Person]

GO

