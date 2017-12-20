using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeraU.Models;

namespace TeraU.Controllers
{
    public class MoviesController : Controller
    {
        private Mycontext db = new Mycontext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Actor).Include(m => m.Genre);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.id_actor = new SelectList(db.Actors, "id_actor", "name_actor");
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "name_genre");
            return View();
        }

        // POST: Movies/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "id_movie,movie,id_genre,id_actor,director,year,description,poster")] Movie movie)
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     byte[] fileData = null;

                     if ((movie.Files.Count > 0) && (movie.Files != null))
                     {
                         using (var binaryReader = new BinaryReader(movie.Files[0].InputStream))
                         {
                             fileData = binaryReader.ReadBytes(movie.Files[0].ContentLength);
                         }
                     }
                     movie.poster = fileData;
                     int year = movie.year;
                     db.Movies.Add(movie);
                     db.SaveChanges();
                     return RedirectToAction("Index");
                 }
                ViewBag.id_actor = new SelectList(db.Actors, "id_actor", "name_actor", movie.id_actor);
                 ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "name_genre", movie.id_genre);
                 return View(movie);
             }
             catch (SystemException)
             {

                     var movies = db.Movies.Add(movie);
                     db.SaveChanges();
                     return RedirectToAction("Index");
             }
         }
         */
         // GET: Movies/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Movie movie = db.Movies.Find(id);
             if (movie == null)
             {
                 return HttpNotFound();
             }
             ViewBag.id_actor = new SelectList(db.Actors, "id_actor", "name_actor", movie.id_actor);
             ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "name_genre", movie.id_genre);
             return View(movie);
         }
        
      
        [HttpPost]
        public ActionResult CreateMovie(Movie m)
        {
            try
            {
                byte[] fileData = null;

                if ((m.Files.Count > 0) && (m.Files != null))
                {
                    using (var binaryReader = new BinaryReader(m.Files[0].InputStream))
                    {
                        fileData = binaryReader.ReadBytes(m.Files[0].ContentLength);
                    }
                }
                    m.poster = fileData;
                    int year = m.year;
                    ViewBag.id_actor = new SelectList(db.Actors, "id_actor", "name_actor");
                    ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "name_genre");
                    var movies = db.Movies.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch (SystemException)
            {

                    var movies = db.Movies.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
        }

        // POST: Movies/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_movie,movie,id_genre,id_actor,director,year,description,poster")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_actor = new SelectList(db.Actors, "id_actor", "name_actor", movie.id_actor);
            ViewBag.id_genre = new SelectList(db.Genres, "id_genre", "name_genre", movie.id_genre);
            return View(movie);
        }
        */
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movieToUpdate = db.Movies.Find(id);
            if (TryUpdateModel(movieToUpdate, "",
               new string[] { "movie", "id_genre", "id_actor","director","year","description","poster" }))
            {
                try
                {
                    byte[] fileData = null;

                    if ((movieToUpdate.Files.Count > 0) && (movieToUpdate.Files != null))
                    {
                        using (var binaryReader = new BinaryReader(movieToUpdate.Files[0].InputStream))
                        {
                            fileData = binaryReader.ReadBytes(movieToUpdate.Files[0].ContentLength);
                        }
                    }
                    movieToUpdate.poster = fileData;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(movieToUpdate);
        }
        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
