using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data.Database {
	public class UsuarioAdapter : Adapter {
		#region DatosEnMemoria
		// Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
		// Al modificar este proyecto para que acceda a la base de datos esta será eliminada
		private static List<Usuario> _Usuarios;

		private static List<Usuario> Usuarios {
			get {
				if (_Usuarios == null) {
					_Usuarios = new List<Business.Entities.Usuario>();
					Business.Entities.Usuario usr;
					usr = new Business.Entities.Usuario();
					usr.ID = 1;
					usr.State = Business.Entities.BusinessEntity.States.Unmodified;
					usr.Nombre = "Casimiro";
					usr.Apellido = "Cegado";
					usr.NombreUsuario = "casicegado";
					usr.Clave = "miro";
					usr.Email = "casimirocegado@gmail.com";
					usr.Habilitado = true;
					_Usuarios.Add(usr);

					usr = new Business.Entities.Usuario();
					usr.ID = 2;
					usr.State = Business.Entities.BusinessEntity.States.Unmodified;
					usr.Nombre = "Armando Esteban";
					usr.Apellido = "Quito";
					usr.NombreUsuario = "aequito";
					usr.Clave = "carpintero";
					usr.Email = "armandoquito@gmail.com";
					usr.Habilitado = true;
					_Usuarios.Add(usr);

					usr = new Business.Entities.Usuario();
					usr.ID = 3;
					usr.State = Business.Entities.BusinessEntity.States.Unmodified;
					usr.Nombre = "Alan";
					usr.Apellido = "Brado";
					usr.NombreUsuario = "alanbrado";
					usr.Clave = "abrete sesamo";
					usr.Email = "alanbrado@gmail.com";
					usr.Habilitado = true;
					_Usuarios.Add(usr);

				}
				return _Usuarios;
			}
		}
		#endregion

		public List<Usuario> GetAll() {
			//List<Usuario> usuarios = new List<Usuario>(Usuarios);
			List<Usuario> usuarios = new List<Usuario>();
			this.OpenConnection();
			SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios",sqlConn);
			try {
				SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
				while (drUsuarios.Read()) {
					Usuario a = new Usuario();
					a.ID = (int)drUsuarios["id_usuarios"];
					a.NombreUsuario = (string)drUsuarios["nombre_usuario"];
					a.Clave = (string)drUsuarios["clave"];
					a.Habilitado = (bool)drUsuarios["habilitado"];
					a.Nombre = (string)drUsuarios["nombre"];
					a.Apellido = (string)drUsuarios["apellido"];
					a.Email= (string)drUsuarios["email"];
					usuarios.Add(a);
				}
			drUsuarios.Close();
			}catch(Exception Ex){
				// TODO try catch finally en la donde llamen acá
				Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
				throw ExcepcionManejada;
			} finally {
				this.CloseConnection();
			}
			return usuarios;
		}

		public Usuario GetOne(int ID) {
			//return Usuarios.Find(delegate (Usuario u) { return u.ID == ID; });

			Usuario usuario = new Usuario();
			this.OpenConnection();
			SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id", sqlConn);
			cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
			cmdUsuario.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;
			try { 
				SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
				if (drUsuario.Read()) {
					usuario.ID = (int)drUsuario["id_usuarios"];
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
				SqlCommand cmdUsuario = new SqlCommand("UPDATE usuarios SET nombre_usuario=@usuario,clave=@clave,habilitado=@habilitado,nombre=@nombre,apellido=@apellido,email=@email) WHERE id_usuario=@id", sqlConn);
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
	}
}
