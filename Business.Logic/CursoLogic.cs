﻿using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }
        public object GetCursosMateriasComisiones()
        {
            return CursoData.GetCursosMateriasComisiones();
        }

        public void Delete(int iD)
        {
            CursoData.Delete(iD);
        }

        public Curso GetOne(int iD)
        {
            return CursoData.GetOne(iD);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public void Save(Curso cursoActual)
        {
            CursoData.Save(cursoActual);
        }

        public bool yaEstaInscripto(int iD, int idPersonaActual)
        {
            return CursoData.yaEstaInscripto(iD, idPersonaActual);
        }

        public List<Curso> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
