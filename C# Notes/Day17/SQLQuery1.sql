-- CREATE DATABASE CG;

-- USE CG;
-- CREATE TABLE student(studid INT PRIMARY KEY, studname VARCHAR(30), lov VARCHAR(50))
-- INSERT INTO student VALUES(101, 'Ram', 'Delhi');

--INSERT INTO student (lov, studid, studname)VALUES('Goa', 102, 'Sham')
--INSERT INTO student (studid, studname) VALUES(102, 'Damn')
--INSERT INTO student values(104, 'Kiran', 'HP'), (105, 'Simran', 'UP')

--UPDATE student SET studname = 'Rahul' WHERE studid = 102;
--UPDATE student SET lov = 'MP' WHERE studid = 102;

--UPDATE student SET studname = 'john', lov = 'Punjab' WHERE studid = 105;

--UPDATE student SET lov = 'Punjab' WHERE studid IN(102,103,104);

--DELETE FROM student WHERE studid = 105;
--DELETE FROM student WHERE studid IN(102,105);
--DELETE FROM student;
--TRUNCATE TABLE student;

--SELECT * FROM student

----------------------------------------

--CREATE TABLE empinfo(empid INT IDENTITY(1,1) PRIMARY KEY, empname VARCHAR(40))
--USE CG;
--INSERT INTO empinfo VALUES ('Ravi')
--INSERT INTO empinfo VALUES ('Ram'), ('Sham')
--DELETE empinfo
--INSERT INTO empinfo VALUES('GG')

--TRUNCATE TABLE empinfo
--INSERT INTO empinfo VALUES('GG')

--SELECT * FROM empinfo;

---------------------------------------

--CREATE TABLE demo1 (id  INT NOT NULL, fname VARCHAR(30), 
--					mname VARCHAR(30) NULL, lname VARCHAR(30))

TRUNCATE TABLE demo1;

INSERT INTO demo1 VALUES(101, NULL, NULL, NULL)
INSERT INTO demo1 VALUES(102, 'Ram', NULL, NULL)
INSERT INTO demo1 VALUES(103, 'Ram', 'Mohan', 'Das')

SELECT * FROM demo1;

create table demo2(id int unique,fname varchar(30) not null,mname varchar(30) null,lname
varchar(40),constraint uk1 unique(mname,lname))

-----------------------------------------

insert into demo2 values(101,'kiran',null,'kumar');--fine
insert into demo2 values(102,'kiran',null,'das')--fine
--insert into demo2 values(102,'kiran',null,'das')--error
insert into demo2 values (103,'kiran',null,'kishore')--fine
insert into demo2 values (null,'kiran',null,'kishore1')--fine
--insert into demo2 values (null,'kiran',null,'kishore2') --error

select * from demo2;

-----------------------------

create table demo3(id int primary key,fname varchar(30) not null,
mname varchar(30) null,lname varchar(40));
insert into demo3 values(101,'kiran',null,null);
insert into demo3 values(101,'kiran',null,null);--error
insert into demo3 values(null,'kiran',null,null);--error
SELECT * FROM demo3

------------------------------------------------

-- table level
create table demo4(id int ,fname varchar(40) not null,
mname varchar(30),lname varchar(40),
constraint pk1 primary key(id))

insert into demo4 values(101,'kiran',null,null);
insert into demo4 values(101,'kiran',null,null);--error
insert into demo4 values(null,'kiran',null,null);--error
SELECT * FROM demo4

----------------------------------------------

--creating a composite primary key 
create table demo5(id int ,fname varchar(40) not null,mname varchar(40) ,lname varchar(40)
constraint pk44 primary key(id,fname));

insert into demo5 values(101,'kiran',null,null);--fine

insert into demo5 values(101,'mahesh',null,null);--fine

insert into demo5 values(102,'mahesh',null,null);--fine

-- like this is wrong 

-- below code is wrong one time only u can do primary key 
-- 
--create table demo6(id int primary key,fname varchar(40) not null,
--mname varchar(30),lname varchar(40),
--constraint pk2 primary key(id,fname));

--4)check constraint --values are checked based on condition 

create table bankdemo(bankid int primary key ,bankname varchar(40),balance int check(balance>2000));
--same written as table level 

create table bankdemo2(bankid int primary key ,bankname varchar(40),balance int,constraint bkchk 
check(balance>2000));

insert into bankdemo values (101,'BOI',300); -- will get erroro as 300 is less than 2000
insert into bankdemo2 values (101,'BOI',100) -- here also eror as more than 2000 only u need to enter 

insert into bankdemo2 values(102,'BOB',2001);-- okay will run 

--5 Default constraint 

--Default constraint : here if u forget 
--any column system will put null to that column 
--but i want my default value there so 
-- default constraint is used 

create table employee(empid int primary key ,
empname varchar(30) default 'Mr.X',salary int);

insert into employee(empid,salary) values(101,23000);

select * from employee;