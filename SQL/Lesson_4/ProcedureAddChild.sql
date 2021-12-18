USE PioneerCamp;
GO

CREATE TABLE Children
(
	ChildID int IDENTITY NOT NULL PRIMARY KEY,
	FName nvarchar(max) NOT NULL,
	MName nvarchar(max) NOT NULL,
	LName nvarchar(max) NOT NULL,
	[Address] nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	BirthDate date NOT NULL
)
GO

CREATE PROC AddChild
(
	@FName nvarchar(max),
	@MName nvarchar(max),
	@LName nvarchar(max),
	@Address nvarchar(max),
	@City nvarchar(max),
	@BirthDate date
)
AS
BEGIN
	INSERT INTO Children(FName, MName, LName, [Address], City, BirthDate)
	VALUES (@FName, @MName, @LName, @Address, @City, @BirthDate)
END;
BEGIN
	SELECT *
	FROM Children
END;

EXEC AddChild 'Petr', 'Ivanenko', 'Ivanov', 'Baseinaia 1F', 'Kyiv', '10/10/2000'