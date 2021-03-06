using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaAdapter MateriaData { get; set; }
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }
        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public object GetMateriasPlanes()
        {
            return MateriaData.GetMateriasPlanes();
        }

        public void Save(Materia m)
        {
            MateriaData.Save(m);
        }
        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public bool isValid(Materia m)
        {
            return !string.IsNullOrWhiteSpace(m.Descripcion)
                && m.HSSemanales > 0
                && m.HSTotales > 0
                && m.IDPlan > 0
                && m.HSTotales > m.HSSemanales;
        }
     }
}
