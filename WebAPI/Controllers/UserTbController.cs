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
using System.Web.Http.Cors;
using GSlateDataAccess;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "get,post")]
    public class UserTbController : ApiController
    {
        private GSlateEntities db = new GSlateEntities();

        // GET: api/UserTb
        [Route("api/User/RetrieveAll")]
        public IQueryable<TBL_USER> Get()
        {
            return db.TBL_USER;
        }

     
        // GET: api/UserTb/5
        [Route("api/User/Retrieve")]
        [ResponseType(typeof(TBL_USER))]
        public IHttpActionResult Get(int id)
        {
            TBL_USER tBL_USER = db.TBL_USER.Find(id);
            if (tBL_USER == null)
            {
                return NotFound();
            }

            return Ok(tBL_USER);
        }

        // PUT: api/UserTb/5
        [Route("api/User/Put")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, TBL_USER tBL_USER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBL_USER.ID)
            {
                return BadRequest();
            }

            db.Entry(tBL_USER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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

        // POST: api/UserTb
        [Route("api/User/Post")]
        [ResponseType(typeof(TBL_USER))]
        public IHttpActionResult Post(TBL_USER tBL_USER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBL_USER.Add(tBL_USER);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Exists(tBL_USER.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tBL_USER.ID }, tBL_USER);
        }

        // DELETE: api/UserTb/5
        [Route("api/User/Delete")]
        [ResponseType(typeof(TBL_USER))]
        public IHttpActionResult Delete(int id)
        {
            TBL_USER tBL_USER = db.TBL_USER.Find(id);
            if (tBL_USER == null)
            {
                return NotFound();
            }

            db.TBL_USER.Remove(tBL_USER);
            db.SaveChanges();

            return Ok(tBL_USER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exists(int id)
        {
            return db.TBL_USER.Count(e => e.ID == id) > 0;
        }
    }
}