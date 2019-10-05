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
using GSlateDataAccess;

namespace WebAPI.Controllers
{
    public class UserProjectTbController : ApiController
    {
        private GSlateEntities db = new GSlateEntities();

        // GET: api/UserProjectTb
        [Route("api/UserProject/RetrieveAll")]
        public IQueryable<TBL_USER_PROJECT> Get()
        {
            return db.TBL_USER_PROJECT;
        }

        // GET: api/UserProjectTb/5
        [Route("api/UserProject/Retrieve")]
        [ResponseType(typeof(TBL_USER_PROJECT))]
        public IHttpActionResult Get(int id)
        {
            TBL_USER_PROJECT tBL_USER_PROJECT = db.TBL_USER_PROJECT.Find(id);
            if (tBL_USER_PROJECT == null)
            {
                return NotFound();
            }

            return Ok(tBL_USER_PROJECT);
        }

        // PUT: api/UserProjectTb/5
        [Route("api/UserProject/Put")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, TBL_USER_PROJECT tBL_USER_PROJECT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBL_USER_PROJECT.USER_ID)
            {
                return BadRequest();
            }

            db.Entry(tBL_USER_PROJECT).State = EntityState.Modified;

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

        // POST: api/UserProjectTb
        [Route("api/UserProject/Post")]
        [ResponseType(typeof(TBL_USER_PROJECT))]
        public IHttpActionResult Post(TBL_USER_PROJECT tBL_USER_PROJECT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBL_USER_PROJECT.Add(tBL_USER_PROJECT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Exists(tBL_USER_PROJECT.USER_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tBL_USER_PROJECT.USER_ID }, tBL_USER_PROJECT);
        }

        // DELETE: api/UserProjectTb/5
        [Route("api/UserProject/Delete")]
        [ResponseType(typeof(TBL_USER_PROJECT))]
        public IHttpActionResult Delete(int id)
        {
            TBL_USER_PROJECT tBL_USER_PROJECT = db.TBL_USER_PROJECT.Find(id);
            if (tBL_USER_PROJECT == null)
            {
                return NotFound();
            }

            db.TBL_USER_PROJECT.Remove(tBL_USER_PROJECT);
            db.SaveChanges();

            return Ok(tBL_USER_PROJECT);
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
            return db.TBL_USER_PROJECT.Count(e => e.USER_ID == id) > 0;
        }
    }
}