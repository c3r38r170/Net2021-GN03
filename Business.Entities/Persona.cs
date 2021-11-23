using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
	public class Persona :BusinessEntity{
		private string _Apellido;
		private string _Direccion;
		private string _Email;
		private string _Nombre;
		private string _Telefono;
		private int _Legajo;
		private int _IDPlan;
		private Plan _Plan;
		private DateTime _FechaNacimiento;
		//private int _tipoPersona;
		private Tipo _tipoPersona;

		public string Apellido { get => _Apellido; set => _Apellido = value; }
		public string Direccion { get => _Direccion; set => _Direccion = value; }
		public string Email { get => _Email; set => _Email = value; }
		public string Nombre { get => _Nombre; set => _Nombre = value; }
		public string Telefono { get => _Telefono; set => _Telefono = value; }
		public int Legajo { get => _Legajo; set => _Legajo = value; }
		public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
		public Plan Plan { get => _Plan; set => _Plan = value; }
		public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
		//public int TipoPersona { get => _tipoPersona; set => _tipoPersona = value; }
		public string NombreCompleto { get => Nombre + " " + Apellido; }
		public Tipo TipoPersona { get => _tipoPersona; set => _tipoPersona = value; }
		public enum Tipo
		{
			Docente=1,
			Alumno,
			Admin,
			Otro
		}
	}
}
