BEGIN TRY

    SELECT 1/0 AS Error

END TRY
BEGIN CATCH

    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_STATE() AS ErrorState,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_LINE() AS ErrorLine,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_MESSAGE() AS ErrorMessage

END CATCH

create table dbo.TestUsers(ID int primary key ,
name varchar(50))

insert into dbo.TestUsers values(1,'Alice')

begin try
insert into dbo.TestUsers values(1,'Bob')
end try 
begin catch 
select
Error_number() as ErrorNumber ,
ERROR_SEVERITY() as ErrorSeverity,
error_state() as ErrorState,
ERROR_MESSAGE() as ErrorMessage,
Error_Line() as Errorline
end catch


--example 3 
--conversion error 
begin try 
declare @val int ;
set @val=convert(int,'abc')
end try 
begin catch 
select 
Error_number() as ErrorNumber ,
ERROR_SEVERITY() as ErrorSeverity,
error_state() as ErrorState,
ERROR_MESSAGE() as ErrorMessage,
Error_Line() as Errorline,
ERROR_PROCEDURE() AS ErrorProcedure
end catch 

--exaple 4 
--------------
CREATE TABLE dbo.TableA (Id INT PRIMARY KEY, Val INT);
CREATE TABLE dbo.TableB (Id INT PRIMARY KEY, Val INT);

INSERT INTO dbo.TableA VALUES (1, 100);
INSERT INTO dbo.TableB VALUES (1, 200);

BEGIN TRY
    BEGIN TRANSACTION;
    UPDATE dbo.TableA SET Val = Val + 10 WHERE Id = 1;
    WAITFOR DELAY '00:00:10';  -- hold lock on TableA
    UPDATE dbo.TableB SET Val = Val + 10 WHERE Id = 1;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,      -- 1205 if deadlocked
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

-- in another tab 

BEGIN TRY
    BEGIN TRANSACTION;
    UPDATE dbo.TableB SET Val = Val + 20 WHERE Id = 1;
    WAITFOR DELAY '00:00:10';  -- hold lock on TableB
    UPDATE dbo.TableA SET Val = Val + 20 WHERE Id = 1;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,      -- 1205 if deadlocked
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;


-- Create Customers table
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100)
);

-- Create Orders table with a foreign key reference to Customers
CREATE TABLE Orders1
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    OrderAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


CREATE PROCEDURE InsertCustomerOrder
    @CustomerName NVARCHAR(100),
    @OrderAmount DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        -- Start transaction
        BEGIN TRANSACTION;

        -- Insert into Customers table
        INSERT INTO Customers (CustomerName)
        VALUES (@CustomerName);

        -- Simulate error by inserting an invalid CustomerID into Orders (e.g., 0, which does not exist)
        INSERT INTO Orders1 (CustomerID, OrderAmount)
        VALUES (1, @OrderAmount);

        -- If no error, commit transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Error handling: Output error details using functions
        PRINT 'An error occurred during the transaction';

        PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10));
        PRINT 'Error Message: ' + ERROR_MESSAGE();
        PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS NVARCHAR(10));
        PRINT 'Error State: ' + CAST(ERROR_STATE() AS NVARCHAR(10));
        PRINT 'Error Procedure: ' + ISNULL(ERROR_PROCEDURE(), 'N/A');
        PRINT 'Error Line: ' + CAST(ERROR_LINE() AS NVARCHAR(10));

        -- Optionally, re-throw the error
        -- THROW;
    END CATCH
END

exec InsertCustomerOrder 'ravi',123.34


select * from customers ;
select * from Orders1;

--now alter the sp using putting 0 like  this below 

alter PROCEDURE InsertCustomerOrder
    @CustomerName NVARCHAR(100),
    @OrderAmount DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        -- Start transaction
        BEGIN TRANSACTION;

        -- Insert into Customers table
        INSERT INTO Customers (CustomerName)
        VALUES (@CustomerName);

        -- Simulate error by inserting an invalid CustomerID into Orders (e.g., 0, which does not exist)
        INSERT INTO Orders1 (CustomerID, OrderAmount)
        VALUES (0, @OrderAmount);

        -- If no error, commit transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Error handling: Output error details using functions
        PRINT 'An error occurred during the transaction';

        PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10));
        PRINT 'Error Message: ' + ERROR_MESSAGE();
        PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS NVARCHAR(10));
        PRINT 'Error State: ' + CAST(ERROR_STATE() AS NVARCHAR(10));
        PRINT 'Error Procedure: ' + ISNULL(ERROR_PROCEDURE(), 'N/A');
        PRINT 'Error Line: ' + CAST(ERROR_LINE() AS NVARCHAR(10));

        -- Optionally, re-throw the error
        -- THROW;
    END CATCH
