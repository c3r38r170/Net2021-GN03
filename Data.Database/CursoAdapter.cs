using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
		public List<Curso> GetAll()
		{
			List<Curso> cursos = new List<Curso>();
			this.OpenConnection();
			SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos", sqlConn);
			try
			{

				SqlDataReader drCurso = cmdCurso.ExecuteReader();
				while (drCurso.Read())
				{
					Curso cur = new Curso();
					cur.ID = (int)drCurso["id_curso"];
					cur.AñoCalendario = (int)drCurso["anio_calendario"];
					cur.Cupo = (int)drCurso["cupo"];
					cur.IDComision = (int)drCurso["id_comision"];
					cur.IDMateria = (int)drCurso["id_materia"];
					cursos.Add(cur);
				}
				drCurso.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return cursos;
		}

		public Curso GetOne(int ID)
		{
			Curso cur = new Curso();
			this.OpenConnection();
			SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", sqlConn);
			cmdCurso.CommandType = System.Data.CommandType.StoredProcedure;
			cmdCurso.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			try
			{
				SqlDataReader drCurso = cmdCurso.ExecuteReader();
				if (drCurso.Read())
				{
					cur.ID = (int)drCurso["id_comision"];
					cur.AñoCalendario = (int)drCurso["anio_calendario"];
					cur.Cupo = (int)drCurso["cupo"];
					cur.IDComision = (int)drCurso["id_comision"];
					cur.IDMateria = (int)drCurso["id_materia"];
				}
				drCurso.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar el curso.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return cur;
		}

		public void Delete(int ID)
		{
			this.OpenConnection();
			SqlCommand cmdCurso = new SqlCommand("DELETE FROM cursos WHERE id_curso=@id", sqlConn);
			cmdCurso.CommandType = System.Data.CommandType.StoredProcedure;
			cmdCurso.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			cmdCurso.ExecuteNonQuery();
		}

		public void Save(Curso cur)
		{
			if (cur.State == BusinessEntity.States.New)
			{
				this.OpenConnection();
				SqlCommand cmdCurso = new SqlCommand("INSERT INTO cursos (anio_calendario,cupo,id_comision,id_materia) VALUES (@anioc,@cupo,@idc,@idm); SET @ID = SCOPE_IDENTITY();", sqlConn);
				cmdCurso.CommandType = System.Data.CommandType.StoredProcedure;
				cmdCurso.Parameters.Add("@anioc", System.Data.SqlDbType.Int).Value = cur.AñoCalendario;
				cmdCurso.Parameters.Add("@cupo", System.Data.SqlDbType.Int).Value = cur.Cupo;
				cmdCurso.Parameters.Add("@idc", System.Data.SqlDbType.Int).Value = cur.IDComision;
				cmdCurso.Parameters.Add("@idm", System.Data.SqlDbType.Int).Value = cur.IDMateria;
				cmdCurso.Parameters.Add("@ID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
				cmdCurso.ExecuteNonQuery();
				cur.ID = (int)cmdCurso.Parameters["@ID"].Value;
				this.CloseConnection();
			}
			else if (cur.State == BusinessEntity.States.Deleted)
			{
				this.Delete(cur.ID);
			}
			else if (cur.State == BusinessEntity.States.Modified)
			{
				this.OpenConnection();
				SqlCommand cmdCurso = new SqlCommand("UPDATE cursos SET anio_calendario=@anioc,cupo=@cupo,id_comision=@idc,id_materia=@idm WHERE id_curso=@ID", sqlConn);
				cmdCurso.CommandType = System.Data.CommandType.StoredProcedure;
				cmdCurso.Parameters.Add("@anioc", System.Data.SqlDbType.Int).Value = cur.AñoCalendario;
				cmdCurso.Parameters.Add("@cupo", System.Data.SqlDbType.Int).Value = cur.Cupo;
				cmdCurso.Parameters.Add("@idc", System.Data.SqlDbType.Int).Value = cur.IDComision;
				cmdCurso.Parameters.Add("@idm", System.Data.SqlDbType.Int).Value = cur.IDMateria;
				cmdCurso.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = cur.ID;
				cmdCurso.ExecuteNonQuery();
				this.CloseConnection();
			}
			cur.State = BusinessEntity.States.Unmodified;
		}
	}
}
