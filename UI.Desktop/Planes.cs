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
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();      
            this.dvgPlanes.DataSource = pl.GetPlanesEspecialidad();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                PlanesDesktop pd = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
                pd.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //int ID = ((Business.Entities.Usuario)this.dvgPlanes.SelectedRows[0].DataBoundItem).ID;
                int ID = int.Parse(this.dvgPlanes.CurrentRow.Cells[0].Value.ToString());
                PlanesDesktop pd = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
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
                //int ID = ((Business.Entities.Usuario)this.dvgPlanes.SelectedRows[0].DataBoundItem).ID;
                int ID = int.Parse(this.dvgPlanes.CurrentRow.Cells[0].Value.ToString());
                PlanesDesktop pd = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
                this.Listar();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
        }
    }
}
