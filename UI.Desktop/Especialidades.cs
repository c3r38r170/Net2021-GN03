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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop ed = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            Especialidad esp = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem);
            int ID = esp.ID;
            string message = $"¿Desea eliminar la especialidad {esp.Descripcion} ?";
            string title = "Eliminar especialidad";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                EspecialidadLogic el = new EspecialidadLogic();
                el.Delete(ID);
                // u.State = BusinessEntity.States.Deleted;
            }
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
