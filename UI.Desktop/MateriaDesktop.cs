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
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia _materiaActual;
        private ModoForm _mf;
        public Materia MateriaActual { get; set; }
        public ModoForm MF { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
            MF = modo;
            MateriaActual = new Materia();
        }
        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            MF = modo;
            //MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
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
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
        }
        public override void MapearADatos()
        {
            if (MF == ModoForm.Alta || MF == ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);

            }
            switch (MF)
            {
                case ModoForm.Alta:
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                    /*case ModoForm.Baja:
                        MateriaActual.State = BusinessEntity.States.Deleted;
                        break;*/
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                NotificarError("El campo 'Descripcion' está vacío");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtHsSemanales.Text))
            {
                NotificarError("El campo 'HS Semanales' está vacío");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtHsTotales.Text))
            {
                NotificarError("El campo 'HS Totales' está vacío");
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

