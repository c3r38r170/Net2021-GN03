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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _usuarioActual;
        private ModoForm _mF;

        public Usuario UsuarioActual { get; set; }
        public ModoForm MF { get; set; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo):this()
        {
            MF = modo;
            InitializeComponent();
        }
        public UsuarioDesktop(int ID, ModoForm modo):this()
        {
            MF = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
            InitializeComponent();
        }
        public virtual void MapearDeDatos() 
        {
            if ((MF == ApplicationForm.ModoForm.Alta) || (MF == ApplicationForm.ModoForm.Alta))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (MF == ApplicationForm.ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (MF == ApplicationForm.ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
        }
        public virtual void MapearADatos()
        {
            if (MF == ApplicationForm.ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Email = this.txtNombre.Text;
                UsuarioActual.NombreUsuario = this.txtNombre.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.State = BusinessEntity.States.New;
            }
        }
        public virtual void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        public virtual bool Validar()
        {
            if ((this.txtNombre.Text).Equals(""))
            {
                Notificar("Error", "El campo 'Nombre' está vacío", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtApellido.Text).Equals(""))
            {
                Notificar("Error", "El campo 'Apellido' está vacío", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtEmail.Text).Equals(""))
            {
                Notificar("Error", "El campo 'Email' está vacío", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtUsuario.Text).Equals(""))
            {
                Notificar("Error", "El campo 'Usuario' está vacío", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtClave.Text).Equals(""))
            {
                Notificar("Error", "El campo 'Clave' está vacío", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtConfirmarClave.Text).Equals(""))
            {
                Notificar("Error", "El campo 'Confirmar Clave' está vacío", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtClave.Text).Length < 8)
            {
                Notificar("Error","La contraseña debe tener más de 8 caracteres",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }
            else if ((this.txtConfirmarClave.Text).Length < 8)
            {
                Notificar("Error", "La contraseña debe tener más de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!(this.txtClave.Text.Equals(this.txtConfirmarClave.Text)))
            {
                Notificar("Error", "La contraseñas deben coincidir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (ComprobarFormatoEmail(this.txtEmail.Text))
            {
                Notificar("Error", "El Email no es válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Boolean b = Validar();
            if (b)
            {
                GuardarCambios();
                Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
