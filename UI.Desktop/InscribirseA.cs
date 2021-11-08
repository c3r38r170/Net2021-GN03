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
    public partial class InscribirseA : Form
    {
        public CursoLogic CursoLogic { get; set; }
        public int IdPersonaActual { get; set; }
        public InscribirseA()
        {
            InitializeComponent();
        }
        public InscribirseA(int id_persona) : this()
        {
            CursoLogic = new CursoLogic();
            IdPersonaActual = id_persona;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(this.dgvCursosInscripcion.CurrentRow.Cells[0].Value.ToString());
                Curso c = CursoLogic.GetOne(ID);
                if (c.Cupo == 0)
                {
                    MessageBox.Show("NO QUEDAN CUPOS");
                }
                else
                {
                    if (CursoLogic.yaEstaInscripto(ID, IdPersonaActual))
                    {
                        MessageBox.Show("YA ESTA INSCRIPTO A ESTE CURSO!");
                    }
                    else
                    {
                        AlumnoInscripcion al = new AlumnoInscripcion();
                        al.Condicion = "cursando";
                        al.IDAlumno = IdPersonaActual;
                        al.IDCurso = c.ID;
                        al.State = BusinessEntity.States.New;
                        InscripcionLogic il = new InscripcionLogic();
                        il.Save(al);

                        c.Cupo = c.Cupo - 1;
                        c.State = BusinessEntity.States.Modified;
                        CursoLogic.Save(c);

                        MessageBox.Show("INSCRIPTO CORRECTAMENTE!");
                    }

                }

                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        public void Listar()
        {
            try
            {
                this.dgvCursosInscripcion.DataSource = CursoLogic.GetCursosMateriasComisiones();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
    }
}
