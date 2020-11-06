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
cod_departamento varchar(2) not null,
cod_provincia varchar(2) not null,
cod_distrito varchar(2) not null,
descrp_ubigeo varchar(300) not null
)
GO

CREATE TABLE TB_DIRECCION(
cod_direccion int IDENTITY(1,1) PRIMARY KEY not null ,
descrip_direccion varchar(250) not null,
cod_cliente int null,
cod_trabajador int null,
cod_departamento varchar(2) not null,
cod_provincia varchar(2) not null,
cod_distrito varchar(2) not null,
)
GO

CREATE TABLE TB_TRABAJADOR(
cod_trabajador int IDENTITY(1,1) primary key not null,
nom_trabajador varchar(200) not null,
ape_trabajador varchar(200) not null,
dni_trabajador char(8) not null,
correo_trabajador varchar(250) not null,
cel_trabajador char(9) not null,
username_trabajador varchar(20) null, 
password_trabajador varchar(20) not null
)
GO

CREATE TABLE TB_CLIENTE(
cod_cliente int IDENTITY(1,1) primary key not null,
nom_cliente varchar(200) not null,
ape_cliente varchar(200) not null,
dni_cliente char(8) not null,
correo_cliente varchar(250) not null, /*funcionara como username */
cel_cliente char(9) not null,
password_cliente varchar(20) not null,
estado_cliente bit not null
)
GO

CREATE TABLE TB_MARCA(
cod_marca int IDENTITY(1,1) primary key not null,
descrp_marca varchar(200) not null
)
GO


CREATE TABLE TB_IMAGENES(
cod_imagen int IDENTITY(1,1) primary key not null,
descrp_imagen varchar(500) not null,
url_imagen image not null
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
cod_imagen int
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
cod_imagen int
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
cod_imagen int
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


CREATE TABLE TB_DETALLE_PEDIDO_SCOOTER(
cod_pedido_scooter int IDENTITY(1,1) primary key not null,
nro_pedido int not null,
cod_scooter int not null
)
GO


CREATE TABLE TB_DETALLE_PEDIDO_ACCESORIO(
cod_pedido_accesorio int IDENTITY(1,1) primary key not null,
nro_pedido int not null,
cod_accesorio int not null
)
GO

CREATE TABLE TB_DETALLE_PEDIDO_BICICLETA(
cod_pedido_bicicleta int IDENTITY(1,1) primary key not null,
nro_pedido int not null,
cod_bicicleta int not null
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

ALTER TABLE TB_DIRECCION
ADD CONSTRAINT FK_DIRECCION_CLIENTE FOREIGN KEY (cod_cliente) REFERENCES TB_CLIENTE(cod_cliente)

ALTER TABLE TB_DIRECCION
ADD CONSTRAINT FK_DIRECCION_TRABAJADOR FOREIGN KEY (cod_trabajador) REFERENCES TB_TRABAJADOR(cod_trabajador)
/*
ALTER TABLE TB_TRABAJADOR
ADD CONSTRAINT FK_TRABAJADOR_DIRECCION FOREIGN KEY (cod_direccion) REFERENCES TB_DIRECCION(cod_direccion)

ALTER TABLE TB_CLIENTE
ADD CONSTRAINT FK_CLIENTE_DIRECCION FOREIGN KEY (cod_direccion) REFERENCES TB_DIRECCION(cod_direccion)
*/
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



ALTER TABLE TB_BICICLETA
ADD CONSTRAINT FK_BICICLETA_IMAGENES FOREIGN KEY (cod_imagen) REFERENCES TB_IMAGENES(cod_imagen)
ALTER TABLE TB_ACCESORIO
ADD CONSTRAINT FK_ACCESORIO_IMAGENES FOREIGN KEY (cod_imagen) REFERENCES TB_IMAGENES(cod_imagen)
ALTER TABLE TB_SCOOTER
ADD CONSTRAINT FK_SCOOTER_IMAGENES FOREIGN KEY (cod_imagen) REFERENCES TB_IMAGENES(cod_imagen)



ALTER TABLE TB_DETALLE_PEDIDO_SCOOTER
ADD CONSTRAINT FK_DETALLE_SCOOTER FOREIGN KEY (cod_scooter) REFERENCES TB_SCOOTER(cod_scooter)
ALTER TABLE TB_DETALLE_PEDIDO_ACCESORIO
ADD CONSTRAINT FK_DETALLE_ACCESORIO FOREIGN KEY (cod_accesorio) REFERENCES TB_ACCESORIO(cod_accesorio)
ALTER TABLE TB_DETALLE_PEDIDO_BICICLETA
ADD CONSTRAINT FK_DETALLE_BICICLETA FOREIGN KEY (cod_bicicleta) REFERENCES TB_BICICLETA(cod_bicicleta)

ALTER TABLE TB_DETALLE_PEDIDO_SCOOTER
ADD CONSTRAINT FK_DETALLE_PEDIDO_SCOOTER FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)
ALTER TABLE TB_DETALLE_PEDIDO_ACCESORIO
ADD CONSTRAINT FK_DETALLE_PEDIDO_ACCESORIO FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)
ALTER TABLE TB_DETALLE_PEDIDO_BICICLETA
ADD CONSTRAINT FK_DETALLE_PEDIDO_BICICLETA FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)



