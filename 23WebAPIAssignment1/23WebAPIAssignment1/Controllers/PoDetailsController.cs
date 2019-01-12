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
    public class PoDetailsController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/PoDetails
        public IQueryable<PoDetail> GetPoDetails()
        {
            return db.PoDetails;
        }

        // GET: api/PoDetails?id=5&itcode=0001
        [ResponseType(typeof(PoDetail))]
        public IHttpActionResult GetPoDetail(string id,string itcode)
        {
            //PoDetail poDetail = db.PoDetails.Find(id);
            var poDetails = db.PoDetails.Where(a => a.PoNo == id)
                                           .Where(a => a.Itcode == itcode);
            PoDetail poDetail = null;
            foreach (var r1 in poDetails.ToList())
            {
                poDetail = new PoDetail();
                poDetail.PoNo = r1.PoNo;
                poDetail.Itcode = r1.Itcode;
                poDetail.Qty = r1.Qty;
            }

            if (poDetail == null)
            {
                return NotFound();
            }

            return Ok(poDetail);
        }


        //// GET: api/PoDetails/5
        //[ResponseType(typeof(PoDetail))]
        //public IQueryable<PoDetail> GetPoDetails(string id)
        //{
        //    IQueryable<PoDetail> poDetail = db.PoDetails.Find(id);
        //    //var poDetails = db.PoDetails.Where(a => a.PoNo == id)
        //    //                               .Where(a => a.Itcode == itcode);
        //    //PoDetail poDetail = null;
        //    //foreach (var r1 in poDetails.ToList())
        //    //{
        //    //    poDetail = new PoDetail();
        //    //    poDetail.PoNo = r1.PoNo;
        //    //    poDetail.Itcode = r1.Itcode;
        //    //    poDetail.Qty = r1.Qty;
        //    //}

        //    //if (poDetail == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    return poDetail;
        //}

        // PUT: api/PoDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoDetail(string id, string itcode, PoDetail poDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poDetail.PoNo && itcode !=poDetail.Itcode)
            {
                return BadRequest();
            }

            db.Entry(poDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoDetailExists(id))
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

        // POST: api/PoDetails
        [ResponseType(typeof(PoDetail))]
        public IHttpActionResult PostPoDetail(PoDetail poDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoDetails.Add(poDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PoDetailExists(poDetail.PoNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = poDetail.PoNo }, poDetail);
        }

        // DELETE: api/PoDetails?id=5&itcode=0011
        [ResponseType(typeof(PoDetail))]
        public IHttpActionResult DeletePoDetail(string id, string itcode)
        {
            //PoDetail poDetail = db.PoDetails.Find(id);
            var poDetails = db.PoDetails.Where(a => a.PoNo == id)
                                           .Where(a => a.Itcode == itcode);
            PoDetail poDetail = null;
            foreach (var r1 in poDetails.ToList())
            {
                poDetail = r1;
                //poDetail.PoNo = r1.PoNo;
                //poDetail.Itcode = r1.Itcode;
                //poDetail.Qty = r1.Qty;
            }

            if (poDetail == null)
            {
                return NotFound();
            }

            db.PoDetails.Remove(poDetail);
            db.SaveChanges();

            return Ok(poDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoDetailExists(string id)
        {
            return db.PoDetails.Count(e => e.PoNo == id) > 0;
        }
    }
}