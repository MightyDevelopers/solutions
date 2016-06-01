CREATE TABLE `Problem`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name NVARCHAR(256) NOT NULL,
    Description NVARCHAR(2056) NOT NULL,
    AuthorId INT NOT NULL,
    ProblemTypeId INT NOT NULL,
    CreatedDateTime DATETIME NOT NULL,
    UpdatedDateTime DATETIME
);

ALTER TABLE `Problem`
ADD CONSTRAINT fk_Problem_ProblemType
FOREIGN KEY (`ProblemTypeId`) REFERENCES `ProblemType` (`Id`);

ALTER TABLE `Problem`
ADD CONSTRAINT fk_Problem_User
FOREIGN KEY (`AuthorId`) REFERENCES `User` (`Id`);