----------------------------------------------------------------------------------------------------------------------------------------
					/*INSERTANDO REGISTROS NECESARIO*/

--INSERT UBIGEO (COMPLETO)


--INSERT DIRECCION (5 A 10 DIRECCIONES)


--INSERT CLIENTE (5 A 10) 


--INSERT TRABAJADOR ----> SERA EL ADMINISTRADOR DE LA PAGINA


--INSERT MARCA (TODAS LAS MARCAS DEL MERCADO QUE PRODUCEN NUESTROS PRODUCTOS )

--SCOOTER

INSERT TB_MARCA VALUES('Xiomi')
INSERT TB_MARCA VALUES('Cecotec')
INSERT TB_MARCA VALUES('Segway Ninebot')
INSERT TB_MARCA VALUES('Razor Power')
INSERT TB_MARCA VALUES('Revolt')

--BICICLETA
INSERT TB_MARCA VALUES('Monark')
INSERT TB_MARCA VALUES('Monarette')
INSERT TB_MARCA VALUES('Giant')
INSERT TB_MARCA VALUES('Liv')
INSERT TB_MARCA VALUES('Felt')


SELECT * FROM TB_MARCA

--INSERT SCOOTER (10 A 15)

INSERT TB_SCOOTER VALUES('Scooter Eléctrico XIAOMI M365 PRO',1,'Neumaticos de 8.5 pulgadas inflables','Negro','25 km/h','Brushless 300W','De disco ventilado trasero de 120 mm y un sistema de frenos antibloqueo regenerativo E-ABS delantero','Aleación de aluminio',1899,5,null)

INSERT TB_SCOOTER VALUES('Scooter electrico Xiaomi M365',1,'Neumaticos de 8.5 pulgadas inflables','Negro','25 km/h','Brushless 250W','Sistema de frenado de disco y un sistema de frenado antibloqueo regenerativo eABS','Aleación de aluminio',1399,2,null)

INSERT TB_SCOOTER VALUES('Scooter electrico Bongo Serie S Unlimited',2,'Tubeless antirreventón de 10 pulgadas','Negro','25 km/h','Potencia nominal de 350W','Doble disco de freno delantero y trasero','Aleación de aluminio',2321,3,null)

INSERT TB_SCOOTER VALUES('Scooter electrico Bongo Serie A',2,'Tubeless antirreventón de 8,5 pulgadas','Gris','25 km/h','Potencia nominal de 350W','Triple sistema de frenado de seguridad extrema disco-electrico-manual','Aleación de aluminio',1264.57,4,null)

INSERT TB_SCOOTER VALUES('Scooter Eléctrico Ninebot Max G30P',3,'Neumatico de 10 pulgadas','Gris','25 km/h','350W Brushless','De tambor delantero mecánico simultáneo y el posterior eléctrico regenerativo','Aleación de aluminio',2799,2,null)

INSERT TB_SCOOTER VALUES('Scooter electrico Ninebot ES3',3,'Llanta sólida de 8 pulgadas','Negro','25 km/h','Potencia nominal de 250W','Electrónico y mecánico','Aleación de aluminio',1999.5,5,null)

INSERT TB_SCOOTER VALUES('Scooter electrico Razor E300',4,'Neumático de 10 pulgadas inflables','Gris','24 km/h','Potencia de 250W','Delantero','Aleación de aluminio',999.89,3,null)

INSERT TB_SCOOTER VALUES('Scooter eléctrico E-Prime III',4,'Neumático delantero de 8 pulgada','Negro','18 km/h','Potencia de 250W','Trasero','Aleación de aluminio',1649.33,2,null)

INSERT TB_SCOOTER VALUES('Scooter eléctrico N4',5,'Neumático delantero de 8 pulgadas con cámara','Negro','25 km/h','Brushless 300W','De disco delantero y freno de pie posterior','Aleación de aluminio',1199,2,null)

INSERT TB_SCOOTER VALUES('Scooter Electrico Silver N2',5,'Llantas de 8.5 tubeless','Gris','25 km/h','Brushless 250W','Delantero','Aleación de aluminio',1099,2,null)

select * from TB_SCOOTER
go



--INSERT ACCESORIO (10 A 15)


--INSERT BICICLETA (10 A 15)

