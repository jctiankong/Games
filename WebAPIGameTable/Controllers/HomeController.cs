using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIGameTable.Models;

namespace WebAPIGameTable.Controllers
{
    public class HomeController : Controller
    {

        private WebAPIGameTableContext db = new WebAPIGameTableContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGenre()
        {
            return View();
        }

        public ActionResult IndexRating()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            IQueryable<Genre> genres = db.Genres;
            SelectList slGenre = new SelectList(genres, "GenreId", "GenreName");
            ViewBag.GenreSelect = slGenre;

            IQueryable<Rating> rating = db.Ratings;
            SelectList slRatings = new SelectList(rating, "RatingId", "RatingValue");
            ViewBag.RatingSelect = slRatings;

            var v = db.Games.Where(a => a.GameId == id).FirstOrDefault();
            return View(v);


        }

        [HttpGet]
        public ActionResult SaveGenre(int id)
        {
            var v = db.Genres.Where(a => a.GenreId == id).FirstOrDefault();
            return View(v);

        }

        [HttpGet]
        public ActionResult SaveRating(int id)
        {
            var v = db.Ratings.Where(a => a.RatingId == id).FirstOrDefault();
            return View(v);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var v = db.Games.Where(a => a.GameId == id).FirstOrDefault();
            if (v != null)
            {
                return View(v);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult DeleteGenre(int id)
        {
            var v = db.Genres.Where(a => a.GenreId == id).FirstOrDefault();
            if (v != null)
            {
                return View(v);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult DeleteRating(int id)
        {
            var v = db.Ratings.Where(a => a.RatingId == id).FirstOrDefault();
            if (v != null)
            {
                return View(v);
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}