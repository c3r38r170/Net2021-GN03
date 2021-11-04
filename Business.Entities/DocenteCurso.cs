﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
	public class DocenteCurso:BusinessEntity {

		private tipoCargo _Cargo;
		private int _IDCurso;
		private int _IDDocente;

		public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
		public int IDDocente { get => _IDDocente; set => _IDDocente = value; }
		public tipoCargo Cargo { get => _Cargo; set => _Cargo = value; }

		public enum tipoCargo
		{
			DocentePractica = 1,
			DocenteTeoria = 2,
			Ayudante = 3,
		}
	}
}