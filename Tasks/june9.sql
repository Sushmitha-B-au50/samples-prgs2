select @@VERSION

select * from sys.databases

select * from sys.tables

select * from HumanResources.Department

select * from HumanResources.EmployeeDepartmentHistory

select * from Person.Person

select *from  Person.Person where  title like 'Ms%'

select distinct title from  Person.Person

select * from HumanResources.Employee

select BusinessEntityID, DATEDIFF(year,HireDate,getdate()) as No_of_yrs from HumanResources.Employee


select e.BusinessEntityID,h.DepartmentID,h.ShiftID, DATEDIFF(year,StartDate,getdate()) as No_of_yrs from  HumanResources.Employee e join HumanResources.EmployeeDepartmentHistory h on
e.BusinessEntityID = h.BusinessEntityID
----------------------------------------------------------
select e.BusinessEntityID,h.DepartmentID,h.ShiftID, DATEDIFF(year,StartDate,getdate()) as No_of_yrs from  HumanResources.Employee e join HumanResources.EmployeeDepartmentHistory h on
e.BusinessEntityID = h.BusinessEntityID where EndDate is null
 union all

 select e.BusinessEntityID,h.DepartmentID,h.ShiftID, DATEDIFF(year,StartDate,EndDate) as No_of_yrs from  HumanResources.Employee e join HumanResources.EmployeeDepartmentHistory h on
e.BusinessEntityID = h.BusinessEntityID where EndDate is not null

select emp.BusinessEntityID,DepartmentID,DATEDIFF(yy,startDate,(CASE 
When EndDate IS NULL THEN GETDATE() ELSE EndDate END)) as Experience from HumanResources.Employee emp  join HumanResources.EmployeeDepartmentHistory edh on emp.BusinessEntityID = edh.BusinessEntityID


 SELECT BusinessEntityID, DATEDIFF (YEAR,BirthDate,GETDATE()) age,(65-DATEDIFF(year,birthdate,getdate())) yearleft from HumanResources.Employee

 select BusinessEntityID,BirthDate,65 - DATEDIFF(year,BirthDate,GETDATE()) serviceperiod,DATEADD(year,65,BirthDate) Retriment_Date from HumanResources.Employee where (DATEDIFF(year,BirthDate,GETDATE()))> 65

 select Color from Production.Product

 select * from Production.Product

 select  replace('NULL', 'NULL','Multicolor') from Production.Product

 SELECT    
	ProductID,Name,COALESCE(Color,'Multicolor') as color
FROM    
	Production.Product

select ProductID,Name,ProductNumber,isnull(Color,'MultiColor') FROM    
	Production.Product

select * from Production.Product
select * from Production.ProductCategory
select * from Production.ProductSubcategory

--select ProductID, cat.Name Category,sub.Name SubCategory,prod.Name ProductName,ListPrice from Production.Product prod join Production.

-----------------------------------------------------------------------------------------


select * from Person.Person

 --1)Display firstname,lastname from person.person whose title is not null.
 

 select FirstName,LastName from Person.Person where Title is not null

-- 2:
 
--Display Firstname,lastname from person.person whose firstname and lastname should have atleast one 'a'.
 

select * from Person.Person where (FirstName like 
'%a%' OR LastName like '%a');

--3: 
--Display currencycode,name from Sales.Currency and Sales.CountryRegionCurrency without using joins
 
 select * from Sales.Currency
 select * from Sales.CountryRegionCurrency

select s.CurrencyCode,Name from Sales.Currency s , Sales.CountryRegionCurrency sr  where s.CurrencyCode = sr.CurrencyCode

select * from HumanResources.Department 
--4: Copy humanresources.department table to the new table named as 'HR.Dept'
 
CREATE TABLE [dbo]. [HR.Dept] (
   [DepartmentID] [int] IDENTITY(1,1) PRIMARY KEY,
    [Name] [varchar](255) NOT NULL,
    [GroupName] [varchar](255),
    [ModifiedDate] [DateTime] NOT NULL,
);
INSERT INTO [HR.Dept]( 
    [Name] ,
    [GroupName] ,
    [ModifiedDate])
SELECT Name,GroupName,ModifiedDate
FROM HumanResources.Department;

select * from [HR.Dept]
--5.Create a table with column named 'SNo' and make that column as identity.insert 20 rows using insert
----into statement(table should contain 5 columns)
create table	Employee(
Sno int Identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Location varchar(10),
Salary money
);
select * from Employee

