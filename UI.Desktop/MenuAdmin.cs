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
    public partial class MenuAdmin : ApplicationForm
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void txtExpecialidad_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Especialidades"))
            {
                Especialidades es = new Especialidades();
                es.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
            
        }

        private void txtPlanes_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Planes"))
            {
                Planes p = new Planes();
                p.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
                
        }

        private void txtComisiones_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Comisiones"))
            {
                Comisiones c = new Comisiones();
                c.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        private void txtMaterias_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Materias"))
            {
                Materias m = new Materias();
                m.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        private void txtCursos_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Cursos"))
            {
                Cursos c = new Cursos();
                c.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        

        private void Personas_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Personas"))
            {
                Personas p = new Personas();
                p.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("Usuarios"))
            {
                Usuarios u = new Usuarios();
                u.Show();
            }
            else
            {
                MessageBox.Show("EL FORMULARIO YA ESTA OPEN");
            }
        }

        private void btnDocentesCursos_Click(object sender, EventArgs e)
        {
            if (!detectarFormularioAbierto("DocenteCurso"))
            {
                DocentesCursos dc = new DocentesCursos();
                dc.Show();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            string message = $"¿Desea eliminar al usuario cerrar session?";
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
    }
}
