/*Ejecutar cada procedimiento aparte.
No olvidar especificar la base de datos (ej: "USE academia;")*/

/*Comisiones*/

CREATE PROCEDURE [dbo].[SelectComisionById]
  @id INT
AS
  BEGIN
  SELECT * FROM comisiones WHERE id_comision=@id;
END;

CREATE PROCEDURE [dbo].[DeleteComision]
  @id INT
A
  BEGIN
  DELETE FROM comisiones WHERE id_comision=@id;
END;

CREATE PROCEDURE [dbo].[NuevaComision]
  @anioe INT
  ,@descc NVARCHAR(50)
  ,@idp INT
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO comisiones (anio_especialidad,desc_comision,id_plan) VALUES (@anioe,@descc,@idp);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarComision]
  @anioe INT
  ,@descc NVARCHAR(50)
  ,@idp INT
  ,@ID INT
AS
  BEGIN
  UPDATE comisiones SET anio_especialidad=@anioe,desc_comision=@descc,id_plan=@idp WHERE id_comision=@ID;
END;

/*Cursos*/

CREATE PROCEDURE [dbo].[SelectCursoById]
  @id INT
AS
  BEGIN
  SELECT * FROM cursos WHERE id_curso=@id;
END;

CREATE PROCEDURE [dbo].[DeleteCurso]
  @id INT
AS
  BEGIN
  DELETE FROM cursos WHERE id_curso=@id;
END;

CREATE PROCEDURE [dbo].[NuevoCurso]
  @anioc INT
  ,@cupo INT
  ,@idc INT
  ,@idm INT
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO cursos (anio_calendario,cupo,id_comision,id_materia) VALUES (@anioc,@cupo,@idc,@idm);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarCurso]
  @anioc INT
  ,@cupo INT
  ,@idc INT
  ,@idm INT
  ,@ID INT
AS
  BEGIN
  UPDATE cursos SET anio_calendario=@anioc,cupo=@cupo,id_comision=@idc,id_materia=@idm WHERE id_curso=@ID;
END;

/*Especialidades*/

CREATE PROCEDURE [dbo].[SelectEspecialidadById]
  @id INT
AS
  BEGIN
  SELECT * FROM especialidades WHERE id_especialidad=@id;
END;

CREATE PROCEDURE [dbo].[DeleteEspecialidad]
  @id INT
AS
  BEGIN
  DELETE FROM especialidades WHERE id_especialidad=@id;
END;

CREATE PROCEDURE [dbo].[NuevaEspecialidad]
  @desc NVARCHAR(50)
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO especialidades (desc_especialidad) VALUES (@desc);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarEspecialidad]
  @desc NVARCHAR(50)
  ,@ID INT
AS
  BEGIN
  UPDATE especialidades SET desc_especialidad=@desc WHERE id_especialidad=@id;
END;

/*Materias*/

CREATE PROCEDURE [dbo].[SelectMateriaById]
  @id INT
AS
  BEGIN
  SELECT * FROM materias WHERE id_materia=@id;
END;

CREATE PROCEDURE [dbo].[DeleteMateria]
  @id INT
AS
  BEGIN
  DELETE FROM materias WHERE id_materia=@id;
END;

CREATE PROCEDURE [dbo].[NuevaMateria]
  @desc NVARCHAR(50)
  ,@hss INT
  ,@hst INT
  ,@idp INT
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO materias (desc_materia,hs_semanales,hs_totales,id_plan) VALUES (@desc,@hss,@hst,@idp);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarMateria]
  @desc NVARCHAR(50)
  ,@hss INT
  ,@hst INT
  ,@idp INT
  ,@ID INT
AS
  BEGIN
  UPDATE materias SET desc_materia=@desc,hs_semanales=@hss,hs_totales=@hst,id_plan=@idp WHERE id_materia=@ID;
END;

/*Personas*/

CREATE PROCEDURE [dbo].[SelectPersonaById]
  @id INT
AS
  BEGIN
  SELECT * FROM personas WHERE id_persona=@id;
END;

CREATE PROCEDURE [dbo].[DeletePersona]
  @id INT
AS
  BEGIN
  DELETE FROM personas WHERE id_persona=@id;
END;

CREATE PROCEDURE [dbo].[NuevaPersona]
  @nombre NVARCHAR(50)
  ,@apellido NVARCHAR(50)
  ,@direccion NVARCHAR(50)
  ,@email NVARCHAR(50)
  ,@telefono NVARCHAR(50)
  ,@fecha_nac DATETIME
  ,@legajo INT
  ,@tipo_persona INT
  ,@id_plan INT
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) VALUES (@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarPersona]
  @nombre NVARCHAR(50)
  ,@apellido NVARCHAR(50)
  ,@direccion NVARCHAR(50)
  ,@email NVARCHAR(50)
  ,@telefono NVARCHAR(50)
  ,@fecha_nac DATETIME
  ,@legajo INT
  ,@tipo_persona INT
  ,@id_plan INT
  ,@ID INT
