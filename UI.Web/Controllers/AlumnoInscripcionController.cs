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
        public ActionResult InscripcionCreate()
        {
            return View(new AlumnoInscripcion());
        }

        // POST: AlumnoInscripcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InscripcionCreate(AlumnoInscripcion ai)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