insert into Employee values ('priya','p','chennai',45000),
('jonah','B','banglore',40000),('sudharshna','s','Chennai',45000),
('kala','K','pune',27000),('Lakshmi','N','mumbai',80000),
('Ravi','S','delhi',30000),('sowmiya','S','banglore',45000),
('Rekha','k','pune',32000),
('Rahul','M','hyderbad',29000),('sethu','L','delhi',40000),
('Reshma','S','pune',30000),('pavi','p','delhi',40000),
('shivu','L','banglore',40000),('eshwari','P','mumbai',25000),
('Ram','B','delhi',27000),('Ramesh','A','chennai',24000),
('thiru','C','patna',40000),('rohan','E','Kolkata',30000),
('karthi','D','delhi',25000),('kalish','R','mumbai',40000)

--6:
--Perform inner join operation to display businessentityid,addresstypeid from humanresources.department and Person.BusinessEntityAddress
--select * from HumanResources.Department 
--select * from Person.BusinessEntityAddress
select b.BusinessEntityID,b.AddressTypeID 
from HumanResources.EmployeeDepartmentHistory dept 
inner join Person.BusinessEntityAddress b
on dept.BusinessEntityID=b.BusinessEntityID


--Task 7:
--Display distinct values of column named 'Group name' from humanresources.department

 select distinct GroupName from humanresources.department

-- Task 8:
--Display documentnode,StandardCost,sum of ListPrice & StandardCost from Production.ProductCostHistory and Production.Product
select * from Production.ProductCostHistory
select * from Production.Product

select p.StandardCost,sum ( ListPrice) as sum_of_ListPrice from Production.Product p join Production.ProductCostHistory pc on 
 p.ProductID = pc.ProductID group by p.StandardCost

-- Task 9:
 
--Use Datediff() fumction to find 'Years on role' using Startdate and enddate from HumanResources.EmployeeDepartmentHistory
select *, DATEDIFF(year,StartDate,EndDate) as years_on_role from  HumanResources.EmployeeDepartmentHistory

select * from HumanResources.EmployeeDepartmentHistory

--10.Filter the data from Sales.SalesPersonQuotaHistory whose sum of '5000 and SalesQuota' is greater than 100000. 
---Arrange in ascending order with respect to the sum of salesquota and 5000

select *,SalesQuota+5000 sumOfSalesQuotaAnd5000 from Sales.SalesPersonQuotaHistory
where SalesQuota+5000>100000
order by sumOfSalesQuotaAnd5000
--Task 11:
--find the maximum taxrate as Max_taxrate from sales.salestaxrate
select * from sales.salestaxrate

select  max(TaxRate) as  Max_taxrate from sales.salestaxrate

--12.Perform Join Operation and display DepartmentID,BusinessentityId,ShiftId,BirthDate.Find Age and display.(use getdate() function).
----Note: Use HumanResources.Employee,HumanResources.Department,HumanResources.EmployeeDepartmentHistory.
select * from HumanResources.Department
select * from HumanResources.EmployeeDepartmentHistory
select * from HumanResources.Employee

select dept.DepartmentID,emp.BusinessEntityID,deptHistory.ShiftID,emp.BirthDate,DATEDIFF(YEAR,emp.BirthDate,GetDate()) Age 
from HumanResources.Department dept 
join HumanResources.EmployeeDepartmentHistory deptHistory
on dept.DepartmentID=deptHistory.DepartmentID
join HumanResources.Employee emp
on deptHistory.BusinessEntityID=emp.BusinessEntityID
order by dept.DepartmentID

--13.Create view named 'Name_age' for Task-12
 
create View Name_age 
as
select dept.DepartmentID,emp.BusinessEntityID,deptHistory.ShiftID,emp.BirthDate,DATEDIFF(YEAR,emp.BirthDate,GetDate()) Age 
from HumanResources.Department dept 
join HumanResources.EmployeeDepartmentHistory deptHistory
on dept.DepartmentID=deptHistory.DepartmentID
join HumanResources.Employee emp
on deptHistory.BusinessEntityID=emp.BusinessEntityID

select * from Name_age



--15.Display maximum rate for each department

select max(pay.Rate) MaxRateInEachDept,his.DepartmentID from HumanResources.EmployeePayHistory pay
join HumanResources.EmployeeDepartmentHistory his
on his.BusinessEntityID=pay.BusinessEntityID
group by his.DepartmentID

select * from HumanResources.EmployeePayHistory
select * from HumanResources.EmployeeDepartmentHistory order by DepartmentID