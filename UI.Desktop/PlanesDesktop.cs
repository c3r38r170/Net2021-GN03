using Business.Entities;
using Business.Logic;
using Data.Database;
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
    public partial class PlanesDesktop : ApplicationForm
    {
        public Plan PlanActual { get; set; }
        public ModoForm MF { get; set; }
        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo) : this()
        {
            MF = modo;
            PlanActual = new Plan();
        }

        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            MF = modo;
            PlanesLogic ul = new PlanesLogic();
            PlanActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                {
                    switch (MF)
                    {
                        case ModoForm.Alta:
                            this.GuardarCambios();
                            this.Close();
                            break;
                        case ModoForm.Modificacion:
                            this.GuardarCambios();
                            this.Close();
                            break;
                    }
                }
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                NotificarError("El campo 'Descripcion' está vacío");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(this.txtEspecialidad.Text))
            {
                NotificarError("El campo 'Especialidad' está vacío");
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

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanesLogic pl = new PlanesLogic();
            pl.Save(PlanActual);
        }

        public override void MapearADatos()
        {
            if (MF == ModoForm.Alta || MF == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = Int32.Parse(this.txtEspecialidad.Text);
            }
            switch (MF)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                /*case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;*/
            }
        }
        public override void MapearDeDatos()
        {
            if ((MF == ModoForm.Alta) || (MF == ModoForm.Modificacion))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (MF == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.txtEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();           
        }

        private void CargaComboBox()
        {
            PlanAdapter pa = new PlanAdapter();
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            listaEspecialidades = pa.CargaComboBox();
            txtEspecialidad.DataSource = listaEspecialidades;
            txtEspecialidad.DisplayMember = "desc_especialidad";
            txtEspecialidad.ValueMember = "id_especialidad";
        }

        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
            CargaComboBox();
        }
    }
}
