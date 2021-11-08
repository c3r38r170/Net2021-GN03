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
    public class ComisionController : Controller
    {
        
        // GET: ComisionController
        [HttpGet]
        public ActionResult ComisionIndex()
        {
            ComisionLogic col = new ComisionLogic();
            return View(col.GetAll());
        }


        // GET: ComisionController/Create
        public ActionResult ComisionCreate()
        {
            return View(new Comision());
        }

        // POST: ComisionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComisionCreate(Comision comi)
        {
			if(comi.Descripcion != null
				&& comi.Descripcion.Trim() != ""
				&& comi.AñoEspecialidad >= 1959
				&& comi.IDPlan > 0) {

				comi.Descripcion = comi.Descripcion.Trim();
				(new ComisionLogic()).Save(comi);
				return RedirectToAction("ComisionIndex");
			} else {
				comi.State = BusinessEntity.States.Unmodified;
				return View(comi);
			}
        }

        // GET: ComisionController/Edit/5
        public ActionResult ComisionEdit(int id)
        {
            ComisionLogic col = new ComisionLogic();
            return View(col.GetOne(id));
        }

        // POST: ComisionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComisionEdit(Comision comi)
        {
            ComisionLogic col = new ComisionLogic();
            comi.State = BusinessEntity.States.Modified;
            col.Save(comi);
            return RedirectToAction("ComisionIndex");
        }
    }
}
