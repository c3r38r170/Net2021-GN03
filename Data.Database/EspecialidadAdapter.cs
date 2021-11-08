﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database {
	public class EspecialidadAdapter : Adapter {

		public List<Especialidad> GetAll() {
			List<Especialidad> especialidades = new List<Especialidad>();
			OpenConnection();
			SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades", sqlConn);
			try {
				SqlDataReader drEspecialidades = cmdEspecialidad.ExecuteReader();
				while (drEspecialidades.Read()) {
					Especialidad e = new Especialidad();
					e.ID = (int)drEspecialidades["id_especialidad"];
					e.Descripcion = (string)drEspecialidades["desc_especialidad"];
					especialidades.Add(e);
				}
				drEspecialidades.Close();
			} catch (Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades.", Ex);
				throw ExcepcionManejada;
			} finally {
				CloseConnection();
			}
			return especialidades;
		}

		public Especialidad GetOne(int ID) {
			Especialidad especialidad = new Especialidad();
			OpenConnection();
			SqlCommand cmdEspecialidad = new SqlCommand("SelectEspecialidadById", sqlConn);
			cmdEspecialidad.CommandType = CommandType.StoredProcedure;
			cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;
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
				CloseConnection();
			}
			return especialidad;
		}

		public void Delete(int ID) {
			OpenConnection();
			SqlCommand cmdEspecialidad = new SqlCommand("DeleteEspecialidad", sqlConn);
			cmdEspecialidad.CommandType = CommandType.StoredProcedure;
			cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			cmdEspecialidad.ExecuteNonQuery();
		}

		public void Save(Especialidad especialidad) {
			if (especialidad.State == BusinessEntity.States.New) {
				OpenConnection();
				SqlCommand cmdEspecialidad = new SqlCommand("NuevaEspecialidad", sqlConn);
				cmdEspecialidad.CommandType = CommandType.StoredProcedure;
				cmdEspecialidad.Parameters.Add("@desc", SqlDbType.VarChar).Value = especialidad.Descripcion;
				cmdEspecialidad.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmdEspecialidad.ExecuteNonQuery();
				especialidad.ID = (int)cmdEspecialidad.Parameters["@ID"].Value;
				CloseConnection();
			} else if (especialidad.State == BusinessEntity.States.Deleted) {
				Delete(especialidad.ID);
			} else if (especialidad.State == BusinessEntity.States.Modified) {
				OpenConnection();
				SqlCommand cmdEspecialidad = new SqlCommand("EditarEspecialidad", sqlConn);
				cmdEspecialidad.CommandType = CommandType.StoredProcedure;
				cmdEspecialidad.Parameters.Add("@desc", SqlDbType.VarChar).Value = especialidad.Descripcion;
				cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
				cmdEspecialidad.ExecuteNonQuery();
				CloseConnection();
			}
			especialidad.State = BusinessEntity.States.Unmodified;
		}
	}
}
