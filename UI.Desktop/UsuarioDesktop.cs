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
	
		public Usuario UsuarioActual { get; set; }

		public UsuarioDesktop() {
			InitializeComponent();
		}
		public UsuarioDesktop(ModoForm modo) : this() {
			Modo = modo;
			
		}
		public UsuarioDesktop(int ID, ModoForm modo) : this() {
			Modo = modo;
			UsuarioActual = new UsuarioLogic().GetOne(ID);
			MapearDeDatos();
		}

		private void UsuarioDesktop_Load(object sender, EventArgs e)
		{
			CargaComboBoxPersona();
		}

		private void CargaComboBoxPersona()
		{
			PersonaLogic pl = new PersonaLogic();
			List<Persona> listaPersonas = pl.GetAll();
			Dictionary<int, int> comboSourcePlan = new Dictionary<int, int>();

			foreach (Persona p in listaPersonas)
			{
				comboSourcePlan.Add(p.ID, p.Legajo);
			}

			cBoxPersonas.DataSource = new BindingSource(comboSourcePlan, null);
			cBoxPersonas.DisplayMember = "Value";
			cBoxPersonas.ValueMember = "Key";
			cBoxPersonas.Text = "...";
		}


		public override void MapearDeDatos(){
			if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
			{
				btnAceptar.Text = "Guardar";
			}
			else if (Modo.Equals("Consulta"))
			{
				btnAceptar.Text = "Aceptar";
			}
			this.txtID.Text = this.UsuarioActual.ID.ToString();
			this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
			this.txtEmail.Text = this.UsuarioActual.Email;
			this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
			this.txtClave.Text = this.UsuarioActual.Clave;
			this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
		}
		public override void MapearADatos() {
			if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
				if (Modo == ModoForm.Alta)
				{
					int IDPersona = ((KeyValuePair<int, int>)cBoxPersonas.SelectedItem).Key;
					Persona p = new PersonaLogic().GetOne(IDPersona);

					Usuario u = new Usuario();
					UsuarioActual = u;
					UsuarioActual.ID_Persona = IDPersona;
					UsuarioActual.Habilitado = this.chkHabilitado.Checked;
					UsuarioActual.Nombre = p.Nombre;
					UsuarioActual.Apellido = p.Apellido;
					UsuarioActual.Email = this.txtEmail.Text;
					UsuarioActual.NombreUsuario = this.txtUsuario.Text;
					UsuarioActual.Clave = this.txtClave.Text;
					UsuarioActual.State = BusinessEntity.States.New;
				}
				else if (Modo == ModoForm.Modificacion)
				{
					int IDPersona = ((KeyValuePair<int, int>)cBoxPersonas.SelectedItem).Key;
					Persona p = new PersonaLogic().GetOne(IDPersona);
					UsuarioActual.ID_Persona = IDPersona;
					UsuarioActual.Habilitado = this.chkHabilitado.Checked;
					UsuarioActual.Nombre = p.Nombre;
					UsuarioActual.Apellido = p.Apellido;
					UsuarioActual.Email = this.txtEmail.Text;
					UsuarioActual.NombreUsuario = this.txtUsuario.Text;
					UsuarioActual.Clave = this.txtClave.Text;
					UsuarioActual.State = BusinessEntity.States.Modified;
				}
			}
		}
		public override void GuardarCambios() {
			MapearADatos();
			UsuarioLogic ul = new UsuarioLogic();
			ul.Save(UsuarioActual);
		}
		public override bool Validar()
		{
			if (string.IsNullOrWhiteSpace(this.cBoxPersonas.Text))
			{
				Notificar("Error", "Incorrect Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
			{
				Notificar("Error", "Incorrect Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtUsuario.Text))
			{
				Notificar("Error", "Incorrect Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtClave.Text))
			{
				Notificar("Error", "Incorrect clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtConfirmarClave.Text))
			{
				Notificar("Error", "Incorrect clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if ((this.txtClave.Text).Length < 8)
			{
				Notificar("Error", "Incorrect clave.\nDebe tener mas de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if ((this.txtConfirmarClave.Text).Length < 8)
			{
				Notificar("Error", "Incorrect clave.\nDebe tener mas de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (this.txtClave.Text != this.txtConfirmarClave.Text)
			{
				Notificar("Error", "Incorrect. clave distinto de Confirmar Clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!ComprobarFormatoEmail(this.txtEmail.Text))
			{
				Notificar("Error", "Incorrect email", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else
			{
				return true;
			}
		}
		public void NotificarError(string mensaje) {
			this.Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		public static bool ComprobarFormatoEmail(string sEmailAComprobar){
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
		private void btnAceptar_Click(object sender, EventArgs e){
			switch (Modo)
			{
				case ModoForm.Alta:
					if (Validar())
					{
						GuardarCambios();
						this.Close();
					}
					break;
				case ModoForm.Modificacion:
					if (Validar())
					{
						GuardarCambios();
						this.Close();
					}
					break;
				case ModoForm.Baja:
					GuardarCambios();
					//UsuarioLogic ul = new UsuarioLogic();
					//ul.Delete(UsuarioActual.ID);
					this.Close();
					break;
			}
		}
		private void btnCancelar_Click(object sender, EventArgs e) {
			Close();
		}

		private void txtNombre_TextChanged(object sender, EventArgs e) {

		}

	}
}
