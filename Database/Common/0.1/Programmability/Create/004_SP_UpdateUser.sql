DELIMITER //

CREATE PROCEDURE UpdateProfile
(
    email NVARCHAR(256),
    firstName NVARCHAR(256),
    lastName NVARCHAR(256),
    lastUpdateDate DATETIME
)
BEGIN
    UPDATE User
    SET
        FirstName = firstName,
        LastName = lastName,
        LastUpdateDate = lastUpdateDate
    WHERE Email = email;
END //

DELIMITER ;