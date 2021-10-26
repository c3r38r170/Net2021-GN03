using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

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
			cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
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
			SqlCommand cmdUsuario = new SqlCommand("DELETE FROM usuarios WHERE id_usuario=@id", sqlConn);
			cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			cmdUsuario.ExecuteNonQuery();
			this.CloseConnection();
		}

		public void Save(Usuario usuario) {
			if (usuario.State == BusinessEntity.States.New) {
				this.OpenConnection();
				SqlCommand cmdUsuario = new SqlCommand("INSERT INTO usuarios (nombre_usuario,clave,habilitado,nombre,apellido,email) VALUES (@usuario,@clave,@habilitado,@nombre,@apellido,@email); SET @ID = SCOPE_IDENTITY();", sqlConn);
				cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
				cmdUsuario.Parameters.Add("@usuario", System.Data.SqlDbType.VarChar).Value = usuario.NombreUsuario;
				cmdUsuario.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = usuario.Clave;
				cmdUsuario.Parameters.Add("@habilitado", System.Data.SqlDbType.Bit).Value = usuario.Habilitado;
				cmdUsuario.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = usuario.Nombre;
				cmdUsuario.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = usuario.Apellido;
				cmdUsuario.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = usuario.Email;
				cmdUsuario.Parameters.Add("@ID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
				cmdUsuario.ExecuteNonQuery();
				usuario.ID = (int)cmdUsuario.Parameters["@ID"].Value;
				this.CloseConnection();
			} else if (usuario.State == BusinessEntity.States.Deleted) {
				this.Delete(usuario.ID);
			} else if (usuario.State == BusinessEntity.States.Modified) {
				this.OpenConnection();
				SqlCommand cmdUsuario = new SqlCommand("UPDATE usuarios SET nombre_usuario=@usuario,clave=@clave,habilitado=@habilitado,nombre=@nombre,apellido=@apellido,email=@email WHERE id_usuario=@id", sqlConn);
				cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
				cmdUsuario.Parameters.Add("@usuario", System.Data.SqlDbType.VarChar).Value = usuario.NombreUsuario;
				cmdUsuario.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = usuario.Clave;
				cmdUsuario.Parameters.Add("@habilitado", System.Data.SqlDbType.Bit).Value = usuario.Habilitado;
				cmdUsuario.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = usuario.Nombre;
				cmdUsuario.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = usuario.Apellido;
				cmdUsuario.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = usuario.Email;
				cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = usuario.ID;
				cmdUsuario.ExecuteNonQuery();
				this.CloseConnection();
			}
			usuario.State = BusinessEntity.States.Unmodified;
		}

		public Usuario GetUserByUsernameAndPassword(String nombre, String contraseña) {
			this.OpenConnection();
			SqlCommand cmdLogIn = new SqlCommand("SELECT id_usuario FROM usuarios WHERE nombre_usuario=@nombre_usuario AND clave=@clave", sqlConn);
			cmdLogIn.Parameters.Add("@nombre_usuario", System.Data.SqlDbType.VarChar).Value = nombre;
			cmdLogIn.Parameters.Add("@clave", System.Data.SqlDbType.VarChar).Value = contraseña;
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
