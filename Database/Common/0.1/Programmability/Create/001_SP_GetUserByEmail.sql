DELIMITER //

CREATE PROCEDURE GetUserByEmail
(
    email nvarchar(256)
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
    WHERE Email = email;
END//

DELIMITER ;