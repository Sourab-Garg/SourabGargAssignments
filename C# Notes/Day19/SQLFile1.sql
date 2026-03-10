USE CG;

CREATE TABLE dept (deptid INT PRIMARY KEY, deptname VARCHAR(40));
INSERT INTO dept VALUES(10, 'HR');
INSERT INTO dept VALUES(20, 'Sales'),(30, 'Dev');
SELECT * FROM dept;


CREATE TABLE emp (empid INT PRIMARY KEY, empname VARCHAR(40), worksin INT FOREIGN KEY REFERENCES dept(deptid));
INSERT INTO emp VALUES(101, 'Ravi', 10),(102, 'Sita', 10),(103, 'Rita', 20),(104, 'Ram', null);
INSERT INTO emp VALUES(105, 'Sunita', 69); --Error as 69(depid) is not present in main table(dept).
SELECT * FROM emp;


CREATE TABLE emp1 (empid INT PRIMARY KEY, empname VARCHAR(40), worksin INT, CONSTRAINT fkey FOREIGN KEY(worksin) REFERENCES dept(deptid));
INSERT INTO emp1 VALUES(101, 'Ravi', 10),(102, 'Sita', 10),(103, 'Rita', 20),(104, 'Ram', null);
SELECT * FROM emp1;


CREATE TABLE doc (docid INT PRIMARY KEY, docname VARCHAR(40));
CREATE TABLE pai (paiid INT PRIMARY KEY, painame VARCHAR(40), docid INT FOREIGN KEY REFERENCES doc(docid));
CREATE TABLE tre (treid INT PRIMARY KEY, trename VARCHAR(40), docid INT , paiid INT, CONSTRAINT fkey1 FOREIGN KEY(docid) REFERENCES doc(docid),
				  CONSTRAINT fkey2 FOREIGN KEY(paiid) REFERENCES pai(paiid));
INSERT INTO doc VALUES (10, 'Sye'),(11, 'Ravi'),(12, 'Sita'),(13, 'Rita');
INSERT INTO pai VALUES (100, 'Rahul', 10),(101, 'Sham',12),(103, 'Mangal', 13);
INSERT INTO tre VALUES (1000, 'Cancer', 10, 100),(1001, 'Tumor', 12, 101),(1002, 'Cold', 13, 103);
INSERT INTO tre VALUES (1003, 'AIDS' , 13, 101);
SELECT * FROM doc;
SELECT * FROM pai;
SELECT * FROM tre;


create table empdetails(empid int primary key, empname varchar(30), empsal int);
insert into empdetails values(101,'ravi',34000)
insert into empdetails values(102,'sohan',30000);
insert into empdetails values(103,'sita',38000);
select sum(empsal) as "totalsal", max(empsal) as "maxsal",min(empsal) as "minsal",avg(empsal) as "average", count(*) as "totalemps" from empdetails;


create table ids(id int)
insert into ids values(1),(2),(1),(1),(1),(2),(3)
SELECT * FROM ids;
SELECT id, COUNT(id) AS freq FROM ids GROUP BY id;


create table dept1(
  deptno int ,
  dname  varchar(14),
  loc    varchar(13),
  constraint pkk1 primary key(deptno)
);
 
 create table empl(
  empno    int primary key,
  ename    varchar(10),
  job      varchar(9),
  mgr      int,
  hiredate date,
  sal      int,
  comm     int,
  deptno   int  foreign key  references dept1 (deptno)
);

insert into dept1 values(10, 'ACCOUNTING', 'NEW YORK');
insert into dept1 values(20, 'RESEARCH', 'DALLAS');
insert into dept1
values(30, 'SALES', 'CHICAGO');
insert into dept1
values(40, 'OPERATIONS', 'BOSTON'); 

select * from dept1;

