/*-----------------------------------------------------------------------------------
  Nombre de la base de datos: WCFUsers
  Descripci�n: Base de datos nueva para el almacenamiento y gesti�n de usuarios
  Autor: Nicol�s Fl�rez
  Fecha de creaci�n: 13-04-2023
  -----------------------------------------------------------------------------------*/
CREATE DATABASE WCFUsers
GO
USE [WCFUsers]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*-----------------------------------------------------------------------------------
  Nombre de la tabla: Users
  Descripci�n: Tabla que almacena informaci�n de usuarios.
  Autor: Nicol�s Fl�rez
  Fecha de creaci�n: 13-04-2023
  -----------------------------------------------------------------------------------*/

CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Sexo] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



