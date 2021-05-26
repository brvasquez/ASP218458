using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP218458.Models;

namespace ASP218458.Controllers
{
    public class producto_compraController : Controller
    {
        private inventarioEntities db = new inventarioEntities();

        // GET: producto_compra
        public ActionResult Index()
        {
            var producto_compra = db.producto_compra.Include(p => p.compra).Include(p => p.producto);
            return View(producto_compra.ToList());
        }

        // GET: producto_compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_compra producto_compra = db.producto_compra.Find(id);
            if (producto_compra == null)
            {
                return HttpNotFound();
            }
            return View(producto_compra);
        }

        // GET: producto_compra/Create
        public ActionResult Create()
        {
            ViewBag.id_compra = new SelectList(db.compra, "id", "id");
            ViewBag.id_producto = new SelectList(db.producto, "id", "nombre");
            return View();
        }

        // POST: producto_compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_compra,id_producto,cantidad")] producto_compra producto_compra)
        {
            if (ModelState.IsValid)
            {
                db.producto_compra.Add(producto_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_compra = new SelectList(db.compra, "id", "id", producto_compra.id_compra);
            ViewBag.id_producto = new SelectList(db.producto, "id", "nombre", producto_compra.id_producto);
            return View(producto_compra);
        }

        // GET: producto_compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_compra producto_compra = db.producto_compra.Find(id);
            if (producto_compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_compra = new SelectList(db.compra, "id", "id", producto_compra.id_compra);
            ViewBag.id_producto = new SelectList(db.producto, "id", "nombre", producto_compra.id_producto);
            return View(producto_compra);
        }

        // POST: producto_compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_compra,id_producto,cantidad")] producto_compra producto_compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_compra = new SelectList(db.compra, "id", "id", producto_compra.id_compra);
            ViewBag.id_producto = new SelectList(db.producto, "id", "nombre", producto_compra.id_producto);
            return View(producto_compra);
        }

        // GET: producto_compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_compra producto_compra = db.producto_compra.Find(id);
            if (producto_compra == null)
            {
                return HttpNotFound();
            }
            return View(producto_compra);
        }

        // POST: producto_compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto_compra producto_compra = db.producto_compra.Find(id);
            db.producto_compra.Remove(producto_compra);
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
