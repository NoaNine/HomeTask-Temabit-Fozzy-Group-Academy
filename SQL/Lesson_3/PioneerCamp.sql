
CREATE DATABASE PioneerCamp ON
(
	NAME = 'PioneerCampDB',			
	FILENAME = 'E:\PioneerCampDB.mdf'
	)
log on						  
	( 
	NAME = 'LogPioneerCampDB',				
	FILENAME = 'E:\PioneerCampDB.ldf'
	)
COLLATE Cyrillic_General_CI_AS
GO

DROP DATABASE PioneerCamp
GO

USE MASTER
USE PioneerCamp

CREATE TABLE Children
(
	ChildID int IDENTITY NOT NULL PRIMARY KEY,
	DetachmentId int FOREIGN KEY REFERENCES Detachments(DetachmentId) ON DELETE CASCADE,
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	
)
GO

CREATE TABLE ChildrenInfo
(
	ChildID int UNIQUE FOREIGN KEY REFERENCES Children(ChildID) ON DELETE CASCADE,
	[Address] nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	BirthDate date NOT NULL
)
GO

CREATE TABLE Scoutmasters --вожатые
(
	ScoutmasterID int IDENTITY NOT NULL PRIMARY KEY,
	DetachmentId int FOREIGN KEY REFERENCES Detachments(DetachmentId) ON DELETE CASCADE,
	Сallsign nvarchar(max) NOT NULL, --позывной
	Gender nvarchar(max) NOT NULL
)
GO

CREATE TABLE ScoutmasterInfo
(
	ScoutmasterID int UNIQUE FOREIGN KEY REFERENCES Scoutmasters(ScoutmasterID) ON DELETE CASCADE,
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	[Address] nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	BirthDate datetime NOT NULL
)
GO

CREATE TABLE Detachments --отряды
(
	DetachmentId int IDENTITY NOT NULL PRIMARY KEY,
	AwardId int UNIQUE FOREIGN KEY REFERENCES Awards(AwardId) ON DELETE CASCADE,
	[Name] nvarchar(max) NOT NULL,
	Slogan nvarchar(max) NOT NULL
)
GO

CREATE TABLE DetachmentEvent
(
	DetachmentId int FOREIGN KEY REFERENCES Detachments(DetachmentId) ON DELETE CASCADE,
	EventId int FOREIGN KEY REFERENCES EventsPioneerCamp(EventId) ON DELETE CASCADE,
	PRIMARY KEY(DetachmentId, EventId)
)
GO

CREATE TABLE Awards 
(
	AwardId int IDENTITY NOT NULL PRIMARY KEY,
	[Name] nvarchar(max) NOT NULL,
	Medal nvarchar(max) NOT NULL CHECK (Medal in ('Золото', 'Серебро', 'Бронза')),
	Trophy nvarchar(max) NOT NULL
)
GO

CREATE TABLE EventsPioneerCamp
(
	EventId int IDENTITY NOT NULL PRIMARY KEY,
	AwardId int UNIQUE FOREIGN KEY REFERENCES Awards(AwardId) ON DELETE CASCADE,
	[Name] nvarchar(max) NOT NULL,
	StartDate datetime NOT NULL
)
GO

CREATE TABLE EventHistory
(
	EventId int NOT NULL UNIQUE FOREIGN KEY REFERENCES EventsPioneerCamp(EventId) ON DELETE CASCADE,
	AmountChildren int NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	EventDate datetime NOT NULL
)
GO