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
    public class ComisionAdapter : Adapter
    {
		public List<Comision> GetAll()
		{
			List<Comision> comisiones = new List<Comision>();
			this.OpenConnection();
			SqlCommand cmdComision = new SqlCommand("SELECT * FROM comisiones", sqlConn);
			try
			{

				SqlDataReader drComision = cmdComision.ExecuteReader();
				while (drComision.Read())
				{
					Comision com = new Comision();
					com.ID = (int)drComision["id_comision"];
					com.AñoEspecialidad = (int)drComision["anio_especialidad"];
					com.Descripcion = (string)drComision["desc_comision"];
					com.IDPlan = (int)drComision["id_plan"];
					comisiones.Add(com);
				}
				drComision.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return comisiones;
		}

        public object GetComisionesPlanes()
        {
			PlanAdapter pa = new PlanAdapter();

			List<Comision> listaComisiones = this.GetAll();
			List<Plan> listaPlanes = pa.GetAll();

			DataTable dtComisionesPlaes = new DataTable();
			DataRow fila;
			DataColumn dcIdComision = new DataColumn("ID");
			DataColumn dcDescComision = new DataColumn("Descripcion Comision");
			DataColumn dcAnioEspecialidad = new DataColumn("Año Especialidad");
			DataColumn dcDescPlan = new DataColumn("Descripcion Plan");

			dtComisionesPlaes.Columns.Add(dcIdComision);
			dtComisionesPlaes.Columns.Add(dcDescComision);
			dtComisionesPlaes.Columns.Add(dcAnioEspecialidad);
			dtComisionesPlaes.Columns.Add(dcDescPlan);

			foreach (Comision c in listaComisiones)
			{
				foreach (Plan p in listaPlanes)
				{
					if (c.IDPlan == p.ID)
					{
						fila = dtComisionesPlaes.NewRow();
						fila[dcIdComision] = c.ID;
						fila[dcDescComision] = c.Descripcion;
						fila[dcAnioEspecialidad] = c.AñoEspecialidad;
						fila[dcDescPlan] = p.Descripcion;
						dtComisionesPlaes.Rows.Add(fila);
					}
				}
			}
			return dtComisionesPlaes;
		}

        public Comision GetOne(int ID)
		{
			Comision com = new Comision();
			this.OpenConnection();
			SqlCommand cmdComision = new SqlCommand("SelectComisionById", sqlConn);
			cmdComision.CommandType = System.Data.CommandType.StoredProcedure;
			cmdComision.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			try
			{
				SqlDataReader drComision = cmdComision.ExecuteReader();
				if (drComision.Read())
				{
					com.ID = (int)drComision["id_comision"];
					com.AñoEspecialidad = (int)drComision["anio_especialidad"];
					com.Descripcion = (string)drComision["desc_comision"];
					com.IDPlan = (int)drComision["id_plan"];
				}
				drComision.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar la comision.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return com;
		}

		public void Delete(int ID)
		{
			this.OpenConnection();
			SqlCommand cmdComision = new SqlCommand("DeleteComision", sqlConn);
			cmdComision.CommandType = System.Data.CommandType.StoredProcedure;
			cmdComision.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			cmdComision.ExecuteNonQuery();
		}

		public void Save(Comision com)
		{
			if (com.State == BusinessEntity.States.New)
			{
				this.OpenConnection();
				SqlCommand cmdComision = new SqlCommand("NuevaComision", sqlConn);
				cmdComision.CommandType = System.Data.CommandType.StoredProcedure;
				cmdComision.Parameters.Add("@anioe", System.Data.SqlDbType.Int).Value = com.AñoEspecialidad;
				cmdComision.Parameters.Add("@descc", System.Data.SqlDbType.VarChar).Value = com.Descripcion;
				cmdComision.Parameters.Add("@idp", System.Data.SqlDbType.Int).Value = com.IDPlan;
				cmdComision.Parameters.Add("@ID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
				cmdComision.ExecuteNonQuery();
				com.ID = (int)cmdComision.Parameters["@ID"].Value;
				this.CloseConnection();
			}
			else if (com.State == BusinessEntity.States.Deleted)
			{
				this.Delete(com.ID);
			}
			else if (com.State == BusinessEntity.States.Modified)
			{
				this.OpenConnection();
				SqlCommand cmdComision = new SqlCommand("EditarComision", sqlConn);
				cmdComision.CommandType = System.Data.CommandType.StoredProcedure;
				cmdComision.Parameters.Add("@anioe", System.Data.SqlDbType.Int).Value = com.AñoEspecialidad;
				cmdComision.Parameters.Add("@descc", System.Data.SqlDbType.VarChar).Value = com.Descripcion;
				cmdComision.Parameters.Add("@idp", System.Data.SqlDbType.Int).Value = com.IDPlan;
				cmdComision.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = com.ID;
				cmdComision.ExecuteNonQuery();
				this.CloseConnection();
			}
			com.State = BusinessEntity.States.Unmodified;
		}
	}
}
