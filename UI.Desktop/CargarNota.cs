using Business.Logic;
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
            int ID = int.Parse(this.dgvListaAlumnos.CurrentRow.Cells[0].Value.ToString());
            CargarNotaDesktop cnd = new CargarNotaDesktop(ID, ApplicationForm.ModoForm.Consulta);
            cnd.ShowDialog();
            this.Listar();
        }

        public void Listar()
        {
            InscripcionLogic il = new InscripcionLogic();
            this.dgvListaAlumnos.DataSource = il.GetAlumnosInscriptosEnCurso(IDcurso);
        }

        private void CargarNota_Load(object sender, System.EventArgs e)
        {
            Listar();
        }
    }
}
