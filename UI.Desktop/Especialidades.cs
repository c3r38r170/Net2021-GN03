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
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
           
                Listar();
         
            
        }

        public void Listar()
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
                ed.ShowDialog();
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
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ed = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ed.ShowDialog();
                this.Listar();
            }
             catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Especialidad esp = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem);
                int ID = esp.ID;
                string message = $"¿Desea eliminar la especialidad {esp.Descripcion} ?";
                string title = "Eliminar especialidad";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    EspecialidadLogic el = new EspecialidadLogic();
                    el.Delete(ID);
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
