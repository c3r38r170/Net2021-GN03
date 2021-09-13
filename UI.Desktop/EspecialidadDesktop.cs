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
        private Especialidad _especialidadActual;
        private ModoForm _MF;

        public Especialidad EspecialidadActual { get; set; }
        public ModoForm MF { get; set; }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            MF = modo;
            EspecialidadActual = new Especialidad();
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            MF = modo;
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadActual = el.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            if ((MF == ModoForm.Alta) || (MF == ModoForm.Alta))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (MF == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
        }
        public override void MapearADatos()
        {
            if (MF == ModoForm.Alta || MF == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }
            switch (MF)
            {
                case ModoForm.Alta:
                    EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                    /*case ModoForm.Baja:
                        EspecialidadActual.State = BusinessEntity.States.Deleted;
                        break;*/
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool v = Validar();
            if (v)
            {
                switch (MF)
                {
                    case ModoForm.Alta:
                        GuardarCambios();
                        this.Close();
                        break;
                    case ModoForm.Modificacion:
                        GuardarCambios();
                        this.Close();
                        break;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
