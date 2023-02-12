
--Se personal
create View VwEmployeeInfo
as
select  (Fname +' '+ Lname) Name, Title, DATEDIFF(YYYY,StartDate,'2023-02-10') Years
from Employee

select * from VwEmployeeInfo

--Lägg till personal
Create Proc SpAddEmployee
@Fname nvarchar(50), @Lname nvarchar(50), @Title nvarchar(50), @StartDate date, @Salary int, @DepartmentID int
as
begin
Insert into Employee(Fname,Lname,Title,StartDate,Salary,DepartmentID) Values(@Fname,@Lname,@Title,@StartDate,@Salary,@DepartmentID)
end

exec SpAddEmployee Ola, Fredriksson, Teacher, '2023-02-04', 28000, 2

--Spara ner elever och sätt betyg på kurs
create proc SpInsertStudentAndGrade
@Fname nvarchar(50),
@Lname nvarchar(50),
@SSN int,
@ClassID int,
@CourseID int,
@GradeID int,
@EmployeeID int
as
begin
declare @GradeDate datetime
set @GradeDate = GETDATE()
insert into Student(Fname,Lname,SSN,ClassID) values (@Fname,@Lname,@SSN,@ClassID)
declare @StudentID int
set @StudentID = SCOPE_IDENTITY()
insert into Enrollment (StudentID,CourseID,GradeID,EmployeeID,GradeDate) values(@StudentID,@CourseID,@GradeID,@EmployeeID,@GradeDate)
end

exec SpInsertStudentAndGrade Ulf, Larsson, 19970121, 2, 3, 2, 4


--Kostnad per department
Create proc SpCostofDepartments
as
begin
select Department, SUM(Employee.Salary) 'Department Cost' from Employee
join Department on Employee.DepartmentID = Department.DepartmentID
group by Department.Department
end

exec SpCostofDepartments

--Medellönen per avdelning
create proc SpAverageSalaryofDepartments
as
begin
select Department, AVG(Employee.Salary) 'Average Salary' from Employee
join Department on Employee.DepartmentID = Department.DepartmentID
group by Department.Department
end

exec SpAverageSalaryofDepartments

--Se Specifik student
Create Proc SpStudentIDinfo
@StudentID int
as
begin
select StudentID, (Student.FName + ' ' + Student.LName) Student, SSN, Class from Student
Join Class on Student.ClassID = Class.ClassID
where StudentID = @StudentID
end

exec SpStudentIDinfo 1

--Sätt betyg på elev

begin try
begin transaction 
insert into Enrollment(StudentID,CourseID,GradeID,EmployeeID,GradeDate) values(7,4,2,6,'2023-02-06')
commit transaction
Print 'Transaction Committed'
End try
Begin Catch
Rollback transaction
print 'Transaction Rolled back'
end catch

