using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class InscripcionLogic: BusinessLogic
    {
        public InscripcionAdapter InscripcionData { get; set; }
        public InscripcionLogic()
        {
            InscripcionData = new InscripcionAdapter();
        }
        public void Save(AlumnoInscripcion al)
        {
            InscripcionData.Save(al);
        }

        public object MateriasPorAlumno(int idPersonaActual)
        {
            return InscripcionData.MateriasPorAlumno(idPersonaActual);
        }

        public AlumnoInscripcion GetOne(int iD)
        {
            return InscripcionData.GetOne(iD);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return InscripcionData.GetAll();
        }

        public object GetAlumnosInscriptosEnCurso(int dcurso)
        {
            return InscripcionData.GetAlumnosInscriptosEnCurso(dcurso);
        }

        public List<AlumnoInscripcion> GetAlumnosPorCurso(int idCurso)
        {
            return InscripcionData.GetAlumnosPorCurso(idCurso);
        }
    }
}
