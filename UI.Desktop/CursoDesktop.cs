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
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso cursoActual { get; set; }
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            cursoActual = new CursoLogic().GetOne(ID);
            MapearDeDatos();
        }

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            CargaComboBoxMaterias();
            CargaComboBoxComisiones();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.cursoActual.ID.ToString();
            this.txtCupo.Text = this.cursoActual.Cupo.ToString();
            this.txtAñoCalendario.Text = this.cursoActual.AñoCalendario.ToString();
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo.Equals("Consulta"))
            {
                btnAceptar.Text = "Aceptar";
            }
        }
        public void CargaComboBoxMaterias()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                List<Materia> listaMaterias = ml.GetAll();
                Dictionary<int, string> comboSourceMateria = new Dictionary<int, string>();

                foreach (Materia m in listaMaterias)
                {
                    comboSourceMateria.Add(m.ID, m.Descripcion);
                }
                cBoxMaterias.DataSource = new BindingSource(comboSourceMateria, null);
                cBoxMaterias.DisplayMember = "Value";
                cBoxMaterias.ValueMember = "Key";
                cBoxMaterias.Text = "";
            }
            catch(Exception e)
            {
                MessageBox.Show("Deben existir Materias");
            }
        }

        public void CargaComboBoxComisiones()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                List<Comision> listaComisiones = cl.GetAll();
                Dictionary<int, string> comboSourceComision = new Dictionary<int, string>();

                foreach (Comision c in listaComisiones)
                {
                    comboSourceComision.Add(c.ID, c.Descripcion);
                }
                cBoxComisiones.DataSource = new BindingSource(comboSourceComision, null);
                cBoxComisiones.DisplayMember = "Value";
                cBoxComisiones.ValueMember = "Key";
                cBoxComisiones.Text = "";
            }
            catch(Exception e)
            {
                MessageBox.Show("Deben existir Comisiones");
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtAñoCalendario.Text))
            {
                Notificar("Error", "Incorrect txtAñosCalendario en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtCupo.Text))
            {
                Notificar("Error", "Incorrect txtCupo en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxMaterias.Text))
            {
                Notificar("Error", "Incorrect cBoxMaterias en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.cBoxComisiones.Text))
            {
                Notificar("Error", "Incorrect cBoxComisiones en blanco", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Curso c = new Curso();
                cursoActual = c;
                cursoActual.AñoCalendario = int.Parse(this.txtAñoCalendario.Text);
                cursoActual.Cupo = int.Parse(this.txtCupo.Text);
                cursoActual.IDComision = ((KeyValuePair<int, string>)cBoxComisiones.SelectedItem).Key;
                cursoActual.IDMateria = ((KeyValuePair<int, string>)cBoxMaterias.SelectedItem).Key;
                cursoActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                cursoActual.AñoCalendario = int.Parse(this.txtAñoCalendario.Text);
                cursoActual.Cupo = int.Parse(this.txtCupo.Text);
                cursoActual.IDComision = ((KeyValuePair<int, string>)cBoxComisiones.SelectedItem).Key;
                cursoActual.IDMateria = ((KeyValuePair<int, string>)cBoxMaterias.SelectedItem).Key;
                cursoActual.State = BusinessEntity.States.Modified;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(cursoActual);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
