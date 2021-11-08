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
            try
            {
                PersonaDesktop ud = new PersonaDesktop(ModoForm.Alta);
                ud.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaDesktop ud = new PersonaDesktop((Persona)this.dgvUsuarios.SelectedRows[0].DataBoundItem, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {try
            {
                Persona u = ((Persona)this.dgvUsuarios.SelectedRows[0].DataBoundItem);
                int ID = u.ID;
                string message = $"¿Desea eliminar a {u.Apellido}, {u.Nombre} de la base de datos? (Esta acción no se puede deshacer.)";
                string title = "Eliminar usuario";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    PersonaLogic ul = new PersonaLogic();
                    ul.Delete(ID);
                }
                this.Listar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Listar();
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
