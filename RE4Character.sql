use RE4Character;

CREATE TABLE Characters(
	CharacterId INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(1000) NOT NULL,
    LastName VARCHAR(1000) NOT NULL,
    Age INT NOT NULL,
    PRIMARY KEY ( CharacterId)
);

CREATE TABLE Organizations(
	OrganizationId INT NOT NULL,
    OrganizationName VARCHAR(1000) NOT NULL,
    OrganizationType VARCHAR(1000) NOT NULL,
    PRIMARY KEY (OrganizationId)
);

ALTER TABLE Characters ADD COLUMN OrganizationId INT;

ALTER TABLE Characters ADD CONSTRAINT FK_CharacterOrg FOREIGN KEY (OrganizationId) REFERENCES Organizations(OrganizationId);

INSERT INTO Organizations (OrganizationId, OrganizationName, OrganizationType) 
VALUES (1,"US-STRATCOM", "Hero"),
(2,"Civilians", "Neutral"),
(3,"Los Illuminados", "Villains"),
(4,"The Organization", "Villains"),
(5,"Test", "Random");

INSERT INTO Characters (FirstName, LastName, Age, OrganizationId) 
VALUES ("Leon", "Kennedy", 27, 1),
("Ashley", "Graham", 20, 2),
("Ada", "Wong", 30, 4),
("Luis", "Serra", 28, 2),
("Albert", "Wesker", 44, 4),
("Ramon", "Salazar", 20, 3),
("Jack",  "Krauser", 28, 4);
