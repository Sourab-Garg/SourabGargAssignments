create function mul(@x int, @y int)
returns int
as
begin 
return @x * @y;
end

select dbo.mul(23,2);

create table orders(orderid int primary key ,orderdate datetime,
whichcustomer varchar(10))

insert into orders values(101,'1996-08-01','c01')
insert into orders values(102,'1997-04-02','c01')
insert into orders values(103,'2012-08-01','c01')
insert into orders values(104,'2013-08-05','c02')
insert into orders values(105,'2014-08-01','c02')

select * from orders;

--write a function to find last or latest  order ordered by the given customer ..
create function findLatestOrder (@cusID varchar(30))
returns datetime
as
begin
DECLARE @latestDate datetime;

SELECT @latestDate = MAX(orderdate)FROM orders WHERE whichcustomer = @cusID;
return @latestDate;
end

SELECT dbo.findLatestOrder('c01') AS LatestOrderDate;
SELECT dbo.findLatestOrder('c02') AS LatestOrderDate;


create table Books(
title_id varchar(10),
pages int,
qty_sold int)
insert into Books values('b0101',200,89)
insert into Books values('b0101',200,189)
insert into Books values('b0102',300,79)
insert into Books values('b0103',700,85)
select * from Books

--Q) write a function on this table which will give me no of books sold based on id value u provide to the function ?
create function booksSold(@titleID varchar(10))
returns int
as
begin
return (select sum(qty_sold) from Books where title_id = @titleID);
end;

select dbo.booksSold('b0101') as totalBooksSold;

create function booksSold1(@titleID varchar(10))
returns int
as
begin
declare @total int;
set @total =  (select sum(qty_sold) from Books where title_id = @titleID);
return isnull(@total, 0)
end;

select dbo.booksSold1('b0109') as totalBooksSold;

create table employee_info(
     ID          int,
     name        varchar (10),
     salary      int,
     start_date  datetime,
     city       varchar (10),
     region      char (1))

insert into employee_info
               values (1,  'Jason', 40420,  '02/01/94', 'New York', 'W')
 insert into employee_info 
               values (2,  'Robert',14420,  '01/02/95', 'Vancouver','N')
insert into employee_info 
               values (2,  'Jhonny',14420,  '01/02/95', 'Vancouver','N')
 insert into employee_info 
               values (3,  'Celia', 24020,  '12/03/96', 'Toronto',  'W')

select * from employee_info


--write an inline table valued function to find employees in particular region 

create function getRegionTable(@region char(1))
returns table 
as
return select * from employee_info where region = @region;
--cant use begin and end as it return table it become a inline user defined function

select * from getRegionTable('N');

SET OPERATORS
-------------
In SQL Server, set operators like UNION, INTERSECT, and EXCEPT or Minus (the SQL Server equivalent of MINUS in other databases like Oracle) are used to combine the results of two or more queries. These set operators return distinct results from the queries involved.

1. UNION
Combines the result sets of two or more queries and removes duplicates.
Returns distinct values from both result sets.
2. INTERSECT
Returns only the rows that are common in both result sets.
3. EXCEPT (Equivalent to MINUS in other databases)
Returns the rows from the first query that are not present in the second query.

Rules for Using Set Operators:

The number of columns and their data types must be the same in both queries.
The order of the columns must be the same.
Example Scenario:
Let's work with two tables, Employees_A and Employees_B, which contain some employee records.

-- Table: Employees_A
CREATE TABLE Employees_A (
    employee_id INT,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50)
);

INSERT INTO Employees_A (employee_id, first_name, last_name)
VALUES (1, 'John', 'Doe'),
       (2, 'Jane', 'Smith'),
       (3, 'Alice', 'Johnson');

-- Table: Employees_B
CREATE TABLE Employees_B (
    employee_id INT,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50)
);

INSERT INTO Employees_B (employee_id, first_name, last_name)
VALUES (2, 'Jane', 'Smith'),
       (3, 'Alice', 'Johnson'),
       (4, 'Bob', 'Brown');


-- Get all distinct employees from both tables
select * from Employees_A
select * from Employees_B

SELECT employee_id, first_name, last_name FROM Employees_A
UNION
SELECT employee_id, first_name, last_name FROM Employees_B;


select * from Employees_A
select * from Employees_B
-- Get the employees that are present in both tables
SELECT employee_id, first_name, last_name FROM Employees_A
INTERSECT
SELECT employee_id, first_name, last_name FROM Employees_B;



select * from Employees_A
select * from Employees_B
-- Get employees that are present in Employees_A but not in Employees_B
SELECT employee_id, first_name, last_name FROM Employees_A
EXCEPT
SELECT employee_id, first_name, last_name FROM Employees_B;


-- Combine UNION, INTERSECT, and EXCEPT in one query
-- Step 1: Find all employees from both tables using UNION
-- Step 2: Find common employees using INTERSECT
-- Step 3: Find employees that are only in Employees_A but not in Employees_B using EXCEPT

select * from Employees_A
select * from Employees_B
SELECT employee_id, first_name, last_name FROM Employees_A
UNION
SELECT employee_id, first_name, last_name FROM Employees_B
INTERSECT
SELECT employee_id, first_name, last_name FROM Employees_A
EXCEPT
SELECT employee_id, first_name, last_name FROM Employees_B;

--INTERSECT (Highest priority – evaluated first)
--UNION and EXCEPT (Equal priority – evaluated from left to right/top to bottom)