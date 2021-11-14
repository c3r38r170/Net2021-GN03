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

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia MateriaActual { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaActual = new MateriaLogic().GetOne(ID);
            MapearDeDatos();
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            CargaComboBox();
        }
        public override void MapearDeDatos()
        {
            this.txtIdMateria.Text = this.MateriaActual.ID.ToString();
            this.txtDescMateria.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo.Equals("Consulta"))
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        private void CargaComboBox()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                List<Plan> listaPlanes = pl.GetAll();
                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                foreach (Plan p in listaPlanes)
                {
                    comboSource.Add(p.ID, p.Descripcion);
                }
                cBoxDescPlan.DataSource = new BindingSource(comboSource, null);
                cBoxDescPlan.DisplayMember = "Value";
                cBoxDescPlan.ValueMember = "Key";
                cBoxDescPlan.Text = "";
            }
            catch(Exception)
            {
                MessageBox.Show("Deben existir Planes");
            }
           
        }

        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescMateria.Text))
            {
                Notificar("Error", "Incorrect txtDescripcion en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtHsSemanales.Text))
            {
                Notificar("Error", "Incorrect Horas Semanales en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtHsTotales.Text))
            {
                Notificar("Error", "Incorrect hs totales en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxDescPlan.Text))
            {
                Notificar("Error", "Incorrect plan en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void MapearADatos()
        {
            try
            {
                if (Modo == ModoForm.Alta)
                {
                    Materia m = new Materia();
                    MateriaActual = m;
                    MateriaActual.Descripcion = this.txtDescMateria.Text;
                    MateriaActual.HSSemanales = int.Parse(this.txtHsSemanales.Text);
                    MateriaActual.HSTotales = int.Parse(this.txtHsTotales.Text);
                    MateriaActual.IDPlan = ((KeyValuePair<int, string>)cBoxDescPlan.SelectedItem).Key;
                    MateriaActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    MateriaActual.Descripcion = this.txtDescMateria.Text;
                    MateriaActual.HSSemanales = int.Parse(this.txtHsSemanales.Text);
                    MateriaActual.HSTotales = int.Parse(this.txtHsTotales.Text);
                    MateriaActual.IDPlan = ((KeyValuePair<int, string>)cBoxDescPlan.SelectedItem).Key;
                    MateriaActual.State = BusinessEntity.States.Modified;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("valor inapropiado");
            }
                
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic el = new MateriaLogic();
            el.Save(MateriaActual);
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
                Close();
        }

       
    }
} 


