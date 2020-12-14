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
    public class PupilentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pupilentes
        public ActionResult Index(string sortOrder, string busqueda)
        {
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "modelo_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            var Pupilentes = db.Pupilentes.AsEnumerable();
            if (!String.IsNullOrEmpty(busqueda))
            {
                Pupilentes = Pupilentes.Where(a => a.Modelo.Contains(busqueda) || a.Color.Contains(busqueda));
            }
            switch (sortOrder)
            {
                default:
                    Pupilentes = Pupilentes.OrderBy(s => s.Modelo);
                    break;

                case "nombre_desc":
                    Pupilentes = Pupilentes.OrderByDescending(s => s.Modelo);
                    break;
                case "Email":
                    Pupilentes = Pupilentes.OrderBy(s => s.Color);
                    break;
                case "email_desc":
                    Pupilentes = Pupilentes.OrderByDescending(s => s.Color);
                    break;
            }
            return View(Pupilentes.ToList());
        }

        // GET: Pupilentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupilentes pupilentes = db.Pupilentes.Find(id);
            if (pupilentes == null)
            {
                return HttpNotFound();
            }
            return View(pupilentes);
        }

        // GET: Pupilentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pupilentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Modelo,Color,Costo,TamañoPupila,TamañoDiametro,PrecioVenta,Imagen")] Pupilentes pupilentes)
        {
            if (ModelState.IsValid)
            {
                db.Pupilentes.Add(pupilentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pupilentes);
        }

        // GET: Pupilentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupilentes pupilentes = db.Pupilentes.Find(id);
            if (pupilentes == null)
            {
                return HttpNotFound();
            }
            return View(pupilentes);
        }

        // POST: Pupilentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Modelo,Color,Costo,TamañoPupila,TamañoDiametro,PrecioVenta,Imagen")] Pupilentes pupilentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupilentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pupilentes);
        }

        // GET: Pupilentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupilentes pupilentes = db.Pupilentes.Find(id);
            if (pupilentes == null)
            {
                return HttpNotFound();
            }
            return View(pupilentes);
        }

        // POST: Pupilentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pupilentes pupilentes = db.Pupilentes.Find(id);
            db.Pupilentes.Remove(pupilentes);
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
