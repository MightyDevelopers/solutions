CREATE TABLE `Project`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name NVARCHAR(256) NOT NULL,
    Description NVARCHAR(2056) NOT NULL,
    GroupId INT NOT NULL,
    CreatorId INT NOT NULL
);

ALTER TABLE `Project`
ADD CONSTRAINT fk_Project_Group 
FOREIGN KEY (`GroupId`) REFERENCES `Group` (`Id`);

ALTER TABLE `Project`
ADD CONSTRAINT fk_Project_User 
FOREIGN KEY (`CreatorId`) REFERENCES `User` (`Id`);