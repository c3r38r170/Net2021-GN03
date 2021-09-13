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
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            this.dvgPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanesLogic pl = new PlanesLogic();
            this.dvgPlanes.DataSource = pl.GetAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop pd = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dvgPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanesDesktop pd = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            pd.ShowDialog();
            this.Listar();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Plan p = ((Business.Entities.Plan)this.dvgPlanes.SelectedRows[0].DataBoundItem);
            int ID = p.ID;
            string message = $"¿Desea eliminar al plan seleccionado?";
            string title = "Eliminar usuario";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                PlanesLogic ul = new PlanesLogic();
                ul.Delete(ID);
            }
            this.Listar();
        }
    }
}
