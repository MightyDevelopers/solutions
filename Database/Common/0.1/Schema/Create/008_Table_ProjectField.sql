CREATE TABLE `ProjectField`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProjectId INT NOT NULL,
    FieldId INT NOT NULL
);

ALTER TABLE `ProjectField`
ADD CONSTRAINT fk_ProjectField_Project 
FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`);

ALTER TABLE `ProjectField`
ADD CONSTRAINT fk_ProjectField_Field
FOREIGN KEY (`FieldId`) REFERENCES `Field` (`Id`);