create database Books

use Books

create table tbl_author (

AuthorID int identity(1,1) ,
AuthorName varchar(20),

Constraint PK_auth Primary Key (AuthorID)
)

create table tbl_books (

BookID int identity(1000,1) ,
Title varchar(50),
AuthorID int,
Price money,

Constraint PK_book Primary Key (BookID),
Constraint FK_auth Foreign Key (AuthorID) references  
tbl_author(AuthorID)
)

create proc sp_InsBook
@Title varchar(50),
@AuthorID int,
@Price Money
as
begin
  Insert into tbl_books(Title,AuthorID,Price) values(@Title,@AuthorID,
@Price)
end

exec sp_InsBook 'two states',3,200

select * from tbl_books


create proc sp_UpdBook  @BookID int,@Title varchar(50),
@AuthorID int,
@Price Money
as
begin
  Update tbl_books SET Title = @Title, AuthorID= @AuthorID,Price = @Price
            WHERE BookID  =  @BookID
end

create proc sp_DeleteBook(@BookID int)

as
begin
  DELETE FROM tbl_books
            WHERE  BookID =  @BookID
end

create proc sp_Getall

as
begin
 select * from tbl_books
end

exec sp_Getall


select * from tbl_author


create proc sp_Ins_Author
@AuthorName varchar(30)
as
begin
  Insert into tbl_author(AuthorName) values(@AuthorName)
end


create proc sp_UpdAuthor  @AuthorID int,@AuthorName varchar(30)
as
begin
  Update tbl_author SET AuthorName = @AuthorName WHERE AuthorID= @AuthorID
end

create proc sp_DeleteAuthor(@AuthorID int)

as
begin
  DELETE FROM tbl_author
            WHERE AuthorID = @AuthorID
end

create proc sp_Getall_authors

as
begin
 select * from tbl_author
end

exec  sp_Getall_authors


