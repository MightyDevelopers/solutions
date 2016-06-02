CREATE TABLE `Article`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name NVARCHAR(256) NOT NULL,
    ProblemId INT NOT NULL,
    AuthorId INT NOT NULL,
    Solution MEDIUMTEXT NOT NULL,
    CreatedDateTime DATETIME NOT NULL
);

ALTER TABLE `Article`
ADD CONSTRAINT fk_Article_Problem
FOREIGN KEY (`ProblemId`) REFERENCES `Problem` (`Id`);

ALTER TABLE `Article`
ADD CONSTRAINT fk_Article_User
FOREIGN KEY (`AuthorId`) REFERENCES `User` (`Id`);