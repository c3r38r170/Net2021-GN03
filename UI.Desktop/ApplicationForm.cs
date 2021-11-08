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
    public partial class ApplicationForm : Form
    {
        public ModoForm modo;

        public ApplicationForm()
        {
            InitializeComponent();
        }
        public ModoForm Modo { get => modo; set => modo = value; }
        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }
        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }


        private void ApplicationForm_Load(object sender, EventArgs e)
        {

        }

		private void ApplicationForm_FormClosed(object sender, FormClosedEventArgs e) {
			if(e.CloseReason == CloseReason.UserClosing) {
				Application.Exit();
			}
		}
	}
}
