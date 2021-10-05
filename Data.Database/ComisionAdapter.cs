using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

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

		public Comision GetOne(int ID)
		{
			Comision com = new Comision();
			this.OpenConnection();
			SqlCommand cmdComision = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", sqlConn);
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
			SqlCommand cmdComision = new SqlCommand("DELETE FROM comisiones WHERE id_comision=@id", sqlConn);
			cmdComision.CommandType = System.Data.CommandType.StoredProcedure;
			cmdComision.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			cmdComision.ExecuteNonQuery();
		}

		public void Save(Comision com)
		{
			if (com.State == BusinessEntity.States.New)
			{
				this.OpenConnection();
				SqlCommand cmdComision = new SqlCommand("INSERT INTO comisiones (anio_especialidad,desc_comision,id_plan) VALUES (@anioe,@descc,@idp); SET @ID = SCOPE_IDENTITY();", sqlConn);
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
				SqlCommand cmdComision = new SqlCommand("UPDATE comisiones SET anio_especialidad=@anioe,desc_comision=@descc,id_plan=@idp WHERE id_comision=@ID", sqlConn);
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
