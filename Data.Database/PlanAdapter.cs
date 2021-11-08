using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Database {
	public class PlanAdapter : Adapter {
		public List<Plan> GetAll() {
			List<Plan> listaPlanes = new List<Plan>();
			try {
				this.OpenConnection();
				SqlCommand cmd = new SqlCommand("SELECT * FROM planes", sqlConn);
				SqlDataReader drPlan = cmd.ExecuteReader();
				while(drPlan.Read()) {
					Plan p = new Plan();
					p.ID = (int)drPlan["id_plan"];
					p.Descripcion = (string)drPlan["desc_plan"];
					p.IDEspecialidad = (int)drPlan["id_especialidad"];
					listaPlanes.Add(p);
				}
				drPlan.Close();
			} catch(Exception Ex) {
				Exception ExcepcionManejada = new Exception("Error al recuperar Planes", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return listaPlanes;
		}

		public object GetPlanesEspecialidad() {
			EspecialidadAdapter ea = new EspecialidadAdapter();

			List<Plan> listaPlanes = this.GetAll();
			List<Especialidad> listaEspecialidades = ea.GetAll();

			DataTable dtPlanesEspecialidades = new DataTable();
			DataRow fila;
			DataColumn dcIdPlan = new DataColumn("ID");
			DataColumn dcDescPlan = new DataColumn("Descripcion Plan");
			DataColumn dcDescEspecialidad = new DataColumn("Descripcion Especialidad");
			dtPlanesEspecialidades.Columns.Add(dcIdPlan);
			dtPlanesEspecialidades.Columns.Add(dcDescPlan);
			dtPlanesEspecialidades.Columns.Add(dcDescEspecialidad);

			foreach(Plan p in listaPlanes) {
				foreach(Especialidad e in listaEspecialidades) {
					if(p.IDEspecialidad == e.ID) {
						fila = dtPlanesEspecialidades.NewRow();
						fila[dcIdPlan] = p.ID;
						fila[dcDescPlan] = p.Descripcion;
						fila[dcDescEspecialidad] = e.Descripcion;
						dtPlanesEspecialidades.Rows.Add(fila);
					}
				}
			}

			return dtPlanesEspecialidades;
		}

		public void Save(Plan plan) {
			
				this.OpenConnection();
				if(plan.State == BusinessEntity.States.New) {
					SqlCommand cmd = new SqlCommand("NuevoPlan", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
					cmd.Parameters.Add("@espe", SqlDbType.Int).Value = plan.IDEspecialidad;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
					cmd.ExecuteNonQuery();
					plan.ID = (int)cmd.Parameters["@ID"].Value;
				} else if(plan.State == BusinessEntity.States.Deleted) {
					this.Delete(plan.ID);
				} else if(plan.State == BusinessEntity.States.Modified) {
					SqlCommand cmd = new SqlCommand("EditarPlan", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@descripcionPlan", SqlDbType.VarChar).Value = plan.Descripcion;
					cmd.Parameters.Add("@idEspecialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
					cmd.ExecuteNonQuery();
				}
				plan.State = BusinessEntity.States.Unmodified;
			
		}

		public void Delete(int ID) {
            try
            {
				this.OpenConnection();
				SqlCommand cmd = new SqlCommand("DeletePlan", sqlConn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
				cmd.ExecuteNonQuery();
			}
		    catch(Exception e)
            {
				Exception ExcepcionManejada = new Exception("Error al recuperar Planes", e);
				throw ExcepcionManejada;
			}
            finally
            {
				this.CloseConnection();
            }
	

		}

		public Plan GetOne(int iD) {
			Plan p = new Plan();
			SqlCommand cmd = new SqlCommand("SelectPlanById", sqlConn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = iD;
			try {
				this.OpenConnection();
				SqlDataReader drPlan = cmd.ExecuteReader();
				if(drPlan.Read()) {
					p.ID = (int)drPlan["id_plan"];
					p.Descripcion = (string)drPlan["desc_plan"];
					p.IDEspecialidad = (int)drPlan["id_especialidad"];
				}
				drPlan.Close();
			} catch(Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return p;
		}
	}
}
