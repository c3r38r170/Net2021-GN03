using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic {
	public class UsuarioLogic:BusinessLogic {
		public UsuarioAdapter UsuarioData {get;set;}
		public UsuarioLogic() {
			UsuarioData = new UsuarioAdapter();
		}
		public Usuario GetOne(int ID) {
			return UsuarioData.GetOne(ID);
		}
		public List<Usuario> GetAll() {
			return UsuarioData.GetAll();
		}
		public void Save(Usuario u) {
			UsuarioData.Save(u);
		}
		public void Delete(int ID) {
			UsuarioData.Delete(ID);
		}
		public Usuario LogIn(String nombre,String contraseña) {
			var usuarioAdapter = new UsuarioAdapter();
			var usuario = usuarioAdapter.GetUserByUsernameAndPassword(nombre, contraseña);

			return usuario;
		}

  }
}
