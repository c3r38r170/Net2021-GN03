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
    public partial class CargarNota : ApplicationForm
    {
        public int IDProfesor { get; set; }
        public CargarNota()
        {
            InitializeComponent();
        }

        public CargarNota(int id) : this()
        {
            IDProfesor = id;
        }

        private void CargarNota_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            this.dgvDocenteCursos.DataSource = dcl.GetAlumnosDeCurso(IDProfesor);
        }

        private void btnCargarNota_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.dgvDocenteCursos.CurrentRow.Cells[0].Value.ToString());
            CargarNotaDesktop f = new CargarNotaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            f.ShowDialog();
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
