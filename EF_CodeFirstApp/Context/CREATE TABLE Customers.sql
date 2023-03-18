CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    first_name VARCHAR (50) NOT NULL,
    last_name VARCHAR (50) NOT NULL,
    visited_at DATETIME,
    phone VARCHAR(20),
    store_id INT NOT NULL,
);
INSERT INTO Customers (first_name, last_name, visited_at, phone, store_id)
VALUES('andres', 'parra', GETDATE(), '23423432', 21)
