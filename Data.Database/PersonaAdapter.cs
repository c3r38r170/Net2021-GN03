using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database {
	public class PersonaAdapter : Adapter {
		public List<Persona> GetAll() {
			List<Persona> personas = new List<Persona>();
			this.OpenConnection();
			SqlCommand cmdPersona = new SqlCommand("SELECT * FROM personas", sqlConn);
			try {

				SqlDataReader drPersonas = cmdPersona.ExecuteReader();
				while (drPersonas.Read()) {
					Persona p = new Persona();
					fillPersonaFromDataReader(drPersonas, p);
					personas.Add(p);
				}
				drPersonas.Close();
			} catch (Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas.", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return personas;
		}

		public Persona GetOne(int ID) {
			Persona persona = new Persona();
			this.OpenConnection();
			SqlCommand cmdPersona = new SqlCommand("SelectPersonaById", sqlConn);
			cmdPersona.CommandType = CommandType.StoredProcedure;
			cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			try {
				SqlDataReader drPersona = cmdPersona.ExecuteReader();
				if (drPersona.Read()) {
					fillPersonaFromDataReader(drPersona, persona);
				}
				drPersona.Close();
			} catch (Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception excepcionManejada = new Exception("Error al recuperar la persona.", Ex);
				throw excepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return persona;
		}

		public void Delete(int ID) {
			this.OpenConnection();
			SqlCommand cmdPersona = new SqlCommand("DeletePersona", sqlConn);
			cmdPersona.CommandType = CommandType.StoredProcedure;
			cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			cmdPersona.ExecuteNonQuery();
		}

		public void Save(Persona persona) {
			if (persona.State == BusinessEntity.States.New) {
				this.OpenConnection();
				SqlCommand cmdPersona = createCommandWithAttributes("NuevaPersona", persona);
				cmdPersona.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmdPersona.ExecuteNonQuery();
				persona.ID = (int)cmdPersona.Parameters["@ID"].Value;
				this.CloseConnection();
			} else if (persona.State == BusinessEntity.States.Deleted) {
				this.Delete(persona.ID);
			} else if (persona.State == BusinessEntity.States.Modified) {
				this.OpenConnection();
				SqlCommand cmdPersona = createCommandWithAttributes("EditarPersona", persona);
				cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
				cmdPersona.ExecuteNonQuery();
				this.CloseConnection();
			}
			persona.State = BusinessEntity.States.Unmodified;
		}

		private void fillPersonaFromDataReader(SqlDataReader dR,Persona p) {
			p.ID = (int)dR["id_persona"];
			p.Nombre = (string)dR["nombre"];
			p.Apellido = (string)dR["apellido"];
			p.Direccion = (string)dR["direccion"];
			p.Email = (string)dR["email"];
			p.Telefono = (string)dR["telefono"];
			p.FechaNacimiento = DateTime.Parse((string)dR["fecha_nac"]);
			p.Legajo = (int)dR["legajo"];
			switch ((int)dR["tipo_persona"]) {
				case 1:
					p.TipoPersona = Persona.Tipo.Docente;
					break;
				case 2:
					p.TipoPersona = Persona.Tipo.Alumno;
					break;
				default:
					p.TipoPersona = Persona.Tipo.Otro;
					break;
			}
			//TODO quizas querramos traer el plan y hacer una propiedad .Plan
			p.IDPlan = (int)dR["id_plan"];
			//p.Plan=PlanAdapter.getOne(p.IDPlan);
		}

		private SqlCommand createCommandWithAttributes(string c,Persona p) {
			SqlCommand sc = new SqlCommand(c, sqlConn);
			sc.CommandType = CommandType.StoredProcedure;
			sc.Parameters.Add("@nombre", SqlDbType.VarChar).Value = p.Nombre;
			sc.Parameters.Add("@apellido", SqlDbType.VarChar).Value = p.Apellido;
			sc.Parameters.Add("@direccion", SqlDbType.VarChar).Value = p.Direccion;
			sc.Parameters.Add("@email", SqlDbType.VarChar).Value = p.Email;
			sc.Parameters.Add("@telefono", SqlDbType.VarChar).Value = p.Telefono;
			sc.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = p.FechaNacimiento;
			sc.Parameters.Add("@legajo", SqlDbType.Int).Value = p.Legajo;
			sc.Parameters.Add("@tipo_persona", SqlDbType.Int).Value =(int)p.TipoPersona;
			sc.Parameters.Add("@id_plan", SqlDbType.Int).Value = p.IDPlan;
			return sc;
		}
	}
}
