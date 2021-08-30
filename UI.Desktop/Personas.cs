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
        //private ToolStripContainer toolStripContainer1;
        //private ToolStrip toolStrip1;
        //private ToolStripButton toolStripButton1 = new ToolStripButton();
        //private ToolStripButton toolStripButton2;
        //private ToolStripButton toolStripButton3;


        public Personas()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
            //toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            //toolStrip1 = new System.Windows.Forms.ToolStrip();

            // Add items to the ToolStrip.

            //toolStripButton2 = new ToolStripButton();
            //toolStripButton3 = new ToolStripButton();
            //toolStripButton1.Enabled = true;
            //toolStripButton2.Enabled = true;
            //toolStripButton3.Enabled = true;

            //toolStrip1.Items.Add(toolStripButton1);
            //toolStrip1.Items.Add(toolStripButton2);
            //toolStrip1.Items.Add(toolStripButton3);

            // Add the ToolStrip to the top panel of the ToolStripContainer.

            //toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);

            // Add the ToolStripContainer to the form.

            //Controls.Add(toolStripContainer1);
        }

        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
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
            int ID = ((Business.Entities.Persona)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop ud = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
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
