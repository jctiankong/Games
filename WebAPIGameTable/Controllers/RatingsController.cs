using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIGameTable.Models;

namespace WebAPIGameTable.Controllers
{
    public class RatingsController : ApiController
    {
        private WebAPIGameTableContext db = new WebAPIGameTableContext();

        // GET: api/Ratings
        public IQueryable<Rating> GetRatings()
        {
            return db.Ratings;
        }

        // GET: api/DataTableRatings
        [HttpGet]
        [Route("api/rating/datatable")]
        public object DataTable()
        {
            IQueryable<Rating> ratings = db.Ratings;
            return new { data = ratings };
        }

        // GET: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> GetRating(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // PUT: api/Ratings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rating.RatingId)
            {
                return BadRequest();
            }

            db.Entry(rating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ratings
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> PostRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ratings.Add(rating);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rating.RatingId }, rating);
        }

        // DELETE: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> DeleteRating(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            db.Ratings.Remove(rating);
            await db.SaveChangesAsync();

            return Ok(rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingExists(int id)
        {
            return db.Ratings.Count(e => e.RatingId == id) > 0;
        }
    }
}