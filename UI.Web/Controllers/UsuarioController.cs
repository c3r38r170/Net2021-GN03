using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;
using Business.Logic;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
<<<<<<< HEAD
=======
        // GET: UsuarioController
>>>>>>> 1e64f281defcecc17b68ca359011ea3c05c66df0
        [HttpGet]
        public ActionResult UsuarioIndex()
        {
            UsuarioLogic ul = new UsuarioLogic();
            return View(ul.GetAll());
        }

        // GET: UsuarioController/Create
        public ActionResult UsuarioCreate()
        {
            return View(new Business.Entities.Usuario());
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioCreate(Usuario usu)
        {
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(usu);
            return RedirectToAction("UsuarioIndex");
        }

        // GET: UsuarioController/Edit/5
        public ActionResult UsuarioEdit(int id)
        {
            UsuarioLogic ul = new UsuarioLogic();
            return View(ul.GetOne(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioEdit(Usuario usu)
        {
            UsuarioLogic ul = new UsuarioLogic();
            usu.State = BusinessEntity.States.Modified;
            ul.Save(usu);
            return RedirectToAction("UsuarioIndex");
        }

        // GET: UsuarioController/Delete/5
        public ActionResult UsuarioDelete(int id)
        {
            UsuarioLogic ul = new UsuarioLogic();
            return View(ul.GetOne(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioDelete(int id, IFormCollection collection)
        {
            UsuarioLogic ul = new UsuarioLogic();
            ul.Delete(id);
            return RedirectToAction("UsuarioIndex");
        }
    }
}
