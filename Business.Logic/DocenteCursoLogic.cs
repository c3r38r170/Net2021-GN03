using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        public DocenteCursoAdapter DocenteCursoData { get; set; }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }

        public void Delete(int iD)
        {
            DocenteCursoData.Delete(iD);
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }

        public object GetAlumnosDeCurso(int IDProfesor)
        {
            return DocenteCursoData.GetAlumnosDeCurso(IDProfesor);
        }

        public void Save(DocenteCurso docenteCursoActual)
        {
            DocenteCursoData.Save(docenteCursoActual);
        }
    }
}
