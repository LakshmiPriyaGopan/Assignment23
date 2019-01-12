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
using _23WebAPIAssignment1;

namespace _23WebAPIAssignment1.Controllers
{
    public class PoMastersController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/PoMasters
        public IQueryable<PoMaster> GetPoMasters()
        {
            return db.PoMasters;
        }

        // GET: api/PoMasters/5
        [ResponseType(typeof(PoMaster))]
        public IHttpActionResult GetPoMaster(string id)
        {
            PoMaster poMaster = db.PoMasters.Find(id);
            if (poMaster == null)
            {
                return NotFound();
            }

            return Ok(poMaster);
        }

        // PUT: api/PoMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoMaster(string id, PoMaster poMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poMaster.PoNo)
            {
                return BadRequest();
            }

            db.Entry(poMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoMasterExists(id))
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

        // POST: api/PoMasters
        [ResponseType(typeof(PoMaster))]
        public IHttpActionResult PostPoMaster(PoMaster poMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoMasters.Add(poMaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PoMasterExists(poMaster.PoNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = poMaster.PoNo }, poMaster);
        }

        // DELETE: api/PoMasters/5
        [ResponseType(typeof(PoMaster))]
        public IHttpActionResult DeletePoMaster(string id)
        {
            PoMaster poMaster = db.PoMasters.Find(id);
            if (poMaster == null)
            {
                return NotFound();
            } 
                db.PoDetails.RemoveRange(poMaster.PoDetails); 
            db.PoMasters.Remove(poMaster); 
            db.SaveChanges();

            return Ok(poMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoMasterExists(string id)
        {
            return db.PoMasters.Count(e => e.PoNo == id) > 0;
        }
    }
}