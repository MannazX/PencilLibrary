CREATE TABLE Pencil (
	PencilID INT IDENTITY(1,1) PRIMARY KEY,
	PencilType VARCHAR(2) NOT NULL,
	PencilBrand VARCHAR(15) NOT NULL,
	PencilThickness FLOAT NOT NULL,
	PencilLength FLOAT NOT NULL,
	Price FLOAT NOT NULL
);

INSERT INTO Pencil VALUES ('HB', 'Crayola', 1.8, 12.5, 25);
INSERT INTO Pencil VALUES ('B', 'Faber-Castell', 1.5, 12.5, 30);