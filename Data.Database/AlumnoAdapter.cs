using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class AlumnoAdapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Persona> _Persona;

        public static List<Persona> Personas
        {
            get
            {
                if (_Persona == null)
                {
                    _Persona = new List<Business.Entities.Persona>();
                    Business.Entities.Persona usr;
                    usr = new Business.Entities.Persona();
                    usr.ID = 23;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.Direccion = "la quiaca";
                    usr.Telefono = "222222222";
                    usr.Legajo = 32456;
                    usr.Email = "pedro@pedro.com";
                    usr.IDPlan = 3;
                    usr.FechaNacimiento = DateTime.Parse("01/01/2012");
                    usr.TipoPersona = Business.Entities.Persona.Tipo.Alumno;
                    _Persona.Add(usr);

                   
                    usr = new Business.Entities.Persona();
                    usr.ID = 22;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Perro";
                    usr.Apellido = "Loco";
                    usr.Direccion = "Jujuy";
                    usr.Telefono = "3245443";
                    usr.Legajo = 33456;
                    usr.Email = "jj@pedro.com";
                    usr.IDPlan = 3;
                    usr.FechaNacimiento = DateTime.Parse("02/02/2022");
                    usr.TipoPersona = Business.Entities.Persona.Tipo.Alumno;
                    _Persona.Add(usr);

                }
                return _Persona;
            }
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            return Personas.Find(delegate (Persona u) { return u.ID == ID; });
        }
        public void Delete(int ID)
        {
            Personas.Remove(this.GetOne(ID));
        }
        public void Save(Persona p)
        {
            if (p.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Persona usr in Personas)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                p.ID = NextID + 1;
                Personas.Add(p);
            }
            else if (p.State == BusinessEntity.States.Deleted)
            {
                this.Delete(p.ID);
            }
            else if (p.State == BusinessEntity.States.Modified)
            {
                Personas[Personas.FindIndex(delegate (Persona u) { return u.ID == p.ID; })] = p;
            }
            p.State = BusinessEntity.States.Unmodified;
        }
    
        #endregion
        public List<Persona> GetAll()
        {
            return new List<Persona>(Personas);
        }
    }
}
