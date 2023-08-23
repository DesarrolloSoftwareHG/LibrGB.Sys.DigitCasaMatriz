
-----CREACION DE BASE DE DATOS------
CREATE DATABASE LibreriaGreenBook
GO
USE LibreriaGreenBook
GO

----------CREACION DE TABLAS PARA BD-----------
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