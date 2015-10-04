create database projectoPoi;
use projectoPoi;



create table cliente (
idCliente		int unsigned not null primary key,
nombreCliente	varchar(50),
passwordCliente varchar(50),
fotoCliente blob
);


create table publicacion(
idPublicacion 		int unsigned auto_increment not null primary key,
fechaPublicacion	datetime not null,
foreign key (idCliente) references cliente
);

create table grupoChat(

idGrupoChat int unsigned auto_increment not null primary key,
nombreGrupoChat varchar(50),
creadorGrupoChat int,
fotoGrupoChat blob
);

create table HistorialConver(
idHistorialConver int unsigned auto_increment not null primary key,
fechaConver datetime,
foreign key(idCliente) references cliente, 
foreign key(idGrupoChat) references grupoChat, 
);



create table  Multimedia(
TipoArchivo blob,
NombreArchivo varchar(50),
Destinatario varchar(30),
Remitente varchar(30)


)