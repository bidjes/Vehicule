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
    public class FinitionsController : Controller
    {
        private GesVehContext db = new GesVehContext();

        // GET: Finitions
        public ActionResult Index()
        {
            return View(db.Finitions.ToList());
        }

        // GET: Finitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finition finition = db.Finitions.Find(id);
            if (finition == null)
            {
                return HttpNotFound();
            }
            return View(finition);
        }

        // GET: Finitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Finitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Prix,CreateBy,ModifiedBy,DeleteBy,CreationDate,ModificationDate,DeletationDate,Delete")] Finition finition)
        {
            if (ModelState.IsValid)
            {
                db.Finitions.Add(finition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finition);
        }

        // GET: Finitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finition finition = db.Finitions.Find(id);
            if (finition == null)
            {
                return HttpNotFound();
            }
            return View(finition);
        }

        // POST: Finitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Prix,CreateBy,ModifiedBy,DeleteBy,CreationDate,ModificationDate,DeletationDate,Delete")] Finition finition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finition);
        }

        // GET: Finitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finition finition = db.Finitions.Find(id);
            if (finition == null)
            {
                return HttpNotFound();
            }
            return View(finition);
        }

        // POST: Finitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Finition finition = db.Finitions.Find(id);
            db.Finitions.Remove(finition);
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
