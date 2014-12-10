using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GesVeh.Model;

namespace GesVeh.Web.Controllers
{
    public class ModelesController : Controller
    {
        private GesVehContext db = new GesVehContext();

        // GET: Modeles
        public ActionResult Index()
        {
            var modeles = db.Modeles.Include(m => m.Marque);
            return View(modeles.ToList());
        }

        // GET: Modeles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.Modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // GET: Modeles/Create
        public ActionResult Create()
        {
            ViewBag.MarqueID = new SelectList(db.Marques, "ID", "Nom");
            return View();
        }

        // POST: Modeles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,MarqueID,CreateBy,ModifiedBy,DeleteBy,CreationDate,ModificationDate,DeletationDate,Delete")] Modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Modeles.Add(modele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarqueID = new SelectList(db.Marques, "ID", "Nom", modele.MarqueID);
            return View(modele);
        }

        // GET: Modeles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.Modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarqueID = new SelectList(db.Marques, "ID", "Nom", modele.MarqueID);
            return View(modele);
        }

        // POST: Modeles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,MarqueID,CreateBy,ModifiedBy,DeleteBy,CreationDate,ModificationDate,DeletationDate,Delete")] Modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarqueID = new SelectList(db.Marques, "ID", "Nom", modele.MarqueID);
            return View(modele);
        }

        // GET: Modeles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.Modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modele modele = db.Modeles.Find(id);
            db.Modeles.Remove(modele);
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
