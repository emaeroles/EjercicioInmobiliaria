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

insert into personas(nombre, id_tipo_doc, documento, sexo)
values ('Ema', (select id_tipo_doc from tipos_doc where tipo_doc = 'DNI'), '23084893', 1)

select top 1 id_persona
from personas
order by id_persona desc

insert into propietarios(id_persona)
values (0)

select metros, costo_por_metro, id_tipo_inmueble, p.id_propietario
from propietarios p join inmuebles i on p.id_propietario = i.id_propietario

select id_propietario, nombre from propietarios po join personas pe on pe.id_persona = po.id_persona


select * from tipos_doc
select * from tipos_inmuebles
select * from inmuebles
select * from propietarios
select * from personas



insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario)
values (0, 0, 0, 0)

insert into personas(nombre, id_tipo_doc, documento, sexo)
values('', 0, '', 0)

select top 1 id_persona from personas order by id_persona desc
insert into propietarios(id_persona)
values(0)

