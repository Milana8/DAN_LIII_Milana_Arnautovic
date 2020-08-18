CREATE DATABASE DAN_LIII
 IF DB_ID('DAN_LIII') IS NULL
CREATE DATABASE DAN_LIII;
GO
USE DAN_LIII;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblUsers')
drop table tblUsers;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployees')
drop table tblEmployees;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManagers')
drop table tblManagers;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAbsence')
drop table tblAbsence;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwEmployees')
drop view vwEmployees;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwManagers')
drop view vwManagers;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwAbsence')
drop view vwAbsence;


Create table tblUsers(
 UserID int identity(1,1) Primary key,
 NameSurname nvarchar (50) not null,
 Email varchar(50) UNIQUE,
 DateOfBirth date not null,
 Username varchar(50) UNIQUE NOT NULL,
 Pasword varchar(50)  NOT NULL,

);


Create table tblEmployees(
 EmployeeID int IDENTITY(1,1) Primary key not null, --Primary key
 HotelFloor int not null,
 Gender char (1) not null,
 Citizenship varchar (50) not null,
 Engagment varchar(50) NOT NULL,
 Salary INT not null,	
 UserID int,	
 
 
);

CREATE TABLE tblManagers(
	ManagerID INT PRIMARY KEY IDENTITY(1,1),
	HotelFloor int NOT NULL,
	Exprience int NOT NULL,
	Qualifications varchar(3) not null,
	UserID int,
);
CREATE TABLE tblAbsence(
	AbsenceID INT PRIMARY KEY IDENTITY(1,1),
	FirstDay date NOT NULL,
	LastDay date NOT NULL,
	Reason varchar(100) not null,
	StatusRequest varchar (50) not null,
	UserID int,
);
ALTER TABLE tblEmployees
ADD FOREIGN KEY (UserID) REFERENCES tblUsers(UserID);


ALTER TABLE tblManagers
ADD FOREIGN KEY (UserID) REFERENCES tblUsers(UserID);

ALTER TABLE tblAbsence
ADD FOREIGN KEY (UserID) REFERENCES tblUsers(UserID);


GO
CREATE VIEW vwEmployees AS
	SELECT	tblUsers.*, 
			tblEmployees.HotelFloor, tblEmployees.Gender, tblEmployees.Citizenship, 
			tblEmployees.Engagment, tblEmployees.Salary, tblEmployees.EmployeeID
	FROM	tblUsers, tblEmployees
	WHERE	tblUsers.UserID = tblEmployees.UserID

GO
CREATE VIEW vwManagers AS
	SELECT	tblUsers.*, 
			tblManagers.HotelFloor, tblManagers.Exprience, tblManagers.Qualifications, tblManagers.ManagerID
	FROM	tblUsers, tblManagers 
	WHERE	tblUsers.UserID = tblManagers.UserID



GO
CREATE VIEW vwAbsence AS
SELECT a.* , u.NameSurname + ' ' + u.Username 'Employee', e.HotelFloor
FROM tblAbsence a
INNER JOIN tblUsers u
ON u.UserID = a.UserID
INNER JOIN tblEmployees e
ON e.UserID = u.UserID;



