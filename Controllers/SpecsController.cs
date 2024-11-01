using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Evidence_api01_witAthentication.Models;

namespace Evidence_api01_witAthentication.Controllers
{
    public class SpecsController : ApiController
    {
        private MedicineDbContext db = new MedicineDbContext();

        // GET: api/Specs
        public IQueryable<Spec> GetSpecs()
        {
            return db.Specs;
        }

        // GET: api/Specs/5
        [ResponseType(typeof(Spec))]
        public IHttpActionResult GetSpec(int id)
        {
            Spec spec = db.Specs.Find(id);
            if (spec == null)
            {
                return NotFound();
            }

            return Ok(spec);
        }

        // PUT: api/Specs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpec(int id, Spec spec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spec.SpecId)
            {
                return BadRequest();
            }

            db.Entry(spec).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecExists(id))
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

        // POST: api/Specs
        [ResponseType(typeof(Spec))]
        public IHttpActionResult PostSpec(Spec spec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specs.Add(spec);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spec.SpecId }, spec);
        }

        // DELETE: api/Specs/5
        [ResponseType(typeof(Spec))]
        public IHttpActionResult DeleteSpec(int id)
        {
            Spec spec = db.Specs.Find(id);
            if (spec == null)
            {
                return NotFound();
            }

            db.Specs.Remove(spec);
            db.SaveChanges();

            return Ok(spec);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecExists(int id)
        {
            return db.Specs.Count(e => e.SpecId == id) > 0;
        }
    }
}