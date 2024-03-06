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
    public class FavotiresListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FavotiresLists
        [Authorize]
        public ActionResult Index()
        {
            FavotiresList favotiresList = new FavotiresList();
            if(db.FavotiresLists.FirstOrDefault(m => m.UserName == User.Identity.Name) != null)
            {
                favotiresList.Comics = db.FavotiresLists.FirstOrDefault(m => m.UserName == User.Identity.Name).Comics.ToList();
            }
            
            favotiresList.UserName = User.Identity.Name;

            return View(favotiresList);
        }
        [HttpPost]
        public ActionResult AddToFavorites(int id)
        {
            if (db.FavotiresLists.FirstOrDefault(m => m.UserName == User.Identity.Name) == null)
            {
                FavotiresList favotiresList = new FavotiresList();
                favotiresList.Comics.Add(db.Comics.Find(id));
                favotiresList.UserName = User.Identity.Name;
                db.FavotiresLists.Add(favotiresList);
                db.SaveChanges();
            }
            else
            {
                FavotiresList favotiresList = db.FavotiresLists.FirstOrDefault(m=>m.UserName == User.Identity.Name);
                favotiresList.Comics.Add(db.Comics.Find(id));
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveFromList(int id)
        {
            FavotiresList favotiresList = db.FavotiresLists.FirstOrDefault(m => m.UserName == User.Identity.Name);
            favotiresList.Comics.Remove(db.Comics.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }




        // GET: FavotiresLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavotiresList favotiresList = db.FavotiresLists.Find(id);
            if (favotiresList == null)
            {
                return HttpNotFound();
            }
            return View(favotiresList);
        }

        // GET: FavotiresLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavotiresLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId")] FavotiresList favotiresList)
        {
            if (ModelState.IsValid)
            {
                db.FavotiresLists.Add(favotiresList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favotiresList);
        }

        // GET: FavotiresLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavotiresList favotiresList = db.FavotiresLists.Find(id);
            if (favotiresList == null)
            {
                return HttpNotFound();
            }
            return View(favotiresList);
        }

        // POST: FavotiresLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId")] FavotiresList favotiresList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favotiresList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favotiresList);
        }

        // GET: FavotiresLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavotiresList favotiresList = db.FavotiresLists.Find(id);
            if (favotiresList == null)
            {
                return HttpNotFound();
            }
            return View(favotiresList);
        }

        // POST: FavotiresLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavotiresList favotiresList = db.FavotiresLists.Find(id);
            db.FavotiresLists.Remove(favotiresList);
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
