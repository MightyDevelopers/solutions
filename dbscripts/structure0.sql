CREATE DATABASE solutions;

USE solutions;

CREATE TABLE users 
(
	Login 			NVARCHAR(255) 	NOT NULL PRIMARY KEY,
    Password    	NVARCHAR(255) 	NOT NULL,
    Email 			NVARCHAR(255),
    FirstName 		NVARCHAR(35),
    LastName 		NVARCHAR(35),
    ProfileImgPath 	NVARCHAR(255),
    Facebook        NVARCHAR(255),
    Age 			INT 			CHECK (Age > 0 OR Age = NULL),
    Sex 			CHAR(1) 		CHECK (Sex = 'M' OR Sex = 'F' OR Sex = 'N' OR Sex = NULL),
    IsPrivate		BIT 			DEFAULT TRUE
)

