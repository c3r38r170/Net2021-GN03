using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Database
{
    public class PlanAdapter: Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> listaPlanes = new List<Plan>();		
			SqlCommand cmd = new SqlCommand("SELECT * FROM planes", sqlConn);
			try
			{
				this.OpenConnection();
				SqlDataReader drPlan = cmd.ExecuteReader();
				while (drPlan.Read())
				{
					Plan p = new Plan();
					p.ID = (int)drPlan["id_plan"];
					p.Descripcion = (string)drPlan["desc_plan"];
					p.IDEspecialidad = (int)drPlan["id_especialidad"];
					listaPlanes.Add(p);
				}
				drPlan.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar Planes", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return listaPlanes;
		}

        public void Save(Plan plan)
        {
            try
            {
				this.OpenConnection();
				if (plan.State == BusinessEntity.States.New)
				{				
					SqlCommand cmd = new SqlCommand("INSERT INTO planes (desc_plan,id_especialidad) VALUES (@desc,@espe); SET @ID = SCOPE_IDENTITY();", sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.Add("@desc", System.Data.SqlDbType.VarChar).Value = plan.Descripcion;
					cmd.Parameters.Add("@espe", System.Data.SqlDbType.Int).Value = plan.IDEspecialidad;
					cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
					cmd.ExecuteNonQuery();
					plan.ID = (int)cmd.Parameters["@ID"].Value;					
				}
				else if (plan.State == BusinessEntity.States.Deleted)
				{
					this.Delete(plan.ID);
				}
				else if (plan.State == BusinessEntity.States.Modified)
				{
					SqlCommand cmd = new SqlCommand("UPDATE planes SET desc_plan=@descripcionPlan,id_especialidad=@idEspecialidad WHERE id_plan=@id", sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.Add("@descripcionPlan", System.Data.SqlDbType.VarChar).Value = plan.Descripcion;
					cmd.Parameters.Add("@idEspecialidad", System.Data.SqlDbType.Int).Value = plan.IDEspecialidad;
					cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = plan.ID;
					cmd.ExecuteNonQuery();	
				}
				plan.State = BusinessEntity.States.Unmodified;
			}
			catch(Exception Ex)
            {
				Exception ExcepcionManejada = new Exception("Error al recuperar Planes", Ex);
				throw ExcepcionManejada;
			}
            finally
            {
				this.CloseConnection();
			}
        }

        public void Delete(int ID)
        {
			SqlCommand cmd = new SqlCommand("DELETE FROM planes WHERE id_plan=@id", sqlConn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
            try
            {
				this.OpenConnection();
				cmd.ExecuteNonQuery();
				
			}catch(Exception Ex)
            {
				Exception ExcepcionManejada = new Exception("Error al recuperar Planes", Ex);
				throw ExcepcionManejada;
            }
            finally
            {
				this.CloseConnection();
			}
			
		}

        public Plan GetOne(int iD)
        {
			Plan p = new Plan();
			SqlCommand cmd = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", sqlConn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = iD;
			try
			{
				this.OpenConnection();
				SqlDataReader drPlan = cmd.ExecuteReader();
				if (drPlan.Read())
				{
					p.ID = (int)drPlan["id_plan"];
					p.Descripcion = (string)drPlan["desc_plan"];
					p.IDEspecialidad = (int)drPlan["id_especialidad"];
				}
				drPlan.Close();
			}
			catch (Exception Ex)
			{
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return p;
		}

        public List<Especialidad> CargaComboBox()
        {
			List<Especialidad> listaEspecialidades = new List<Especialidad>();
			SqlCommand mycomando = new SqlCommand("SELECT * FROM especialidades", sqlConn);
            try
            {
				this.OpenConnection();
				SqlDataReader mydr = mycomando.ExecuteReader();
				while (mydr.Read())
				{
					Especialidad e = new Especialidad();
					e.ID = (int)mydr["id_especialidad"];
					e.Descripcion = (string)mydr["desc_especialidad"];
					listaEspecialidades.Add(e);
				}
            }
            catch (Exception e)
            {
				Exception ExcepcionManejada = new Exception("Error al Cargar el ComboBox de planes", e);
				throw ExcepcionManejada;
            }
            finally
            {
				this.CloseConnection();
			}
			
			return listaEspecialidades;
		}
    }
}
