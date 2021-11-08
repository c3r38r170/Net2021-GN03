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
        public Persona PersonaActual { get; set; }
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
			Modo = modo;
        }

		public PersonaDesktop(int ID, ModoForm modo) : this()
		{
			Modo = modo;
			PersonaActual = new PersonaLogic().GetOne(ID);
			MapearDeDatos();
		}

		private void PersonaDesktop_Load(object sender, EventArgs e)
		{
			CargaComboBoxIDPlan();
			CargaComboBoxTipoPersona();
		}

		public override void MapearDeDatos()
		{
			this.txtID.Text = this.PersonaActual.ID.ToString();
			this.txtNombre.Text = this.PersonaActual.Nombre;
			this.txtApellido.Text = this.PersonaActual.Apellido;
			this.txtDireccion.Text = this.PersonaActual.Telefono;
			this.txtDireccion.Text = this.PersonaActual.Direccion;
			this.txtEmail.Text = this.PersonaActual.Email;
			this.txtTelefono.Text = this.PersonaActual.Telefono;
			this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
			this.txtFecha.Value = this.PersonaActual.FechaNacimiento;
			if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
			{
				btnAceptar.Text = "Guardar";
			}
			else if (Modo.Equals("Consulta"))
			{
				btnAceptar.Text = "Aceptar";
			}
		}

		public void CargaComboBoxIDPlan()
		{
			PlanLogic pl = new PlanLogic();
			List<Plan> listaPlanes = pl.GetAll();
			Dictionary<int, string> comboSourcePlan = new Dictionary<int, string>();

			foreach (Plan p in listaPlanes)
			{
				comboSourcePlan.Add(p.ID, p.Descripcion);
			}

			cBoxIDPlan.DataSource = new BindingSource(comboSourcePlan, null);
			cBoxIDPlan.DisplayMember = "Value";
			cBoxIDPlan.ValueMember = "Key";
			cBoxIDPlan.Text = "";
		}

		public void CargaComboBoxTipoPersona()
		{
			cBoxTipoPersona.Items.Add("Alumno");
			cBoxTipoPersona.Items.Add("Profesor");
			cBoxTipoPersona.Items.Add("Admin");
			cBoxTipoPersona.Text = "";
		}

		public override bool Validar()
		{
			if (string.IsNullOrWhiteSpace(this.txtApellido.Text))
			{
				Notificar("Error", "Incorrect txtApellido en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtDireccion.Text))
			{
				Notificar("Error", "Incorrect txtDireccion en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
			{
				Notificar("Error", "Incorrect Email en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtLegajo.Text))
			{
				Notificar("Error", "Incorrect Legajo en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
			{
				Notificar("Error", "Incorrect nombre en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtTelefono.Text))
			{
				Notificar("Error", "Incorrect telefono en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!CompruebaNroTelefono(this.txtTelefono.Text))
			{
				Notificar("Error", "Incorrect telefono", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.cBoxIDPlan.Text))
			{
				Notificar("Error", "Incorrect cBoxIDPlan en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.cBoxTipoPersona.Text))
			{
				Notificar("Error", "Incorrect cBoxTipoPersona en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!CompruebaEmail(this.txtEmail.Text))
			{
				Notificar("Error", "Incorrect email", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else
			{
				return true;
			}
		}

		public override void MapearADatos()
		{
			if (Modo == ModoForm.Alta)
			{
				Persona p = new Persona();
				PersonaActual = p;
				PersonaActual.Apellido = this.txtApellido.Text;
				PersonaActual.Nombre = this.txtNombre.Text;
				PersonaActual.Direccion = this.txtDireccion.Text;
				PersonaActual.Email = this.txtEmail.Text;
				PersonaActual.Telefono = this.txtTelefono.Text;
				PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
				PersonaActual.FechaNacimiento = this.txtFecha.Value;
				PersonaActual.IDPlan = ((KeyValuePair<int, string>)cBoxIDPlan.SelectedItem).Key;
				PersonaActual.State = BusinessEntity.States.New;
				if (this.cBoxTipoPersona.Text.Equals("Alumno"))
				{

                    PersonaActual.TipoPersona = Persona.Tipo.Alumno;
					

				}
				else if (this.cBoxTipoPersona.Text.Equals("Profesor"))
				{
					PersonaActual.TipoPersona = Persona.Tipo.Docente;
				}
				else if (this.cBoxTipoPersona.Text.Equals("Admin"))
				{
					PersonaActual.TipoPersona = Persona.Tipo.Admin;
				}
			}
			else if (Modo == ModoForm.Modificacion)
			{
				PersonaActual.Apellido = this.txtApellido.Text;
				PersonaActual.Nombre = this.txtNombre.Text;
				PersonaActual.Direccion = this.txtDireccion.Text;
				PersonaActual.Email = this.txtEmail.Text;
				PersonaActual.Telefono = this.txtTelefono.Text;
				PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
				PersonaActual.FechaNacimiento = this.txtFecha.Value;
				PersonaActual.IDPlan = ((KeyValuePair<int, string>)cBoxIDPlan.SelectedItem).Key;
				PersonaActual.State = BusinessEntity.States.Modified;
				if (this.cBoxTipoPersona.Text.Equals("Alumno"))
				{
					PersonaActual.TipoPersona = Persona.Tipo.Alumno;
				}
				else if (this.cBoxTipoPersona.Text.Equals("Profesor"))
				{
					PersonaActual.TipoPersona = Persona.Tipo.Docente;
				}
				else if (this.cBoxTipoPersona.Text.Equals("Admin"))
				{
					PersonaActual.TipoPersona = Persona.Tipo.Admin;
				}
			}
		}

		public override void GuardarCambios()
		{
			MapearADatos();
			PersonaLogic ul = new PersonaLogic();
			ul.Save(PersonaActual);
		}
		private void btnAceptar_Click(object sender, EventArgs e)
        {
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
			}
		}

		public static bool CompruebaEmail(string sEmailAComprobar)
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

		public static bool CompruebaNroTelefono(string strNumber)
		{
			Regex regex = new Regex("\\A[0-9]{7,10}\\z");
			Match match = regex.Match(strNumber);

			if (match.Success)
				return true;
			else
				return false;
		}

		public void NotificarError(string mensaje)
		{
			this.Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
