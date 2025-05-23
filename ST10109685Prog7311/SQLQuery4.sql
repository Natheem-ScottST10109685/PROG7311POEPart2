﻿CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Role NVARCHAR(20) CHECK (Role IN ('Employee', 'Farmer')) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL
);
