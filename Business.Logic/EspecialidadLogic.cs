using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }
		public Especialidad GetOne(int ID)
		{
			return EspecialidadData.GetOne(ID);
		}
		public List<Especialidad> GetAll()
		{
			return EspecialidadData.GetAll();
		}
		public void Save(Especialidad e)
		{
			EspecialidadData.Save(e);
		}
		public void Delete(int ID)
		{
			EspecialidadData.Delete(ID);
		}
	}
}
