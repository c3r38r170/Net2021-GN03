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
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.DataSource = cl.GetCursosMateriasComisiones();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop pd = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            int ID = int.Parse(this.dgvCursos.CurrentRow.Cells[0].Value.ToString());
            CursoDesktop cd = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            cd.ShowDialog();
            this.Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.dgvCursos.CurrentRow.Cells[0].Value.ToString());
            string message = $"¿Desea eliminar curso {ID}?";
            string title = "Eliminar Curso";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                CursoLogic cl = new CursoLogic();
                cl.Delete(ID);

            }
            this.Listar();
        }
    }
}
