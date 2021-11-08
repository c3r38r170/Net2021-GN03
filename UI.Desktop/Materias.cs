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
namespace UI.Desktop
{
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetMateriasPlanes();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
                formMateria.ShowDialog();
                this.Listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = int.Parse(this.dgvMaterias.CurrentRow.Cells[0].Value.ToString());
                MateriaDesktop md = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                md.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Materia m = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem);
                int ID = int.Parse(this.dgvMaterias.CurrentRow.Cells[0].Value.ToString());
                string message = $"¿Desea eliminar la materia {ID}?";
                string title = "Eliminar materia";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    MateriaLogic ml = new MateriaLogic();
                    ml.Delete(ID);

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
