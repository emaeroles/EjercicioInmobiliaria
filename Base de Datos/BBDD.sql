create database inmobiliaria
go
use inmobiliaria
go

create table tipos_doc(
id_tipo_doc int primary key identity(1,1),
tipo_doc varchar(30)
)

create table personas(
id_persona int primary key identity(1,1),
nombre varchar(80),
id_tipo_doc int
constraint fk_personas_tipos_doc foreign key(id_tipo_doc)
	references tipos_doc(id_tipo_doc),
documento varchar(50),
sexo int
)

create table propietarios(
id_propietario int primary key identity(1,1),
id_persona int
constraint fk_propietario_personas foreign key(id_propietario)
	references personas(id_persona),
)

create table tipos_inmuebles(
id_tipo_inmueble int primary key identity(1,1),
tipo_inmueble varchar(30)
)

create table inmuebles(
id_inmuebles int primary key identity(1,1),
metros decimal,
costo_por_metro money,
id_tipo_inmueble int
constraint fk_inmuebles_tipos_inmuebles foreign key(id_tipo_inmueble)
	references tipos_inmuebles(id_tipo_inmueble),
id_propietario int
constraint fk_inmuebles_propietario foreign key(id_propietario)
	references propietarios(id_propietario)
)

----------- INSERTS TIPOS -------------------------------------------------------------------------

insert into tipos_doc(tipo_doc)
values ('DNI')
insert into tipos_doc(tipo_doc)
values ('Pasaporte')
insert into tipos_doc(tipo_doc)
values ('Cedula')

insert into tipos_inmuebles(tipo_inmueble)
values ('Casa')
insert into tipos_inmuebles(tipo_inmueble)
values ('Departamento')
insert into tipos_inmuebles(tipo_inmueble)
values ('Lote')

----------- INSERTS PROPIETARIOS E INMUEBLES ------------------------------------------------------

--Diego (1)
insert into personas(nombre, id_tipo_doc, documento, sexo)
values('Diego', 1, '28846523', 2)
insert into propietarios(id_persona)
values (1)

--Casa (1)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (150, 1100, 1, 1)

--Lote (3)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (300, 110, 3, 1)

---------------------------------------------------------------------------------------------------
--Ramon (2)
insert into personas(nombre, id_tipo_doc, documento, sexo)
values('Ramon', 1, '30465876', 2)
insert into propietarios(id_persona)
values (2)

--Departameto (2)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (80, 1500, 2, 2)

--Lote (3)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (250, 130, 3, 2)

---------------------------------------------------------------------------------------------------
--Sara (3)
insert into personas(nombre, id_tipo_doc, documento, sexo)
values('Sara', 1, '33456851', 1)
insert into propietarios(id_persona)
values (3)

--Casa (1)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (110, 1200, 1, 3)

--Departameto (2)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (50, 1200, 2, 3)

---------------------------------------------------------------------------------------------------
--Rocio (4)
insert into personas(nombre, id_tipo_doc, documento, sexo)
values('Rocio', 2, '32459741', 1)
insert into propietarios(id_persona)
values (4)

--Departameto (2)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (30, 1100, 2, 4)

--Lote (3)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (400, 90, 3, 4)

---------------------------------------------------------------------------------------------------
--Eliana (5)
insert into personas(nombre, id_tipo_doc, documento, sexo)
values('Eliana', 1, '12856849', 1)
insert into propietarios(id_persona)
values (5)

--Casa (1)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (120, 1000, 1, 5)

--Lote (3)
insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (250, 125, 3, 5)