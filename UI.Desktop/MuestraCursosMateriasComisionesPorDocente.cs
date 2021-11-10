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
    public partial class MuestraCursosMateriasComisionesPorDocente : ApplicationForm
    {
        public int IDProfesor { get; set; }
        public MuestraCursosMateriasComisionesPorDocente()
        {
            InitializeComponent();
        }

        public MuestraCursosMateriasComisionesPorDocente(int id) : this()
        {
            IDProfesor = id;
        }

        private void CargarNota_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
           
            try
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                this.dgvDocenteCursos.DataSource = dcl.GetCurosPorDocentes(IDProfesor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCargarNota_Click(object sender, EventArgs e)//ES EL BOTON SELECCIONAR CURSo
        {
            try
            {
                int ID = int.Parse(this.dgvDocenteCursos.CurrentRow.Cells[0].Value.ToString());
                CargarNota cn = new CargarNota(ID);
                cn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
