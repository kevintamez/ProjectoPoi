create database PuntoDeVenta;

use PuntoDeVenta;

create table Usuario(
idUsuario int unsigned not null primary key,
nombreUsuario varchar(25),
email varchar(50),
contraseña varchar(50),
apellidoMaternoUsuario varchar(25),
apellidoPaternoUsuario varchar(25),
tipoUsuario enum('Manager','Cajero'),
CURP varchar(18),
RFC varchar(50),
nivelDeEstudios enum('Universidad','Preparatoria','Secundaria','Primaria'),
estado varchar(25),
pais varchar(50),
calle varchar(10),
colonia varchar(25),
fechaNacimiento date,
fotoUsuario mediumblob,

idSucursal int unsigned not null,

foreign key (idSucursal) references sucursal(idSucursal)

);

Create table empresa(
idEmpresa int unsigned not null primary key,
nombreEmpresa varchar(25),

);

Create table sucursal(
idSucursal int unsigned not null primary key,
nombreSucursal varchar(25),
direccionSucursal varchar(50),
idEmpresa int unsigned not null,
foreign key (idEmpresa) references empresa(idEmpresa)
);
create table producto (
idProducto int unsigned not null primary key,
nombreProducto varchar(50),
descripcionLarga text,
descripcionCorta varchar(50),
precio double,
imagenProducto mediumblob
);

create table Departamento(
idDepartamento int unsigned not null primary key,
nombreDepartamento varchar(30)
);



create table venta(
folio int unsigned not null primary key,
Cliente_id int unsigned not null,
Producto_id int unsigned not null,
foreign key(Cliente_id) references Usuario(idUsuario)
);

create table ventaDetalle(
)


-- Store Procedure
create Precedure agregarManager(
email varchar(50),
nombre varchar(50),
contraseña varchar(50),
nombreEmpresa varchar(25)
) 
BEGIN
insert into usuario(email,nombre,contraseña) values(email, nombre, contraseña)
insert into empresa(nombreEmpresa) values(nombreEmpresa)
END