insert into empl values( 7839, 'KING', 'PRESIDENT', null,'1981-11-17' , 5000, null, 10);
insert into empl values( 7698, 'BLAKE', 'MANAGER', 7839,'1981-05-01',2850, null, 30);
insert into empl values( 7782, 'CLARK', 'MANAGER', 7839,'1981-06-09', 2450, null, 10);
insert into empl values( 7566, 'JONES', 'MANAGER', 7839,'1981-04-02', 2975, null, 20);
insert into empl values( 7788, 'SCOTT', 'ANALYST', 7566,'1987-04-19', 3000, null, 20);
insert into empl values( 7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, null, 20);
insert into empl values( 7369, 'SMITH', 'CLERK', 7902,'1980-12-17', 800, null, 20);
insert into empl values( 7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30);
insert into empl values(  7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30);
insert into empl values( 7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30);
insert into empl values(  7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30);
insert into empl values( 7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, null, 20);
insert into empl values( 7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, null, 30);
insert into empl values( 7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, null, 10);

select * from dept1;
select * from empl;

SELECT deptno, COUNT(deptno) AS freq, MAX(sal) AS "max sal", MIN(sal) AS minsal FROM empl GROUP BY deptno;
select job,sum(sal) as "totalsal" from empl group by job having sum(sal) > 5000;


create table dept3(deptid int primary key ,deptname varchar(30));
insert into dept3 values(10,'sales'),(20,'Marketing'),(30,'Software'),(40,'HR');

create table emp3(empid int primary key ,empname varchar(30),worksin int foreign key references dept3(deptid));
insert into emp3 values(101,'ravi',10),(102,'kiran',20),(103,'mahesh',30),(104,'suresh',20),(105,'satish',null);

select * from dept3;
select * from emp3;

SELECT e1.empname, d1.deptname FROM emp3 AS e1 INNER JOIN dept3 AS d1 ON e1.worksin = d1.deptid;
SELECT e1.empname, d1.deptname FROM emp3 AS e1 LEFT JOIN dept3 AS d1 ON e1.worksin = d1.deptid;
SELECT e1.empname, d1.deptname FROM emp3 AS e1 LEFT JOIN dept3 AS d1 ON e1.worksin = d1.deptid WHERE d1.deptname IS NULL;
SELECT e1.empname, d1.deptname FROM dept3 AS d1 RIGHT JOIN emp3 AS e1 ON e1.worksin = d1.deptid WHERE d1.deptname IS NULL;

SELECT d1.deptname, e1.empname FROM dept3 AS d1 LEFT JOIN emp3 AS e1 ON e1.worksin = d1.deptid;
SELECT d1.deptname, e1.empname FROM dept3 AS d1 LEFT JOIN emp3 as e1 ON e1.worksin = d1.deptid WHERE e1.empname IS NULL;


create table Location1(locid int primary key, locname varchar(30),empid int references emp3(empid));

insert into location1 values (1001,'delhi',102),(1002,'bangalore',103),(1003,'pune',104),(1004,'chennai',105);

select * from dept3;
select * from emp3;
select * from location1;

select e1.empname, d1.deptname,l1.locname from emp3 as e1 inner join dept3 as d1 on e1.worksin = d1.deptid inner join location1 as l1 on e1.empid = l1.empid;
select e1.empname from emp3 e1 inner join dept3 d1 on e1.worksin=d1.deptid inner join location1 l1 on e1.empid=l1.empid;

-- give me all the employees who got dept but not location 
--version 1
select e1.empname,d1.deptname,l1.locname from emp3 e1 inner join dept3 d1 on
e1.worksin=d1.deptid left join location l1 on e1.empid=l1.empid;

--version 2 
select e1.empname,d1.deptname,l1.locname from emp3 e1 inner join dept3 d1 on
e1.worksin=d1.deptid left join location l1 on e1.empid=l1.empid where l1.locname is null;

--version 3 

select e1.empname from emp3 e1 inner join dept3 d1 on
e1.worksin=d1.deptid left join location l1 on e1.empid=l1.empid where l1.locname is null;

-- give me all the employees who has not got dept but got location 
---version 1
select e1.empname,d1.deptname,l1.locname from emp3 e1 left join dept3 d1 on
e1.worksin=d1.deptid inner join location l1 on e1.empid=l1.empid;

--version 2 
select e1.empname,d1.deptname,l1.locname from emp3 e1 left join dept3 d1 on
e1.worksin=d1.deptid inner join location l1 on e1.empid=l1.empid where d1.deptname is null;

-- version 3 
select e1.empname from emp3 e1 left join dept3 d1 on
e1.worksin=d1.deptid inner join location l1 on e1.empid=l1.empid where d1.deptname is null;