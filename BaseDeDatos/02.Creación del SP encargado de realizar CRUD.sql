/**

Procedimiento almacenado SP_USERS_CRUD
Este procedimiento almacenado realiza operaciones CRUD (Create, Read, Update, Delete) sobre la tabla Users en la base de datos WCFUsers.
@param Id - Valor entero opcional que representa el identificador del usuario.
@param Name - Valor de cadena opcional que representa el nombre del usuario.
@param DateOfBirth - Valor de fecha opcional que representa la fecha de nacimiento del usuario.
@param Gender - Valor de cadena opcional que representa el género del usuario.
@param Action - Valor de cadena que indica la acción a realizar (CREATE, READ, UPDATE, DELETE).
@param RowsAffected - Valor entero que representa el número de filas afectadas por la operación.
@return void
Autor: Nicolás Flórez
Fecha: 13/04/2023
*/

USE [WCFUsers]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_USERS_CRUD]
    @Id INT = NULL,
    @Name NVARCHAR(100) = NULL,
    @DateOfBirth DATE = NULL,
    @Gender NVARCHAR(1) = NULL,
    @Action NVARCHAR(10),
	@RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Action = 'CREATE')
    BEGIN
        INSERT INTO Users (Nombre, FechaNacimiento, Sexo)
        VALUES (@Name, @DateOfBirth, @Gender)
		SET @RowsAffected = @@ROWCOUNT;
    END
    ELSE IF (@Action = 'UPDATE')
    BEGIN
        UPDATE Users
        SET Nombre = @Name, FechaNacimiento = @DateOfBirth, Sexo = @Gender
        WHERE IdUser = @Id
		SET @RowsAffected = @@ROWCOUNT;
    END
    ELSE IF (@Action = 'DELETE')
    BEGIN
        DELETE FROM Users
        WHERE IdUser = @Id
		SET @RowsAffected = @@ROWCOUNT;
    END
    ELSE IF (@Action = 'READ')
    BEGIN
        SELECT IdUser, Nombre, FechaNacimiento, Sexo
        FROM Users
        WHERE (@Id IS NULL OR IdUser = @Id)
        AND (@Name IS NULL OR Nombre = @Name)
        AND (@DateOfBirth IS NULL OR FechaNacimiento = @DateOfBirth)
        AND (@Gender IS NULL OR Sexo = @Gender)
    END
END