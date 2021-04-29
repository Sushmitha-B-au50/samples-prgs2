
--use pubs
-- 1)Print the city name and the count of authors from every city

  	select city,count(au_id) as au_from_city from authors group by city

	
-- 2)Print the authors who are not from the city in which the publisher 'New Moon Books' is from.

	  	select Concat(au_fname, '  ', au_lname) as author_fullname from authors where city not in
		(select city from publishers where pub_name ='New Moon Books' )


--3) Create a procudure that will take the author first name and last name and new price 
--The procedure should update teh price of the books written by the author with the give name 

create proc proc_Setting_NewPriceusing_Auname(  @aufname varchar(50)  ,  @aulname varchar(50) ,  @new_price int)
as
begin
 
   update titles set price  = @new_price from titles where title_id in
  (select title_id from titleauthor where au_id in
  (select au_id from authors where au_fname=@aufname  and au_lname=@aulname))

 end

exec proc_Setting_NewPriceusing_Auname 'Johnson','White' , 900
exec proc_Setting_NewPriceusing_Auname 'Marjorie','Green' , 400

select * from titles


--4) Create a function that will calculate tax for the sale of every book
--If quantity <10 tax is 2%
--10 -20 tax is 5%
--20 - 50 tax is 6%
--above 30 tax is 7.5%
--The fuction should take quantity and return tax

create function fn_Calculate_tax(@qty int)
returns float
as
begin
declare
    @tax float
set @tax = 0

if(@qty>0 and @qty<10)
   set @tax = 2

else  if(@qty>10 and @qty<20)
   set @tax = 5

else  if(@qty>20 and @qty<30)
   set @tax = 6

else  
   set @tax = 7.5

return @tax

end


select title_id,qty,dbo.fn_Calculate_tax(qty) as Taxamount_forbook from sales;



