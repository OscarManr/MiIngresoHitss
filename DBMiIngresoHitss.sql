
CREATE DATABASE MiIngresoHitss;
GO


USE MiIngresoHitss;
GO


CREATE TABLE Productos (
    ProductoId INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Descripcion VARCHAR(500),
    Precio DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE ListasDePrecios (
    ListaPrecioId INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL
);
GO


CREATE TABLE Clientes (
    ClienteId INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Direccion VARCHAR(500),
    Telefono VARCHAR(20)
);
GO


CREATE TABLE Ventas (
    VentaId INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT,
    ProductoId INT,
    FechaVenta DATETIME NOT NULL,
    Cantidad INT NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Cliente_Venta FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    CONSTRAINT FK_Producto_Venta FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId)
);
GO

CREATE TABLE Reportes (
    FechaInicio DATETIME NOT NULL,
	FechaFin DATETIME NOT NULL, 
);
GO

