using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PlanLogic: BusinessLogic
    {
        public PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public void Save(Plan planActual)
        {
            PlanData.Save(planActual);
        }

        public object GetPlanesEspecialidad()
        {
            return PlanData.GetPlanesEspecialidad();
        }
    }
}
