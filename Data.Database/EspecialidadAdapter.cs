using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
	public class EspecialidadAdapter : Adapter {

		public List<Especialidad> GetAll() {
			List<Especialidad> especialidades = new List<Especialidad>();
			this.OpenConnection();
			SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades", sqlConn);
			try {

				SqlDataReader drEspecialidades = cmdEspecialidad.ExecuteReader();
				while (drEspecialidades.Read()) {
					Especialidad e = new Especialidad();
					e.Descripcion = (string)drEspecialidades["desc_especialidad"];
					especialidades.Add(e);
				}
				drEspecialidades.Close();
			} catch (Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades.", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return especialidades;
		}

		public Especialidad GetOne(int ID) {
			Especialidad especialidad = new Especialidad();
			this.OpenConnection();
			SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", sqlConn);
			cmdEspecialidad.CommandType = System.Data.CommandType.StoredProcedure;
			cmdEspecialidad.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			try {
				SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();
				if (drEspecialidad.Read()) {
					especialidad.ID = (int)drEspecialidad["id_especialidad"];
					especialidad.Descripcion = (string)drEspecialidad["desc_especialidad"];
				}
				drEspecialidad.Close();
			} catch (Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar la especialidad.", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return especialidad;
		}

		public void Delete(int ID) {
			this.OpenConnection();
			SqlCommand cmdEspecialidad = new SqlCommand("DELETE FROM especialidades WHERE id_especialidad=@id", sqlConn);
			cmdEspecialidad.CommandType = System.Data.CommandType.StoredProcedure;
			cmdEspecialidad.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			cmdEspecialidad.ExecuteNonQuery();
		}

		public void Save(Especialidad especialidad) {
			if (especialidad.State == BusinessEntity.States.New) {
				this.OpenConnection();
				SqlCommand cmdEspecialidad = new SqlCommand("INSERT INTO especialidades (desc_especialidad) VALUES (@desc); SET @ID = SCOPE_IDENTITY();", sqlConn);
				cmdEspecialidad.CommandType = System.Data.CommandType.StoredProcedure;
				cmdEspecialidad.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = especialidad.Descripcion;
				cmdEspecialidad.Parameters.Add("@ID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
				cmdEspecialidad.ExecuteNonQuery();
				especialidad.ID = (int)cmdEspecialidad.Parameters["@ID"].Value;
				this.CloseConnection();
			} else if (especialidad.State == BusinessEntity.States.Deleted) {
				this.Delete(especialidad.ID);
			} else if (especialidad.State == BusinessEntity.States.Modified) {
				this.OpenConnection();
				SqlCommand cmdEspecialidad = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc WHERE id_especialidad=@id", sqlConn);
				cmdEspecialidad.CommandType = System.Data.CommandType.StoredProcedure;
				cmdEspecialidad.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = especialidad.Descripcion;
				cmdEspecialidad.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = especialidad.ID;
				cmdEspecialidad.ExecuteNonQuery();
				this.CloseConnection();
			}
			especialidad.State = BusinessEntity.States.Unmodified;
		}
	}
}
