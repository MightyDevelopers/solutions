CREATE TABLE Rule
(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ActionId INT NOT NULL,
    Name NVARCHAR(256) NOT NULL,
    IsRoot bit NOT NULL,
    MemberName NVARCHAR(256) NOT NULL,
    Operation NVARCHAR(256) NOT NULL,
    Value NVARCHAR(256) NOT NULL,
    RuleForPass INT,
    RuleForFail INT 
);

ALTER TABLE `Rule`
ADD CONSTRAINT fk_Rule_Action 
FOREIGN KEY (`ActionId`) REFERENCES `Action` (`Id`);

ALTER TABLE `Rule`
ADD CONSTRAINT fk_Rule_PassRule 
FOREIGN KEY (`ActionId`) REFERENCES `Rule` (`Id`);

ALTER TABLE `Rule`
ADD CONSTRAINT fk_Rule_FailRule 
FOREIGN KEY (`ActionId`) REFERENCES `Rule` (`Id`);