AS
  BEGIN
  UPDATE personas SET nombre=@nombre,apellido=@apellido,direccion=@direccion,email=@email,telefono=@telefono,fecha_nac=@fecha_nac,legajo=@legajo,tipo_persona=@tipo_persona,id_plan=@id_plan WHERE id_persona=@id;
END;

/*Planes*/

CREATE PROCEDURE [dbo].[SelectPlanById]
  @id INT
AS
  BEGIN
  SELECT * FROM planes WHERE id_plan=@id;
END;

CREATE PROCEDURE [dbo].[DeletePlan]
  @id INT
AS
  BEGIN
  DELETE FROM planes WHERE id_plan=@id;
END;

CREATE PROCEDURE [dbo].[NuevoPlan]
  @desc NVARCHAR(50)
  ,@espe INT
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO planes (desc_plan,id_especialidad) VALUES (@desc,@espe);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarPlan]
  @descripcionPlan NVARCHAR(50)
  ,@idEspecialidad INT
  ,@ID INT
AS
  BEGIN
  UPDATE planes SET desc_plan=@descripcionPlan,id_especialidad=@idEspecialidad WHERE id_plan=@id;
END;

/*Usuarios*/

CREATE PROCEDURE [dbo].[SelectUsuarioById]
  @id INT
AS
  BEGIN
  SELECT * FROM usuarios WHERE id_usuario=@id;
END;

CREATE PROCEDURE [dbo].[DeleteUsuario]
  @id INT
AS
  BEGIN
  DELETE FROM usuarios WHERE id_usuario=@id;
END;

CREATE PROCEDURE [dbo].[NuevoUsuario]
  @nombre NVARCHAR(50)
  ,@apellido NVARCHAR(50)
  ,@clave NVARCHAR(50)
  ,@usuario NVARCHAR(50)
  ,@habilitado BIT
  ,@email NVARCHAR(50)
  ,@id_persona INT
  ,@ID INT OUTPUT
AS
  BEGIN
  INSERT INTO usuarios (nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona) VALUES (@usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona);
  SET @ID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE [dbo].[EditarUsuario]
  @nombre NVARCHAR(50)
  ,@apellido NVARCHAR(50)
  ,@clave NVARCHAR(50)
  ,@usuario NVARCHAR(50)
  ,@habilitado BIT
  ,@email NVARCHAR(50)
  ,@id_persona INT
  ,@ID INT
AS
  BEGIN
  UPDATE usuarios SET nombre_usuario=@usuario,clave=@clave,habilitado=@habilitado,nombre=@nombre,apellido=@apellido,email=@email,id_persona=@id_persona WHERE id_usuario=@id;
END;

CREATE PROCEDURE [dbo].[GetUsuarioByNombreUsuarioYContraseña]
	@nombre_usuario NVARCHAR(50)
	,@clave NVARCHAR(50)
AS
	BEGIN
	SELECT id_usuario FROM usuarios WHERE nombre_usuario=@nombre_usuario AND clave=@clave;
END;

/*Resets*/
DROP PROCEDURE DeleteCurso;
DROP PROCEDURE DeleteComision;
DROP PROCEDURE DeleteEspecialidad;
DROP PROCEDURE DeleteMateria;
DROP PROCEDURE DeletePersona;
DROP PROCEDURE DeletePlan;
DROP PROCEDURE DeleteUsuario;
DROP PROCEDURE EditarComision;
DROP PROCEDURE EditarCurso;
DROP PROCEDURE EditarEspecialidad;
DROP PROCEDURE EditarMateria;
DROP PROCEDURE EditarPersona;
DROP PROCEDURE EditarPlan;
DROP PROCEDURE EditarUsuario;
DROP PROCEDURE GetUsuarioByNombreUsuarioYContraseña;
DROP PROCEDURE NuevaComision;
DROP PROCEDURE NuevaEspecialidad;
DROP PROCEDURE NuevaMateria;
DROP PROCEDURE NuevaPersona;
DROP PROCEDURE NuevoCurso;
DROP PROCEDURE NuevoPlan;
DROP PROCEDURE NuevoUsuario;
DROP PROCEDURE SelectComisionById;
DROP PROCEDURE SelectCursoById;
DROP PROCEDURE SelectEspecialidadById;
DROP PROCEDURE SelectMateriaById;
DROP PROCEDURE SelectPersonaById;
DROP PROCEDURE SelectPlanById;
DROP PROCEDURE SelectUsuarioById;