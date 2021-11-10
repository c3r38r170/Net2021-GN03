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
    public partial class DocentesCursos : Form
    {
        public DocentesCursos() 
        {
            InitializeComponent();
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            this.dgvDocenteCurso.DataSource = dcl.GetAll();
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
            try
            {
                DocenteCursoDesktop dcd = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
                dcd.ShowDialog();
                this.Listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocenteCurso.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop pd = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(this.dgvDocenteCurso.CurrentRow.Cells[3].Value.ToString());
                string message = $"¿Desea eliminar  {ID}?";
                string title = "Eliminar";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    dcl.Delete(ID);

                }
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
