using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public ModoForm MF { get; set; }
        public Persona PersonaActual { get; set; }
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            MF = modo;
            PersonaActual = new Persona();
        }

		public PersonaDesktop(int ID, ModoForm modo) : this()
		{
			MF = modo;
			PersonaLogic ul = new PersonaLogic();
			PersonaActual = ul.GetOne(ID);
			MapearDeDatos();
		}

		public override void MapearDeDatos()
		{
			if ((MF == ModoForm.Alta) || (MF == ModoForm.Alta))
			{
				this.btnAceptar.Text = "Guardar";
			}
			else if (MF == ModoForm.Consulta)
			{
				this.btnAceptar.Text = "Aceptar";
			}
			this.txtID.Text = this.PersonaActual.ID.ToString();
			this.txtApellido.Text = this.PersonaActual.Apellido;
			this.txtNombre.Text = this.PersonaActual.Nombre;
			this.txtEmail.Text = this.PersonaActual.Email;
			this.txtDireccion.Text = this.PersonaActual.Direccion;
			this.txtTelefono.Text = this.PersonaActual.Telefono;
			this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
			this.txtIDPlan.Text = this.PersonaActual.IDPlan.ToString();
			this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
		}

		private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool v = Validar();
            if (v)
            {
                switch (MF)
                {
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

		public override void GuardarCambios()
		{
			MapearADatos();
			PersonaLogic ul = new PersonaLogic();
			ul.Save(PersonaActual);
		}

		public override void MapearADatos()
		{
			if (MF == ModoForm.Alta || MF == ModoForm.Modificacion)
			{
				PersonaActual.Nombre = this.txtNombre.Text;
				PersonaActual.Apellido = this.txtApellido.Text;
				PersonaActual.Email = this.txtEmail.Text;
				PersonaActual.Direccion = this.txtDireccion.Text;
				PersonaActual.Telefono = this.txtTelefono.Text;
				PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
				PersonaActual.IDPlan = Int32.Parse(this.txtIDPlan.Text);
				PersonaActual.ID = Int32.Parse(this.txtID.Text);
				PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);

			}
			switch (MF)
			{
				case ModoForm.Alta:
					PersonaActual.State = BusinessEntity.States.New;
					break;
				case ModoForm.Modificacion:
					PersonaActual.State = BusinessEntity.States.Modified;
					break;
					/*case ModoForm.Baja:
						UsuarioActual.State = BusinessEntity.States.Deleted;
						break;*/
			}
		}

		public override bool Validar()
		{
			if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
			{
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtApellido.Text))
			{
				NotificarError("El campo 'Apellido' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
			{
				NotificarError("El campo 'Email' está vacío");
				return false;
			}
			else if (!ComprobarFormatoEmail(this.txtEmail.Text))
			{
				NotificarError("El Email no es válido");
				return false;
			}
			else if  (string.IsNullOrWhiteSpace(this.txtDireccion.Text))
			{
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtTelefono.Text))
            {
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtLegajo.Text))
            {
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtIDPlan.Text))
            {
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtFechaNacimiento.Text))
            {
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtTipo.Text))
            {
				NotificarError("El campo 'Nombre' está vacío");
				return false;
			}
			else
			{
				return true;
			}
		}

		public static bool ComprobarFormatoEmail(string sEmailAComprobar)
		{
			String sFormato;
			sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			if (Regex.IsMatch(sEmailAComprobar, sFormato))
			{
				if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public void NotificarError(string mensaje)
		{
			this.Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}
