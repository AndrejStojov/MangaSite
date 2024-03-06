using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MangaSite.Models;

namespace MangaSite.Controllers
{
    public class TypeCsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeCs
        public ActionResult Index()
        {
            return View(db.TypeCs.ToList());
        }

        // GET: TypeCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeC typeC = db.TypeCs.Find(id);
            if (typeC == null)
            {
                return HttpNotFound();
            }
            return View(typeC);
        }

        // GET: TypeCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeCId,TypeName")] TypeC typeC)
        {
            if (ModelState.IsValid)
            {
                db.TypeCs.Add(typeC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeC);
        }

        // GET: TypeCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeC typeC = db.TypeCs.Find(id);
            if (typeC == null)
            {
                return HttpNotFound();
            }
            return View(typeC);
        }

        // POST: TypeCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeCId,TypeName")] TypeC typeC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeC);
        }

        // GET: TypeCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeC typeC = db.TypeCs.Find(id);
            if (typeC == null)
            {
                return HttpNotFound();
            }
            return View(typeC);
        }

        // POST: TypeCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeC typeC = db.TypeCs.Find(id);
            db.TypeCs.Remove(typeC);
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
