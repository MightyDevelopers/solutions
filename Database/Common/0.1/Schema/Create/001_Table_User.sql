CREATE TABLE `User`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email NVARCHAR(256) NOT NULL,
    Password NVARCHAR (64) NOT NULL,
    FirstName NVARCHAR(256),
    LastName NVARCHAR(256),
    RegistrationDate DATETIME,
    LastUpdateDate DATETIME
);