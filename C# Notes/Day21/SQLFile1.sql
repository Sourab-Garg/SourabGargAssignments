USE CG;

create table Products(productid int primary key ,prodname varchar(40),Description varchar(100))

insert into products values(1,'TV','52 inch black color lcd TV ');
insert into products values(2,'Laptop','very thin silver predator latop  ');
insert into products values(3,'Desktop','HP high performance dektop');

select * from products;

create table Productsales(salesid int primary key ,productid int ,UserPrice int ,quantitysold int ,
constraint ssk foreign key (productid) references Products(productid))

insert into Productsales values(1,3,450,5);
insert into Productsales values(2,2,250,7);
insert into Productsales values(3,3,450,4);
insert into Productsales values(4,3,450,9);

select * from Products;
select * from Productsales;

select productid, prodname, Description from products where productid not in (select productid from Productsales);
select productid, prodname, Description from products where productid in (select productid from Productsales);

select sum(quantitysold) as totalquanitiysold from Productsales where productid = 3; 

select pd.prodname, (select sum(quantitysold) from Productsales where productid = pd.productid) as qtysold from Products as pd;

select pd.prodname, sum(ps.quantitysold) as qtysold from Products as pd inner join Productsales as ps on pd.productid = ps.productid group by pd.productid, pd.prodname;

CREATE TABLE Employees (
    empid INT PRIMARY KEY,
    empname VARCHAR(50),
    salary INT,
    dept_id INT
);

-- Create Departments table
CREATE TABLE Departments (
    dept_id INT PRIMARY KEY,
    dept_name VARCHAR(50)
);

-- Insert into Employees
INSERT INTO Employees VALUES (101, 'Ravi', 1200, 1);
INSERT INTO Employees VALUES (102, 'Mohan', 2500, 2);
INSERT INTO Employees VALUES (103, 'Kumar', 1400, 1);
INSERT INTO Employees VALUES (104, 'Senthil', 800, 1);
INSERT INTO Employees VALUES (105, 'Manju', 2000, 2);

-- Insert into Departments
INSERT INTO Departments VALUES (1, 'IT');
INSERT INTO Departments VALUES (2, 'HR');

-- Verify data
SELECT * FROM Employees;
SELECT * FROM Departments;

select avg(salary) from Employees where dept_id = 2;

----------------------------------------------------------------------------------

SELECT e.empid, e.empname, e.salary, d.dept_name
FROM Employees e
JOIN Departments d ON e.dept_id = d.dept_id
JOIN (
    SELECT dept_id, AVG(salary) AS dept_avg
    FROM Employees
    GROUP BY dept_id
) dept_avg ON e.dept_id = dept_avg.dept_id
WHERE e.salary > dept_avg.dept_avg;

--another sceanrio 
CREATE TABLE Products1 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    category_id INT,
    price INT
);

-- Insert data into Products
INSERT INTO Products1 VALUES (1, 'Laptop', 1, 1200);
INSERT INTO Products1 VALUES (2, 'Mouse', 1, 25);
INSERT INTO Products1 VALUES (3, 'DeskJet', 2, 150);
INSERT INTO Products1 VALUES (4, 'LaserJet', 2, 800);
INSERT INTO Products1 VALUES (5, 'Keyboard', 1, 75);
INSERT INTO Products1 VALUES (6, 'Monitor', 1, 300);

-- Verify data
SELECT * FROM Products1;
 
--Scenario: Find the highest priced product in each category using correlated subquery.
-- inner query 
select max(price) from products1 where category_id=2

select p1.category_id, (select max(p2.price) from Products1 as p2 where p1.category_id = p2.category_id) as maxprice from Products1 as p1;



Transaction demo 
------------------
In SQL Server, COMMIT and ROLLBACK are used to manage transactions. A transaction is a unit of work that is either completely applied to the database or completely rolled back, ensuring consistency and integrity.

Key Concepts:
COMMIT: Saves all changes made during the transaction to the database.
ROLLBACK: Undoes all changes made during the transaction.
Example Scenario:
Let’s walk through a practical example where you insert, update, and delete records in a transaction, and either commit or rollback the changes.

 CREATE TABLE Employees1 (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50)
);


--code for roll back transaction 
begin transaction
declare @empid int ;
--insert into employee1 table and get the genrated id 
insert into Employees1(FirstName,LastName,Department) values('ravi','kumar','software');
set @empid=SCOPE_IDENTITY();--get the last inserted value 
--update the inserted value 
-- Update the inserted employee
UPDATE Employees1 SET Department='Testing' WHERE EmployeeID = @empid;
-- Force rollback by checking for an ID that does not exist
IF NOT EXISTS (SELECT * FROM Employees1 WHERE EmployeeID = 9999) -- EmployeeID 9999 does not exist
BEGIN
    PRINT 'Error: Employee not found, rolling back the transaction';
    ROLLBACK TRANSACTION;
END
ELSE
BEGIN
    PRINT 'No errors, committing transaction';
    COMMIT TRANSACTION;
END


select * from Employees1

-- code of commit transaction 

BEGIN TRANSACTION;
DECLARE @EmpID1 INT;
-- Insert a new employee and get the generated EmployeeID
INSERT INTO Employees1 (FirstName, LastName, Department) 
VALUES ('ravi1', 'kumar1', 'software1');

SET @EmpID1 = SCOPE_IDENTITY(); -- Get the last inserted ID

-- Update the inserted employee
UPDATE Employees1 SET Department='Testing' WHERE EmployeeID = @EmpID1;

-- Force rollback by checking for an ID that does not exist
IF NOT EXISTS (SELECT * FROM Employees1 WHERE EmployeeID =@EmpID1) -- EmployeeID 9999 does not exist
BEGIN
    PRINT 'Error: Employee not found, rolling back the transaction';
    ROLLBACK TRANSACTION;
END
ELSE
BEGIN
    PRINT 'No errors, committing transaction';
    COMMIT TRANSACTION;
END

select * from Employees1




CREATE TABLE Employeedata (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50)
);

--create a freshh table

-- code for save point 
------------------------
BEGIN TRANSACTION;
DECLARE @EmpID3 INT;

-- Insert a new employee and get the generated EmployeeID
INSERT INTO Employeedata (FirstName, LastName, Department) 
VALUES ('ravi3', 'kumar3', 'software3');
save transaction savepoint1;
SET @EmpID3 = SCOPE_IDENTITY(); -- Get the last inserted ID
-- Update the inserted employee
UPDATE Employeedata SET Department='Testing6' WHERE EmployeeID = @EmpID3;
-- Check if the employee exists
IF NOT EXISTS (SELECT * FROM Employeedata WHERE EmployeeID = 999) -- again rolling back but till save point1
BEGIN
   PRINT 'An error occurred, rolling back only part of the transaction';
    ROLLBACK TRANSACTION savepoint1; 
    PRINT 'Rolled back the error, but Employee is only inserted but that is not updated ';
END
ELSE
BEGIN
    PRINT 'No errors, committing transaction';
    COMMIT TRANSACTION;