DELIMITER //

CREATE PROCEDURE InsertUser
(
    email NVARCHAR(256),
    password NVARCHAR(64)
)
BEGIN
    DECLARE moment DATETIME DEFAULT NOW();
    
    INSERT INTO User(Email, Password, RegistrationDate, LastUpdateDate)
    VALUES(email, password, moment, moment);
    
    SELECT Id, Email, Password
    FROM User
    WHERE Email = email
    LIMIT 1;
END //

DELIMITER ;