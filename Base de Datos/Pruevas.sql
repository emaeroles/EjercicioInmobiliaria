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
