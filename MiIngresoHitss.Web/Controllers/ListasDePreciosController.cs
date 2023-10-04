using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiIngresoHitss.Web.Models;

namespace MiIngresoHitss.Web.Controllers
{
    public class ListasDePreciosController : Controller
    {
        private MiIngresoHitssEntities db = new MiIngresoHitssEntities();

        // GET: ListasDePrecios
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        // GET: ListasDePrecios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListasDePrecios listasDePrecios = db.ListasDePrecios.Find(id);
            if (listasDePrecios == null)
            {
                return HttpNotFound();
            }
            return View(listasDePrecios);
        }

        // GET: ListasDePrecios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListasDePrecios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaPrecioId,Nombre")] ListasDePrecios listasDePrecios)
        {
            if (ModelState.IsValid)
            {
                db.ListasDePrecios.Add(listasDePrecios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listasDePrecios);
        }

        // GET: ListasDePrecios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListasDePrecios listasDePrecios = db.ListasDePrecios.Find(id);
            if (listasDePrecios == null)
            {
                return HttpNotFound();
            }
            return View(listasDePrecios);
        }

        // POST: ListasDePrecios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaPrecioId,Nombre")] ListasDePrecios listasDePrecios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listasDePrecios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listasDePrecios);
        }

        // GET: ListasDePrecios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListasDePrecios listasDePrecios = db.ListasDePrecios.Find(id);
            if (listasDePrecios == null)
            {
                return HttpNotFound();
            }
            return View(listasDePrecios);
        }

        // POST: ListasDePrecios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListasDePrecios listasDePrecios = db.ListasDePrecios.Find(id);
            db.ListasDePrecios.Remove(listasDePrecios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
