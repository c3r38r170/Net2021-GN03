using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic {
	public class PersonaLogic : BusinessLogic {
		public PersonaAdapter PersonaData { get; set; }
		public PersonaLogic() {
			PersonaData = new PersonaAdapter();
		}
		public List<Persona> GetAll() {
			return PersonaData.GetAll();
		}

		public void Save(Persona u) {
			PersonaData.Save(u);
		}

		public void Delete(int ID) {
			PersonaData.Delete(ID);
		}

		public Persona GetOne(int ID) {
			return PersonaData.GetOne(ID);
		}

		public bool isValid(Persona u)
        {
			DateTime comp = new DateTime(1900, 01, 01, 00, 00, 00);
            if (PersonaData.Existe(u.Legajo))
            {
				u.ID = -1;
				return false;
            }
			return !string.IsNullOrWhiteSpace(u.Nombre)
				&& !string.IsNullOrWhiteSpace(u.Apellido)
				&& !string.IsNullOrWhiteSpace(u.Direccion)
				&& !string.IsNullOrWhiteSpace(u.Email)
				&& !string.IsNullOrWhiteSpace(u.Telefono)
				&& u.Legajo > 0
				&& u.Plan != null;
        }
	}
}
