-- HemlockLibrarian Library Management Database for SQL Server
-- By Felix An
CREATE DATABASE librarymanagement;
GO

USE librarymanagement;
GO

CREATE TABLE Users (
	UserID bigint NOT NULL PRIMARY KEY,
	UserName nvarchar(200),
	Email nvarchar(200),
	Phone nvarchar(200),
	PIN varchar(20),
	Balance money,
);

CREATE TABLE Branches (
	BranchID bigint NOT NULL PRIMARY KEY,
	BranchName nvarchar(200),
	PhoneNumber varchar(50),
	Address nvarchar(500),
	City nvarchar(200),
	State nvarchar(200),
	PostalCode nvarchar(20),
	Country nvarchar(200)
);

CREATE TABLE Books (
	BookID bigint NOT NULL PRIMARY KEY,
	Title nvarchar(200),
	Author nvarchar(200),
	ISBN varchar(50),
	PublicationYear int,
	DeweyClassification decimal(10, 7),
	BookDescription nvarchar(4000),
);

CREATE TABLE Items (
	ItemID bigint PRIMARY KEY,
	BookID bigint FOREIGN KEY REFERENCES Books(BookID),
	BranchID bigint FOREIGN KEY REFERENCES Branches(BranchID),
	CheckoutStatus tinyint,
	/*
	CheckoutStatus ID Lookup Table:
	0 - In Library
	1 - On Loan
	2 - In Transit
	3 - On Hold Shelf
	4 - Missing
	*/
	CurrentBranchID bigint FOREIGN KEY REFERENCES Branches(BranchID), -- This is the branch that book was last at or currently at, if the book was transferred or returned to another branch for holds or returns.
);

CREATE TABLE Holds (
	HoldID bigint NOT NULL PRIMARY KEY,
	UserID bigint FOREIGN KEY REFERENCES Users(UserID),
	BookID bigint FOREIGN KEY REFERENCES Books(BookID),
	HoldDate datetime
);


CREATE TABLE Transactions (
	TransactionID bigint NOT NULL PRIMARY KEY,
	UserID bigint FOREIGN KEY REFERENCES Users(UserID),
	ItemID bigint FOREIGN KEY REFERENCES Items(ItemID),
	CheckoutDate datetime,
	ReturnDate datetime,
	Fine money
);

-- End of create table batch
GO

-- Functions to generate the next ID for the specified entity
CREATE FUNCTION dbo.GenerateUserID()
RETURNS bigint
AS
BEGIN
    DECLARE @MaxID bigint;
    
    SELECT @MaxID = MAX(UserID) FROM Users;
    
    RETURN ISNULL(@MaxID, 0) + 1;
END
GO

CREATE FUNCTION dbo.GenerateBookID()
RETURNS bigint
AS
BEGIN
    DECLARE @MaxID bigint;
    
    SELECT @MaxID = MAX(BookID) FROM Books;
    
    RETURN ISNULL(@MaxID, 0) + 1;
END
GO

CREATE FUNCTION dbo.GenerateItemID()
RETURNS bigint
AS
BEGIN
    DECLARE @MaxID bigint;
    
    SELECT @MaxID = MAX(ItemID) FROM Items;
    
    RETURN ISNULL(@MaxID, 0) + 1;
END
GO

CREATE FUNCTION dbo.GenerateHoldID()
RETURNS bigint
AS
BEGIN
    DECLARE @MaxID bigint;
    
    SELECT @MaxID = MAX(HoldID) FROM Holds;
    
    RETURN ISNULL(@MaxID, 0) + 1;
END
GO

CREATE FUNCTION dbo.GenerateBranchID()
RETURNS bigint
AS
BEGIN
    DECLARE @MaxID bigint;
    
    SELECT @MaxID = MAX(BranchID) FROM Branches;
    
    RETURN ISNULL(@MaxID, 0) + 1;
END
GO

CREATE FUNCTION dbo.GenerateTransactionID()
RETURNS bigint
AS
BEGIN
    DECLARE @MaxID bigint;
    
    SELECT @MaxID = MAX(TransactionID) FROM Transactions;
    
    RETURN ISNULL(@MaxID, 0) + 1;
END
GO