create proc sp_updt

@empid int,
@empname VarChar(20),
@empsal float

as

update EmployeeTbl set empname=@EmpName,empsal=@EmpSal where empId=@EmpId
