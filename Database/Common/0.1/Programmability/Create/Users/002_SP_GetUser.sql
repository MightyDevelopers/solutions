DELIMITER //

CREATE PROCEDURE GetUserByCredentials
(
    email NVARCHAR(256),
    password NVARCHAR(64)
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
    WHERE Email = email and Password = password;
END//

DELIMITER ;