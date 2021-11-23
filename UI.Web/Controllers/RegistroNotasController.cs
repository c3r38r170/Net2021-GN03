using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Web.Controllers
{
    public class RegistroNotasController : Controller
    {
        // GET: RegistroNotasController
        public ActionResult RegistroNotasIndex()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            return View(dcl.GetAll());
        }

         // GET: RegistroNotasController/Create
        public ActionResult RegistroNotasCarga(int id)
        {
            return RedirectToAction("InscripcionListar", "AlumnoInscripcion", new { id });
        }
    }
}
