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

        private void btnAgregarNota_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("CargarNota"))
            {
                CargarNota cn = new CargarNota(IdProfesor);
                cn.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
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
    }
}
