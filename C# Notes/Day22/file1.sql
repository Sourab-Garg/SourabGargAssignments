create procedure printdata 
as 
begin 
declare @x varchar(30)
set @x='india is doing well'
print @x;
end 

exec printdata

-- if  u want to modify the above procedure 

alter procedure printdata 
as 
begin 
declare @x varchar(30)
set @x='india is doing well'
print 'hello world'
print @x;
end 

-- u can check using object explorerr in programability section 
-- default name space is dbo means database owner 
-- if u dont give namesapce in db it gets stored in dbo

create procedure getSum (@a int, @b int)
as begin
declare @sum int = @a + @b;
return @sum;
end;

create procedure getSum1 (@a int, @b int, @sum int output)
as begin
set @sum = @a + @b;
return @sum;
end;

declare @result int;
exec @result =  getSum 10,11;
print 'The sum is ' + Convert(varchar(30), @result);


declare @result1 int;
exec getSum1 11,11, @result1 output;
print 'The sum2 is ' + Convert(varchar(30), @result1);

DECLARE @Status INT;
DECLARE @TheSum INT;

EXEC @Status = getSum1 11, 11, @TheSum OUTPUT;

PRINT 'Procedure Status: ' + CAST(@Status AS VARCHAR(10));
PRINT 'The actual sum:   ' + CAST(@TheSum AS VARCHAR(10));

CREATE PROCEDURE getSum2
    @num1 INT,
    @num2 INT,
    @sum INT OUTPUT 
AS
BEGIN
    IF @num1 IS NULL OR @num2 IS NULL
    BEGIN
        RETURN 1; 
    END

    SET @sum = @num1 + @num2;

    RETURN 0;  
END

DECLARE @Status2 INT;
DECLARE @CalculatedSum INT;

EXEC @Status2 = getSum2 11, 11, @CalculatedSum OUTPUT;

IF @Status2 = 0
    BEGIN
        PRINT 'SUCCESS!';
        PRINT 'The sum is: ' + CAST(@CalculatedSum AS VARCHAR(10));
    END
ELSE
    BEGIN
       PRINT 'ERROR: The procedure failed with status ' + CAST(@Status2 AS VARCHAR(10));
    END


create procedure calculator (@num1 int ,@num2 int,@addresult int output ,@substractresult
int output)
as
begin 
set @addresult=@num1 + @num2;
set @substractresult=@num1-@num2;
select @addresult;
select @substractresult;
end 

declare @sum int ;
declare @diff int;
exec calculator 100,34,@sum output,@diff output 
print 'The sum is '+Convert(varchar(20),@sum)
print 'The diff is '+Convert(varchar(20),@diff)

create procedure calculator1 (@num1 int ,@num2 int,@addresult int output ,@substractresult
int output)
as
begin 
set @addresult=@num1 + @num2;
set @substractresult=@num1-@num2;
end 

declare @sum1 int ;
declare @diff1 int;
exec calculator1 100,34,@sum1 output,@diff1 output 
print 'The sum is '+Convert(varchar(20),@sum1)
print 'The diff is '+Convert(varchar(20),@diff1)

-- write a sp for finding x to the power of y 
create procedure findPower(@x int, @y int )
as
begin
declare @result int;
set @result = power(@x,@y);
print @result;
end

exec findpower 12,3


 create table studentdata(studid int primary key ,studname varchar(50))
-- sp for insert 
create proc insertstud (@studid1 int ,@studname1 varchar(50))
as
begin 
insert into studentdata values(@studid1,@studname1);
end 

exec insertstud 102,'suresh'

select * from studentdata 

-- sp for udpate 
create proc updatestud (@studid1 int ,@studname1 varchar(50))
as
begin 
update  studentdata set studname=@studname1 where studid=@studid1;
end 

exec updatestud 102,'kiran'

select * from studentdata 

-- sp for delete
create proc deletestud (@studid1 int)
as
begin 
delete  studentdata  where studid=@studid1;
end 

exec deletestud 102

select * from studentdata 


-- sp for select 

create proc selectstud(@studid1 int)
as
begin 
select * from studentdata where studid=@studid1
end

exec selectstud 101


 --write a proc to display only  name of student only 

alter  proc selectstud(@studid1 int)
as
begin
declare @name1 varchar(40);
select @name1=studname from studentdata where studid=@studid1;
print @name1;
end

exec selectstud 101