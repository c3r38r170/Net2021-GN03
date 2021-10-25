INSERT INTO especialidades(desc_especialidad) 
VALUES ('descripcion uno')

INSERT planes(desc_plan, id_especialidad) 
VALUES ('descripcion 1 de plan', '1')

INSERT personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) 
VALUES ('Ivan', 'Pirito', 'Pellegrini 1345', 'IvanPi@asdff.com', '341 475 2070', '2000/10/08', '68990', '1', '1'),
       ('Cebelinda', 'Parada', '', 'asdff@ffdsa.com', '341 678 7890', '1983/01/18', '12345', '2', '1'),
	   ('Profesor', 'Profesor', 'Aca nomas 923', 'Profesor@profesor.com', '111 111 1111', '2000/01/01', '11111', '3', '1')

INSERT INTO usuarios( nombre_usuario, clave, habilitado, nombre, apellido, email, cambia_clave, id_persona) 
VALUES ('admin', 'admin', '1', 'Juana', 'De Arco', 'juanaDARC@juanalacuaba.com', '0', '2'),
       ('Profesor', 'Profesor', '1', 'Professor', 'Professor', 'pp@dppff.com', '0', '7'),
	   ('Visual', 'studio', '1', 'Cebelinda', '=)', 'CebePara@lindada.com', '0', '3')


INSERT comisiones(desc_comision, anio_especialidad, id_plan) 
VALUES ('comision 301', '2035', '1'),
       ('comision 302', '2011', '1')

INSERT materias(desc_materia, hs_semanales, hs_totales, id_plan) 
VALUES ('Matematica inferior', '6', '205', '1'),
       ('Java', '4', '193', '1'),
	   ('FisicaII','3','200','1')

INSERT cursos(id_materia, id_comision, anio_calendario, cupo) 
VALUES ('1', '1', '2021', '64'),
       ('3', '2', '2021', '100') 

INSERT INTO modulos(desc_modulo, ejecuta)
VALUES('descripcion de 1er modulo', 'el que ejecuta?')

