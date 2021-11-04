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
    public partial class MenuAlumno : ApplicationForm
    {
        public int IdPersona { get; set; }
        public MenuAlumno()
        {
            InitializeComponent();
        }

        public MenuAlumno(int idpersona) : this()
        {
            IdPersona = idpersona;
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

        private void btnInscribirseA_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("InscribirseA"))
            {
                InscribirseA ia = new InscribirseA(IdPersona);
                ia.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        private void btnInscriptoEn_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("InscriptoEn"))
            {
                InscriptoEn ia = new InscriptoEn(IdPersona);
                ia.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }
    }
}
