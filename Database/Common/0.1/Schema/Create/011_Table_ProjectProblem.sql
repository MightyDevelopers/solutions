CREATE TABLE `ProjectProblem`
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProjectId INT NOT NULL,
    ProblemId INT NOT NULL
);

ALTER TABLE `ProjectProblem`
ADD CONSTRAINT fk_ProjectProblem_Project 
FOREIGN KEY (`ProjectId`) REFERENCES `Project` (`Id`);

ALTER TABLE `ProjectProblem`
ADD CONSTRAINT fk_ProjectProblem_Problem
FOREIGN KEY (`ProblemId`) REFERENCES `Problem` (`Id`);