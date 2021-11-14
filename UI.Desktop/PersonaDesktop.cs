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

		public PersonaDesktop(Persona p, ModoForm modo) : this()
		{
			Modo = modo;
			PersonaActual = p;
			MapearDeDatos();
		}

		private void PersonaDesktop_Load(object sender, EventArgs e)
		{
			CargaComboBoxIDPlan();
			CargaComboBoxTipoPersona();
		}

		public override void MapearDeDatos()
		{
			txtID.Text = PersonaActual.ID.ToString();
			txtNombre.Text = PersonaActual.Nombre;
			txtApellido.Text = PersonaActual.Apellido;
			txtDireccion.Text = PersonaActual.Telefono;
			txtDireccion.Text = PersonaActual.Direccion;
			txtEmail.Text = PersonaActual.Email;
			txtTelefono.Text = PersonaActual.Telefono;
			txtLegajo.Text = PersonaActual.Legajo.ToString();
			txtFecha.Value = PersonaActual.FechaNacimiento;
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
            try
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
				cBoxIDPlan.Text = Modo.Equals(ModoForm.Alta) ?
					""
					: (from l in listaPlanes where l.ID == PersonaActual.IDPlan select l.Descripcion).First();
			}
			catch(Exception)
            {
				MessageBox.Show("Deben existir Planes");
            }
			

			
		}

		public void CargaComboBoxTipoPersona() {
			cBoxTipoPersona.Items.Add("Docente");
			cBoxTipoPersona.Items.Add("Alumno");
			cBoxTipoPersona.Items.Add("Admin");
			cBoxTipoPersona.Text = Modo.Equals(ModoForm.Alta)?
				""
				:PersonaActual.TipoPersona.ToString();
		}

		public override bool Validar()
		{
			if (string.IsNullOrWhiteSpace(txtApellido.Text))
			{
				Notificar("Error", "Incorrect txtApellido en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtDireccion.Text))
			{
				Notificar("Error", "Incorrect txtDireccion en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				Notificar("Error", "Incorrect Email en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtLegajo.Text))
			{
				Notificar("Error", "Incorrect Legajo en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!VerificaLegajo(PersonaActual, int.Parse(this.txtLegajo.Text)))
			{
				Notificar("Error", "Legajo existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
			{
				Notificar("Error", "Incorrect nombre en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(txtTelefono.Text))
			{
				Notificar("Error", "Incorrect telefono en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!CompruebaNroTelefono(txtTelefono.Text))
			{
				Notificar("Error", "Número de teléfono con formato incorrecto.\nEl número de teléfono debe constar de entre 7 y 10 números seguidos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(cBoxIDPlan.Text))
			{
				Notificar("Error", "Debe elegir un plan.", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (string.IsNullOrWhiteSpace(cBoxTipoPersona.Text))
			{
				Notificar("Error", "Incorrect cBoxTipoPersona en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else if (!CompruebaEmail(txtEmail.Text))
			{
				Notificar("Error", "Incorrect email", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else return true;
		}

		public override void MapearADatos()
		{
            try
            {
				if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
				{
					if (Modo == ModoForm.Alta)
					{
						Persona p = new Persona();
						PersonaActual = p;
						PersonaActual.State = BusinessEntity.States.New;
					}
					else
					{
						PersonaActual.State = BusinessEntity.States.Modified;
					}
					PersonaActual.Apellido = txtApellido.Text;
					PersonaActual.Nombre = txtNombre.Text;
					PersonaActual.Direccion = txtDireccion.Text;
					PersonaActual.Email = txtEmail.Text;
					PersonaActual.Telefono = txtTelefono.Text;
					PersonaActual.Legajo = int.Parse(txtLegajo.Text);
					PersonaActual.FechaNacimiento = txtFecha.Value;
					PersonaActual.IDPlan = ((KeyValuePair<int, string>)cBoxIDPlan.SelectedItem).Key;
					Persona.Tipo t;
					switch (cBoxTipoPersona.Text)
					{
						case "Alumno":
							t = Persona.Tipo.Alumno;
							break;
						case "Docente":
							t = Persona.Tipo.Docente;
							break;
						case "Admin":
							t = Persona.Tipo.Admin;
							break;
						default:
							t = Persona.Tipo.Otro;
							break;
					}
					PersonaActual.TipoPersona = t;
				}
			}
			catch(Exception e)
            {
				MessageBox.Show(e.Message);
            }
		
		}

		public override void GuardarCambios()
		{
            try
            {
                MapearADatos();
				PersonaLogic ul = new PersonaLogic();
				ul.Save(PersonaActual);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
		private void btnAceptar_Click(object sender, EventArgs e)
        {
			switch (Modo) {
			case ModoForm.Modificacion:
			case ModoForm.Alta:
				if (Validar()){
					GuardarCambios();
					Close();
				}
				break;
			}
		}

		public static bool CompruebaEmail(string sEmailAComprobar)
		{
			String sFormato;
			sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			return (Regex.IsMatch(sEmailAComprobar, sFormato))
				&& (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0);
		}

		public static bool CompruebaNroTelefono(string strNumber)
		{
			Regex regex = new Regex("\\A[0-9]{7,10}\\z");
			Match match = regex.Match(strNumber);

			return match.Success;
		}

		public void NotificarError(string mensaje)
		{
			Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
			Close();
        }

		public bool VerificaLegajo(Persona persona, int l)
		{
			List<Persona> listaPer = new PersonaLogic().GetAll();

			if (Modo == ModoForm.Modificacion)
			{
				for (int i = 0; i < listaPer.Count(); i++)
				{
					if (listaPer[i].Legajo == l)
					{
						listaPer.RemoveAt(i);
					}
				}
			}
			else
			{
				foreach (Persona p in listaPer)
				{
					if (p.Legajo.Equals(l)) { return false; }
				}
			}


			return true;
		}
	}
}
