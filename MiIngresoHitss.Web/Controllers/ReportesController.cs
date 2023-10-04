using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiIngresoHitss.Web.Models;

namespace MiIngresoHitss.Web.Controllers
{
    public class ReportesController : Controller
    {
        private MiIngresoHitssEntities db = new MiIngresoHitssEntities();

        // GET: Reportes
        public ActionResult Index()
        {
            return View(db.Reportes.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  void Create([Bind(Include = "FechaInicio,FechaFin")] Reportes reportes)
        {
            if (ModelState.IsValid)
            {
                //StringWriter strw = new StringWriter();
                //strw.WriteLine("\"Nombre\",\"Descripcion\",\"Precio\"");
                //Response.ClearContent();
                //Response.AddHeader("content-disposition",
                //    string.Format("attachment;filename=ProductListing_{0}.csv", DateTime.Now));
                //Response.ContentType = "text/csv";

                //var ListProducts = db.Productos.OrderBy(x => x.ProductoId).ToList();
                //var ListFiltrada = ListProducts.Where(x => x.Precio >= precioInicio && x.Precio <= precioFin).ToList();

                //foreach (var product in ListFiltrada)
                //{
                //    strw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"", product.Nombre, product.Descripcion, product.Precio));
                //}
                //Response.Write(strw.ToString());
                //Response.End();

            }


             
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: Reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FechaInicio,FechaFin")] Reportes reportes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportes);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            Reportes reportes = db.Reportes.Find(id);
            db.Reportes.Remove(reportes);
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
