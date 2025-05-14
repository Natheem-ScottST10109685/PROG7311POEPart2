CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    Price DECIMAL(10, 2),
    FarmerEmail NVARCHAR(100),
    FOREIGN KEY (FarmerEmail) REFERENCES Users(Email)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

