using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeeKawaii.Models;

namespace BeeKawaii.Controllers
{
    public class ProductoHechoAManoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductoHechoAManoes
        public ActionResult Index(string sortOrder, string busqueda)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            var Producto = db.ProductoHechoAMano.AsEnumerable();
            if (!String.IsNullOrEmpty(busqueda))
            {
                Producto = Producto.Where(a => a.Nombre.Contains(busqueda) || a.Tipo.Contains(busqueda));                
            }
            switch (sortOrder)
            {
                default:
                    Producto = Producto.OrderBy(s => s.Tipo);
                    break;

                case "nombre_desc":
                    Producto = Producto.OrderByDescending(s => s.Nombre);
                    break;
                case "Email":
                    Producto = Producto.OrderBy(s => s.Material);
                    break;
                case "email_desc":
                    Producto = Producto.OrderByDescending(s => s.Material);
                    break;
            }
            return View(Producto.ToList());
        }

        // GET: ProductoHechoAManoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoHechoAMano productoHechoAMano = db.ProductoHechoAMano.Find(id);
            if (productoHechoAMano == null)
            {
                return HttpNotFound();
            }
            return View(productoHechoAMano);
        }

        // GET: ProductoHechoAManoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoHechoAManoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Nombre,Caracteristicas,Material,Tamaño,TiempoRealización,Costo,PrecioVenta,Imagen")] ProductoHechoAMano productoHechoAMano)
        {
            if (ModelState.IsValid)
            {
                db.ProductoHechoAMano.Add(productoHechoAMano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoHechoAMano);
        }

        // GET: ProductoHechoAManoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoHechoAMano productoHechoAMano = db.ProductoHechoAMano.Find(id);
            if (productoHechoAMano == null)
            {
                return HttpNotFound();
            }
            return View(productoHechoAMano);
        }


        // POST: ProductoHechoAManoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Nombre,Caracteristicas,Material,Tamaño,TiempoRealización,Costo,PrecioVenta,Imagen")] ProductoHechoAMano productoHechoAMano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoHechoAMano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productoHechoAMano);
        }

        // GET: ProductoHechoAManoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoHechoAMano productoHechoAMano = db.ProductoHechoAMano.Find(id);
            if (productoHechoAMano == null)
            {
                return HttpNotFound();
            }
            return View(productoHechoAMano);
        }

        // POST: ProductoHechoAManoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoHechoAMano productoHechoAMano = db.ProductoHechoAMano.Find(id);
            db.ProductoHechoAMano.Remove(productoHechoAMano);
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
