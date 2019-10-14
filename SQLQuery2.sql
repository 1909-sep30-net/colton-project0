CREATE TABLE Inventory (
	LocationID INT NOT NULL,
	ProductID INT NOT NULL,
	Supply INT NOT NULL,
	CONSTRAINT PK_Inventory PRIMARY KEY (LocationID, ProductID),
	CONSTRAINT FK_Inventory_Location_ID FOREIGN KEY (LocationID) REFERENCES Location(ID),
	CONSTRAINT FK_Inventory_Product_ID FOREIGN KEY (ProductID) REFERENCES Product(ID),
	CONSTRAINT CHK_Supply_Nonnegative CHECK (Supply >= 0)
);

INSERT INTO Customer (FirstName, LastName) VALUES
	('Colton', 'Clary'),
	('Marcus', 'Gardner'),
	('Yolanda', 'Garza'),
	('Monica', 'Snook'),
	('Amber', 'Davidson');

SELECT * FROM Customer;
INSERT INTO Location (Street, City, Zipcode, State) VALUES
	('1001 Center Street', 'Arlington', 76010, 'Texas'),
	('10605 Allegheny Dr.', 'Dallas', 75229, 'Texas');

SELECT * FROM Location;

INSERT INTO Orders (LocationID, CustomerID, OrderTime) VALUES
	(2, 3, GETDATE()),
	(1, 4, GETDATE()),
	(1, 2, GETDATE()),
	(1, 4, GETDATE()),
	(1, 1, GETDATE());

	INSERT INTO Product (Name, Price) VALUES
	('Staff', 199.99),
	('Dagger', 20.99),
	('Broadsword', 67.99),
	('Amulet', 5000.00),
	('Potion', 25.00),
	('Ring', 300.00);

SELECT * FROM Product;

	INSERT INTO Inventory (LocationID, ProductID, Supply) VALUES
	(1, 3, 4),
	(2, 4, 11),
	(1, 6, 21),
	(2, 2, 8),
	(1, 3, 14),
	(2, 5, 6),
	(1, 1, 6),
	(2, 3, 15),
	(1, 5, 7),
	(1, 6, 12);


SELECT * FROM Orders;


