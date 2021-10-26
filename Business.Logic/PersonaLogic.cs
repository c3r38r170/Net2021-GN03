﻿using System;
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
	}
}