INSERT TB_SCOOTER VALUES('Bicicleta Mirage',1,'24','Negro','V Brake','16 kg',849,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta Tricicargo Crosstown',1,'26','Negro','V Brake delantero y tambor posterior','20 kg',1699,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta Delta ADV',2,'26','Negro Verde','Disco Delantero y V Brake Trasero','16 kg',549,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta Master Bike',2,'26','Negro Verde','V Brake','18 kg',459,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta XTC JR',3,'20','Metallic Blue','Alloy Linear Pull','18 kg',1199,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta 2020 Suede 2',3,'26','Azul','Aluminio Direct Pull','18 kg',1899,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta Enchant',4,'20','Azul','Alloy Linear Pull','17 kg',1099,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta TEMPT 3',4,'27.5','Negro','SHIMANO M315','19 kg',2799,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta Fr Advanced Ultegra Plasma Red',5,'24','Rojo','Disco hidráulico Shimano BR8070','10 kg',2500,2,null)

INSERT TB_SCOOTER VALUES('Bicicleta Fr Advanced Ultegra Aquafresh',5,'24','Oceano','Disco hidráulico Shimano BR8070','10 kg',2500,2,null)	


--INSERT TRABAJADOR (1 a 4)
insert TB_TRABAJADOR (nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador) values ('Carlos', 'Gomez', '87654321', 'carlos@gmail.com', '987654321', 't20201', '123');
insert TB_TRABAJADOR (nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador) values ('Pablo', 'Saravia', '82654322', 'pablo@gmail.com', '985644322', 't20202', '123');
insert TB_TRABAJADOR (nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador) values ('Eduardo', 'Cordoba', '87558393', 'eduardo@gmail.com', '985423433', 't20203', '123');

--GENERAR PEDIDO (2 A 5 )



/*CADA INSERCION TIENE QUE ESTAR BIEN REALIZADA*/





-------------------------------------------------------------------------------------------------------------------------------------------------------------------
														/*GENERAR SP*/

/*** TABLA CLIENTE *****/

update dbo.TB_CLIENTE set estado_cliente=1
go


create proc usp_Cliente_Buscar
@correo varchar(250),@password_cliente varchar(10)
as
begin
	select correo_cliente,password_cliente,nom_cliente,ape_cliente 
	from TB_CLIENTE 
	where correo_cliente=@correo and password_cliente=@password_cliente
end 
go


create proc usp_Cliente_Insertar
@nom_cliente varchar(200),@ape_cliente varchar(200),@dni_cliente char(8),@correo_cliente varchar(250),@cel_cliente char(9),@password_cliente varchar(10)
as
begin
	insert dbo.TB_CLIENTE(nom_cliente,ape_cliente,dni_cliente,correo_cliente,cel_cliente,password_cliente,estado_cliente)
	Values(@nom_cliente,@ape_cliente,@dni_cliente,@correo_cliente,@cel_cliente,@password_cliente,1)
end 
go


create proc usp_Cliente_Actualizar
@cod_cliente int,@nom_cliente varchar(200),@ape_cliente varchar(200),@dni_cliente char(8),@correo_cliente varchar(250),@cel_cliente char(9),@username_cliente varchar(10),@password_cliente varchar(10)
as
begin	
	update dbo.TB_CLIENTE 
	set nom_cliente=@nom_cliente,
		ape_cliente=@ape_cliente,
		dni_cliente=@dni_cliente,
		correo_cliente=@correo_cliente,
		cel_cliente=@cel_cliente,
		password_cliente=@password_cliente
	where cod_cliente=@cod_cliente
end 
go


-----------------------------------------------------------------------------
/*** TABLA SCOOTER *****/

create proc usp_Scooter_Listar
as
begin
	select cod_scooter,descrp_scooter,s.cod_marca,m.descrp_marca,aro_scooter,color_scooter,velocidad_scooter,motor_scooter,freno_scooter,material_scooter,precio_scooter,stock_scooter
	from TB_SCOOTER s 
	join TB_MARCA m on s.cod_marca=m.cod_marca
end
go


create proc usp_Scooter_Consultar
@descp_scooter varchar(350),
@cod_marca int 
as
begin
	select cod_scooter,descrp_scooter,m.descrp_marca,aro_scooter,color_scooter,velocidad_scooter,motor_scooter,freno_scooter,material_scooter,precio_scooter,stock_scooter
	from TB_SCOOTER s 
	join TB_MARCA m on s.cod_marca=m.cod_marca
	where @descp_scooter='' or  UPPER(descrp_scooter)=UPPER(@descp_scooter) and s.cod_marca=@cod_marca 
end
go



create proc usp_Marca_Listar
as
begin
	select cod_marca,descrp_marca
	from TB_MARCA 
end
go



-----------------------------------------------------------------------------
/*** TABLA TRABAJADOR *****/

create or alter proc usp_Trabajador_Buscar
@username varchar(20),
@password varchar(20)
as
begin
	select nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador
	from TB_TRABAJADOR
	where username_trabajador = @username and password_trabajador = @password
end
go