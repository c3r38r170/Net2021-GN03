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

		public void Listar() {
			try {
				List<AlumnoInscripcion> ListaInscripcionesAlumnoActual = (new InscripcionLogic()).GetInscripcionesAlumnoActual(IdPersonaActual);

				DataTable dtInscripcionCurso = new DataTable();
				DataColumn dcIdInscripcion = new DataColumn("ID inscripcion");
				DataColumn dcIdCurso = new DataColumn("ID curso");
				DataColumn dcCondicion = new DataColumn("Condicion");
				DataColumn dcNota = new DataColumn("Nota");
				DataColumn dcIdMateria = new DataColumn("ID Materia");
				DataColumn dcIdComision = new DataColumn("ID comision");
				dtInscripcionCurso.Columns.Add(dcIdInscripcion);
				dtInscripcionCurso.Columns.Add(dcIdCurso);
				dtInscripcionCurso.Columns.Add(dcCondicion);
				dtInscripcionCurso.Columns.Add(dcNota);
				dtInscripcionCurso.Columns.Add(dcIdMateria);
				dtInscripcionCurso.Columns.Add(dcIdComision);

				DataRow fila;
				//LLENO LISTA CON TODOS LOS CURSOS
				List<Curso> ListaCursos = (new CursoLogic()).GetAll();

				foreach(AlumnoInscripcion ai in ListaInscripcionesAlumnoActual) {
					foreach(Curso c in ListaCursos) {
						if(ai.IDCurso == c.ID) {
							fila = dtInscripcionCurso.NewRow();
							fila[dcIdInscripcion] = ai.ID;
							fila[dcIdCurso] = c.ID;
							fila[dcCondicion] = ai.Condicion;
							fila[dcNota] = ai.Nota;
							fila[dcIdMateria] = c.IDMateria;
							fila[dcIdComision] = c.IDComision;
							dtInscripcionCurso.Rows.Add(fila);
						}
					}
				}
				//LLENO LISTA CON TODAS LAS COMISIONES
				List<Comision> ListaComisiones = (new ComisionLogic()).GetAll();
				//CREO TABLA A CUASI DEVOLVER
				DataTable dtACuasiDevolver = new DataTable();
				DataColumn dcIDInscripcion = new DataColumn("ID inscripcion");
				DataColumn dcMateria = new DataColumn("Materia");
				DataColumn dcComision = new DataColumn("Comision");
				DataColumn dcCondicionn = new DataColumn("Condicion");
				DataColumn dcNotaa = new DataColumn("Nota");
				dtACuasiDevolver.Columns.Add(dcIDInscripcion);
				dtACuasiDevolver.Columns.Add(dcMateria);
				dtACuasiDevolver.Columns.Add(dcComision);
				dtACuasiDevolver.Columns.Add(dcCondicionn);
				dtACuasiDevolver.Columns.Add(dcNotaa);
				//CARGO TABLA2
				foreach(DataRow row in dtInscripcionCurso.Rows) {
					foreach(Comision c in ListaComisiones) {
						if(int.Parse(row["ID comision"].ToString()) == c.ID) {
							fila = dtACuasiDevolver.NewRow();
							fila[dcIDInscripcion] = row["ID inscripcion"];
							fila[dcMateria] = row["ID Materia"];
							fila[dcComision] = c.Descripcion;
							fila[dcCondicionn] = row["Condicion"];
							fila[dcNotaa] = row["Nota"];
							dtACuasiDevolver.Rows.Add(fila);
						}
					}
				}

				//LLENO LISTA CON MATERIAS
				List<Materia> ListaMaterias = (new MateriaLogic()).GetAll();
				//CREO TABLA A DEVOLVER
				DataTable dtADevolver = new DataTable();
				DataColumn IdInscripcion = new DataColumn("ID inscripcion.");
				DataColumn Materia = new DataColumn("Materia.");
				DataColumn Comision = new DataColumn("Comision.");
				DataColumn Condicion = new DataColumn("Condicion.");
				DataColumn Nota = new DataColumn("Nota.");
				dtADevolver.Columns.Add(IdInscripcion);
				dtADevolver.Columns.Add(Materia);
				dtADevolver.Columns.Add(Comision);
				dtADevolver.Columns.Add(Condicion);
				dtADevolver.Columns.Add(Nota);
				//CARGO TABLA A DEVOLVER
				foreach(DataRow row in dtACuasiDevolver.Rows) {
					foreach(Materia m in ListaMaterias) {
						if(int.Parse(row["Materia"].ToString()) == m.ID) {
							fila = dtADevolver.NewRow();
							fila[IdInscripcion] = row["ID inscripcion"];
							fila[Materia] = m.Descripcion;
							fila[Comision] = row["Comision"];
							fila[Condicion] = row["Condicion"];
							fila[Nota] = row["Nota"];
							dtADevolver.Rows.Add(fila);
						}
					}
				}
				this.dgvInscriptoEn.DataSource= dtADevolver;
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

	}
}
