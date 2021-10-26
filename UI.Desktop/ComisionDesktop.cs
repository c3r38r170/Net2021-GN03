using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public Comision ComisionActual { get; set; }
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo; 
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionActual = new ComisionLogic().GetOne(ID);
            MapearDeDatos();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            CargaComboBox();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAñoEspecialidad.Text = this.ComisionActual.AñoEspecialidad.ToString();
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo.Equals(ModoForm.Baja))
            {
                btnAceptar.Text = "Eliminar";
            }
            else if (Modo.Equals("Consulta"))
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        public void CargaComboBox()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> listaPlanes = pl.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();

            foreach (Plan p in listaPlanes)
            {
                comboSource.Add(p.ID, p.Descripcion);
            }
            cBoxPlan.DataSource = new BindingSource(comboSource, null);
            cBoxPlan.DisplayMember = "Value";
            cBoxPlan.ValueMember = "key";
            cBoxPlan.Text = "";
        }

        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                Notificar("Error", "Incorrect txtDescripcion en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxPlan.Text))
            {
                Notificar("Error", "Incorrect cBox en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtAñoEspecialidad.Text))
            {
                Notificar("Error", "Incorrect txtDescripcion en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Comision c = new Comision();
                ComisionActual = c;
                ComisionActual.AñoEspecialidad = int.Parse(this.txtAñoEspecialidad.Text);
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.IDPlan = ((KeyValuePair<int, string>)cBoxPlan.SelectedItem).Key;
                ComisionActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                ComisionActual.AñoEspecialidad = int.Parse(this.txtAñoEspecialidad.Text);
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.IDPlan = ((KeyValuePair<int, string>)cBoxPlan.SelectedItem).Key;
                ComisionActual.State = BusinessEntity.States.Modified;
            }
            else if (Modo == ModoForm.Baja)
            {
                ComisionActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic el = new ComisionLogic();
            el.Save(ComisionActual);
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
                case ModoForm.Baja:
                    GuardarCambios();
                    this.Close();
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
