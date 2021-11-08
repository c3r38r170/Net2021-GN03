using Business.Entities;
using Business.Logic;
using Data.Database;
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
    public partial class PlanesDesktop : ApplicationForm
    {
        public Plan PlanActual { get; set; }
        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanActual = new PlanLogic().GetOne(ID);
            MapearDeDatos();
        }

        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
            CargaComboBox();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
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

        private void CargaComboBox()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> listaEspecialidades = el.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();

            foreach (Especialidad e in listaEspecialidades)
            {
                comboSource.Add(e.ID, e.Descripcion);
                //cBoxEspecialidad.Items.Add(e.Descripcion);
                //cBoxEspecialidad.Items.Add(new { id_especialidad = e.ID, desc_especialidad = e.Descripcion });
            }
            cBoxEspecialidad.DataSource = new BindingSource(comboSource, null);
            cBoxEspecialidad.DisplayMember = "Value";
            cBoxEspecialidad.ValueMember = "Key";
            cBoxEspecialidad.Text = "";
        }

        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                Notificar("Error", "Incorrect txtDescripcion en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxEspecialidad.Text))
            {
                Notificar("Error", "Incorrect cBox en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void MapearADatos()
        {
            if(Modo == ModoForm.Alta)
            {
                Plan p = new Plan();
                PlanActual = p;
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = ((KeyValuePair<int, string>)cBoxEspecialidad.SelectedItem).Key; //int key = ((KeyValuePair<int, string>)cBoxEspecialidad.SelectedItem).Key;
                //string value  = ((KeyValuePair<int, string>)cBoxEspecialidad.SelectedItem).Value;
                PlanActual.State = BusinessEntity.States.New;
            }
            else if(Modo == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = ((KeyValuePair<int, string>)cBoxEspecialidad.SelectedItem).Key;
                PlanActual.State = BusinessEntity.States.Modified;
            }
            else if (Modo == ModoForm.Baja)
            {
                PlanActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(PlanActual);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
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
                    //PlanLogic ul = new PlanLogic();
                    //ul.Delete(PlanActual.ID);
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
