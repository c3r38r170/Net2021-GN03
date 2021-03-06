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
    public class CursoController : Controller
    {
        // GET: CursoController
        [HttpGet]
        public ActionResult CursoIndex()
        {
            CursoLogic cl = new CursoLogic();
            return View(cl.GetAll());
        }

        // GET: CursoController/Create
        public ActionResult CursoCreate()
        {
            return View(new Business.Entities.Curso());
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CursoCreate(Curso cu)
        {
			var cL = new CursoLogic();
			if(cL.isValid(cu)) {
				cL.Save(cu);
				return RedirectToAction("CursoIndex");
			} else {
				cu.State = BusinessEntity.States.Unmodified;
				return View(cu);
			}
        }

        // GET: CursoController/Edit/5
        public ActionResult CursoEdit(int id)
        {
            CursoLogic cl = new CursoLogic();
            return View(cl.GetOne(id));
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CursoEdit(Curso cu) {
			var cL = new CursoLogic();
			if(cL.isValid(cu)) {
				cu.State = BusinessEntity.States.Modified;
				cL.Save(cu);
				return RedirectToAction("CursoIndex");
			} else {
				cu.State = BusinessEntity.States.Unmodified;
				return View(cu);
			}
		}

        // GET: CursoController/Delete/5
        public ActionResult CursoDelete(int id)
        {
            CursoLogic cl = new CursoLogic();
            return View(cl.GetOne(id));
        }

        // POST: CursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            CursoLogic cl = new CursoLogic();
            cl.Delete(id);
            return RedirectToAction("CursoIndex");
        }
    }
}
