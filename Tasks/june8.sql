--Tasks:
--1.	Please explore the following built-in Functions:
--Count()
--Sum()
--Datediff()
--Dateadd()
--Convert()
--Left()
--Len()
--Reverse()
--2.	Create a function to Prefix Rupee Symbol before money value.
--3.	Create  a view on a single table.
--Insert data into view and see if it reflects in Table.
--Insert data into table and see if it reflects in View.
--4.	Create Stored procedure to insert, update and delete data into table.


select DATEDIFF(year,'1999/10/24',getdate())

select DATEDIFF(day,'2021/3/12',getdate())

select count(*) as no_of_persons from Persons

SELECT SUM (Balance) FROM Persons 

select len('peacock')

SELECT DATEADD(year, 1, '2017/08/25') AS DateAdd;

SELECT DATEADD(month, -2, '2021/06/8') AS DateAdd;

SELECT FirstName, DOB, DATEADD(year, 18, DOB) AS DateAdd FROM Persons;

SELECT CONVERT(int, 25.88);

 select CONVERT(VARCHAR(19),GETDATE()) --19 means convert to mon day year and time

 SELECT REVERSE('SQL learning');

 SELECT LEFT('SQL learning', 5) AS ExtractString;

 SELECT LEFT(FirstName, 2) AS ExtractString
FROM Persons;

DECLARE @currency money = 1239.56;
SELECT @currency NoFilter,

FORMAT(@currency, 'C', 'en-in') 'rupee'

create view vwperson
as 
select PersonID, LastName,FirstName, Address, City,DOB,Balance from Persons

select * from vwperson

INSERT INTO Persons (PersonID, LastName,FirstName, Address, City,DOB,Balance)
VALUES (6, 'r', 'jack', 'london', 'norway','1987/8/14',9000);

INSERT INTO vwperson
 (PersonID, LastName,FirstName, Address, City,DOB,Balance)
VALUES (7, 'k', 'avinash', 'TN', 'chennai','1987/5/4',6000);


create proc proc_InsertPerson(
@eLastname varchar(20),@eFirstname varchar(20),
@eAddress varchar(20),@City varchar(20))
as
  Insert into Persons(LastName,FirstName, Address, City) values(@eLastname ,@eFirstname,
@eAddress ,@City)

exec proc_InsertPerson 'ramu' ,'prasad','14th car st','chennai'

create proc proc_UpdatePerson(@ePersonId int
,@eFirstname varchar(20),
@City varchar(20))
as
  Update Persons SET FirstName =@eFirstName , City = @City
            WHERE PersonId  = @ePersonId 

exec proc_UpdatePerson  4,'jack' ,'norway' 

create proc proc_DeletePerson(@ePersonId int)

as
  DELETE FROM Persons
            WHERE  PersonId =  @ePersonId

exec proc_DeletePerson  11

select * from Persons


