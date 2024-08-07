-- Creación de la base de datos
CREATE DATABASE Microservicio;
GO

USE Microservicio;
GO

-- Tabla de Roles
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(250)
);
GO

-- Tabla de Acciones
CREATE TABLE Actions(
    ActionId INT PRIMARY KEY IDENTITY(1,1),
    ActionName NVARCHAR(50)
);
GO

-- Tabla de Acciones de Roles
CREATE TABLE RolesDetails (
    RoleDetailId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT,
    ActionId INT,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (ActionId) REFERENCES Actions(ActionId)
);
GO

-- Tabla de Usuarios
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    RoleId INT,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO

-- Tabla de Categorías
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(250)
);
GO

-- Tabla de Productos
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(250),
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
GO

-- Insertar Datos de Ejemplo en Actions
INSERT INTO Actions (ActionName) VALUES
('ListCategory'),
('CreateCategory'),
('EditCategory'),
('ListProduct'),
('CreateProduct'),
('EditProduct'),
('CreateOrder')

-- Insertar Datos de Ejemplo en Roles
INSERT INTO Roles (Name, Description) VALUES
('Admin', 'Administrator with full access'),
('Seller', 'Can sell products'),
('Inventory', 'Can manage inventory')
GO

-- Insertar Datos de Ejemplo en Roles
INSERT INTO RolesDetails (RoleId, ActionId) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),

(2, 1),
(2, 4),
(2, 7),

(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 5),
(3, 6)
GO

-- Insertar Datos de Ejemplo en Usuarios
INSERT INTO Users (Username, PasswordHash, Email, RoleId) VALUES
('admin', '$2y$10$.uJOdfxC4T.fA6OkSgPI5.or/gKTHV8GDSkRn7kCvgrcjeanwwtxW', 'admin@example.com', 1),
('seller', '$2y$10$.uJOdfxC4T.fA6OkSgPI5.or/gKTHV8GDSkRn7kCvgrcjeanwwtxW', 'seller@example.com', 2),
('inventory', '$2y$10$.uJOdfxC4T.fA6OkSgPI5.or/gKTHV8GDSkRn7kCvgrcjeanwwtxW', 'inventory.com', 3);
GO

-- Insertar Datos de Ejemplo en Categorías
INSERT INTO Categories (Name, Description) VALUES
('Electronics', 'Electronic gadgets and devices'),
('Clothing', 'Men and women clothing'),
('Books', 'Various kinds of books');
GO

-- Insertar Datos de Ejemplo en Productos
INSERT INTO Products (Name, Description, Price, Stock, CategoryId) VALUES
('Smartphone', 'Latest smartphone with 5G', 699.99, 50, 1),
('Jeans', 'Blue denim jeans', 49.99, 100, 2),
('Novel', 'A thrilling mystery novel', 14.99, 200, 3);
GO



/*
delete from Users;
DBCC CHECKIDENT ('Users', RESEED, 0);
GO

delete from RolesDetails;
DBCC CHECKIDENT ('RolesDetails', RESEED, 0);
GO

delete from Roles;
DBCC CHECKIDENT ('Roles', RESEED, 0);
GO
*/