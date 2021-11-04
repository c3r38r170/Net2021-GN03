using Business.Entities;
using Business.Logic;
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
    public partial class CargarNotaDesktop : ApplicationForm
    {
        public AlumnoInscripcion InscripcionActual { get; set; }
        public CargarNotaDesktop()
        {
            InitializeComponent();
        }

        public CargarNotaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            InscripcionActual = new InscripcionLogic().GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearADatos()
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            InscripcionActual = ai;
            InscripcionActual.ID = int.Parse(this.txtID.Text);
            InscripcionActual.Nota = int.Parse(this.txtNota.Text);
            InscripcionActual.Condicion = this.txtCondicion.Text;
            InscripcionActual.State = BusinessEntity.States.Modified;
        }

        public override bool Validar()
        {

            if (string.IsNullOrWhiteSpace(this.txtCondicion.Text))
            {
                Notificar("Error", "Incorrect Condicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!this.txtCondicion.Text.Equals("regular") && !this.txtCondicion.Text.Equals("libre") && !this.txtCondicion.Text.Equals("promovido"))
            {
                Notificar("Error", "Incorrect Condicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtNota.Text))
            {
                Notificar("Error", "Incorrect txtNota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (int.Parse(this.txtNota.Text) < 1 || int.Parse(this.txtNota.Text) > 10)
            {
                Notificar("Error", "Incorrect txtNota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            InscripcionLogic il = new InscripcionLogic();
            il.Save(InscripcionActual);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
