using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
	public class DocenteCurso:BusinessEntity {

		private TiposCargos _curso;
		private int _IDCurso;
		private int _IDDocente;

		public TiposCargos Curso { get => _curso; set => _curso = value; }
		public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
		public int IDDocente { get => _IDDocente; set => _IDDocente = value; }
		
		public enum TiposCargos
		{
			Docente,
			Barrendero
		}
	}
}