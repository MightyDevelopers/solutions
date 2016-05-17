DELIMITER //

CREATE PROCEDURE GetAllUsers()
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
        User;
END//

DELIMITER ;