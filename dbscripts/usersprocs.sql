USE Solutions;

DELIMITER //

CREATE PROCEDURE GetUser
(
    IN login        NVARCHAR(255),
    IN `password`   NVARCHAR(255)
)
BEGIN
    SELECT Email, FirstName, LastName, ProfileImgPath, Age, Sex, IsPrivate
    FROM Users
    WHERE Users.Login = login AND Users.`Password` = `password`;
END//

CREATE PROCEDURE InsertUser
(
    IN login        NVARCHAR(255),
    IN `password`   NVARCHAR(255)
)
BEGIN
    INSERT INTO Users(Login, `Password`)
    VALUES(login, `password`);
END//

CREATE PROCEDURE UpdateUserPassword
(
    IN login        NVARCHAR(255),
    IN `password`   NVARCHAR(255)
)
BEGIN
    UPDATE Users
    SET Users.`Password` = `password`
    WHERE Users.Login = login;
END//

CREATE PROCEDURE UpdateUserLogin
(
    IN login        NVARCHAR(255),
    IN `password`   NVARCHAR(255)
)
BEGIN
    UPDATE Users
    SET Users.Login = login
    WHERE Users.`Password` = `password`;
END//

CREATE PROCEDURE DeleteUser
(
    IN login        NVARCHAR(255),
    IN `password`   NVARCHAR(255)
)
BEGIN
    DELETE FROM Users
    WHERE Users.Login = login 
        AND Users.`Password` = `password`;
END//

CREATE PROCEDURE UpdateUserProfile
(
    IN login            NVARCHAR(255),
    IN email 		    NVARCHAR(255),
    IN firstName 		NVARCHAR(35),
    IN lastName 		NVARCHAR(35),
    IN profileImgPath 	NVARCHAR(255),
    IN age 			    INT,
    IN sex 			    CHAR(1),
    IN isPrivate        BIT
)
BEGIN
    UPDATE Users
    SET Users.Email = email,
        Users.FirstName = firstName,
        Users.LastName = lastName,
        User.ProfileImgPath = profileImgPath,
        User.Age = age,
        User.Sex = sex,
        User.IsPrivate = isPrivate
    WHERE Users.Login = login;
END//

CREATE PROCEDURE SearchUsersByName
(
    IN username NVARCHAR(71)
)
BEGIN
    SELECT Email, FirstName, LastName, ProfileImgPath, Age, Sex, IsPrivate
    FROM Users
    WHERE   (Users.FirstName LIKE CONCAT('%', username, '%')
            OR Users.LastName LIKE CONCAT('%', username, '%')
            OR CONCAT (Users.FirstName, " ", Users.LastName) LIKE CONCAT('%', username, '%'))
        AND 
            Users.IsPrivate = FALSE;
END//

DELIMITER ;