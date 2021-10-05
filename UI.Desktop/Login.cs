using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Database;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
        }

		private void btnAcceder_Click(object sender, EventArgs e) {
			if (txtUsuario.Text == "") {
        MessageBox.Show("Ingrese nombre de usuario.");
        return;
      }
      if (txtContraseña.Text == "") {
        MessageBox.Show("Ingrese contraseña.");
        return;
      }


      var usuario = new UsuarioAdapter().GetUserByUsernameAndPassword(txtUsuario.Text,txtContraseña.Text);

			if (usuario.ID == 0) {
        MessageBox.Show("Las credenciales son incorrectas, intente nuevamente.");
			} else {
        MessageBox.Show("Bienvenido, "+usuario.Nombre+"!!");
			}
		}

		private void txtUsuario_TextChanged(object sender, EventArgs e) {

		}
	}
}
