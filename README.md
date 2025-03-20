# BooksManager Project
Project Overview
The BooksManager application is a database-driven system designed to manage and query book information. This README provides an outline of the database schema, data insertion, stored procedures, and folder structure.

Database Schema
Table Creation
sql
CREATE TABLE mstBook (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    AuthorFirstName NVARCHAR(100) NOT NULL,
    AuthorLastName NVARCHAR(100) NOT NULL,
    Publisher NVARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

Insert Data
sql
INSERT INTO mstBook (Title, AuthorFirstName, AuthorLastName, Publisher, YearPublished, Price)
VALUES 
('The Pragmatic Programmer', 'Andrew', 'Hunt', 'Addison-Wesley', 1999, 45.99),
('Clean Code', 'Robert', 'Martin', 'Prentice Hall', 2008, 39.99),
('Design Patterns', 'Erich', 'Gamma', 'Addison-Wesley', 1994, 49.99);
Stored Procedures
Get All Sorted List of Books
This procedure retrieves all books sorted by Publisher, Author's Last Name, First Name, and Title:

sql
CREATE PROCEDURE getAllSortListBooks
AS
BEGIN
    SELECT * FROM mstBook ORDER BY Publisher, AuthorLastName, AuthorFirstName, Title;
END
Get All Sorted List of Books by Author and Title
This procedure retrieves all books sorted by Author's Last Name, First Name, and Title:

sql
CREATE PROCEDURE getAllSortListBooksWithAuthorAndTitle
AS
BEGIN
    SELECT * FROM mstBook ORDER BY AuthorLastName, AuthorFirstName, Title;
END
Folder Structure
Below is the tree view of the BooksManager project folder structure:

BooksManager/
├── Connected Services/
├── Dependencies/
├── Properties/
│   └── launchSettings.json
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
├── Controllers/
├── Helpers/
├── Interfaces/
├── Models/
├── Repositories/
├── Views/
│   ├── Shared/
│   ├── Home/
│   └── Errors/
└── README.md
