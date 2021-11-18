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
            try
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
				cBoxPersonas.Text = Modo.Equals(ModoForm.Alta) ?
					"..."
					: UsuarioActual.PersonaAsociada.Legajo.ToString();
			}
			catch(Exception e)
            {
				MessageBox.Show("Deben cargarse personas");
            }
			
		}


		public override void MapearDeDatos(){
			txtID.Text = UsuarioActual.ID.ToString();
			chkHabilitado.Checked = UsuarioActual.Habilitado;
			txtEmail.Text = UsuarioActual.Email;
			txtUsuario.Text = UsuarioActual.NombreUsuario;
			txtClave.Text = UsuarioActual.Clave;
			txtConfirmarClave.Text = UsuarioActual.Clave;

			if(Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion)) {
				btnAceptar.Text = "Guardar";
				cBoxPersonas.Enabled = Modo.Equals(ModoForm.Alta);
			} else if(Modo.Equals(ModoForm.Consulta)) {
				btnAceptar.Text = "Aceptar";
			}
		}
		public override void MapearADatos() {
			if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) {
				if (Modo == ModoForm.Alta){
					Usuario u = new Usuario();
					UsuarioActual = u;
					UsuarioActual.State = BusinessEntity.States.New;
				}else if (Modo == ModoForm.Modificacion){
					UsuarioActual.State = BusinessEntity.States.Modified;
				}
				int IDPersona = ((KeyValuePair<int, int>)cBoxPersonas.SelectedItem).Key;
				Persona p = new PersonaLogic().GetOne(IDPersona);
				UsuarioActual.ID_Persona = IDPersona;
				UsuarioActual.Habilitado = chkHabilitado.Checked;
				UsuarioActual.Nombre = p.Nombre;
				UsuarioActual.Apellido = p.Apellido;
				UsuarioActual.PersonaAsociada = p;
				UsuarioActual.Email = txtEmail.Text;
				UsuarioActual.NombreUsuario = txtUsuario.Text;
				UsuarioActual.Clave = txtClave.Text;
			}
		}
		public override void GuardarCambios() {
			MapearADatos();
			UsuarioLogic ul = new UsuarioLogic();
			ul.Save(UsuarioActual);
		}
		public override bool Validar()
		{
			if (string.IsNullOrWhiteSpace(cBoxPersonas.Text))
			{
				Notificar("Error", "Incorrect Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				Notificar("Error", "Incorrect Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtUsuario.Text))
			{
				Notificar("Error", "Incorrect Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtClave.Text))
			{
				Notificar("Error", "Incorrect clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtConfirmarClave.Text))
			{
				Notificar("Error", "Incorrect clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (txtClave.Text.Length < 8)
			{
				Notificar("Error", "Incorrect clave.\nDebe tener mas de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (txtClave.Text != txtConfirmarClave.Text)
			{
				Notificar("Error", "Incorrect. clave distinto de Confirmar Clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!UsuarioLogic.ComprobarFormatoEmail(txtEmail.Text))
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
			Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		private void btnAceptar_Click(object sender, EventArgs e){
			switch (Modo)
			{
				case ModoForm.Alta:
					if (Validar())
					{
						GuardarCambios();
						Close();
					}
					break;
				case ModoForm.Modificacion:
					if (Validar())
					{
						GuardarCambios();
						Close();
					}
					break;
				case ModoForm.Baja:
					GuardarCambios();
					//UsuarioLogic ul = new UsuarioLogic();
					//ul.Delete(UsuarioActual.ID);
					Close();
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
