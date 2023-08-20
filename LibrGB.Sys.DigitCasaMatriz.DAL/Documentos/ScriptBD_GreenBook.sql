/* 
	11/08/2023
	LibreriaGreenBook
	Grupo05
*/

-- FASE 1: Crear base de datos

CREATE DATABASE LibreriaGreenBook
GO
USE LibreriaGreenBook
GO

-- FASE 2: Crear tablas de la base de datos.

CREATE TABLE Categoria(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Codigo Varchar(MAX) NOT NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NOT NULL
);

CREATE TABLE Estatus(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

CREATE TABLE UnidadDeMedida(
Id Int NOT NULL Primary Key Identity(1,1),
UDM Varchar(MAX) NOT NULL,
IdEstatus Int NOT NULL Foreign Key References Estatus(Id),
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

CREATE TABLE Proveedor(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Direccion Varchar(MAX) NOT NULL,
NumeroTelefono Varchar(8) NOT NULL,
NumeroCelular Varchar(8) NOT NULL,
CorreoElectronico Varchar(MAX) NOT NULL,
SitioWeb Varchar(MAX) NOT NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

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

CREATE TABLE Genero(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL
);

CREATE TABLE EstadoCivil(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL
);

CREATE TABLE RolDeUsuario(
Id Int NOT NULL Primary Key Identity(1,1),
Nombre Varchar(MAX) NOT NULL,
Descripcion Varchar(MAX) NOT NULL,
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

CREATE TABLE Empleado(
Id Int NOT NULL Primary Key Identity(1,1),
Nombres Varchar(MAX) NOT NULL,
Apellidos Varchar(MAX) NOT NULL,
DUI Varchar(9) NOT NULL,
FechaNacimiento DATETIME NOT NULL,
IdGenero Int NOT NULL Foreign Key References Genero(Id),
IdEstadoCivil Int NOT NULL Foreign Key References EstadoCivil(Id),
Direccion Varchar(MAX) NOT NULL,
NumeroTelefono Varchar(8) NULL,
NumeroCelular Varchar(8) NOT NULL,
CorreoElectronico Varchar(MAX) NOT NULL,
Usuario Varchar(MAX) NOT NULL,
Password Varchar(MAX) NOT NULL,
IdRol Int NOT NULL Foreign Key References RolDeUsuario(Id),
FechaCreacion DateTime NOT NULL,
FechaModificacion DateTime NULL DEFAULT GETDATE()
);

CREATE TABLE CambioPassword(
Id Int NOT NULL Primary Key Identity(1,1),
Usuario Varchar(MAX) NOT NULL,
PasswordNueva Varchar(MAX) NOT NULL,
ConfirmarPasswordNueva Varchar(MAX) NOT NULL
);

-- FASE 3: Creación de procedimientos almacenados

------------ PROCEDIMIENTOS ALMACENADOS PARA CATEGORIA--------------

-- GUARDAR CATEGORIA--
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


------------ PROCEDIMIENTOS ALMACENADOS PARA UNIDAD DE MEDIDA--------------

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
    SELECT * FROM UnidadDeMedida
END

--OBTENER UNIDAD DE MEDIDA POR ID--
CREATE PROCEDURE SPObtenerUnidadDeMedidaPorId
@Id INT
AS
BEGIN 
SELECT * FROM UnidadDeMedida WHERE UnidadDeMedida.Id = @Id
END

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerUnidadDeMedidaLike
@UDM VARCHAR(MAX) 
AS
BEGIN 
SELECT * FROM UnidadDeMedida WHERE UnidadDeMedida.UDM LIKE '%' + @UDM + '%'
END


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


------------ PROCEDIMIENTOS ALMACENADOS PARA PRODUCTO--------------

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

--MODIFICAR PRODUCTO--
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
    SELECT * FROM Producto
END

--OBTENER PRODUCTO POR ID--
CREATE PROCEDURE SPObtenerProductoPorId
@Id INT
AS
BEGIN 
SELECT * FROM Producto WHERE Producto.Id = @Id
END

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerProductoLike
@Codigo VARCHAR(MAX) 
AS
BEGIN 
SELECT * FROM Producto WHERE Producto.Codigo LIKE '%' + @Codigo + '%'
END


------------ PROCEDIMIENTOS ALMACENADOS PARA ESTATUS--------------

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


------------ PROCEDIMIENTOS ALMACENADOS PARA GENERO--------------

--MOSTRAR GENERO--
CREATE PROCEDURE SPMostrarGenero
AS
BEGIN
    SELECT * FROM Genero
END

--OBTENER GENERO POR ID--
CREATE PROCEDURE SPObtenerGeneroPorId
@Id INT
AS
BEGIN 
SELECT * FROM Genero WHERE Genero.Id = @Id
END


------------ PROCEDIMIENTOS ALMACENADOS PARA ESTADO CIVIL--------------

--MOSTRAR ESTADO CIVIL--
CREATE PROCEDURE SPMostrarEstadoCivil
AS
BEGIN
    SELECT * FROM EstadoCivil
END

--OBTENER ESTADO CIVIL POR ID--
CREATE PROCEDURE SPObtenerEstadoCivilPorId
@Id INT
AS
BEGIN 
SELECT * FROM EstadoCivil WHERE EstadoCivil.Id = @Id
END


------------ PROCEDIMIENTOS ALMACENADOS PARA ROL DE USUARIO--------------

-- GUARDAR ROL DE USUARIO--
CREATE PROCEDURE SPGuardarRolDeUsuario
 @Nombre VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO RolDeUsuario(Nombre, Descripcion, FechaCreacion)
 VALUES (@Nombre, @Descripcion, @FechaCreacion);
END

--MODIFICAR ROL DE USUARIO--
CREATE PROCEDURE SPModificarRolDeUsuario
 @Id Int,
 @Nombre VARCHAR(MAX),
 @Descripcion VARCHAR(MAX),
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE Producto
		SET
			Nombre = @Nombre,
			Descripcion = @Descripcion,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--ELIMINAR ROL DE USUARIO--
CREATE PROCEDURE SPEliminarRolDeUsuario
@Id INT
AS
BEGIN
    DELETE FROM RolDeUsuario
    WHERE Id = @Id;
END

--MOSTRAR ROL DE USUARIO--
CREATE PROCEDURE SPMostrarRolDeUsuario
AS
BEGIN
    SELECT * FROM RolDeUsuario
END

--OBTENER ROL DE USUARIO POR ID--
CREATE PROCEDURE SPObtenerRolDeUsuarioPorId
@Id INT
AS
BEGIN 
SELECT * FROM RolDeUsuario WHERE RolDeUsuario.Id = @Id
END

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerRolDeUsuarioLike
@Nombre VARCHAR(MAX) 
AS
BEGIN 
SELECT * FROM RolDeUsuario WHERE RolDeUsuario.Nombre LIKE '%' + @Nombre + '%'
END


------------ PROCEDIMIENTOS ALMACENADOS PARA EMPLEADOS--------------

-- GUARDAR EMPLEADOS--
CREATE PROCEDURE SPGuardarEmpleado
 @Nombres VARCHAR(MAX),
 @Apellidos VARCHAR(MAX),
 @DUI VARCHAR(MAX),
 @FechaNacimiento DATETIME,
 @IdGenero INT,
 @IdEstadoCivil INT,
 @Direccion VARCHAR(MAX),
 @NumeroTelefono VARCHAR(8),
 @NumeroCelular VARCHAR(8),
 @CorreoElectronico VARCHAR(MAX),
 @Usuario VARCHAR(MAX),
 @Password VARCHAR(MAX),
 @IdRol INT,
 @FechaCreacion DATETIME
 AS
 BEGIN
 INSERT INTO Empleado(Nombres, Apellidos, DUI, FechaNacimiento, IdGenero, IdEstadoCivil, Direccion, NumeroTelefono, NumeroCelular, CorreoElectronico, Usuario, Password, IdRol, FechaCreacion)
 VALUES (@Nombres, @Apellidos, @DUI, @FechaNacimiento, @IdGenero, @IdEstadoCivil, @Direccion, @NumeroTelefono, @NumeroCelular, @CorreoElectronico, @Usuario, @Password, @IdRol, @FechaCreacion);
END

--MODIFICAR EMPLEADO--
CREATE PROCEDURE SPModificarEmpleado
 @Id Int,
 @Nombres VARCHAR(MAX),
 @Apellidos VARCHAR(MAX),
 @DUI VARCHAR(MAX),
 @FechaNacimiento DATETIME,
 @IdGenero INT,
 @IdEstadoCivil INT,
 @Direccion VARCHAR(MAX),
 @NumeroTelefono VARCHAR(8),
 @NumeroCelular VARCHAR(8),
 @CorreoElectronico VARCHAR(MAX),
 @Usuario VARCHAR(MAX),
 @Password VARCHAR(MAX),
 @IdRol INT,
 @FechaModificacion DATETIME
AS
BEGIN
UPDATE Empleado
		SET
			Nombres = @Nombres,
			Apellidos = @Apellidos,
			DUI = @DUI,
			FechaNacimiento = @FechaNacimiento,
			IdGenero = @IdGenero,
			IdEstadoCivil = @IdEstadoCivil,
			Direccion = @Direccion,
			NumeroTelefono = @NumeroTelefono,
			NumeroCelular = @NumeroCelular,
			CorreoElectronico = @CorreoElectronico,
			Usuario = @Usuario,
			Password = @Password,
			IdRol = @IdRol,
			FechaModificacion = @FechaModificacion
		WHERE
			Id = @Id;
END

--ELIMINAR EMPLEADO--
CREATE PROCEDURE SPEliminarEmpleado
@Id INT
AS
BEGIN
    DELETE FROM Empleado
    WHERE Id = @Id;
END

--MOSTRAR EMPLEADO--
CREATE PROCEDURE SPMostrarEmpleado
AS
BEGIN
    SELECT * FROM Empleado
END

--OBTENER EMPLEADO POR ID--
CREATE PROCEDURE SPObtenerEmpleadoPorId
@Id INT
AS
BEGIN 
SELECT * FROM Empleado WHERE Empleado.Id = @Id
END

--OBTENER DATOS AL BUSCAR--
CREATE PROCEDURE SPObtenerEmpleadoLike
@DUI VARCHAR(MAX) 
AS
BEGIN 
SELECT * FROM Empleado WHERE Empleado.DUI LIKE '%' + @DUI + '%'
END

-- FASE 4: Agregar registros a todas las tablas de la base de datos.

INSERT INTO EstadoCivil(Nombre)
VALUES ('Soltero/a'), ('Casado/a'), ('Union de Hecho'), ('Separado/a'), ('Divorciado/a'), ('Viudo/a')

INSERT INTO Genero(Nombre)
VALUES ('Masculiono'), ('Femenino'), ('Otro..')

INSERT INTO Estatus(Nombre, Descripcion, FechaCreacion)
VALUES ('Disponible', 'El producto o la Unidad de Medida estan Disponibles', GETDATE()),
       ('No Disponible', 'El producto o la Unidad de Medida no estan Disponibles', GETDATE())

-- FASE 5: Creacion de procedimientos almacenados de consultas SELECT con Multi-tablas para reportes.

SELECT p.Nombre AS Producto, c.Nombre AS Categoria
FROM Producto AS p JOIN Categoria AS c
ON p.IdCategoria = c.Id

SELECT p.Nombre AS Producto, pr.Nombre AS Categoria
FROM Producto AS p JOIN Proveedor AS pr
ON p.IdCategoria = pr.Id