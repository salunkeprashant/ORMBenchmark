create table Users(
 UserID integer identity(1,1) not null primary key,
 JoiningDate date
 );
 
 CREATE TABLE Admins(
 AdminID INTEGER identity(1,1) NOT NULL PRIMARY KEY,
 AdminName varchar(15),
 Username nvarchar(30),
 Password nvarchar(12)
 );
 
 create table UserDetails(
 ID integer identity(1,1) not null primary key,
 UserID integer,
 FirstName varchar(15),
 LastName varchar(15),
 foreign key (UserID) references Users(UserID)
 on delete cascade
 on update cascade
);

create table ContactDetails(
 ID integer identity(1,1) not null primary key,
 UserID integer,
 MobileNo bigint,
 EmailAddress nvarchar(30),
 foreign key(UserID) references Users(UserID)
 on delete cascade
 on update cascade
 );
 
create table Address(
 AddressID integer identity(1,1) not null primary key,
 UserID integer,
 AddressLine nvarchar(200),
 CityName nvarchar(20),
 StateName nvarchar(20),
 foreign key(UserID) references Users(UserID)
 on delete cascade
 on update cascade
 );

CREATE TABLE BookCategory ( 
	CategoryID integer identity(1,1) PRIMARY KEY not null,
    CategoryName varchar(50)
);
 
create table Authors(
 AuthorID integer identity(1,1) not null primary key,
 AuthorName varchar(30),
 BookPublished nchar(3)
);
 
CREATE TABLE Books ( 
BookID integer identity(1,1) not null primary key, 
BookName varchar(300),
CategoryID integer,
AuthorID integer,
Pages nchar(5),
YearOfPublish nchar(4),
Ratings decimal(2,1), 
Quantity nchar(3),
foreign key (CategoryID) references BookCategory(CategoryID),
foreign key (AuthorID) references Authors(AuthorID)
);

CREATE TABLE ItemCategory ( 
 CategoryID integer identity(1,1) PRIMARY KEY not null,
 CategoryName varchar(50)
);

create table Inventory(
ItemID integer identity(1,1) primary key,
CategoryID integer,
ItemName nvarchar(30),
ItemDescription varchar(300),
Quantity nchar(3),
foreign key (CategoryID) references ItemCategory(CategoryID)
 );
 
create table BookTransaction(
TransactionID integer identity(1,1) primary key,
AdminID integer,
UserID integer,
BookID integer,
IssueDate date,
ReturnDate date,
foreign key(AdminID) references Admins(AdminID),
foreign key(UserID) references Users(UserID),
foreign key(BookID) references Books(BookID)

);

create table ItemTransaction(
TransactionID integer identity(1,1) primary key,
AdminID integer,
UserID integer,
ItemID integer,
IssueDate date,
ReturnDate date,
foreign key(AdminID) references Admins(AdminID),
foreign key(UserID) references Users(UserID),
foreign key(ItemID) references Inventory(ItemID)
);

CREATE INDEX IX_Author ON Authors(AuthorName)

CREATE INDEX IX_Book ON Books(BookID) include (Ratings)

CREATE INDEX IX_Item ON Inventory(ItemName)

CREATE INDEX IX_BookTxn on BookTransaction(UserID,BookID) include (IssueDate)

CREATE INDEX IX_ItemTxn on ItemTransaction(UserID,ItemID) include (IssueDate)
