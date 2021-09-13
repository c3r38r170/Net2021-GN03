using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Data.Database
{
    public class PlanAdapter: Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> listPlanes = new List<Plan>();         
            SqlCommand mycomando = new SqlCommand("SELECT * FROM planes", sqlConn);
            try
            {
                this.OpenConnection();
                SqlDataReader drPlan = mycomando.ExecuteReader();
                while (drPlan.Read())
                {
                    Plan p = new Plan();
                    p.ID = (int)drPlan["id_plan"];
                    p.Descripcion = (string)drPlan["desc_plan"];
                    p.IDEspecialidad = (int)drPlan["id_especialidad"];
                    listPlanes.Add(p);
                }  
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
            return listPlanes;
        }

        public void Save(Plan plan)
        {   
                try
                {
                if (plan.State == BusinessEntity.States.New)
                {
                    this.OpenConnection();
                    SqlCommand SqlComm = new SqlCommand("INSERT INTO plan (desc_plan,id_especialidad ) VALUES (@descripcion,@especialidad); SET @ID = SCOPE_IDENTITY();", sqlConn);
                    SqlComm.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                    SqlComm.Parameters.Add("@especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                    SqlComm.ExecuteNonQuery();
                    plan.ID = (int)SqlComm.Parameters["@ID"].Value;
                    this.CloseConnection();
                }
                else if (plan.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(plan.ID);
                }
                else if (plan.State == BusinessEntity.States.Modified)
                {
                    this.OpenConnection();
                    SqlCommand SqlComm = new SqlCommand("UPDATE plan SET desc_plan=@descripcion, id_especialidad=@especialidad WHERE id_plan = @idPlan", sqlConn);
                    SqlComm.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                    SqlComm.Parameters.Add("@especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                    SqlComm.Parameters.Add("@idPlan", SqlDbType.Int).Value = plan.ID;
                    SqlComm.ExecuteNonQuery();
                    this.CloseConnection();
                }
                //plan.State = BusinessEntity.States.Unmodified;
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
        }

        public void Delete(int iD)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("DELETE FROM plan WHERE id_plan=@id", sqlConn);
                cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = iD;
                cmdUsuario.ExecuteNonQuery();
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
        }

        public Plan GetOne(int iD)
        {
            Plan i = null;
            string sentenciaSQL = "SELECT * FROM plan WHERE id_plan = '" +iD+ "'";
            SqlCommand command = new SqlCommand(sentenciaSQL, sqlConn);
            try
            {
                command.Connection = sqlConn;
                this.OpenConnection();
                SqlDataReader mydr = command.ExecuteReader();
                if (mydr.Read())
                {
                    i = new Plan();
                    i.ID = (int)mydr["id_plan"];
                    i.IDEspecialidad = (int)mydr["id_especialidad"];
                    i.Descripcion = (string)mydr["desc_plan"];
                }
                mydr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el Plan especifado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return i;
        }

        public List<Especialidad> CargaComboBox()
        {
            List<Especialidad> lista = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades", sqlConn);
                SqlDataReader drEspecialidades = cmd.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad p = new Especialidad();
                    p.ID = (int)drEspecialidades["id_especialidad"];
                    p.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    lista.Add(p);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }
    }
}
