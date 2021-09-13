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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvAlumnos.DataSource = ul.GetAll();
        }
        private void Alumnos_Load(object sender, EventArgs e)
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
            UsuarioDesktop ud = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            Usuario u = ((Business.Entities.Usuario)this.dgvAlumnos.SelectedRows[0].DataBoundItem);
            int ID = u.ID;
            string message = $"¿Desea eliminar al usuario {u.Apellido}, {u.Nombre}?";
            string title = "Eliminar usuario";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                UsuarioLogic ul = new UsuarioLogic();
                ul.Delete(ID);
                // u.State = BusinessEntity.States.Deleted;
            }
            this.Listar();
        }
    }
}
