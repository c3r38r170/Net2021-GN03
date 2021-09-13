using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using System.Text.RegularExpressions;

namespace UI.Desktop {
	public partial class UsuarioDesktop : ApplicationForm {
		private Usuario _usuarioActual;
		private ModoForm _mF;

		public Usuario UsuarioActual { get; set; }
		public ModoForm MF { get; set; }

		public UsuarioDesktop() {
			InitializeComponent();
		}
		public UsuarioDesktop(ModoForm modo) : this() {
			MF = modo;
			UsuarioActual = new Usuario();
		}
		public UsuarioDesktop(int ID, ModoForm modo) : this() {
			MF = modo;
			UsuarioLogic ul = new UsuarioLogic();
			UsuarioActual = ul.GetOne(ID);
			MapearDeDatos();
		}
		public override void MapearDeDatos() {
			if ((MF == ModoForm.Alta) || (MF == ModoForm.Alta)) {
				this.btnAceptar.Text = "Guardar";
			} else if (MF == ModoForm.Consulta) {
				this.btnAceptar.Text = "Aceptar";
			}
			this.txtID.Text = this.UsuarioActual.ID.ToString();
			this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
			this.txtNombre.Text = this.UsuarioActual.Nombre;
			this.txtApellido.Text = this.UsuarioActual.Apellido;
			this.txtEmail.Text = this.UsuarioActual.Email;
			this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
			this.txtClave.Text = this.UsuarioActual.Clave;
			this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
		}
		public override void MapearADatos() {
			if (MF == ModoForm.Alta || MF == ModoForm.Modificacion) {
				UsuarioActual.Nombre = this.txtNombre.Text;
				UsuarioActual.Apellido = this.txtApellido.Text;
				UsuarioActual.Email = this.txtEmail.Text;
				UsuarioActual.NombreUsuario = this.txtUsuario.Text;
				UsuarioActual.Clave = this.txtClave.Text;
				UsuarioActual.Habilitado = this.chkHabilitado.Checked;
			}
			switch (MF) {
				case ModoForm.Alta:
					UsuarioActual.State = BusinessEntity.States.New;
					break;
				case ModoForm.Modificacion:
					UsuarioActual.State = BusinessEntity.States.Modified;
					break;
				/*case ModoForm.Baja:
					UsuarioActual.State = BusinessEntity.States.Deleted;
					break;*/
			}
		}
		public override void GuardarCambios() {
			MapearADatos();
			UsuarioLogic ul = new UsuarioLogic();
			ul.Save(UsuarioActual);
		}
		public override bool Validar() {
			if (string.IsNullOrWhiteSpace(this.txtNombre.Text)) {
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			} else if (string.IsNullOrWhiteSpace(this.txtApellido.Text)) {
				NotificarError("El campo 'Apellido' está vacío");
				return false;
			} else if (string.IsNullOrWhiteSpace(this.txtEmail.Text)) {
				NotificarError("El campo 'Email' está vacío");
				return false;
			} else if (string.IsNullOrWhiteSpace(this.txtUsuario.Text)) {
				NotificarError("El campo 'Usuario' está vacío");
				return false;
			} else if (string.IsNullOrWhiteSpace(this.txtClave.Text)) {
				NotificarError("El campo 'Clave' está vacío");
				return false;
			} else if (string.IsNullOrWhiteSpace(this.txtConfirmarClave.Text)) {
				NotificarError("El campo 'Confirmar Clave' está vacío");
				return false;
			} else if ((this.txtClave.Text).Length < 8) {
				NotificarError("La contraseña debe tener más de 8 caracteres");
				return false;
			} else if ((this.txtConfirmarClave.Text).Length < 8) {
				NotificarError("La contraseña debe tener más de 8 caracteres");
				return false;
			} else if (this.txtClave.Text != this.txtConfirmarClave.Text) {
				NotificarError("La contraseñas deben coincidir");
				return false;
			} else if (!ComprobarFormatoEmail(this.txtEmail.Text)) {
				NotificarError("El Email no es válido");
				return false;
			} else {
				return true;
			}
		}
		public void NotificarError(string mensaje) {
			this.Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		public static bool ComprobarFormatoEmail(string sEmailAComprobar) {
			String sFormato;
			sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			if (Regex.IsMatch(sEmailAComprobar, sFormato)) {
				if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0) {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}
		}
		private void btnAceptar_Click(object sender, EventArgs e) {
			bool v = Validar();
			if (v) {
				switch (MF) {
					case ModoForm.Alta:
						GuardarCambios();
						this.Close();
						break;
					case ModoForm.Modificacion:
						GuardarCambios();
						this.Close();
						break;
				}
			}
		}
		private void btnCancelar_Click(object sender, EventArgs e) {
			Close();
		}

		private void txtNombre_TextChanged(object sender, EventArgs e) {

		}
	}
}
