using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
	public class Curso :BusinessEntity{
		private int _AñoCalendario;
		private int _Cupo;
		private int _IDComision;
		private int _IDMateria;

		public int AñoCalendario { get => _AñoCalendario; set => _AñoCalendario = value; }
		public int Cupo { get => _Cupo; set => _Cupo = value; }
		public int IDComision { get => _IDComision; set => _IDComision = value; }
		public int IDMateria { get => _IDMateria; set => _IDMateria = value; }

		private Comision _ComisionAsociada;
		public Comision ComisionAsociada {
			get => _ComisionAsociada;
			set => _ComisionAsociada = value;
		}

		private Materia _MateriaAsociada;
		public Materia MateriaAsociada {
			get => _MateriaAsociada;
			set => _MateriaAsociada = value;
		}
	}
}
