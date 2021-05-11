 --assignment
 --use pubs

  --1)Select the author firtname and last name

 select au_fname First_Name, au_lname Last_Name from authors

 --2)Sort the titles by the title name in descending order and print all teh details

 select title as title_name from  titles order by title  desc

 --3)Print the number of titlespublished by every author
 
  select au_id,count(title_id) numof_titles from titleauthor  group by au_id

 --select au_fname as author_fullname , count(title) as no_of_title from  authors a, titleauthor t, titles ts , publishers p where  a.au_id = t.au_id AND
  --t.title_id = ts.title_id AND ts.pub_id = p.pub_id group by p.pub_id ,a.au_fname
 

 --4)print the author name and title name

 select  Concat(au_fname, '  ', au_lname) as author_fullname,title as title_name from titleauthor t inner join titles ts on t.title_id = ts.title_id inner join authors a  on t.au_id = a.au_id

  --5)print the publisher name and the average advance for every publisher

   select p.pub_name,avg(t.advance) average_advance from publishers p left outer join titles t  on p.pub_id = t.pub_id
	group by t. pub_id,p.pub_name

	--6) print the publishername, author name, title name and the sale amount(qty*price)

	select  pub_name, Concat(au_fname, '  ', au_lname) as author_fullname, title, (s.qty*ts.price) as sales_amount from publishers p, authors a, titleauthor t, titles ts , sales s where  a.au_id = t.au_id AND
  t.title_id = ts.title_id AND ts.pub_id = p.pub_id  AND ts.title_id = s.title_id


  --7) print the price of all that titles that have name taht ends with s

         select price,title from titles where title like '%s'

  -- 8) print the title names that contain and in it

        select title from titles where title like '%and%'


   --9)  print the employee name and the publisher name

     select Concat(fname, '  ', lname) as empol_fullname,pub_name as pub_fullname from employee e  join  publishers p  on e.pub_id = p.pub_id

 
 --10) print the publisher name and number of employees woking in it if the publisher has more than 2 employees
    
	   select  pub_name,count(fname) as no_of_emp  from  publishers p join employee e  on p.pub_id = e.pub_id group by pub_name  having count(fname) > 2


 --11) Print the author names who have published using teh publisher name 'Algodata Infosystems'

 select Concat(au_fname, ' ' ,au_lname) as au_names_who_published_using_publname_infosys  from authors where au_id in
(select au_id from titleauthor where title_id in
(select title_id from titles where pub_id in
(select pub_id from publishers where  pub_name='Algodata Infosystems')))


--12) Print the employees of the publisher 'Algodata Infosystems'

 select Concat(fname, '  ', lname) as emps_of_publishers from employee e  join  publishers p  on e.pub_id = p.pub_id
  where pub_name ='Algodata Infosystems'

