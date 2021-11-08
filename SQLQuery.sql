BEGIN TRANSACTION;

/*TODO: Hacer DROP IF NOT EXISTS y CREATE de cada tabla para que si hacemos algún cambio, podamos replicarlo fácilmente.*/

TRUNCATE TABLE docentes_cursos;
TRUNCATE TABLE modulos_usuarios;
TRUNCATE TABLE alumnos_inscripciones;

DELETE FROM usuarios;
DELETE FROM personas;
DELETE FROM cursos;
DELETE FROM materias;
DELETE FROM comisiones;
DELETE FROM modulos;
DELETE FROM planes;
DELETE FROM especialidades;

SET IDENTITY_INSERT especialidades ON;
INSERT INTO especialidades (id_especialidad, desc_especialidad) VALUES (1,'descripcion uno');
SET IDENTITY_INSERT especialidades OFF;

SET IDENTITY_INSERT planes ON;
INSERT planes(id_plan, desc_plan, id_especialidad) VALUES (1, 'descripcion 1 de plan', 1);
SET IDENTITY_INSERT planes OFF;

SET IDENTITY_INSERT modulos ON;
INSERT INTO modulos(id_modulo,desc_modulo, ejecuta) VALUES (1, 'descripcion de 1er modulo', 'el que ejecuta?');
SET IDENTITY_INSERT modulos OFF;

SET IDENTITY_INSERT comisiones ON;
INSERT comisiones (id_comision,desc_comision, anio_especialidad, id_plan) VALUES
	(1,'comision 301', 2020, 1),
    (2,'comision 302', 2011, 1);
SET IDENTITY_INSERT comisiones OFF;
	
SET IDENTITY_INSERT materias ON;
INSERT materias(id_materia,desc_materia, hs_semanales, hs_totales, id_plan) VALUES
	(1,'Matematica inferior', 6, 205, 1),
    (2,'Java', 4, 193, 1),
	(3,'FisicaII',3,200,1);
SET IDENTITY_INSERT materias OFF;

SET IDENTITY_INSERT cursos ON;
INSERT cursos (id_curso,id_materia, id_comision, anio_calendario, cupo) VALUES
	(1,1, 1, 2021, 64),
    (2,3, 2, 2021, 100);
SET IDENTITY_INSERT cursos OFF;

SET IDENTITY_INSERT personas ON;
INSERT personas (id_persona,nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) VALUES
	(1,'Ivan', 'Pirito', 'Pellegrini 1345', 'IvanPi@asdff.com', '3414752070', '09-10-2000', 68990, 2, 1),
	(2,'Juana', 'De Arco', 'RD 8989', 'juanitanita@googler.com', '3412022020', '08-09-1999', 4568, 3, 1),
	(3,'Cerena', 'Parra', '', 'Parraceri@fasfa.com', '341687890', '18-01-1983', 12345, 2,1),
	(4,'Profesor', 'Profesor', 'Aca nomas 923', 'Profesor@profesor.com', '1111111111', '01-01-2000', 11111, 1, 1);
SET IDENTITY_INSERT personas OFF;

SET IDENTITY_INSERT usuarios ON;
INSERT INTO usuarios (id_usuario, nombre_usuario, clave, habilitado, nombre, apellido, email, cambia_clave, id_persona) VALUES
	(1,'admin', 'admin', 1, 'Juana', 'De Arco', 'juanaDARC@juanalacuaba.com', 0, 2),
    (2,'Profesor', 'Profesor', 1, 'Professor', 'Professor', 'pp@dppff.com', 0, 4),
	(3,'Visual', 'studio', 1, 'Cebelinda', '=)', 'CebePara@lindada.com', 0, 3),
	(4,'ivanpirito','pirito123',1,'Ivan','Pirito','IvanPi@asdff.com',0,1);
SET IDENTITY_INSERT usuarios OFF;

COMMIT;