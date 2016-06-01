CREATE TABLE `ProjectTechnology`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProjectId INT NOT NULL,
    TechnologyId INT NOT NULL
);

ALTER TABLE `ProjectTechnology`
ADD CONSTRAINT fk_ProjectTechnology_Project 
FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`);

ALTER TABLE `ProjectTechnology`
ADD CONSTRAINT fk_ProjectTechnology_TechnologyId 
FOREIGN KEY (`TechnologyId`) REFERENCES `Technology` (`Id`);