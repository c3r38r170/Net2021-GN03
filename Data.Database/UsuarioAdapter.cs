using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database {
	public class UsuarioAdapter : Adapter {
		public List<Usuario> GetAll() {
			List<Usuario> usuarios = new List<Usuario>();
			this.OpenConnection();
			SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios",sqlConn);
			try {
				SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
				while (drUsuarios.Read()) {
					usuarios.Add(CreateUsuarioFromDataReader(drUsuarios);
				}
			drUsuarios.Close();
			}catch(Exception Ex){
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return usuarios;
		}

		public Usuario GetOne(int ID) {
			Usuario usuario = new Usuario();
			this.OpenConnection();
			SqlCommand cmdUsuario = new SqlCommand("SelectUsuarioById", sqlConn);
			cmdUsuario.CommandType = CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			try { 
				SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
				if (drUsuario.Read()) {
					usuario.ID = (int)drUsuario["id_usuario"];
					usuario.NombreUsuario = (string)drUsuario["nombre_usuario"];
					usuario.Clave = (string)drUsuario["clave"];
					usuario.Habilitado = (bool)drUsuario["habilitado"];
					usuario.Nombre = (string)drUsuario["nombre"];
					usuario.Apellido = (string)drUsuario["apellido"];
					usuario.Email = (string)drUsuario["email"];
					usuario.PersonaAsociada = (new PersonaAdapter()).GetOne((int)drUsuario["id_persona"]);
				}
				drUsuario.Close();
			} catch (Exception Ex) {
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return usuario;
		}

		public void Delete(int ID) {
			this.OpenConnection();
			SqlCommand cmdUsuario = new SqlCommand("DeleteUsuario", sqlConn);
			cmdUsuario.CommandType = CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
			cmdUsuario.ExecuteNonQuery();
			this.CloseConnection();
		}

		public void Save(Usuario usuario) {
			if (usuario.State == BusinessEntity.States.New) {
				this.OpenConnection();
				SqlCommand cmdUsuario = new SqlCommand("NuevoUsuario", sqlConn);
				cmdUsuario.CommandType = CommandType.StoredProcedure;
				cmdUsuario.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
				cmdUsuario.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
				cmdUsuario.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
				cmdUsuario.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
				cmdUsuario.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.Apellido;
				cmdUsuario.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
				cmdUsuario.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmdUsuario.ExecuteNonQuery();
				usuario.ID = (int)cmdUsuario.Parameters["@ID"].Value;
				this.CloseConnection();
			} else if (usuario.State == BusinessEntity.States.Deleted) {
				this.Delete(usuario.ID);
			} else if (usuario.State == BusinessEntity.States.Modified) {
				this.OpenConnection();
				SqlCommand cmdUsuario = new SqlCommand("EditarUsuario", sqlConn);
				cmdUsuario.CommandType = CommandType.StoredProcedure;
				cmdUsuario.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
				cmdUsuario.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
				cmdUsuario.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
				cmdUsuario.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
				cmdUsuario.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.Apellido;
				cmdUsuario.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
				cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
				cmdUsuario.ExecuteNonQuery();
				this.CloseConnection();
			}
			usuario.State = BusinessEntity.States.Unmodified;
		}

		public Usuario GetUserByUsernameAndPassword(String nombre, String contraseña) {
			this.OpenConnection();
			SqlCommand cmdLogIn = new SqlCommand("GetUsuarioByNombreUsuarioYContraseña", sqlConn);
			cmdLogIn.CommandType = CommandType.StoredProcedure;
			cmdLogIn.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = nombre;
			cmdLogIn.Parameters.Add("@clave", SqlDbType.VarChar).Value = contraseña;
			object result = cmdLogIn.ExecuteScalar();
			if (result == null)
				return new Usuario();
			int ID = (int)result;
			this.CloseConnection();
			return GetOne(ID);
		}

		private Usuario CreateUsuarioFromDataReader(SqlDataReader dR) {
			Usuario a = new Usuario();
			a.ID = (int)dR["id_usuarios"];
			a.NombreUsuario = (string)dR["nombre_usuario"];
			a.Clave = (string)dR["clave"];
			a.Habilitado = (bool)dR["habilitado"];
			a.Nombre = (string)dR["nombre"];
			a.Apellido = (string)dR["apellido"];
			a.Email = (string)dR["email"];
			return a;
		}
	}
}
