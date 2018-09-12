CREATE TABLE userstb
(
ID int IDENTITY(1,1) PRIMARY KEY,
name nvarchar(50) NOT NULL,
username varchar(50) NOT NULL UNIQUE,
password nvarchar(50) NOT NULL,
mobile nvarchar(50) NULL,
branch nvarchar(50) NOT NULL,
)

CREATE TABLE tourtb
(
ID int IDENTITY(1,1) PRIMARY KEY,
tourfrom nvarchar(50) NOT NULL,
tourto nvarchar(50) NOT NULL,
tourkm nvarchar(50) NOT NULL,
touramount money NOT NULL
)

CREATE TABLE drivertb
(
ID int IDENTITY(1,1) PRIMARY KEY,
name nvarchar(50) NOT NULL,
username varchar(50) NOT NULL UNIQUE,
password nvarchar(50) NOT NULL,
mobile nvarchar(50) NULL,
branch nvarchar(50) NOT NULL,
status nvarchar(50) NOT NULL,
taxi nvarchar(50) NOT NULL
)

CREATE TABLE clientstb
(
ID int IDENTITY(1,1) PRIMARY KEY,
name nvarchar(50) NOT NULL,
username varchar(50) NOT NULL UNIQUE,
password nvarchar(50) NOT NULL,
mobile nvarchar(50) NULL
)


CREATE TABLE restb
(
ID int IDENTITY(1,1) PRIMARY KEY,
client nvarchar(50) NOT NULL,
tourfrom nvarchar(50) NOT NULL,
tourto nvarchar(50) NOT NULL,
km nvarchar(50) NOT NULL,
amount money NOT NULL,
texi nvarchar(50) NOT NULL,
date date NOT NULL,
comment nvarchar(150) NOT NULL,
status nvarchar(50) NOT NULL
) 
