using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
	class EspecialidadAdapter : Adapter {

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
			SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", sqlConn);
			cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			try {
				SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
				if (drUsuario.Read()) {
					especialidad.ID = (int)drUsuario["id_especialidad"];
					especialidad.Descripcion = (string)drUsuario["desc_especialidad"];
				}
				drUsuario.Close();
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
			SqlCommand cmdUsuario = new SqlCommand("DELETE FROM especialidades WHERE id_especialidad=@id", sqlConn);
			cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			cmdUsuario.ExecuteNonQuery();
		}

		public void Save(Especialidad especialidad) {
			if (especialidad.State == BusinessEntity.States.New) {
				this.OpenConnection();
				SqlCommand cmdUsuario = new SqlCommand("INSERT INTO especialidades (desc_especialidad) VALUES (@desc); SET @ID = SCOPE_IDENTITY();", sqlConn);
				cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
				cmdUsuario.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = especialidad.Descripcion;
				cmdUsuario.Parameters.Add("@ID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
				cmdUsuario.ExecuteNonQuery();
				especialidad.ID = (int)cmdUsuario.Parameters["@ID"].Value;
				this.CloseConnection();
			} else if (especialidad.State == BusinessEntity.States.Deleted) {
				this.Delete(especialidad.ID);
			} else if (especialidad.State == BusinessEntity.States.Modified) {
				this.OpenConnection();
				SqlCommand cmdUsuario = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc WHERE id_especialidad=@id", sqlConn);
				cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
				cmdUsuario.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = especialidad.Descripcion;
				cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = especialidad.ID;
				cmdUsuario.ExecuteNonQuery();
				this.CloseConnection();
			}
			especialidad.State = BusinessEntity.States.Unmodified;
		}
	}
}
