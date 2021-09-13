using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanesLogic : BusinessLogic
    {
        public PlanAdapter PlanData { get; set; }

        public PlanesLogic()
        {
            PlanData = new PlanAdapter();
        }
        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Save(Plan planActual)
        {
            PlanData.Save(planActual);
        }

        public Plan GetOne(int iD)
        {
            return PlanData.GetOne(iD);
        }

        public void Delete(int iD)
        {
            PlanData.Delete(iD);
        }
    }
}
