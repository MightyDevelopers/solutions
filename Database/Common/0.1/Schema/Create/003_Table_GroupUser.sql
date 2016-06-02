CREATE TABLE `GroupUser`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    GroupId INT NOT NULL,
    UserId INT NOT NULL
);

ALTER TABLE `GroupUser`
ADD CONSTRAINT fk_GroupUser_Group 
FOREIGN KEY (`GroupId`) REFERENCES `Group` (`Id`);

ALTER TABLE `GroupUser`
ADD CONSTRAINT fk_GroupUser_User 
FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`);