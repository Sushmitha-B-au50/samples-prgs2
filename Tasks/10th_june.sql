select DepartmentID,Max(Rate) as Highest_salary, min(Rate) as lowest_salary,avg(Rate) as average_sal from HumanResources.EmployeePayHistory emp 
join HumanResources.EmployeeDepartmentHistory dept  on dept.BusinessEntityID = emp.BusinessEntityID

group by DepartmentID Having Max(Rate) = 125.50

select pay.BusinessEntityID,FirstName,LastName,Rate as highsalary from HumanResources.EmployeePayHistory pay 
join Person.Person  per on per.BusinessEntityID = pay.BusinessEntityID 
where Rate = (select max(Rate) from HumanResources.EmployeePayHistory)


select * from Production.Product where  ListPrice = (select max(ListPrice)  from Production.Product)

select ProductID,Name,Color from Production.Product 
where  Color  =(select Color from Production.Product where ProductID = 317)

select ProductID,Name,ListPrice,(select AVG(ListPrice) from Production.Product) as DiffPrice
from Production.Product

select Name,ListPrice from Production.Product where 
ListPrice >= ANY (select Max(ListPrice) from
Production.Product group by ProductSubcategoryID)


select c.LastName,c.FirstName  from Person.Person c join HumanResources.Employee e 
on e.BusinessEntityID = c.BusinessEntityID

select Bonus from Sales.SalesPerson

select FirstName,LastName from HumanResources.Employee emp join
Person.Person per on 
emp.BusinessEntityID = per.BusinessEntityID where 6700 in (select Bonus from Sales.SalesPerson
sp where sp.BusinessEntityID = emp.BusinessEntityID)

---inner query tht uses the table in outer query

with TopSales(SalespID, NumberOfSales)
as
(select SalesPersonID,Count(*) from Sales.SalesOrderHeader

where SalesPersonID is not null  Group by SalesPersonId) 
select * from  TopSales where SalespID IS NOT NULL Order by NumberOfSales Desc

select LoginID, NumSales from HumanResources.Employee e INNER JOIN TopSales on
TopSales.SalesPersonID =e.BusinessEntityID

order by NumSales Desc
select * from TopSales

-----cte

--1. Write using SUbquery
--Table Production.Product has a field called DaysToManufacture.
--Find the name of all products that are manufactured with the same numbers of DaysToManufacture of the product - 'Blade'

select * from Production.Product

select ProductID,Name , DaysToManufacture from Production.Product 
where  DaysToManufacture  =(select DaysToManufacture from Production.Product where Name = 'Blade')

--2.Sub Query
--Table Production.Product has the field weight.
--Find the heaviest product using the weight column and group it using the ProductModelID.
--Find the name of the products in the combination of ANY, ALL and SoME

select Name,Weight from Production.Product where 
Weight >= ANY(select Max(Weight) as maxwt from
Production.Product group by ProductModelID)

select Name,Weight from Production.Product where 
Weight >= ALL(select Max(Weight) as maxwt from
Production.Product group by ProductModelID)

select Name,Weight from Production.Product where 
Weight >= Some(select Max(Weight) as maxwt from
Production.Product group by ProductModelID)

--3.Sub Query
--Use the following tables:
--Sales.SalesPerson, Sales.SalesTerritory, Person.Person
--FInd the FirstName, Lastname, Territory name, Region of the person doing maximum sales per territory

select * from Sales.SalesPerson

select * from  Sales.SalesTerritory

select * from Person.Person

select FirstName, Lastname, Name ,CountryRegionCode,sal.SalesLastYear from Sales.SalesPerson sal
join Person.Person  per on per.BusinessEntityID = sal.BusinessEntityID  join Sales.SalesTerritory 
st on sal.TerritoryID = st.TerritoryID
where sal.SalesLastYear in (select max(SalesLastYear) from Sales.SalesPerson group by TerritoryID )

--4. Correlated SUbquery
--Use the following tables:
--HumanResources.Employee, PersonPerson, Sales.SalesPerson

--inner table - sales.salesPerson.(select the appropriate outer table to do the join)
--Get the field SalesQuota
--Fetch FirstName, Lastname of the salesPerson who has achieved the SalesQuota of 25000

 select * from HumanResources.Employee
 select * from Person.Person
  select * from Sales.SalesPerson

select FirstName,LastName from HumanResources.Employee emp join
Person.Person per on 
emp.BusinessEntityID = per.BusinessEntityID where 250000 in (select SalesQuota from Sales.SalesPerson
sp where sp.BusinessEntityID = emp.BusinessEntityID)

--5. Correlated Subquery
--SelfJoin using the table Sales.SalesOrderDetail
--Find the ProductID, OrderQty of the product whose UnitPrice is lessthan average UnitPrice

select p.ProductID,OrderQty,UnitPrice,AvgUnitPrice
from Sales.SalesOrderDetail p
join
(select ProductID,avg(UnitPrice) AvgUnitPrice
from Sales.SalesOrderDetail
group by ProductID) 
as tle
on p.ProductID=tle.ProductID
where UnitPrice<AvgUnitPrice
order by ProductID