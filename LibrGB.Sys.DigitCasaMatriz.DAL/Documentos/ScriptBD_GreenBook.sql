
-----CREACION DE BASE DE DATOS------
CREATE DATABASE LibreriaGreenBook
GO
USE LibreriaGreenBook
GO

-----------------------------------------------------------------------------
CREATE TABLE Categoria(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Codigo Varchar(MAX) NOT NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NOT NULL DEFAULT GETDATE()
);


------- CREACION DE PROCEDIMIENTOS ALMACENADOS ---------

---GUARDAR CATEGORIA----
CREATE PROCEDURE SPGuardarCategoria
 @Nombre VARCHAR(MAX),
 @Codigo VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO Categoria(Nombre,Codigo,Descripcion,FechaCreacion)
 VALUES (@Nombre,@Codigo,@Descripcion,@FechaCreacion);
END

--MODIFICAR CATEGORIA--
CREATE PROCEDURE SPModificarCategoria
 @Id INT,
 @Nombre VARCHAR(MAX),
 @Codigo VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE Categoria
		SET
			Nombre = @Nombre,
			Codigo = @Codigo,
			Descripcion = @Descripcion,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--ELIMINAR CATEGORIA--
CREATE PROCEDURE SPEliminarCategoria
@Id INT
AS
BEGIN
    DELETE FROM Categoria
    WHERE Id = @Id;
END

--MOSTRAR CATEGORIA--
CREATE PROCEDURE SPMostrarCategoria
AS
BEGIN
    SELECT * FROM Categoria
END

--OBTENER CATEGORIA POR ID--
CREATE PROCEDURE SPObtenerCategoriaPorId
@Id INT
AS
BEGIN 
SELECT * FROM Categoria WHERE Categoria.Id = @Id
END

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerCategoriasLike
@Nombre VARCHAR(MAX) 
AS
BEGIN 
SELECT * FROM Categoria WHERE Categoria.Nombre LIKE '%' + @Nombre + '%'
END


