using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
	{
		public List<Materia> GetAll()
		{
			List<Materia> materias = new List<Materia>();
			this.OpenConnection();
			SqlCommand cmdMateria= new SqlCommand("SELECT * FROM materias", sqlConn);
			try
			{

				SqlDataReader drMaterias = cmdMateria.ExecuteReader();
				while (drMaterias.Read())
				{
					Materia m = new Materia();
					m.ID = (int)drMaterias["id_materia"];
					m.Descripcion = (string)drMaterias["desc_materia"];
					m.HSSemanales = (int)drMaterias["hs_semanales"];
					m.HSTotales = (int)drMaterias["hs_totales"];
					m.IDPlan = (int)drMaterias["id_plan"];
					materias.Add(m);
				}
				drMaterias.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return materias;
		}

        public object GetMateriasPlanes()
        {
			PlanAdapter pa = new PlanAdapter();

			List<Plan> listaPlanes = pa.GetAll();
			List<Materia> listaMateria = this.GetAll();

			DataTable dtMateriasPlanes = new DataTable();
			DataRow fila;
			DataColumn idMateria = new DataColumn("ID");
			DataColumn descMateria = new DataColumn("Descripcion Materia");
			DataColumn hsSemanales = new DataColumn("Horas Semanales");
			DataColumn hsTotales = new DataColumn("Horas Totales");
			DataColumn descPlan = new DataColumn("Plan");

			dtMateriasPlanes.Columns.Add(idMateria);
			dtMateriasPlanes.Columns.Add(descMateria);
			dtMateriasPlanes.Columns.Add(hsSemanales);
			dtMateriasPlanes.Columns.Add(hsTotales);
			dtMateriasPlanes.Columns.Add(descPlan);

			foreach (Materia m in listaMateria)
			{
				foreach (Plan p in listaPlanes)
				{
					if (m.IDPlan == p.ID)
					{
						fila = dtMateriasPlanes.NewRow();
						fila[idMateria] = m.ID;
						fila[descMateria] = m.Descripcion;
						fila[hsSemanales] = m.HSSemanales;
						fila[hsTotales] = m.HSTotales;
						fila[descPlan] = p.Descripcion;
						dtMateriasPlanes.Rows.Add(fila);
					}
				}
			}

			return dtMateriasPlanes;
		}

        public Materia GetOne(int ID)
		{
			Materia materia = new Materia();
			this.OpenConnection();
			SqlCommand cmdMateria = new SqlCommand("SelectMateriaById", sqlConn);
			cmdMateria.CommandType = CommandType.StoredProcedure;
			cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			try
			{
				SqlDataReader drMateria = cmdMateria.ExecuteReader();
				if (drMateria.Read())
				{
					materia.ID = (int)drMateria["id_materia"];
					materia.Descripcion = (string)drMateria["desc_materia"];
					materia.HSSemanales = (int)drMateria["hs_semanales"];
					materia.HSTotales = (int)drMateria["hs_totales"];
					materia.IDPlan = (int)drMateria["id_plan"];
				}
				drMateria.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar la materia.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return materia;
		}

		public void Delete(int ID)
		{
			this.OpenConnection();
			SqlCommand cmdMateria = new SqlCommand("DeleteMateria", sqlConn);
			cmdMateria.CommandType = CommandType.StoredProcedure;
			cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			cmdMateria.ExecuteNonQuery();
		}

		public void Save(Materia materia)
		{
            try
            {
				if (materia.State == BusinessEntity.States.New)
				{
					this.OpenConnection();
					SqlCommand cmdMateria = new SqlCommand("NuevaMateria", sqlConn);
					cmdMateria.CommandType = CommandType.StoredProcedure;
					cmdMateria.Parameters.Add("@desc", SqlDbType.VarChar).Value = materia.Descripcion;
					cmdMateria.Parameters.Add("@hss", SqlDbType.Int).Value = materia.HSSemanales;
					cmdMateria.Parameters.Add("@hst", SqlDbType.Int).Value = materia.HSTotales;
					cmdMateria.Parameters.Add("@idp", SqlDbType.Int).Value = materia.IDPlan;
					cmdMateria.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
					cmdMateria.ExecuteNonQuery();
					materia.ID = (int)cmdMateria.Parameters["@ID"].Value;
					this.CloseConnection();
				}
				else if (materia.State == BusinessEntity.States.Deleted)
				{
					this.Delete(materia.ID);
				}
				else if (materia.State == BusinessEntity.States.Modified)
				{
					this.OpenConnection();
					SqlCommand cmdMateria = new SqlCommand("EditarMateria", sqlConn);
					cmdMateria.CommandType = CommandType.StoredProcedure;
					cmdMateria.Parameters.Add("@desc", SqlDbType.VarChar).Value = materia.Descripcion;
					cmdMateria.Parameters.Add("@hss", SqlDbType.Int).Value = materia.HSSemanales;
					cmdMateria.Parameters.Add("@hst", SqlDbType.Int).Value = materia.HSTotales;
					cmdMateria.Parameters.Add("@idp", SqlDbType.Int).Value = materia.IDPlan;
					cmdMateria.Parameters.Add("@ID", SqlDbType.Int).Value = materia.ID;
					cmdMateria.ExecuteNonQuery();
					this.CloseConnection();
				}
				materia.State = BusinessEntity.States.Unmodified;
			}
            catch (Exception ex)
            {
				Exception ExcepcionManejada = new Exception("Error al recuperar la materia.", ex);
				throw ExcepcionManejada;
			}
			
		}
	}
}
