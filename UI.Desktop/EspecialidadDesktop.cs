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
    public partial class EspecialidadDesktop : ApplicationForm
    {    
        public Especialidad EspecialidadActual { get; set; }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadActual = new EspecialidadLogic().GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            if (Modo.Equals(ModoForm.Alta) || Modo.Equals(ModoForm.Modificacion))
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo.Equals(ModoForm.Baja))
            {
                btnAceptar.Text = "Eliminar";
            }
            else if (Modo.Equals("Consulta"))
            {
                btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Especialidad e = new Especialidad();
                EspecialidadActual = e;
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = BusinessEntity.States.Modified;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                NotificarError("El campo 'Descripcion' está vacío");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void NotificarError(string mensaje)
        {
            this.Notificar("Error", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        GuardarCambios();
                        this.Close();
                    }
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        GuardarCambios();
                        this.Close();
                    }
                    break;
            }
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
