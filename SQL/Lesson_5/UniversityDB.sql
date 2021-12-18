CREATE DATABASE UniversityDB ON
(
	NAME = 'UniversityDB',			
	FILENAME = 'E:\UniversityDB.mdf'
	)
log on						  
	( 
	NAME = 'LogUniversityDB',				
	FILENAME = 'E:\UniversityDB.ldf'
	)
COLLATE Cyrillic_General_CI_AS
GO

USE UniversityDB;

USE master;

DROP DATABASE UniversityDB;

CREATE TABLE Students
(
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	NumberReportCard int IDENTITY NOT NULL PRIMARY KEY,
	NumberGroup int FOREIGN KEY REFERENCES [Groups](NumberGroup),
	Gpa smallint NOT NULL
)
GO

CREATE TABLE StudentPersonalInfo
(
	NumberReportCard int UNIQUE FOREIGN KEY REFERENCES Students(NumberReportCard),
	[Address] nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	Phone char(12) NOT NULL CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	BirthDate date NOT NULL
)
GO

CREATE TABLE Teachers
(
	TeacherID int IDENTITY NOT NULL PRIMARY KEY,
	ChairID int FOREIGN KEY REFERENCES Chairs(ChairID),
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	AcademicPosition nvarchar(max) NOT NULL,
	Specialization nvarchar(max) NOT NULL
)
GO

CREATE TABLE TeacherPersonalInfo
(
	TeacherID int UNIQUE FOREIGN KEY REFERENCES Teachers(TeacherID),
	[Address] nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	Phone char(12) NOT NULL CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	BirthDate date NOT NULL,
	MaritalStatus nvarchar(10) NOT NULL, CHECK (MaritalStatus in ('Женат', 'Не женат', 'Замужем', 'Не замужем'))
)
GO

CREATE TABLE Faculties
(
	FacultyID int IDENTITY NOT NULL PRIMARY KEY,
	[Name] nvarchar(max) NOT NULL
)
GO

CREATE TABLE Chairs --кафедры
(
	ChairID int IDENTITY NOT NULL PRIMARY KEY,
	FacultyID int FOREIGN KEY REFERENCES Faculties(FacultyID),
	[Name] nvarchar(max) NOT NULL,
)
GO

CREATE TABLE [Groups]
(
	NumberGroup int IDENTITY NOT NULL PRIMARY KEY,
	ChairID int FOREIGN KEY REFERENCES Chairs(ChairID)
)
GO

CREATE TABLE GroupsTeachersDisciplines
(
	NumberGroup int FOREIGN KEY REFERENCES [Groups](NumberGroup),
	TeacherID int FOREIGN KEY REFERENCES Teachers(TeacherID),
	DisciplineID int FOREIGN KEY REFERENCES Disciplines(DisciplineID),
	PRIMARY KEY (NumberGroup, TeacherID, DisciplineID)
)
GO

CREATE TABLE Disciplines
(
	DisciplineID int IDENTITY NOT NULL PRIMARY KEY,
	ChairID int FOREIGN KEY REFERENCES Chairs(ChairID),
	TeacherID int FOREIGN KEY REFERENCES Teachers(TeacherID),
	[Name] nvarchar(max) NOT NULL,
	[Hours] smallint NOT NULL
)
GO