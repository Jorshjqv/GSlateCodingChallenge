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
    public class ProjectTbController : ApiController
    {
        private GSlateEntities db = new GSlateEntities();

        // GET: api/ProjectTb
        [Route("api/Project/RetrieveAll")]
        public IQueryable<TBL_PROJECT> Get()
        {
            return db.TBL_PROJECT;
        }

        // GET: api/ProjectTb/5
        [Route("api/Project/Retrieve")]
        [ResponseType(typeof(TBL_PROJECT))]
        public IHttpActionResult Get(int id)
        {
            TBL_PROJECT tBL_PROJECT = db.TBL_PROJECT.Find(id);
            if (tBL_PROJECT == null)
            {
                return NotFound();
            }

            return Ok(tBL_PROJECT);
        }

        // PUT: api/ProjectTb/5
        [Route("api/Project/Put")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, TBL_PROJECT tBL_PROJECT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBL_PROJECT.ID)
            {
                return BadRequest();
            }

            db.Entry(tBL_PROJECT).State = EntityState.Modified;

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

        // POST: api/ProjectTb
        [Route("api/Project/Post")]
        [ResponseType(typeof(TBL_PROJECT))]
        public IHttpActionResult Post(TBL_PROJECT tBL_PROJECT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBL_PROJECT.Add(tBL_PROJECT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Exists(tBL_PROJECT.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tBL_PROJECT.ID }, tBL_PROJECT);
        }

        // DELETE: api/ProjectTb/5
        [Route("api/Project/Delete")]
        [ResponseType(typeof(TBL_PROJECT))]
        public IHttpActionResult Delete(int id)
        {
            TBL_PROJECT tBL_PROJECT = db.TBL_PROJECT.Find(id);
            if (tBL_PROJECT == null)
            {
                return NotFound();
            }

            db.TBL_PROJECT.Remove(tBL_PROJECT);
            db.SaveChanges();

            return Ok(tBL_PROJECT);
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
            return db.TBL_PROJECT.Count(e => e.ID == id) > 0;
        }
    }
}