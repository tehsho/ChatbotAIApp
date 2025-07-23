-- Create the database
CREATE DATABASE ChatbotAI;
GO

-- Use the new database
USE ChatbotAI;
GO

-- Create Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(255),
    PasswordHash NVARCHAR(255) NOT NULL,  -- Store hashed password (e.g., bcrypt)
    Role NVARCHAR(50) DEFAULT 'User',     -- Role can be 'User', 'Admin', etc.
    IsActive BIT DEFAULT 1,               -- Used to deactivate accounts
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Create Messages table
CREATE TABLE Messages (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    MessageText NVARCHAR(MAX) NOT NULL,
    ResponseText NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO
