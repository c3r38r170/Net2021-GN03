using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class InscripcionAdapter: Adapter
    {
        public void Save(AlumnoInscripcion al)
        {
            if (al.State == BusinessEntity.States.Deleted)
            {
                this.Delete(al.ID);
            }
            else if (al.State == BusinessEntity.States.New)
            {
                this.Insert(al);
            }
            else if (al.State == BusinessEntity.States.Modified)
            {
                this.Update(al);
            }
            al.State = BusinessEntity.States.Unmodified;
        }

        public object MateriasPorAlumno(int idPersonaActual)
        {
            List<AlumnoInscripcion> ListaInscripcionesAlumnoActual = this.GetInscripcionesAlumnoActual(idPersonaActual);

            DataTable dtInscripcionCurso = new DataTable();
            DataColumn dcIdInscripcion = new DataColumn("ID inscripcion");
            DataColumn dcIdCurso = new DataColumn("ID curso");
            DataColumn dcCondicion = new DataColumn("Condicion");
            DataColumn dcNota = new DataColumn("Nota");
            DataColumn dcIdMateria = new DataColumn("ID Materia");
            DataColumn dcIdComision = new DataColumn("ID comision");
            dtInscripcionCurso.Columns.Add(dcIdInscripcion);
            dtInscripcionCurso.Columns.Add(dcIdCurso);
            dtInscripcionCurso.Columns.Add(dcCondicion);
            dtInscripcionCurso.Columns.Add(dcNota);
            dtInscripcionCurso.Columns.Add(dcIdMateria);
            dtInscripcionCurso.Columns.Add(dcIdComision);

            DataRow fila;
            //LLENO LISTA CON TODOS LOS CURSOS
            CursoAdapter ca = new CursoAdapter();
            List<Curso> ListaCursos = ca.GetAll();

            foreach (AlumnoInscripcion ai in ListaInscripcionesAlumnoActual)
            {
                foreach (Curso c in ListaCursos)
                {
                    if (ai.IDCurso == c.ID)
                    {
                        fila = dtInscripcionCurso.NewRow();
                        fila[dcIdInscripcion] = ai.ID;
                        fila[dcIdCurso] = c.ID;
                        fila[dcCondicion] = ai.Condicion;
                        fila[dcNota] = ai.Nota;
                        fila[dcIdMateria] = c.IDMateria;
                        fila[dcIdComision] = c.IDComision;
                        dtInscripcionCurso.Rows.Add(fila);
                    }
                }
            }
            //LLENO LISTA CON TODAS LAS COMISIONES
            ComisionAdapter comAdap = new ComisionAdapter();
            List<Comision> ListaComisiones = comAdap.GetAll();
            //CREO TABLA A CUASI DEVOLVER
            DataTable dtACuasiDevolver = new DataTable();
            DataColumn dcIDInscripcion = new DataColumn("ID inscripcion");
            DataColumn dcMateria = new DataColumn("Materia");
            DataColumn dcComision = new DataColumn("Comision");
            DataColumn dcCondicionn = new DataColumn("Condicion");
            DataColumn dcNotaa = new DataColumn("Nota");
            dtACuasiDevolver.Columns.Add(dcIDInscripcion);
            dtACuasiDevolver.Columns.Add(dcMateria);
            dtACuasiDevolver.Columns.Add(dcComision);
            dtACuasiDevolver.Columns.Add(dcCondicionn);
            dtACuasiDevolver.Columns.Add(dcNotaa);
            //CARGO TABLA2
            foreach (DataRow row in dtInscripcionCurso.Rows)
            {
                foreach (Comision c in ListaComisiones)
                {
                    if (int.Parse(row["ID comision"].ToString()) == c.ID)
                    {
                        fila = dtACuasiDevolver.NewRow();
                        fila[dcIDInscripcion] = row["ID inscripcion"];
                        fila[dcMateria] = row["ID Materia"];
                        fila[dcComision] = c.Descripcion;
                        fila[dcCondicionn] = row["Condicion"];
                        fila[dcNotaa] = row["Nota"];
                        dtACuasiDevolver.Rows.Add(fila);
                    }
                }
            }

            //LLENO LISTA CON MATERIAS
            MateriaAdapter ma = new MateriaAdapter();
            List<Materia> ListaMaterias = ma.GetAll();
            //CREO TABLA A DEVOLVER
            DataTable dtADevolver = new DataTable();
            DataColumn IdInscripcion = new DataColumn("ID inscripcion.");
            DataColumn Materia = new DataColumn("Materia.");
            DataColumn Comision = new DataColumn("Comision.");
            DataColumn Condicion = new DataColumn("Condicion.");
            DataColumn Nota = new DataColumn("Nota.");
            dtADevolver.Columns.Add(IdInscripcion);
            dtADevolver.Columns.Add(Materia);
            dtADevolver.Columns.Add(Comision);
            dtADevolver.Columns.Add(Condicion);
            dtADevolver.Columns.Add(Nota);
            //CARGO TABLA A DEVOLVER
            foreach (DataRow row in dtACuasiDevolver.Rows)
            {
                foreach (Materia m in ListaMaterias)
                {
                    if (int.Parse(row["Materia"].ToString()) == m.ID)
                    {
                        fila = dtADevolver.NewRow();
                        fila[IdInscripcion] = row["ID inscripcion"];
                        fila[Materia] = m.Descripcion;
                        fila[Comision] = row["Comision"];
                        fila[Condicion] = row["Condicion"];
                        fila[Nota] = row["Nota"];
                        dtADevolver.Rows.Add(fila);
                    }
                }
            }
            return dtADevolver;
        }

        public object GetAlumnosInscriptosEnCurso(int dcurso)
        {
            List<AlumnoInscripcion> ListaAlumnosInscripciones = this.GetAll();

            DataRow fila;
            DataTable dt = new DataTable();
            DataColumn IdInscripcion = new DataColumn("");
            DataColumn IdAlumno = new DataColumn("");
            DataColumn Condicion = new DataColumn("");
            DataColumn Nota = new DataColumn("");
            dt.Columns.Add(IdInscripcion);
            dt.Columns.Add(IdAlumno);
            dt.Columns.Add(Condicion);
            dt.Columns.Add(Nota);

            foreach (AlumnoInscripcion ai in ListaAlumnosInscripciones)
            {
                if (ai.IDCurso == dcurso)
                {
                    fila = dt.NewRow();
                    fila[IdInscripcion] = ai.ID;
                    fila[IdAlumno] = ai.IDAlumno;
                    fila[Condicion] = ai.Condicion;
                    fila[Nota] = ai.Nota;
                    dt.Rows.Add(fila);
                }
            }

            DataRow fila2;
            DataTable dtQseDevuelve = new DataTable();
            DataColumn IDInscripcion = new DataColumn("ID inscripcion");
            DataColumn Nombre = new DataColumn("Nombre");
            DataColumn Apellido = new DataColumn("Apellido");
            DataColumn Legajo = new DataColumn("Legajo");
            DataColumn Condition = new DataColumn("Condicion");
            DataColumn Notaa = new DataColumn("Nota");
            dtQseDevuelve.Columns.Add(IDInscripcion);
            dtQseDevuelve.Columns.Add(Nombre);
            dtQseDevuelve.Columns.Add(Apellido);
            dtQseDevuelve.Columns.Add(Legajo);
            dtQseDevuelve.Columns.Add(Condition);
            dtQseDevuelve.Columns.Add(Notaa);

            PersonaAdapter pa = new PersonaAdapter();
            List<Persona> ListaPersonas = pa.GetAll();

            foreach (Persona p in ListaPersonas)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (p.ID == int.Parse(row[IdAlumno].ToString()))
                    {
                        fila2 = dtQseDevuelve.NewRow();
                        fila2[IDInscripcion] = row[IdInscripcion];
                        fila2[Nombre] = p.Nombre;
                        fila2[Apellido] = p.Apellido;
                        fila2[Legajo] = p.Legajo;
                        fila2[Condition] = row[Condicion];
                        fila2[Notaa] = row[Nota];
                        dtQseDevuelve.Rows.Add(fila2);
                    }
                }
            }
            return dtQseDevuelve;
        }

        public AlumnoInscripcion GetOne(int iD)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = iD;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ai.ID = (int)dr["id_inscripcion"];
                    ai.IDAlumno = (int)dr["id_alumno"];
                    ai.IDCurso = (int)dr["id_curso"];
                    ai.Condicion = (string)dr["condicion"];
                    ai.Nota = (int)dr["nota"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ai;
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumnoActual(int idPersona)
        {
            List<AlumnoInscripcion> ListaTodasLasInscripciones = this.GetAll();
            List<AlumnoInscripcion> ListaInscripcionesAlumnoActual = new List<AlumnoInscripcion>();

            foreach (AlumnoInscripcion ai in ListaTodasLasInscripciones)
            {
                if (ai.IDAlumno == idPersona)
                {
                    ListaInscripcionesAlumnoActual.Add(ai);
                }
            }

            return ListaInscripcionesAlumnoActual;
        }

        public List<AlumnoInscripcion> GetAlumnosPorCurso(int idCurso)
        {
            return new List<AlumnoInscripcion>( this.GetAll().Where(a=>a.IDCurso==idCurso) );
        }

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> ListaInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)dr["id_inscripcion"];
                    ai.IDAlumno = (int)dr["id_alumno"];
                    ai.IDCurso = (int)dr["id_curso"];
                    ai.Condicion = (string)dr["condicion"];
                    ai.Nota = (int)dr["nota"];
                    ListaInscripciones.Add(ai);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Inscripciones.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return ListaInscripciones;
        }

        private void Update(AlumnoInscripcion al)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET nota=@nota, condicion=@condicion WHERE id_inscripcion=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = al.ID;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = al.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = al.Condicion;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al Modificar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        private void Delete(int iD)
        {
            throw new NotImplementedException();
        }

        private void Insert(AlumnoInscripcion al)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion, nota) VALUES (@id_alumno,@id_curso,@condicion,@nota); SET @ID = SCOPE_IDENTITY();", sqlConn);

                cmd.Parameters.Add("@id_alumno", SqlDbType.Int).Value = al.IDAlumno;
                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = al.IDCurso;
                cmd.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = al.Condicion;
                cmd.Parameters.Add("@nota", SqlDbType.Int).Value = al.Nota;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                //e.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());//asi se obtiene el ID que se asigno a la BD automaticamente
                cmd.ExecuteNonQuery();
                al.ID = (int)cmd.Parameters["@ID"].Value;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error en la inscripcion:", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


    }
}

