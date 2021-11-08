using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
	public class Plan :BusinessEntity{
		private string _Descripcion;
		private int _IDEspecialidad;
		private Especialidad _especialidad;

		public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
		public int IDEspecialidad { get => _IDEspecialidad; set => _IDEspecialidad = value; }
        public Especialidad Especialidad { get => _especialidad; set => _especialidad = value; }
    }
}
