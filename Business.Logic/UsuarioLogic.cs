using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			return (new UsuarioAdapter()).GetUserByUsernameAndPassword(nombre, contraseña);
		}
		public static bool ComprobarFormatoEmail(string sEmailAComprobar) {
			String sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			return Regex.IsMatch(sEmailAComprobar, sFormato) && Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0;
		}

	}
}
