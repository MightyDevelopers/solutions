DELIMITER //

CREATE PROCEDURE InsertGroup
(
    name NVARCHAR(256),
    userId int
)
BEGIN
    DECLARE moment DATETIME DEFAULT NOW();
        
    START TRANSACTION;
        
        INSERT INTO `Group` (Name, CreatorId, CreationDate)
        VALUES (name, userId, moment);
        
        SET @groupId = LAST_INSERT_ID();
        
        INSERT INTO `GroupUser` (`GroupId`, `UserId`)
        VALUES (@groupId, userId);
        
        SELECT Id, Name, CreatorId, CreationDate
        FROM `Group`
        WHERE Id = @groupId
        LIMIT 1;
    
    COMMIT;
END //

DELIMITER ;