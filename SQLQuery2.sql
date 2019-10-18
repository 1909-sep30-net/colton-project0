

INSERT INTO Customer (FirstName, LastName) VALUES
	('Colton', 'Clary'),
	('Marcus', 'Gardner'),
	('Yolanda', 'Garza'),
	('Monica', 'Snook'),
	('Amber', 'Davidson');

SELECT * FROM Customer;
INSERT INTO Location (Address) VALUES
	('1001 Center Street, Arlington, Texas, 55555'),
	('10605 Allegheny Dr., Dallas, Texas, 75229');

SELECT * FROM Location;

/* INSERT INTO Orders (LocationID, CustomerID, OrderTime) VALUES
	(2, 3, GETDATE()),
	(1, 4, GETDATE()),
	(1, 2, GETDATE()),
	(1, 4, GETDATE()),
	(1, 1, GETDATE()); */

	INSERT INTO Product (Name, Price) VALUES
	('Staff', 199.99),
	('Dagger', 20.99),
	('Broadsword', 67.99),
	('Amulet', 5000.00),
	('Potion', 25.00),
	('Ring', 300.00);

SELECT * FROM Product;

	INSERT INTO Inventory (LocationID, ProductID, Quantity) VALUES
	(2, 4, 11),
	(1, 6, 21),
	(2, 2, 8),
	(1, 3, 14),
	(2, 5, 6),
	(1, 1, 6),
	(2, 3, 15),
	(1, 5, 7);


SELECT * FROM Orders;


