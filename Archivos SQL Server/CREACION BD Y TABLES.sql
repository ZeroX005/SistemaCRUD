CREATE DATABASE BDCRUDINVENTARIO
GO

CREATE TABLE Nacionalidad( 

	cod_nacionalidad			int PRIMARY KEY NOT NULL IDENTITY,
	nombre_nacionalidad			varchar(50) not null

);
go

CREATE TABLE Usuario(

	cod_usuario					int PRIMARY KEY NOT NULL IDENTITY,
	usuario						varchar(45) not null,
	password					varchar(45) not null,
	nombre_usuario				varchar(50) not null,
	apellido_usuario			varchar(50) not null,
	dni							int not null,
	cod_nacionalidad			int not null
	FOREIGN KEY (cod_nacionalidad) REFERENCES Nacionalidad(cod_nacionalidad)

);
go


CREATE TABLE Proveedor(

	cod_proveedor				int PRIMARY KEY NOT NULL IDENTITY,
	razon_social				varchar(50) not null,
	ruc_proveedor				varchar(20) not null,
	direccionlegal_proveedor	varchar(50) not null,
	distrito_proveedor			varchar(45) not null,
	departamento_proveedor		varchar(45) not null

);
go

CREATE TABLE Marca(

	cod_marca					int PRIMARY KEY NOT NULL IDENTITY,
	nombre_marca				varchar(50) not null

);
go

CREATE TABLE Categoria(

	cod_categoria				int PRIMARY KEY NOT NULL IDENTITY,
	nombre_categoria			varchar(50) not null

);
go


CREATE TABLE Producto(

	cod_producto				int PRIMARY KEY NOT NULL IDENTITY,
	nombre_producto				varchar(45) not null,
	modelo_producto				varchar(45) not null,
	cod_marca					int not null,
	cod_proveedor				int not null,
	cod_categoria				int not null,
	cantidad					int not null,
	precio						DECIMAL not null,
	FOREIGN KEY(cod_marca) REFERENCES Marca(cod_marca),
	FOREIGN KEY(cod_proveedor) REFERENCES Proveedor(cod_proveedor),
	FOREIGN KEY(cod_categoria) REFERENCES Categoria(cod_categoria),

);
go

