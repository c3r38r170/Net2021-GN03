using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class CargarNota : Form
    {
        public int IDcurso { get; set; }
        public CargarNota()
        {
            InitializeComponent();
        }
        public CargarNota(int id) : this()
        {
            IDcurso = id;
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnCargarNota_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool correc = true;
                AlumnoInscripcion ai;
                int indice = 0;
                int cantFilasDeDataGrid = this.dgvListaAlumnos.Rows.Count;
                AlumnoInscripcion[] arregloDeNotasYCondicion = new AlumnoInscripcion[cantFilasDeDataGrid];
                foreach (DataGridViewRow dr in this.dgvListaAlumnos.Rows)
                {
                    ai = new AlumnoInscripcion();
                    ai.ID = int.Parse(dr.Cells["IdInscripcion"].Value.ToString());
                    ai.Condicion = dr.Cells["Condicion"].Value.ToString();
                    ai.Nota = int.Parse(dr.Cells["Nota"].Value.ToString());
                    if (ai.Nota < 0 || ai.Nota > 10)
                    {
                        correc = false;
                    }
                    arregloDeNotasYCondicion[indice] = ai;
                    indice++;
                }
                if (correc == true)
                {
                    InscripcionLogic il = new InscripcionLogic();
                    il.CargaNotasYCondicion(arregloDeNotasYCondicion);
                    this.Listar();
                    MessageBox.Show("Notas cargadas correctamente");
                }
                else
                {
                    MessageBox.Show("Nota no permitida");
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        public void Listar()
        {
            InscripcionLogic il = new InscripcionLogic();
            this.dgvListaAlumnos.DataSource = il.GetAlumnosInscriptosEnCurso(IDcurso);
        }

        private void CargarNota_Load(object sender, System.EventArgs e)
        {
            this.dgvListaAlumnos.AutoGenerateColumns = false;
            Listar();
        }
    }
}
