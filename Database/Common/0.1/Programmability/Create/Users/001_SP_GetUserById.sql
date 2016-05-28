DELIMITER //

CREATE PROCEDURE GetUserById
(
    userId int
)
BEGIN
    SELECT 
        Id,
        Email,
        Password,
        FirstName,
        LastName,
        RegistrationDate,
        LastUpdateDate
    FROM
        User
    WHERE Id = userId;
END//

DELIMITER ;