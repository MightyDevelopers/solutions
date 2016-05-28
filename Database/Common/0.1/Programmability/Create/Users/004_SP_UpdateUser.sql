DELIMITER //

CREATE PROCEDURE UpdateProfile
(
    email NVARCHAR(256),
    firstName NVARCHAR(256),
    lastName NVARCHAR(256)
)
BEGIN
    UPDATE User
    SET
        FirstName = firstName,
        LastName = lastName,
        LastUpdateDate = NOW()
    WHERE Email = email
    LIMIT 1;
    
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
END //

DELIMITER ;