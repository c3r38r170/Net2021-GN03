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
    public class MateriaController : Controller
    {
        
        [HttpGet]
        // GET: MateriaController
        public ActionResult MateriaIndex()
        {
            MateriaLogic ml = new MateriaLogic();
            return View(ml.GetAll());
        }

        // GET: MateriaController/Create
        public ActionResult MateriaCreate()
        {
            return View(new Materia());
        }

        // POST: MateriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MateriaCreate(Materia m)
        {
            MateriaLogic ml = new MateriaLogic();
            ml.Save(m);
            return RedirectToAction("MateriaIndex");
            /*try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }

        // GET: MateriaController/Edit/5
        public ActionResult MateriaEdit(int id)
        {
            MateriaLogic ml = new MateriaLogic();
            return View(ml.GetOne(id));
        }

        // POST: MateriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MateriaEdit(Materia m)
        {
            MateriaLogic ml = new MateriaLogic();
            m.State = BusinessEntity.States.Modified;
            ml.Save(m);
            return RedirectToAction("MateriaIndex");
            /*try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }

        // GET: MateriaController/Delete/5
        public ActionResult MateriaDelete(int id)
        {
            MateriaLogic ml = new MateriaLogic();
            return View(ml.GetOne(id));
        }

        // POST: MateriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MateriaDelete(int id, IFormCollection collection)
        {
            MateriaLogic ml = new MateriaLogic();
            ml.Delete(id);
            return RedirectToAction("MateriaIndex");
            /*try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }
    }
}
