﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
		public List<Curso> GetAll()
		{
			List<Curso> cursos = new List<Curso>();
			this.OpenConnection();
			SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos", sqlConn);
			try
			{

				SqlDataReader drCurso = cmdCurso.ExecuteReader();
				while (drCurso.Read())
				{
					Curso cur = new Curso();
					cur.ID = (int)drCurso["id_curso"];
					cur.AñoCalendario = (int)drCurso["anio_calendario"];
					cur.Cupo = (int)drCurso["cupo"];
					cur.IDComision = (int)drCurso["id_comision"];
					cur.IDMateria = (int)drCurso["id_materia"];
					cursos.Add(cur);
				}
				drCurso.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return cursos;
		}

        public object GetCursosMateriasComisiones()
        {
			ComisionAdapter ca = new ComisionAdapter();
			MateriaAdapter ma = new MateriaAdapter();

			List<Comision> ListaComisiones = ca.GetAll();
			List<Materia> ListaMaterias = ma.GetAll();
			List<Curso> ListaCursos = this.GetAll();

			//CREO TABLA1
			DataTable dtCursosMateriasComisiones = new DataTable();
			DataColumn dcIdCurso = new DataColumn("ID");
			DataColumn dcDescMateria = new DataColumn("Descripcion Materia");
			DataColumn dcDescComision = new DataColumn("Descripcion Comision");
			DataColumn dcAnio = new DataColumn("Año Calendario");
			DataColumn dcCupo = new DataColumn("Cupo");
			dtCursosMateriasComisiones.Columns.Add(dcIdCurso);
			dtCursosMateriasComisiones.Columns.Add(dcDescMateria);
			dtCursosMateriasComisiones.Columns.Add(dcDescComision);
			dtCursosMateriasComisiones.Columns.Add(dcAnio);
			dtCursosMateriasComisiones.Columns.Add(dcCupo);

			//CREO FILA QUE SE USA EN AMBAS TABLAS 
			DataRow fila;

			//CARGO TABLA 1
			foreach (Curso c in ListaCursos)
			{
				foreach (Materia m in ListaMaterias)
				{
					if (c.IDMateria == m.ID)
					{
						fila = dtCursosMateriasComisiones.NewRow();
						fila[dcIdCurso] = c.ID;
						fila[dcDescMateria] = m.Descripcion;
						fila[dcDescComision] = c.IDComision;
						fila[dcAnio] = c.AñoCalendario;
						fila[dcCupo] = c.Cupo;
						dtCursosMateriasComisiones.Rows.Add(fila);
					}
				}
			}
			//CREO TABLA2
			DataTable dtQueSeDevuelve = new DataTable();
			DataColumn dcIdCurso2 = new DataColumn("ID");
			DataColumn dcDescMateria2 = new DataColumn("Descripcion Materia");
			DataColumn dcDescComision2 = new DataColumn("Descripcion Comision");
			DataColumn dcAnio2 = new DataColumn("Año Calendario");
			DataColumn dcCupo2 = new DataColumn("Cupo");
			dtQueSeDevuelve.Columns.Add(dcIdCurso2);
			dtQueSeDevuelve.Columns.Add(dcDescMateria2);
			dtQueSeDevuelve.Columns.Add(dcDescComision2);
			dtQueSeDevuelve.Columns.Add(dcAnio2);
			dtQueSeDevuelve.Columns.Add(dcCupo2);

			//CARGO TABLA2, ESTA TABLA ES LA QUE SE DEVUELVE
			foreach (DataRow row in dtCursosMateriasComisiones.Rows)
			{
				foreach (Comision c in ListaComisiones)
				{
					if (int.Parse(row["Descripcion Comision"].ToString()) == c.ID)//row["Descripcion Comision"] contiene el ID de la comision, "Descripcion Comision" es el titulo de la columna de la data table
					{
						fila = dtQueSeDevuelve.NewRow();
						fila[dcIdCurso2] = row["ID"];
						fila[dcDescMateria2] = row["Descripcion Materia"];
						fila[dcDescComision2] = c.Descripcion;
						fila[dcAnio2] = row["Año Calendario"];
						fila[dcCupo2] = row["Cupo"];
						dtQueSeDevuelve.Rows.Add(fila);
					}
				}
			}

			return dtQueSeDevuelve;
		}

        public Curso GetOne(int ID)
		{
			Curso cur = new Curso();
			this.OpenConnection();
			SqlCommand cmdCurso = new SqlCommand("SelectCursoById", sqlConn);
			cmdCurso.CommandType = CommandType.StoredProcedure;
			cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			try
			{
				SqlDataReader drCurso = cmdCurso.ExecuteReader();
				if (drCurso.Read())
				{
					cur.ID = (int)drCurso["id_comision"];
					cur.AñoCalendario = (int)drCurso["anio_calendario"];
					cur.Cupo = (int)drCurso["cupo"];
					cur.IDComision = (int)drCurso["id_comision"];
					cur.IDMateria = (int)drCurso["id_materia"];
				}
				drCurso.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("Error al recuperar el curso.", Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return cur;
		}

		public void Delete(int ID)
		{
			this.OpenConnection();
			SqlCommand cmdCurso = new SqlCommand("DeleteCurso", sqlConn);
			cmdCurso.CommandType = CommandType.StoredProcedure;
			cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			cmdCurso.ExecuteNonQuery();
		}

		public void Save(Curso cur)
		{
			if (cur.State == BusinessEntity.States.New)
			{
				this.OpenConnection();
				SqlCommand cmdCurso = new SqlCommand("NuevoCurso", sqlConn);
				cmdCurso.CommandType = CommandType.StoredProcedure;
				cmdCurso.Parameters.Add("@anioc", SqlDbType.Int).Value = cur.AñoCalendario;
				cmdCurso.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
				cmdCurso.Parameters.Add("@idc", SqlDbType.Int).Value = cur.IDComision;
				cmdCurso.Parameters.Add("@idm", SqlDbType.Int).Value = cur.IDMateria;
				cmdCurso.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmdCurso.ExecuteNonQuery();
				cur.ID = (int)cmdCurso.Parameters["@ID"].Value;
				this.CloseConnection();
			}
			else if (cur.State == BusinessEntity.States.Deleted)
			{
				this.Delete(cur.ID);
			}
			else if (cur.State == BusinessEntity.States.Modified)
			{
				this.OpenConnection();
				SqlCommand cmdCurso = new SqlCommand("EditarCurso", sqlConn);
				cmdCurso.CommandType = CommandType.StoredProcedure;
				cmdCurso.Parameters.Add("@anioc", SqlDbType.Int).Value = cur.AñoCalendario;
				cmdCurso.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
				cmdCurso.Parameters.Add("@idc", SqlDbType.Int).Value = cur.IDComision;
				cmdCurso.Parameters.Add("@idm", SqlDbType.Int).Value = cur.IDMateria;
				cmdCurso.Parameters.Add("@ID", SqlDbType.Int).Value = cur.ID;
				cmdCurso.ExecuteNonQuery();
				this.CloseConnection();
			}
			cur.State = BusinessEntity.States.Unmodified;
		}
	}
}
