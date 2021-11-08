using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class InscriptoEn : Form
    {
        public InscripcionLogic InscripcionLogic { get; set; }

        public int IdPersonaActual { get; set; }
        public InscriptoEn()
        {
            InitializeComponent();
        }

        public InscriptoEn(int id_persona) : this()
        {
            InscripcionLogic = new InscripcionLogic();
            IdPersonaActual = id_persona;
        }

        private void InscriptoEn_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Listar()
        {
            try
            {
                this.dgvInscriptoEn.DataSource = InscripcionLogic.MateriasPorAlumno(IdPersonaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
