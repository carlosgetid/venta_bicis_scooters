USE master
GO

IF DB_ID('BD_VENTAS_BICICLETA_SCOOTER') IS NOT NULL
DROP DATABASE BD_VENTAS_BICICLETA_SCOOTER
GO

CREATE DATABASE BD_VENTAS_BICICLETA_SCOOTER
GO

USE BD_VENTAS_BICICLETA_SCOOTER
GO

-------------------------------------------------------------------------------------------------------------------------------------------
		/*CREACION DE TABLAS*/

CREATE TABLE TB_UBIGEO(
cod_ubigeo int IDENTITY(1,1) PRIMARY KEY not null ,
cod_departamento int not null,
cod_provincia int not null,
cod_distrito int not null,
descrp_ubigeo varchar(300) not null
)
GO

CREATE TABLE TB_DIRECCION(
cod_direccion int IDENTITY(1,1) PRIMARY KEY not null ,
cod_departamento int not null,
cod_provincia int not null,
cod_distrito int not null,
)
GO

CREATE TABLE TB_TRABAJADOR(
cod_trabajador int IDENTITY(1,1) primary key not null,
nom_trabajador varchar(200) not null,
ape_trabajador varchar(200) not null,
dni_trabajador char(8) not null,
correo_trabajador varchar(250) not null,
cel_trabajador char(9) not null,
cod_direccion int not null,
username_trabajador varchar(10) not null,
paswoord_trabajador varchar(10) not null
)
GO

CREATE TABLE TB_CLIENTE(
cod_cliente int IDENTITY(1,1) primary key not null,
nom_cliente varchar(200) not null,
ape_cliente varchar(200) not null,
dni_cliente char(8) not null,
correo_cliente varchar(250) not null,
cel_cliente char(9) not null,
cod_direccion int not null,
username_cliente varchar(10) not null,
paswoord_cliente varchar(10) not null
)
GO

CREATE TABLE TB_MARCA(
cod_marca int IDENTITY(1,1) primary key not null,
descrp_marca varchar(200) not null
)
GO

CREATE TABLE TB_SCOOTER(
cod_scooter int IDENTITY(1,1) primary key not null,
descrp_scooter varchar(350) not null,
cod_marca int not null,
aro_scooter varchar(200) not null,
color_scooter varchar(200) not null,
velocidad_scooter varchar(200) not null,
motor_scooter varchar(200) not null,
freno_scooter varchar(200) not null,
material_scooter varchar(200) not null,
precio_scooter decimal not null,
stock_scooter int not null,
)
GO

CREATE TABLE TB_ACCESORIO(
cod_accesorio int IDENTITY(1,1) primary key not null,
descrp_accesorio varchar(350) not null,
cod_marca int not null,
color_accesorio varchar(200) not null,
peso_accesorio varchar(200) not null,
material_accesorio varchar(200) not null,
duracion_accesorio varchar(200) not null,
dimension_accesorio varchar(200) not null,
precio_accesorio decimal not null,
stock_accesorio int not null,
)
GO

CREATE TABLE TB_BICICLETA(
cod_bicicleta int IDENTITY(1,1) primary key not null,
descrp_bicicleta varchar(350) not null,
cod_marca int not null,
aro_bicicleta varchar(200) not null,
color_bicicleta varchar(200) not null,
freno_bicicleta varchar(200) not null,
peso_bicicleta varchar(200) not null,
precio_bicicleta decimal not null,
stock_bicicleta int not null,
)
GO

CREATE TABLE TB_PEDIDO(
nro_pedido int IDENTITY(1,1) primary key not null,
cod_cliente int not null,
fecha_pedido date not null,
tipo_pedido varchar(200) not null,
cod_accesorio int not null,
cod_bicicleta int not null,
cod_scooter int not null
)
GO

CREATE TABLE TB_BOLETA(
nro_boleta int IDENTITY(1,1) primary key not null,
fecha_boleta Date not null,
nro_pedido int not null 
)
GO

CREATE TABLE TB_FACTURA(
nro_factura int IDENTITY(1,1) primary key not null,
cod_ruc char(11) not null,
fecha_factura Date not null,
nro_pedido int not null 
)
GO

------------------------------------------------------------------------------------------------------------------------------------------------
					/*AGREGANDO CONSTRAINT*/

ALTER TABLE TB_DIRECCION
ADD CONSTRAINT FK_DIRECCION_UBIGEO FOREIGN KEY (cod_direccion) REFERENCES TB_UBIGEO(cod_ubigeo)

ALTER TABLE TB_TRABAJADOR
ADD CONSTRAINT FK_TRABAJADOR_DIRECCION FOREIGN KEY (cod_direccion) REFERENCES TB_DIRECCION(cod_direccion)

ALTER TABLE TB_CLIENTE
ADD CONSTRAINT FK_CLIENTE_DIRECCION FOREIGN KEY (cod_direccion) REFERENCES TB_DIRECCION(cod_direccion)

ALTER TABLE TB_SCOOTER
ADD CONSTRAINT FK_SCOOTER_MARCA FOREIGN KEY (cod_marca) REFERENCES TB_MARCA(cod_marca)

ALTER TABLE TB_ACCESORIO
ADD CONSTRAINT FK_ACCESORIO_MARCA FOREIGN KEY (cod_marca) REFERENCES TB_MARCA(cod_marca)

ALTER TABLE TB_BICICLETA
ADD CONSTRAINT FK_BICICLETA_MARCA FOREIGN KEY (cod_marca) REFERENCES TB_MARCA(cod_marca)


ALTER TABLE TB_PEDIDO
ADD CONSTRAINT FK_CLIENTE_PEDIDO FOREIGN KEY (cod_cliente) REFERENCES TB_CLIENTE(cod_cliente)
ALTER TABLE TB_PEDIDO
ADD CONSTRAINT FK_ACCESORIO_PEDIDO FOREIGN KEY (cod_accesorio) REFERENCES TB_ACCESORIO(cod_accesorio)
ALTER TABLE TB_PEDIDO
ADD CONSTRAINT FK_BICICLETA_PEDIDO FOREIGN KEY (cod_bicicleta) REFERENCES TB_BICICLETA(cod_bicicleta)
ALTER TABLE TB_PEDIDO
ADD CONSTRAINT FK_SCOOTER_PEDIDO FOREIGN KEY (cod_scooter) REFERENCES TB_SCOOTER(cod_scooter)

ALTER TABLE TB_BOLETA
ADD CONSTRAINT FK_BOLETA_PEDIDO FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)

ALTER TABLE TB_FACTURA
ADD CONSTRAINT FK_FACTURA_PEDIDO FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)


----------------------------------------------------------------------------------------------------------------------------------------
					/*INSERTANDO REGISTROS NECESARIO*/

--INSERT UBIGEO (COMPLETO)


--INSERT DIRECCION (5 A 10 DIRECCIONES)


--INSERT CLIENTE (5 A 10) 


--INSERT TRABAJADOR ----> SERA EL ADMINISTRADOR DE LA PAGINA


--INSERT MARCA (TODAS LAS MARCAS DEL MERCADO QUE PRODUCEN NUESTROS PRODUCTOS )


--INSERT SCOOTER (10 A 15)


--INSERT ACCESORIO (10 A 15)


--INSERT BICICLETA (10 A 15)


--GENERAR PEDIDO (2 A 5 )



/*CADA INSERCION TIENE QUE ESTAR BIEN REALIZADA*/



