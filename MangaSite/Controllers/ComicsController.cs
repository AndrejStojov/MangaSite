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
    public class ComicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comics
        public ActionResult Index(string search)
        {

            var comics = db.Comics.Where(x => x.Name.Contains(search) || search==null).ToList();
            var types = db.TypeCs.ToList();
            var genres = db.Genres.ToList();
            ComicGenreViewModel model = new ComicGenreViewModel();
            model.Comics = comics;
            model.Genres = genres;
            model.typeCs = types;
            return View(model);
        }

        // GET: Comics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // GET: Comics/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.TypeCId = new SelectList(db.TypeCs, "TypeCId", "TypeName");
            return View();
        }

        // POST: Comics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AuthorId,TypeCId,Name,Descripion,ImgURL,Serialized,Rating")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Comics.Add(comic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", comic.AuthorId);
            ViewBag.TypeCId = new SelectList(db.TypeCs, "TypeCId", "TypeName", comic.TypeCId);
            return View(comic);
        }

        // GET: Comics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", comic.AuthorId);
            ViewBag.TypeCId = new SelectList(db.TypeCs, "TypeCId", "TypeName", comic.TypeCId);
            return View(comic);
        }

        // POST: Comics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,TypeCId,Name,Descripion,ImgURL,Serialized,Rating")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", comic.AuthorId);
            ViewBag.TypeCId = new SelectList(db.TypeCs, "TypeCId", "TypeName", comic.TypeCId);
            return View(comic);
        }

        // GET: Comics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // POST: Comics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comic comic = db.Comics.Find(id);
            db.Comics.Remove(comic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddGenre(int id)
        {
            ComicGenre model = new ComicGenre();
            model.ComicId = id;
            model.Comic = db.Comics.Find(id);
            model.Genres = db.Genres.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddGenre(ComicGenre model)
        {
            var comic = db.Comics.Find(model.ComicId);
            var genre=db.Genres.Find(model.GenreId);
            comic.Genres.Add(genre);
            db.SaveChanges();
            return Redirect("/Comics/Details/"+comic.Id);
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
