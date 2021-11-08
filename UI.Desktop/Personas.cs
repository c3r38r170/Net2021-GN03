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
    public partial class Personas : ApplicationForm
    {
   
        public Personas()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvUsuarios.DataSource = pl.GetAll();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop ud = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            PersonaDesktop ud = new PersonaDesktop((Persona)this.dgvUsuarios.SelectedRows[0].DataBoundItem, ApplicationForm.ModoForm.Modificacion);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            Persona u = ((Business.Entities.Persona)this.dgvUsuarios.SelectedRows[0].DataBoundItem);
            int ID = u.ID;
            string message = $"¿Desea eliminar al usuario {u.Apellido}, {u.Nombre}?";
            string title = "Eliminar usuario";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                PersonaLogic ul = new PersonaLogic();
                ul.Delete(ID);
                // u.State = BusinessEntity.States.Deleted;
            }
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
