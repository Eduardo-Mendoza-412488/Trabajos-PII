CREATE DATABASE Transacción
GO
USE Transacción
/*USE master
DROP DATABASE Transacción*/
CREATE TABLE FormasPago(
id_formaPago INT IDENTITY(1,1),
forma_pago VARCHAR(50),
CONSTRAINT pk_id_formaPago PRIMARY KEY(id_formaPago))
--select * from articulos
CREATE TABLE Articulos(
id_articulo INT IDENTITY(1,1),
articulo VARCHAR(50),
estado bit
CONSTRAINT pk_id_articulo PRIMARY KEY(id_articulo))
---select * from Detalle_Facturas
CREATE TABLE Facturas(
nro_factura INT IDENTITY(1,1),
fecha DATETIME,
id_formaPago INT,
cliente varchar(50),
esta_activo bit
CONSTRAINT pk_nro_factura PRIMARY KEY(nro_factura)
CONSTRAINT fk_id_formPago FOREIGN KEY(id_formaPago)
	REFERENCES FormasPago (id_formaPago))

CREATE TABLE Detalle_Facturas(
id INT,
nro_factura INT,
id_articulo INT,
cantidad INT
CONSTRAINT fk_id_articulo FOREIGN KEY(id_articulo)
	REFERENCES Articulos (id_articulo))


--Clientes
INSERT INTO Articulos(articulo, estado) VALUES('Gaseosa', 1)
INSERT INTO Articulos(articulo,estado) VALUES('Leche',1)
INSERT INTO Articulos(articulo,estado) VALUES('Galletas',1)

--Forma de pago
INSERT INTO FormasPago(forma_pago) VALUES('Efectivo')
INSERT INTO FormasPago(forma_pago) VALUES('Tarjeta')
--select * from articulos
--Facturas
INSERT INTO Facturas(fecha, id_formaPago, cliente, esta_activo) VALUES(getdate(), 2, 'Hernan', 1)

--Detalle Facturas
INSERT INTO detalle_Facturas(id ,nro_factura, id_articulo, cantidad) VALUES(1,1, 1, 2)
INSERT INTO detalle_Facturas(id ,nro_factura, id_articulo, cantidad) VALUES(2,1, 3, 5)

go

Create Procedure SP_RECUPERAR_FACTURA
AS

BEGIN
	SELECT f.*, fp.forma_pago FROM Facturas f, FormasPago fp WHERE fp.id_formaPago= f.id_formaPago
END

GO
--SELECT f.*, fp.forma_pago FROM Facturas f, FormasPago fp WHERE fp.id_formaPago= f.id_formaPago
Create Procedure SP_RECUPERAR_DETALLE_FACTURA
@codigo int
AS
BEGIN
	SELECT d.*, a.articulo FROM Detalle_Facturas d, Articulos a WHERE nro_factura = @codigo and d.id_articulo= a.id_articulo
END

go

--select * from facturas
--select * from detalle_facturas


create procedure SP_GUARDAR_MAESTRO
@codigo int = 0,
@codFPago int, 
@cliente varchar(50),
@id int output
AS
BEGIN 
	IF @codigo = 0
		BEGIN
			Insert into Facturas(fecha, id_formaPago, cliente, esta_activo) 
			values (getdate(), @codFPago, @cliente, 1);
			set @id = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			update Facturas 
			set id_formaPago = @codFPago,
				cliente = @cliente
				where nro_factura=@codigo
		END
END

go

create procedure SP_INSERTAR_DETALLES
@codigo int ,
@nroFactura int,
@idArt int,
@cantidad int
AS
BEGIN
	INSERT INTO Detalle_Facturas (id, nro_factura, id_articulo, cantidad)
	VALUES(@codigo, @nrofactura, @idArt, @cantidad)
END

go
--select * from facturas
create procedure SP_BAJA_FACTURA
@codigo int
AS
BEGIN 
	UPDATE Facturas
	SET esta_activo = 0
	WHERE nro_factura = @codigo
END

------SP de Articulos

go

create procedure SP_GUARDAR_ARTICULO
@codigo int,
@articulo varchar(50)
AS  
BEGIN 
	IF @codigo = 0
		BEGIN
			Insert into Articulos(articulo, estado) 
			values (@articulo, 1);
		END
	ELSE
		BEGIN
			update Articulos 
			set articulo = @articulo
				where id_articulo=@codigo
		END
END


go
--------------------

CREATE PROCEDURE RECUPERAR_ARTICULOS
AS
BEGIN
	select * from Articulos
END

go
------------------

CREATE PROCEDURE RECUPERAR_ARTICULOxID
@codigo int
AS
BEGIN
	select * from Articulos where id_articulo = @codigo
END
--
go 

CREATE PROCEDURE BAJA_ARTICULO
@codigo int
AS
BEGIN
	update Articulos
	SET estado = 0
	WHERE id_articulo = @codigo
END


