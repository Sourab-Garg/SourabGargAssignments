--Q1

CREATE DATABASE UnivsersityDB;
USE UnivsersityDB;

CREATE SCHEMA Enrollment;

CREATE TABLE Enrollment.Students(StudentID INT PRIMARY KEY IDENTITY(1,1), Fname VARCHAR(20) NOT NULL, Lname VARCHAR(20) NOT NULL, Email VARCHAR(20) UNIQUE, dob DATETIME);

ALTER TABLE Enrollment.Students ADD sex CHAR;
ALTER TABLE Enrollment.Students ADD CONSTRAINT defdob DEFAULT GETDATE() FOR dob;

SELECT * FROM Enrollment.Students;

--Q2

CREATE TABLE Enrollment.Brands(BrandID INT PRIMARY KEY IDENTITY(1,1), BrandName VARCHAR(20) NOT NULL);
CREATE TABLE Enrollment.Products(ProductID INT PRIMARY KEY IDENTITY(1,1), ProductName VARCHAR(30) NOT NULL,BrandID INT FOREIGN KEY REFERENCES Enrollment.Brands(BrandID),Price INT CHECK (Price > 0)); 

--Q3

CREATE TABLE Employees(EmpID INT PRIMARY KEY IDENTITY(1,1), ssn VARCHAR(10) UNIQUE, salary DECIMAL(12,2) DEFAULT 0.00, stauts BIT);
ALTER TABLE Employees DROP COLUMN ssn;
DELETE FROM Employees;
TRUNCATE TABLE Employees;

INSERT INTO Employees(ssn, salary, stauts) VALUES('11234', 22.22, 1),('1123', 2.21,0),('123',1.00, 1);
INSERT INTO Employees(ssn, stauts) VALUES ('111', 1),('222',0); 
SELECT * FROM Employees;

-- Insert Brands
INSERT INTO Enrollment.Brands (BrandName) VALUES ('Apple'),
		('Samsung'), ('Sony'), ('Dell');
INSERT INTO Enrollment.Brands (BrandName) vALUES ('jio');
-- Insert Products 
INSERT INTO Enrollment.Products (ProductName, BrandID, Price) 
VALUES  ('iPhone 15', 1, 800),
		('Galaxy S23', 2, 700), 
		('Bravia TV', 3, 1200), 
		('XPS 13', 4, 1100);

SELECT eb.BrandName, ep.ProductName FROM Enrollment.Products AS ep INNER JOIN Enrollment.Brands as eb on ep.BrandID = eb.BrandID;
SELECT * FROM Enrollment.Products AS ep INNER JOIN Enrollment.Brands as eb on ep.BrandID = eb.BrandID;
SELECT eb.BrandName, ep.ProductName FROM Enrollment.Brands AS eb LEFT JOIN Enrollment.Products AS ep ON eb.BrandID = ep.BrandID;

UPDATE ep SET ep.Price = ep.Price * 0.5 FROM Enrollment.Products AS ep INNER JOIN Enrollment.Brands AS eb ON ep.BrandID = eb.BrandID WHERE eb.BrandName = 'Samsung';
SELECT eb.BrandName, ep.ProductName, ep.Price FROM Enrollment.Products AS ep INNER JOIN Enrollment.Brands as eb on ep.BrandID = eb.BrandID;


-- Insert Students
INSERT INTO Enrollment.Students (Fname, Lname, Email, dob, sex)
VALUES 
('Sourab', 'Garg', 'sourab@uni.edu', '2003-05-10', 'M'),
('Simran', 'Kaur', 'sim@uni.edu', '2004-12-25', 'F'),
('Sahil', 'Sharma', 'sahil@uni.edu', '2006-01-01', 'M'),
('Alice', 'Smith', 'alice@uni.edu', '2004-01-15', 'F'),
('Bob', 'Jones', 'bob@uni.edu', '2002-11-22', 'M');

SELECT Fname, Lname, Email From Enrollment.Students WHERE dob > '2003-01-01' AND Fname LIKE 'S%' ORDER BY Lname ;

DELETE Enrollment.Students WHERE Email = 'bob@uni.edu';
SELECT * FROM Enrollment.Students;

-- Adding a few more products for better aggregate testing
INSERT INTO Enrollment.Products (ProductName, BrandID, Price) 
VALUES ('MacBook Pro', 1, 2500), ('Surface Laptop', 4, 1500), ('Sony Headphones', 3, 300);

-- Adding a few more students
INSERT INTO Enrollment.Students (Fname, Lname, Email, dob, sex)
VALUES ('Rahul', 'Verma', 'rahul@uni.edu', '2002-01-01', 'M'),
       ('Priya', 'Rai', 'priya@uni.edu', '2005-06-15', 'F');

ALTER TABLE Enrollment.Students ADD CONSTRAINT csex CHECK (sex IN ('M','F'));
INSERT INTO Enrollment.Students (Fname, Lname, Email, dob, sex)
VALUES ('Rahul', 'Verma', 'rah22ul@uni.edu', '2002-01-01', 'T');

SELECT eb.BrandID, eb.BrandName, SUM(ep.Price) as totalPrice, AVG(ep.Price) as avgPrice FROM Enrollment.Brands AS eb INNER JOIN Enrollment.Products as ep ON eb.BrandID = ep.BrandID GROUP BY eb.BrandID, eb.BrandName;

SELECT eb.BrandName, ep.Price FROM Enrollment.Products as ep INNER JOIN Enrollment.Brands as eb ON ep.BrandID = eb.BrandID WHERE ep.Price > (SELECT AVG(Price) FROM Enrollment.Products);
SELECT eb.BrandName, ep.ProductName, ep.Price FROM Enrollment.Brands as eb inner join Enrollment.Products as ep on eb.BrandID = ep.BrandID Where ep.price = (SELECT MIN(Price) from Enrollment.Products);

SELECT COUNT(*) FROM Enrollment.Students WHERE sex = 'F' AND dob > ('2003-01-01'); dents;