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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        public DocenteCurso DocenteCursoActual { get; set; }
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            DocenteCursoActual = new DocenteCursoLogic().GetOne(ID);
            MapearDeDatos();
        }

        private void DocenteCursoDesktop_Load(object sender, EventArgs e)
        {
            CargaComboBoxCursos();
            CargaComboBoxDocentes();
            CargaComboBoxCargos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = DocenteCursoActual.ID.ToString();
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo.Equals("Consulta"))
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        private void CargaComboBoxCursos()
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> listaCursos = cl.GetAll();
            Dictionary<int, int> comboSourceCurso = new Dictionary<int, int>();

            foreach (Curso c in listaCursos)
            {
                comboSourceCurso.Add(c.ID, c.ID);
            }
            cBoxCursos.DataSource = new BindingSource(comboSourceCurso, null);
            cBoxCursos.DisplayMember = "Value";
            cBoxCursos.ValueMember = "Key";
            cBoxCursos.Text = "...";
        }

        private void CargaComboBoxDocentes()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> listaPersonas = pl.GetAll();
            Dictionary<int, int> comboSourcePersona = new Dictionary<int, int>();

            foreach (Persona p in listaPersonas)
            {
                if (((int)p.TipoPersona) == 1)
                {
                    comboSourcePersona.Add(p.ID, p.Legajo);
                }
            }
            cBoxDocentes.DataSource = new BindingSource(comboSourcePersona, null);
            cBoxDocentes.DisplayMember = "Value";
            cBoxDocentes.ValueMember = "Key";
            cBoxDocentes.Text = "...";
        }

        private void CargaComboBoxCargos()
        {
            Dictionary<int, string> comboSourceCargo = new Dictionary<int, string>();

            comboSourceCargo.Add(1, "Docente Practica");
            comboSourceCargo.Add(2, "Docente Teorio");
            comboSourceCargo.Add(3, "Ayudante");

            cBoxCargos.DataSource = new BindingSource(comboSourceCargo, null);
            cBoxCargos.DisplayMember = "Value";
            cBoxCargos.ValueMember = "Key";
            cBoxCargos.Text = "...";
        }

        public override bool Validar()
        {
            if (cBoxDocentes.Text.Equals("..."))
            {
                Notificar("Error", "Incorrect No selecciono Docente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cBoxCursos.Text.Equals("..."))
            {
                Notificar("Error", "Incorrect No selecciono Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cBoxCargos.Text.Equals("..."))
            {
                Notificar("Error", "Incorrect No selecciono Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DocenteCurso dc = new DocenteCurso();
                DocenteCursoActual = dc;
                DocenteCursoActual.IDCurso = ((KeyValuePair<int, int>)cBoxCursos.SelectedItem).Key;
                DocenteCursoActual.IDDocente = ((KeyValuePair<int, int>)cBoxDocentes.SelectedItem).Key;
                DocenteCursoActual.Cargo = (DocenteCurso.tipoCargo)((KeyValuePair<int, string>)cBoxCargos.SelectedItem).Key;
                DocenteCursoActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                DocenteCursoActual.IDCurso = ((KeyValuePair<int, int>)cBoxCursos.SelectedItem).Key;
                DocenteCursoActual.IDDocente = ((KeyValuePair<int, int>)cBoxDocentes.SelectedItem).Key;
                DocenteCursoActual.Cargo = (DocenteCurso.tipoCargo)((KeyValuePair<int, string>)cBoxCargos.SelectedItem).Key;
                DocenteCursoActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            dcl.Save(DocenteCursoActual);
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
