using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        public ComisionAdapter comisionData { get; set; }

        public ComisionLogic()
        {
            comisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return comisionData.GetAll();
        }
        public object GetComisionesPlanes()
        {
            return comisionData.GetComisionesPlanes();
        }

        public Comision GetOne(int iD)
        {
            return comisionData.GetOne(iD);
        }

        public void Save(Business.Entities.Comision c)
        {
            comisionData.Save(c);
        }
    }
}
