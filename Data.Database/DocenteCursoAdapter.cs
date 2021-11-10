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
    public class DocenteCursoAdapter: Adapter
    {
        public List<DocenteCurso> GetAll() 
        {
            List<DocenteCurso> listaDocentesCuros = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM docentes_cursos", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)dr["id_dictado"];
                    dc.IDCurso = (int)dr["id_curso"];
                    dc.IDDocente = (int)dr["id_docente"];
                    dc.Cargo = (DocenteCurso.tipoCargo)dr["cargo"];
                    listaDocentesCuros.Add(dc);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return listaDocentesCuros;
        }

        public object GetCurosPorDocentes(int iDProfesor)
        {
            CursoAdapter ca = new CursoAdapter();
            DataTable dtCursosMateriasComisiones = (DataTable)ca.GetCursosMateriasComisiones();

            List<DocenteCurso> ListaDocentes_Cursos = this.GetAll();

            DataRow fila;
            DataTable dt = new DataTable();
            DataColumn IdCurso = new DataColumn("ID Curso");
            DataColumn Comision = new DataColumn("Comision");
            DataColumn Materia = new DataColumn("Materia");
            dt.Columns.Add(IdCurso);
            dt.Columns.Add(Comision);
            dt.Columns.Add(Materia);

            foreach (DocenteCurso dc in ListaDocentes_Cursos)
            {
                foreach (DataRow row in dtCursosMateriasComisiones.Rows)
                {
                    if (dc.IDCurso == int.Parse(row["ID"].ToString()))
                    {
                        fila = dt.NewRow();
                        fila[IdCurso] = dc.IDCurso;
                        fila[Comision] = row["Descripcion Comision"];
                        fila[Materia] = row["Descripcion Materia"];
                        dt.Rows.Add(fila);

                    }
                }
            }
            return dt;
        }

        public object GetAlumnosDeCurso(int IDProfesor)
        {
            DataRow fila;

            DataTable dt = new DataTable();
            DataColumn dcIdInscripcion = new DataColumn("ID inscripcion");
            DataColumn dcIdAlumno = new DataColumn("ID alumno");
            DataColumn dcCondicion = new DataColumn("Condicion");
            DataColumn dcNota = new DataColumn("Nota");
            DataColumn dcIdCurso = new DataColumn("ID Curso");
            dt.Columns.Add(dcIdCurso);
            dt.Columns.Add(dcIdInscripcion);
            dt.Columns.Add(dcIdAlumno);
            dt.Columns.Add(dcCondicion);
            dt.Columns.Add(dcNota);
            List<DocenteCurso> Lista = this.GetAll();
            List<DocenteCurso> ListaDocenteCursos = new List<DocenteCurso>();
            foreach (DocenteCurso dc in Lista)
            {
                if (dc.IDDocente == IDProfesor)
                {
                    ListaDocenteCursos.Add(dc);
                }
            }

            InscripcionAdapter ia = new InscripcionAdapter();
            List<AlumnoInscripcion> ListaAlumnosInscripcion = ia.GetAll();

            foreach (DocenteCurso dc in ListaDocenteCursos)
            {
                foreach (AlumnoInscripcion ai in ListaAlumnosInscripcion)
                {
                    if (dc.IDCurso == ai.IDCurso)
                    {
                        fila = dt.NewRow();
                        fila[dcIdInscripcion] = ai.ID;
                        fila[dcIdAlumno] = ai.IDAlumno;
                        fila[dcCondicion] = ai.Condicion;
                        fila[dcNota] = ai.Nota;
                        fila[dcIdCurso] = ai.IDCurso;
                        dt.Rows.Add(fila);
                    }
                }
            }

            CursoAdapter ca = new CursoAdapter();
            DataTable dt2 = (DataTable)ca.GetCursosMateriasComisiones();

            DataTable dt3 = new DataTable();
            DataColumn IDInscripcion = new DataColumn("ID inscripcion.");
            DataColumn IDAlumno = new DataColumn("ID alumno.");
            DataColumn Materia = new DataColumn("materia.");
            DataColumn Comision = new DataColumn("comision.");
            DataColumn Condicion = new DataColumn("condicion.");
            DataColumn Nota = new DataColumn("nota.");
            dt3.Columns.Add(IDInscripcion);
            dt3.Columns.Add(IDAlumno);
            dt3.Columns.Add(Materia);
            dt3.Columns.Add(Comision);
            dt3.Columns.Add(Condicion);
            dt3.Columns.Add(Nota);
            foreach (DataRow row1 in dt2.Rows)
            {
                foreach (DataRow row2 in dt.Rows)
                {
                    if (int.Parse(row1["ID"].ToString()) == int.Parse(row2[dcIdCurso].ToString()))
                    {
                        fila = dt3.NewRow();
                        fila[IDInscripcion] = row2[dcIdInscripcion];
                        fila[IDAlumno] = row2[dcIdAlumno];
                        fila[Materia] = row1["Descripcion Materia"];
                        fila[Comision] = row1["Descripcion Comision"];
                        fila[Condicion] = row2[dcCondicion];
                        fila[Nota] = row2[dcNota];
                        dt3.Rows.Add(fila);
                    }
                }
            }

            PersonaAdapter pa = new PersonaAdapter();
            List<Persona> ListaPersona = pa.GetAll();

            DataTable dtADevolver = new DataTable();
            DataColumn idInscripcion = new DataColumn("ID inscripcion");
            DataColumn nombreAlumno = new DataColumn("Nombre Alumno");
            DataColumn apellidoAlumno = new DataColumn("Apellido Alumno");
            DataColumn legajo = new DataColumn("Legajo Alumno");
            DataColumn materiaa = new DataColumn("Materia");
            DataColumn comision = new DataColumn("Comision");
            DataColumn condicion = new DataColumn("Condicion");
            DataColumn nota = new DataColumn("Nota");
            dtADevolver.Columns.Add(idInscripcion);
            dtADevolver.Columns.Add(nombreAlumno);
            dtADevolver.Columns.Add(apellidoAlumno);
            dtADevolver.Columns.Add(legajo);
            dtADevolver.Columns.Add(materiaa);
            dtADevolver.Columns.Add(comision);
            dtADevolver.Columns.Add(condicion);
            dtADevolver.Columns.Add(nota);
            foreach (DataRow row in dt3.Rows)
            {
                foreach (Persona p in ListaPersona)
                {
                    if (p.ID == int.Parse(row[IDAlumno].ToString()))
                    {
                        fila = dtADevolver.NewRow();
                        fila[idInscripcion] = row[IDInscripcion];
                        fila[nombreAlumno] = p.Nombre;
                        fila[apellidoAlumno] = p.Apellido;
                        fila[legajo] = p.Legajo;
                        fila[materiaa] = row[Materia];
                        fila[comision] = row[Comision];
                        fila[condicion] = row[Condicion];
                        fila[nota] = row[Nota];
                        dtADevolver.Rows.Add(fila);
                    }
                }
            }
            return dtADevolver;
        }

        public void Save(DocenteCurso docenteCursoActual)
        {
            if (docenteCursoActual.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCursoActual.ID);
            }
            else if (docenteCursoActual.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCursoActual);
            }
            else if (docenteCursoActual.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCursoActual);
            }
            docenteCursoActual.State = BusinessEntity.States.Unmodified;
        }

        private void Update(DocenteCurso docenteCursoActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente, cargo=@cargo WHERE id_dictado=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docenteCursoActual.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCursoActual.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCursoActual.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCursoActual.Cargo;

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

        private void Insert(DocenteCurso docenteCursoActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO docentes_cursos (id_curso, id_docente, cargo) VALUES (@id_curso,@id_docente,@cargo); SET @ID = SCOPE_IDENTITY();", sqlConn);

                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCursoActual.IDCurso;
                cmd.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCursoActual.IDDocente;
                cmd.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCursoActual.Cargo;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                //usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());//asi se obtiene el ID que se asigno a la BD automaticamente
                cmd.ExecuteNonQuery();
                docenteCursoActual.ID = (int)cmd.Parameters["@ID"].Value;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al Insertar docente_curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DocenteCurso GetOne(int iD)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from docentes_cursos where id_dictado=@id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = iD;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dc.ID = (int)dr["id_dictado"];
                    dc.IDCurso = (int)dr["id_curso"];
                    dc.IDDocente = (int)dr["id_docente"];
                    dc.Cargo = (DocenteCurso.tipoCargo)dr["cargo"];
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
            return dc;
        }

        public void Delete(int iD)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("delete from docentes_cursos where id_dictado=@id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = iD;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar docente_curso: {0}", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}