-----------------------------------------------------------------------------
CREATE TABLE Estatus(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

------------ PROCEDIMIENTOS ALMACENADOS PARA ESTATUS--------------

-- GUARDAR ESTATUS --
CREATE PROCEDURE SPGuardarEstatus
 @Nombre VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO Estatus(Nombre, Descripcion, FechaCreacion)
 VALUES (@Nombre, @Descripcion, @FechaCreacion);
END

--MODIFICAR ESTATUS--
CREATE PROCEDURE SPModificarEstatus
 @Id Int,
 @Nombre VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE Estatus
		SET
			Nombre = @Nombre,
			Descripcion = @Descripcion,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--MOSTRAR ESTATUS--
CREATE PROCEDURE SPMostrarEstatus
AS
BEGIN
    SELECT * FROM Estatus
END

--OBTENER ESTATUS POR ID--
CREATE PROCEDURE SPObtenerEstatusPorId
@Id INT
AS
BEGIN 
SELECT * FROM Estatus WHERE Estatus.Id = @Id
END

------ COMANDOS DML PARA DATOS PREDEFINIDOS ------
INSERT INTO Estatus(Nombre, Descripcion, FechaCreacion)
VALUES ('Indefinido', 'Por el Momento No existe estatus Establecido', GETDATE()),
	   ('Disponible', 'El producto o la Unidad de Medida estan Disponibles', GETDATE()),
       ('No Disponible', 'El producto o la Unidad de Medida no estan Disponibles', GETDATE())


----------------------------------------------------------------------------------------------------------------


CREATE TABLE UnidadDeMedida(
Id Int NOT NULL Primary Key Identity(1,1),
UDM Varchar(MAX) NOT NULL,
IdEstatus Int NOT NULL Foreign Key References Estatus(Id),
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

-- GUARDAR UNIDAD DE MEDIDA--
CREATE PROCEDURE SPGuardarUnidadDeMedida
 @UDM VARCHAR(MAX),
 @IdEstatus INT,
 @Descripcion VARCHAR(MAX),
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO UnidadDeMedida(UDM, IdEstatus, Descripcion, FechaCreacion)
 VALUES (@UDM, @IdEstatus, @Descripcion, @FechaCreacion);
END

--MODIFICAR UNIDAD DE MEDIDA--
CREATE PROCEDURE SPModificarUnidadDeMedida
 @Id INT,
 @UDM VARCHAR(MAX),
 @IdEstatus INT,
 @Descripcion VARCHAR(MAX),
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE UnidadDeMedida
		SET
			UDM = @UDM,
			IdEstatus = @IdEstatus,
			Descripcion = @Descripcion,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--ELIMINAR UNIDAD DE MEDIDA--
CREATE PROCEDURE SPEliminarUnidadDeMedida
@Id INT
AS
BEGIN
    DELETE FROM UnidadDeMedida
    WHERE Id = @Id;
END

--MOSTRAR UNIDAD DE MEDIDA--
CREATE PROCEDURE SPMostrarUnidadDeMedida
AS
BEGIN
   SELECT u.*, E.Id,E.Nombre FROM UnidadDeMedida as U 
join Estatus as E 
ON U.IdEstatus = E.Id
END
GO

--OBTENER UNIDAD DE MEDIDA POR ID--
CREATE PROCEDURE SPObtenerUnidadDeMedidaPorId
@Id INT
AS
BEGIN 
SELECT u.*, E.Id,E.Nombre FROM UnidadDeMedida as U 
join Estatus as E 
ON U.IdEstatus = E.Id
WHERE U.Id = @Id
END
GO

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerUnidadDeMedidaLike
@UDM VARCHAR(MAX) 
AS
BEGIN 
SELECT u.*, E.Id, E.Nombre 
FROM UnidadDeMedida as U 
JOIN Estatus as E 
ON U.IdEstatus = E.Id
WHERE U.UDM LIKE '%' + @UDM + '%'
END


-----------------------------------------------------------------------------
CREATE TABLE Proveedor(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Direccion Varchar(MAX) NOT NULL,
NumeroTelefono Varchar(8) NOT NULL,
NumeroCelular Varchar(8) NULL,
CorreoElectronico Varchar(MAX) NOT NULL,
SitioWeb Varchar(MAX) NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

------------ PROCEDIMIENTOS ALMACENADOS PARA PROVEEDOR--------------

-- GUARDAR PROVEEDOR--
CREATE PROCEDURE SPGuardarProveedor
 @Nombre VARCHAR(MAX),
 @Direccion VARCHAR(MAX),
 @NumeroTelefono VARCHAR(8),
 @NumeroCelular VARCHAR(8),
 @CorreoElectronico VARCHAR(MAX),
 @SitioWeb VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO Proveedor(Nombre, Direccion, NumeroTelefono, NumeroCelular, CorreoElectronico, SitioWeb, Descripcion, FechaCreacion)
 VALUES (@Nombre, @Direccion, @NumeroTelefono, @NumeroCelular, @CorreoElectronico, @SitioWeb, @Descripcion, @FechaCreacion);
END

--MODIFICAR PROVEEDOR--
CREATE PROCEDURE SPModificarProveedor
 @Id Int,
 @Nombre VARCHAR(MAX),
 @Direccion VARCHAR(MAX),
 @NumeroTelefono VARCHAR(8),
 @NumeroCelular VARCHAR(8),
 @CorreoElectronico VARCHAR(MAX),
 @SitioWeb VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE Proveedor
		SET
			Nombre = @Nombre,
			Direccion = @Direccion,
			NumeroTelefono = @NumeroTelefono,
			NumeroCelular = @NumeroCelular,
			CorreoElectronico = @CorreoElectronico,
			SitioWeb = @SitioWeb,
			Descripcion = @Descripcion,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--ELIMINAR PROVEEDOR--
CREATE PROCEDURE SPEliminarProveedor
@Id INT
AS
BEGIN
    DELETE FROM Proveedor
    WHERE Id = @Id;
END

--MOSTRAR PROVEEDOR--
CREATE PROCEDURE SPMostrarProveedor
AS
BEGIN
    SELECT * FROM Proveedor
END

--OBTENER PROVEEDOR POR ID--
CREATE PROCEDURE SPObtenerProveedorPorId
@Id INT
AS
BEGIN 
SELECT * FROM Proveedor WHERE Proveedor.Id = @Id
END

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerProveedorLike
@Nombre VARCHAR(MAX) 
AS
BEGIN 
SELECT * FROM Proveedor WHERE Proveedor.Nombre LIKE '%' + @Nombre + '%'
END

---------------------------------------------------------------------------------------------


CREATE TABLE Producto(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Codigo Varchar(MAX) NOT NULL,
IdEstatus Int NOT NULL Foreign Key References Estatus(Id),
Precio Decimal(10,2) NOT NULL,
IdUDM Int NOT NULL Foreign Key References UnidadDeMedida(Id),
IdCategoria Int NOT NULL Foreign Key References Categoria(Id),
IdProveedor Int NOT NULL Foreign Key References Proveedor(Id),
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

-------------- CREACION DE PROCEDIMIENTOS ALMACENADOS ----------------

-- GUARDAR PRODUCTO--
CREATE PROCEDURE SPGuardarProducto
 @Nombre VARCHAR(MAX),
 @Codigo VARCHAR(MAX),
 @IdEstatus INT,
 @Precio Decimal(10,2),
 @IdUDM INT,
 @IdCategoria INT,
 @IdProveedor INT,
 @Descripcion VARCHAR(MAX),
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO Producto(Nombre, Codigo, IdEstatus, Precio, IdUDM, IdCategoria, IdProveedor, Descripcion, FechaCreacion)
 VALUES (@Nombre, @Codigo, @IdEstatus, @Precio, @IdUDM, @IdCategoria, @IdProveedor, @Descripcion, @FechaCreacion);
END


CREATE PROCEDURE SPModificarProducto
 @Id Int,
 @Nombre VARCHAR(MAX),
 @Codigo VARCHAR(MAX),
 @IdEstatus INT,
 @Precio Decimal(10,2),
 @IdUDM INT,
 @IdCategoria INT,
 @IdProveedor INT,
 @Descripcion VARCHAR(MAX),
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE Producto
		SET
			Nombre = @Nombre,
			Codigo = @Codigo,
			IdEstatus = @IdEstatus,
			Precio = @Precio,
			IdUDM = @IdUDM,
			IdCategoria = @IdCategoria,
			IdProveedor = @IdProveedor,
			Descripcion = @Descripcion,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--ELIMINAR PRODUCTO--
CREATE PROCEDURE SPEliminarProducto
@Id INT
AS
BEGIN
    DELETE FROM Producto
    WHERE Id = @Id;
END

--MOSTRAR PRODUCTO--
CREATE PROCEDURE SPMostrarProducto
AS
BEGIN
    SELECT 
        p.*,
        c.Id AS CategoriaId, c.Nombre AS CategoriaNombre,
        pr.Id AS ProveedorId, pr.Nombre AS ProveedorNombre,
        u.Id AS UnidadDeMedidaId, u.UDM AS UnidadDeMedidaNombre,
        e.Id AS EstatusId, e.Nombre AS EstatusNombre
    FROM Producto AS p
    JOIN Categoria AS c ON p.IdCategoria = c.Id
    JOIN Proveedor AS pr ON p.IdProveedor = pr.Id
    JOIN UnidadDeMedida AS u ON p.IdUDM = u.Id
    JOIN Estatus AS e ON p.IdEstatus = e.Id;
END


--OBTENER PRODUCTO POR ID--
CREATE PROCEDURE SPObtenerProductoPorId
@Id INT
AS
BEGIN 
SELECT 
        p.*,
        c.Id AS CategoriaId, c.Nombre AS CategoriaNombre,
        pr.Id AS ProveedorId, pr.Nombre AS ProveedorNombre,
        u.Id AS UnidadDeMedidaId, u.UDM AS UnidadDeMedidaNombre,
        e.Id AS EstatusId, e.Nombre AS EstatusNombre
    FROM Producto AS p
    JOIN Categoria AS c ON p.IdCategoria = c.Id
    JOIN Proveedor AS pr ON p.IdProveedor = pr.Id
    JOIN UnidadDeMedida AS u ON p.IdUDM = u.Id
    JOIN Estatus AS e ON p.IdEstatus = e.Id
    WHERE p.Id = @Id;
END


CREATE PROCEDURE SPObtenerProductoLike
@Codigo VARCHAR(MAX)
AS
BEGIN 
SELECT 
        p.*,
        c.Id AS CategoriaId, c.Nombre AS CategoriaNombre,
        pr.Id AS ProveedorId, pr.Nombre AS ProveedorNombre,
        u.Id AS UnidadDeMedidaId, u.UDM AS UnidadDeMedidaNombre,
        e.Id AS EstatusId, e.Nombre AS EstatusNombre
    FROM Producto AS p
    JOIN Categoria AS c ON p.IdCategoria = c.Id
    JOIN Proveedor AS pr ON p.IdProveedor = pr.Id
    JOIN UnidadDeMedida AS u ON p.IdUDM = u.Id
    JOIN Estatus AS e ON p.IdEstatus = e.Id
    WHERE p.Codigo LIKE '%' + @Codigo + '%';
END