END
exec InsertCustomerOrder 'mahesh',128.34


select * from customers ;
select * from Orders1;

Begin try
declare @age int =125;
if @age < 18 
RAISERROR('User must be atleast 18',16,5);
if @age > 120
RaisError('User age is unrealistic high',16,6);
if @age  is null
RaisError('Age cannot be null',16,7);
end try 
begin catch 
select 
 ERROR_NUMBER() AS ErrorNumber,
        ERROR_STATE()  AS ErrorState,   -- will be 5, 6, or 7
        ERROR_MESSAGE() AS ErrorMessage
end catch 


CREATE TABLE Employees23 (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(50),
    Department VARCHAR(50),
    Salary INT
);

-- Insert sample data
INSERT INTO Employees23 (EmpID, Name, Department, Salary)
VALUES 
(1, 'Alice', 'HR', 60000),
(2, 'Bob', 'IT', 55000),
(3, 'Charlie', 'HR', 70000),
(4, 'David', 'IT', 60000),
(5, 'Eva', 'Finance', 75000),
(6, 'Frank', 'Finance', 62000),
(7, 'Grace', 'IT', 55000),
(8, 'Hannah', 'HR', 50000);

select * from Employees23;

Task:
--We want to find all employees whose salary is greater than the average salary of their 
--respective department.

select avg(Salary) as avgsal from Employees23;
select DEpartment, avg(Salary) as avgsal from Employees23 group by Department;


SELECT Name, Salary FROM Employees23 as e1 WHERE Salary > (SELECT AVG(Salary) FROM Employees23 where Department = e1.Department);

UPDATE Employees23 SET Salary = 55000 WHERE Name IN ('Bob', 'Grace');

-- Add one more IT employee with 55000 to make it three
INSERT INTO Employees23 (EmpID, Name, Department, Salary)
VALUES (9, 'Ivy', 'IT', 55000);

-- Add one HR employee with the same salary as Alice (60000)
INSERT INTO Employees23 (EmpID, Name, Department, Salary)
VALUES (10, 'Jack', 'HR', 60000);

select EmpID,Name,Department,Salary ,row_number() over(partition by department order by salary desc) as Rownum from employees23;

select EmpID,Name,Department,Salary ,rank() over(partition by department order by salary desc) as Rownum from employees23;

select EmpID,Name,Department,Salary ,dense_rank() over(partition by department order by salary desc) as Rownum from employees23;



Indexes:
----------
when indexes are applied on the table the data retrival of the table will be fast 
and when ever i am inserting the values in the table it will be inserted by following the index rules 

we have two type of indexes 

--->clustered index 
--->non clustered index 

clustered index is nothing the primay key only once i implement clustered index or primary key whole rows will be sorted as per the index only  it will be sorted 
for a table u can apply at a time only one clustere index or primary 

once it is applied again i cannot becasue everthing is arranged in physical order 

Non clustered  index can be applied more than once to different columns .

In clustered index i wil reach the data directly 

In non clstered index i will reach the leaf node or the link from i can reach the data .

eg: In the book i will have index in the front page and then index at the last page index in the front page means direclty i will reach the data and appnedix which is given on last pages of book i will reach data partially in pages 

create table depmgrdet(did char(3),dname varchar(10),mid char(3))
insert into depmgrdet values('d03','production','e02')
insert into depmgrdet values('d02','marketing',null)
select * from depmgrdet
create nonclustered index ix_depmgrdet on depmgrdet(did)
select * from depmgrdet

--can create another clustred index on another column
create table empmgrdet(ename char(3),dname varchar(10),mid char(3))
create clustered index ix_empmgrdet on empmgrdet(ename) 
insert into empmgrdet values('e05','parag','e02')
insert into empmgrdet values('e04','smith','e05')
select * from empmgrdet
insert into depmgrdet values('d04','advt','e03')
insert into depmgrdet values('d05','sale','e03')
insert into depmgrdet values('d08','advt','e03')
insert into depmgrdet values('d07','sale','e03')
select * from depmgrdet
--can create non clustred index on same column
create nonclustered index ix_empmgrdet1 on empmgrdet(mid)
--can create more than one non clustred index
create nonclustered index ix_empmgrdetname on empmgrdet(dname)
--can create clusterd index if not exist on table if non clustred index exist
create clustered index ix_depmgrdetid on depmgrdet(did)

select * from depdet
create nonclustered index ix_deptncid on depdet(depid)
create clustered index ix_deptcid on depdet(depid)
create clustered index ix_deptcname on depdet(dname)