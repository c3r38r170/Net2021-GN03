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
    public class AlumnoInscripcionController : Controller
    {
        // GET: AlumnoInscripcionController/Create
        public ActionResult InscripcionCreate(int per)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            ai.IDAlumno = per;
            return View(ai);
        }

        // POST: AlumnoInscripcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InscripcionCreate(AlumnoInscripcion ai)
        {
            InscripcionLogic il = new InscripcionLogic();
            ai.Condicion = "cursando";
            il.Save(ai);
            //return RedirectToAction("LogIn","Home");
            return RedirectToAction("Panel", "Home");
        }
    }
}
