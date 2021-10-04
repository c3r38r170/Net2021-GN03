using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        public PersonaAdapter AlumnoData { get; set; }
        public PersonaLogic()
        {
            AlumnoData = new PersonaAdapter();
        }
        public List<Persona> GetAll()
        {
            return AlumnoData.GetAll();
        }

        public void Save(Persona u)
        {
            AlumnoData.Save(u);
        }

        public void Delete(int iD)
        {
            AlumnoData.Delete(iD);
        }

        public Persona GetOne(int iD)
        {
            return AlumnoData.GetOne(iD);
        }
    }
}
