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
    public partial class MenuDocente : ApplicationForm
    {
        public int IdProfesor { get; set; }
        public MenuDocente()
        {
            InitializeComponent();
        }

        public MenuDocente(int idProfesor) : this()
        {
            IdProfesor = idProfesor;
        }

        private bool detectarFormularioAbierto(string formulario)
        {
            bool abierto = false;

            if (Application.OpenForms[formulario] != null)
            {
                abierto = true;
            }
            return abierto;
        }

        private void btnAgregarNota_Click_1(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("MuestraCursosMateriasComisionesPorDocente"))
            {
                MuestraCursosMateriasComisionesPorDocente cn = new MuestraCursosMateriasComisionesPorDocente(IdProfesor);
                cn.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            string message = $"¿Desea cerrar session?";
            string title = "Cerrar Session";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Close();
            }
        }

        private void MenuDocente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
